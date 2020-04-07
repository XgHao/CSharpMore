using System;
using System.Windows.Forms;

namespace SocketTask
{
    public static class ExeMethods
    {
        /// <summary>
        /// 设置Text【线程之间】
        /// </summary>
        /// <param name="textBox"></param>
        ///  <param name="str"></param>
        public static void SetText(this TextBox textBox, string str)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<string>(s => textBox.Text = s), str);
            }
            else
            {
                textBox.Text = str;
            }
        }

        /// <summary>
        /// 刷新Listbox【线程之间】
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="item"></param>
        /// <param name="AddOrRemove"></param>
        public static void RefrshItem(this ListBox listBox, string item, bool AddOrRemove)
        {
            //增加
            if (AddOrRemove)
            {
                //存在直接返回
                if (listBox.Items.Contains(item)) return;

                if (listBox.InvokeRequired)
                    listBox.Invoke(new Action<string>(t =>
                    {
                        listBox.Items.Add(t);
                    }), item);
                else
                    listBox.Items.Add(item);
            }
            //删除
            else
            {
                //不存在直接返回
                if (!listBox.Items.Contains(item)) return;

                if (listBox.InvokeRequired)
                    listBox.Invoke(new Action<string>(t =>
                    {
                        listBox.Items.Remove(t);
                    }), item);
                else
                    listBox.Items.Remove(item);
            }
        }

        /// <summary>
        /// 增加信息TextBox【线程之间】
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="msg">要增加的消息</param>
        /// <returns></returns>
        public static void AddInfo(this TextBox textBox, string msg)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<string>(m =>
                {
                    textBox.AppendText($"[{DateTime.Now}]{Environment.NewLine}{m}{Environment.NewLine}{Environment.NewLine}");
                    //textBox.HoldBottom();
                }), msg);
            }
            else
            {
                textBox.AppendText($"[{DateTime.Now}]{Environment.NewLine}{msg}{Environment.NewLine}{Environment.NewLine}");
            }
        }
    }
}