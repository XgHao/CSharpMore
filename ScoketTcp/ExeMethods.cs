using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoketTcp
{
    public static class ExeMethods
    {
        /// <summary>
        /// 定位到文本末
        /// </summary>
        /// <param name="textBox"></param>
        public static void HoldBottom(this TextBox textBox)
        {
            //获取焦点
            textBox.Focus();

            //光标定位到文本后
            textBox.Select(textBox.TextLength, 0);

            //滚动到光标处
            textBox.ScrollToCaret();
        }

        /// <summary>
        /// 增加信息【跨线程】
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="msg">要增加的消息</param>
        /// <returns></returns>
        public static object AddInfo(this TextBox textBox, string msg)
        {
            return textBox.Invoke(new Action<string>(m =>
            {
                textBox.AppendText($"[{DateTime.Now}]{Environment.NewLine}{m}{Environment.NewLine}{Environment.NewLine}");
                textBox.HoldBottom();
            }), msg);
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="item">要操作的目标</param>
        /// <param name="AddOrRme">操作 [Add:True] [Remove:False]</param>
        /// <returns></returns>
        public static object RefrshInfo(this ListBox listBox,string item,bool AddOrRme)
        {
            return listBox.Invoke(new Action<string, bool>((m, f) =>
            {
                if (f && !listBox.Items.Contains(m))
                    listBox.Items.Add(m);
                else if (!f && listBox.Items.Contains(m))
                    listBox.Items.Remove(m);
            }), item, AddOrRme);
        }

        /// <summary>
        /// 以文件的形势发送
        /// </summary>
        /// <param name="srcArrByte"></param>
        /// <returns></returns>
        public static byte[] ToFile(this byte[] srcArrByte)
        {
            byte[] dtsArrByte = new byte[srcArrByte.Length + 1];
            dtsArrByte[0] = 1;
            Buffer.BlockCopy(srcArrByte, 0, dtsArrByte, 1, srcArrByte.Length);
            return dtsArrByte;
        }

        /// <summary>
        /// 以文本的形势发送
        /// </summary>
        /// <param name="srcArrByte"></param>
        /// <returns></returns>
        public static byte[] ToTxt(this byte[] srcArrByte)
        {
            byte[] dtsArrByte = new byte[srcArrByte.Length + 1];
            dtsArrByte[0] = 0;
            Buffer.BlockCopy(srcArrByte, 0, dtsArrByte, 1, srcArrByte.Length);
            return dtsArrByte;
        }
    }
}
