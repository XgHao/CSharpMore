using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateApply
{
    //声明一个委托
    public delegate void AddCntDelegate(int _cnt);

    public partial class FrmParent : Form
    {
        public FrmParent()
        {
            InitializeComponent();

            //初始化某些值
            lbl_cnt.Text = lbl_count.Text = "0";

            FrmChild frmChild = new FrmChild();

            frmChild.AddCntDelegate += _cnt => lbl_cnt.Text = _cnt.ToString();
            frmChild.AddCntDelegate += _cnt => lbl_count.Text += _cnt.ToString();
            frmChild.Show();
        }
    }
}
