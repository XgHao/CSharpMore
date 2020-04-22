using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoke_And_BeginInvoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    int cnt = lbl_Count.GetInt();
                    lbl_Count.SetInt(++cnt);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
