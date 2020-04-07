using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortDemo.Common
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExeMethods
    {
        /// <summary>
        /// 跨线程设置文本内容
        /// </summary>
        /// <param name="control"></param>
        public static void SetTextWithInvoke(this Control control, string str)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<string>(s =>
                {
                    control.Text += $"【{DateTime.Now}】：{s}{Environment.NewLine}";
                }), str);
                return;
            }
            control.Text += $"【{DateTime.Now}】：{str}{Environment.NewLine}";
        }
    }
}
