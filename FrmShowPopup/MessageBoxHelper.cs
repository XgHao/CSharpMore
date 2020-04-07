using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmShowPopup
{
    /// <summary>
    /// 消息框帮助类
    /// </summary>
    public static class MessageBoxHelper
    {
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="form"></param>
        /// <param name="hint"></param>
        public static void Hint(this Form form, Control control, string hint, ShowPosition position = ShowPosition.Bottom_Right)
        {
            Point point;

            switch (position)
            {
                case ShowPosition.Top_Left:
                    point = new Point
                    {
                        X = control.Location.X,
                        Y = control.Location.Y
                    };
                    break;
                case ShowPosition.Top_Mid:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width / 2,
                        Y = control.Location.Y
                    };
                    break;
                case ShowPosition.Top_Right:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width,
                        Y = control.Location.Y
                    };
                    break;
                case ShowPosition.Mid_Left:
                    point = new Point
                    {
                        X = control.Location.X,
                        Y = control.Location.Y + control.Size.Height / 2
                    };
                    break;
                case ShowPosition.Mid_Mid:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width / 2,
                        Y = control.Location.Y + control.Size.Height / 2
                    };
                    break;
                case ShowPosition.Mid_Right:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width,
                        Y = control.Location.Y + control.Size.Height / 2
                    };
                    break;
                case ShowPosition.Bottom_Left:
                    point = new Point
                    {
                        X = control.Location.X,
                        Y = control.Location.Y + control.Size.Height
                    };
                    break;
                case ShowPosition.Bottom_Mid:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width / 2,
                        Y = control.Location.Y + control.Size.Height
                    };
                    break;
                case ShowPosition.Bottom_Right:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width,
                        Y = control.Location.Y + control.Size.Height
                    };
                    break;
                default:
                    point = new Point
                    {
                        X = control.Location.X + control.Size.Width,
                        Y = control.Location.Y + control.Size.Height
                    };
                    break;
            }

            //提示框
            Help.ShowPopup(control, hint, form.PointToScreen(point));
        }

        public static void AddTextWithInvoke(this TextBox textBox, string txt, Control control = null)
        {
            var name = (control ?? textBox).Name;

            if (textBox.InvokeRequired)
            {
                (control ?? textBox).Invoke(new Action<string>(t =>
                {
                    textBox.AppendText($"[{DateTime.Now}]{Environment.NewLine}{t}{Environment.NewLine}{Environment.NewLine}");
                }), txt);
                return;
            }

            textBox.AppendText($"[{DateTime.Now}]{Environment.NewLine}{txt}{Environment.NewLine}{Environment.NewLine}");
        }
    }

    /// <summary>
    /// 显示位置
    /// </summary>
    public enum ShowPosition
    {
        /// <summary>
        /// 上左
        /// </summary>
        Top_Left,
        /// <summary>
        /// 上中
        /// </summary>
        Top_Mid,
        /// <summary>
        /// 上右
        /// </summary>
        Top_Right,
        /// <summary>
        /// 中左
        /// </summary>
        Mid_Left,
        /// <summary>
        /// 中中
        /// </summary>
        Mid_Mid,
        /// <summary>
        /// 中右
        /// </summary>
        Mid_Right,
        /// <summary>
        /// 底左
        /// </summary>
        Bottom_Left,
        /// <summary>
        /// 底中
        /// </summary>
        Bottom_Mid,
        /// <summary>
        /// 底右
        /// </summary>
        Bottom_Right
    }

    

    public enum AddOrRemove
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add,
        /// <summary>
        /// 移除
        /// </summary>
        Remove
    }
}
