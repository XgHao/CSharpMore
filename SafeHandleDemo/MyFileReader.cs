using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SafeHandleDemo
{
    /// <summary>
    /// The MyFileReader class is a sample class that accesses an operating system resource and implements IDisposable.
    /// MyFileReader类是访问操作系统资源并实现IDisposeable的示例类。
    /// This is useful to show the types of transformation required to make your resource wrapping classess more resilient.
    /// 这有助于显示使资源包装类更具弹性所需的转换类型。
    /// Note the Dispose and Finalize implementations.Consider this a simulation of System.IO.FileStream.
    /// 注意Dispose和Finalize实现，假设这是对System.IO.FileStream的模拟
    /// </summary>
    public class MyFileReader : IDisposable
    {
        /// <summary>
        /// _handle is set to null to indicate disposal of this instance.
        /// _handle设置为null以指示此实例的处置
        /// </summary>
        private MySafeFileHandle _handle;

        public MyFileReader(string fileName)
        {
            string fullPath = Path.GetFullPath(fileName);
            //如果未对调用堆栈中处于较高位置的所有调用方授予当前实例所指定的权限，则在运行时强制 System.Security.Security.SecurityException
            new FileIOPermission(FileIOPermissionAccess.Read, fullPath).Demand();

            //Open a file, and save its handle in _handle.
            //打开一个文件，并将其句柄保存在_handle中
            //Note that the most optimized code turns into two processor instructions:1)a call,and 2)moving the return value into the _handle field.
            //注意，最优的代码将转化为两条处理指令：1）调用 2）将返回值移动到“_handle”字段中
            //With SafeHandle,the CLR's platform invoke marshaling layer will store the handle into the SafeHandle object in an atomic fashion.
            //使用SafeHandle时，CLR平台会调用封送处理层将以原子方式将句柄储存到SafeHandle对象中
            //There is still the problem that the SafeHandle object may not be stored in _handle,
            //but the real operating system handle value has been safely stored in a critical finalizable object,
            //ensuring against leaking the handle even if there is an asynchronous exception.
            //这里还有一个问题：SafeHandle对象可能没有被存在_handle中
            //但是实际的操作系统句柄值已经安全存储在一个关键的可终结对象中，确保即使存在异常也不会泄漏句柄
            MySafeFileHandle tmpHandle;
            tmpHandle = NativeMethods.CreateFile(fileName, NativeMethods.GENERIC_READ, FileShare.Read, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            //An async exception here will cause us to run our finalizer with a null _handle,
            //but MySafeFileHandle's ReleaseHandle code will be invoked to free the handle.
            //此处异步异常将会导致我们使用空句柄运行终接器，但将调用MySafeFileHandle的ReleaseHandle代码来释放该句柄

            //This call to Sleep,run from the fault injection code in Main, will help trigger a race.
            //这个调用Sleep，从Main中的错误注入代码运行，将助于出发一场比赛。
            //But it will not cause a handle leak because the handle is already stored in a SafeHandle instance.
            //但他不会导致句柄泄漏，因为句柄已存储在SafeHandle实例中
            //Critical finalization then guarantees that freeing the handle,even during an unexpected AppDomain unload.
            //然后，关键终结将确保释放句柄，即使在意外的AppDomain卸载期间也是如此
            Thread.Sleep(500);
            _handle = tmpHandle;    //Make _handle point to a critical f inalizable object.
                                    //使句柄指向一个关键的可终结对象

            //Determine if file is opened successfully.
            //确保文件打开成功
            if (_handle.IsInvalid)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error(), fileName);
            }
        }

        /// <summary>
        /// Follow the Dispose pattern - public nonvirtual
        /// 遵循Dispose模式 - public no virtual
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// No finalizer is needed. 
        /// 不需要终结器
        /// The finalizer on SafeHandle will clean up the MySafeFileHandle instance,if it hasn't already been disposed.
        /// SafeHandle上的终结器将清理该实例，如果尚未释放MySafeFileHandle实例
        /// Howerver,there may be a need for a subclass to introduce a finalizer,so Dispose is properly implemented here.
        /// 然而，可能需要一个子类来引入终结器，所以这里正确的实现了Dispose
        /// </summary>
        /// <param name="disposing"></param>
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        protected virtual void Dispose(bool disposing)
        {
            //Note there are three interesting states here:
            //值得注意的是，这有三种状态
            //1).CreateFile failed,_handle contains an invalid handle.
            //1）CreateFile失败，_handle包含无效句柄
            //2).We called Dispose already, _handle is closed.
            //2)我们已经调用了Dispose，句柄已关闭
            //3)._handle is null,due to an async exception before calling CreateFile.
            //3）_handle为空，因为在调用CreateFile之前发生了异步异常
            //Note that the finalizer runs if the constructor fails.
            //注意，如果构造函数失败，则终结器将运行
            if (_handle != null && !_handle.IsInvalid)
            {
                //Free the handle
                //释放句柄
                _handle.Dispose();
            }

            //SafeHandle records the fact that we've called Dispose.
            //SafeHandle记录了我们调用Dispose的事实
        }

        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        public byte[] ReadContents(int length)
        {
            //Is the handle disposed?
            //句柄是否释放
            if (_handle.IsInvalid)
            {
                throw new ObjectDisposedException("FileReader is closed");
            }

            //This sample code will not work for all files.
            //示例代码不适用于所有文件
            byte[] bytes = new byte[length];
            int r = NativeMethods.ReadFile(_handle, bytes, length, out int numRead, IntPtr.Zero);

            //Since we removed MyFileReader's finalizer,we no longer need to call GC.KeepAlive here.
            //因为我们删除了MyFileReader的终结器，所以不再需要在这里调用GC.KeepAlive。
            //Platform invoke will keep the SafeHandle instance alive for the duration of the call.
            //平台调用将使SafeHandle实例在调用期间保持活动状态
            if (r == 0) 
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            if (numRead < length)
            {
                byte[] newBytes = new byte[numRead];
                Array.Copy(bytes, newBytes, numRead);
                bytes = newBytes;
            }
            return bytes;
        }
    }
}
