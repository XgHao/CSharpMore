using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SafeHandleDemo
{
    [SecurityPermission(SecurityAction.InheritanceDemand,UnmanagedCode = true)] //要求继承此类或重写方法类已被授予指定的权限。声明调用非托管代码的权限
    [SecurityPermission(SecurityAction.Demand,UnmanagedCode = true)]            //要求调用堆栈中的所有高级调用方已被授予指定的权限。声明调用非托管代码的权限
    class MySafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Create a SafeHandle,informing the base class that this SafeHandle instance "owns" the handle,
        /// and therefore should call our ReleaseHandle method when the SafeHandle is no longer in use.
        /// 创建一个SafeHandle，通知基类这个SafeHandle实例“拥有”这个句柄，
        /// 因此SafeHandle不再使用时，其应该调用ReleaseHandle方法
        /// </summary>
        private MySafeFileHandle() : base(true)  //若要在终止阶段可靠地释放此句柄，则为 true；若要阻止可靠释放（不建议使用），则为 false。
        {

        }

        /// <summary>
        /// 执行释放句柄所需的代码
        /// 【协议】：在遇到异常时，该方法可能会失败但是不会损坏状态，且会返回调用方法成败
        /// </summary>
        /// <returns></returns>
        [ReliabilityContract(Consistency.WillNotCorruptState,Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            //Here,we must obey all rules for constrained execution regins
            //这里，我们必须准守约束执行区域的所有规则
            return NativeMethods.CloseHandle(handle);
            //If ReleaseHandle failed,it can be reported via the "releaseHandleFailed" managed debugging assistant (MDA)
            //This MDA is disabled by default,but can be enabled in a debugger or during testing to diagonse handle corruption problems.
            //We do not throw an exception because most code could not recover from the problem.
            //如果ReleaseHandle失败，可以通过“ReleaseHandleFailed”(MDA)托管调试助手报告，
            //默认情况下，此MDA被禁用，但是可以在调试器中启用，也可以在测试期间启用，已诊断处理损问题。
            //我们不会抛出异常，因为大多数代码无法从问题中恢复。
        }
    }
}
