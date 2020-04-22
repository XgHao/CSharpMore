using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoke_And_BeginInvoke
{
    public static class ExtendMethods
    {
        public static int GetInt(this Label textBox)
        {
            int cnt = 0;
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() =>
                {
                    cnt = textBox.GetInt();
                }));
            }
            else
            {
                cnt = Convert.ToInt32(textBox.Text);
            }
            return cnt;
        }


        public static void SetInt(this Label label, int cnt)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() =>
                {
                    label.SetInt(cnt);
                }));
            }
            else
            {
                label.Text = cnt.ToString();
            }
        }
    }
}
