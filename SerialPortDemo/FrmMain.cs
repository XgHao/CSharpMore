using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortDemo.Helper;
using SerialPortDemo.Common;

namespace SerialPortDemo
{
    public partial class FrmMain : Form
    {
        //创建串口操作助手对象
        private SerialPortHelper SerialPortHelper = null;

        public FrmMain()
        {
            InitializeComponent();

            //获取串口
            InitSerialPort(null, null);

            //绑定校验位、停止位
            cboCheckBit.DataSource = Enum.GetNames(typeof(Parity));
            cboStopBit.DataSource = Enum.GetNames(typeof(StopBits)).Reverse().ToArray();

            //串口基本参数默认值
            SerialPortArgsDefault();
        }

        /// <summary>
        /// 串口参数默认值
        /// </summary>
        public void SerialPortArgsDefault()
        {
            cboBaudRrate.SelectedIndex = 5;
            cboCheckBit.SelectedIndex = 0;
            cboDataBit.SelectedIndex = 3;
            cboStopBit.SelectedIndex = 2;
        }

        /// <summary>
        /// 初始化端口
        /// </summary>
        private void InitSerialPort(object sender, EventArgs e)
        {
            SerialPortHelper = new SerialPortHelper();
            //绑定数据接收
            SerialPortHelper.SerialPortObj.DataReceived += SerialPort_DataReceived;

            cboCOMList.Items.Clear();
            if (SerialPortHelper.PortNameList.Length == 0)
            {
                MessageBox.Show("当前计算机上没有可用的端口", "警告信息");
                btnOperatePort.Enabled = false;
            }
            else
            {
                cboCOMList.Items.AddRange(SerialPortHelper.PortNameList);
                cboCOMList.SelectedIndex = 0;
                btnOperatePort.Enabled = true;
            }
        }

        /// <summary>
        /// 串口参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortArgsSetting_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                var obj = (sender as ComboBox).Name;
                switch (obj)
                {
                    //波特率
                    case "cboBaudRrate":
                        SerialPortHelper.SerialPortObj.BaudRate = int.Parse(cboBaudRrate.Text);
                        break;
                    //校验位
                    case "cboCheckBit":
                        SerialPortHelper.SerialPortObj.Parity = (Parity)Enum.Parse(typeof(Parity), cboCheckBit.Text, true);
                        break;
                    //数据位
                    case "cboDataBit":
                        SerialPortHelper.SerialPortObj.DataBits = int.Parse(cboDataBit.Text);
                        break;
                    //停止位
                    case "cboStopBit":
                        SerialPortHelper.SerialPortObj.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBit.Text, true);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SerialPortArgsDefault();
                MessageBox.Show($"设置串口参数时出错：{ex.Message + Environment.NewLine}已将参数还原为默认值", "不支持的参数组合", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperatePort_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOperatePort.Text.Equals("打开端口"))
                {
                    SerialPortHelper.OpenSerialPort(cboCOMList.Text, SerialPortStatus.Open);
                    lblSerialPortStatus.Text = "端口已打开";
                    lblStatusShow.BackColor = Color.Green;
                    btnOperatePort.Text = "关闭端口";
                }
                else
                {
                    SerialPortHelper.OpenSerialPort(cboCOMList.Text, SerialPortStatus.Close);
                    lblSerialPortStatus.Text = "端口已关闭";
                    lblStatusShow.BackColor = Color.Red;
                    btnOperatePort.Text = "打开端口";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"端口操作异常：{ex.Message}");
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            var data = txtSender.Text.Trim();
            if (data.Length == 0) 
            {
                MessageBox.Show("请先填写发送内容");
                txtSender.Focus();
                return;
            }

            //发送
            try
            {
                SerialPortHelper.SendData(data, ckb16Send.Checked ? SendFormat.Hex : SendFormat.String);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送失败，{ex.Message}");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var byteData = SerialPortHelper.ReceiveData();
                string data = ckb16Receive.Checked
                    ? SerialPortHelper.SysconvertHelper.BytesTo16(byteData, Enum16Hex.Blank)
                    : SerialPortHelper.SysconvertHelper.BytesToString(byteData, Enum16Hex.None);

                //设置文本
                txtReceiver.SetTextWithInvoke(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"接收数据时出错，{ex.Message}");
            }
        }
    }
}
