using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SafeHandleDemo
{
    [SuppressUnmanagedCodeSecurity()] //允许托管代码在不进行堆栈审核的情况下调用到非托管代码
    static class NativeMethods
    {
        /// <summary>
        /// Win32 constants for accessing files.
        /// 用于访问文件的Win32常量
        /// </summary>
        internal const int GENERIC_READ = unchecked((int)0x80000000);

        /// <summary>
        /// Allocate a file object in the kernel, then return a handle to it
        /// 在内核中分配一个文件对象，然后返回一个句柄
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dwDesireAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="securityAttrs_MustBeZero"></param>
        /// <param name="dwCreateionDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile_MustBeZero"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal extern static MySafeFileHandle CreateFile(string fileName, int dwDesireAccess, FileShare dwShareMode, IntPtr securityAttrs_MustBeZero, FileMode dwCreateionDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile_MustBeZero);

        /// <summary>
        /// Use the file handle
        /// 使用文件句柄
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="bytes"></param>
        /// <param name="numBytesToRead"></param>
        /// <param name="numBytesRead"></param>
        /// <param name="overlapped_MustBeZero"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        internal extern static int ReadFile(MySafeFileHandle handle, byte[] bytes, int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

        /// <summary>
        /// Free the kernel's file object(close the file)
        /// 释放内核的文件对象（关闭文件）
        /// 【协议】：在遇到异常时，该方法可能会失败但保证不损坏状态，返回调用方法是成功还是失败
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState,Cer.MayFail)] 
        internal extern static bool CloseHandle(IntPtr handle);
    }
}
