using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmShowPopup
{
    public partial class Form1 : Form
    {
        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
            
        }



        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            CancellationTokenSource.Cancel();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (!CancellationTokenSource.IsCancellationRequested) 
                {
                    txt_IP.AddTextWithInvoke($"[{DateTime.Now}]{Environment.NewLine}111{Environment.NewLine}{Environment.NewLine}");
                    Thread.Sleep(500);
                }
                
            }, CancellationTokenSource.Token);
        }

        
    }
}
