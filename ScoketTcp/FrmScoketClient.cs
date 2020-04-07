using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ScoketTcp.Common;
using System.IO;

namespace ScoketTcp
{
    public partial class FrmScoketClient : Form
    {
        //全局变量
        Socket socketClient = null;

        public FrmScoketClient() 
        {
            InitializeComponent();
        }

        public FrmScoketClient(string _serverIP, string _serverPort) : this()
        {
            Txt_ServerIP.Text = _serverIP;
            Txt_ServerPort.Text = _serverPort;
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (socketClient != null) 
            {
                MessageBox.Show($"连接已存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //连接
            try
            {
                //获取网络终结点及Socket对象
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(Txt_ServerIP.Text), int.Parse(Txt_ServerPort.Text));
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Txt_RecInfo.AppendText("连接中..." + Environment.NewLine);
                socketClient.Connect(iPEndPoint);
            }
            catch (Exception ex)
            {
                Txt_RecInfo.AddInfo($"连接失败。{ex.Message}");
                socketClient = null;
                return;
            }
            Txt_RecInfo.AddInfo("连接成功！");

            //连接成功，开启线程-监听消息
            Thread thread = new Thread((sc) =>
            {
                Socket sClient = sc as Socket;
                //定义一个数据缓冲区
                byte[] arrMsgRec = null;

                //接受客户端数据
                int len = -1;
                while (true)
                {
                    arrMsgRec = new byte[Const.BufferByteSize];
                    try
                    {
                        len = sClient.Receive(arrMsgRec); 
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    if (len > 1) 
                    {
                        string recvMsg = Encoding.Default.GetString(arrMsgRec, 1, len - 1);
                        if (arrMsgRec[0] == 0) 
                        {
                            Txt_RecInfo.AddInfo($"{sClient.RemoteEndPoint.ToString()}：{recvMsg}");
                        }
                        else if (arrMsgRec[0] == 1)
                        {
                            string res = "接受到文件，拒绝保存";
                            if (MessageBox.Show("接受到文件，是否保存？", "接收到文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                            {
                                Invoke(new Action<byte[]>(arrMsg =>
                                {
                                    //保存文件
                                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        string path = saveFileDialog.FileName;
                                        using (FileStream fs = new FileStream(path, FileMode.Create))
                                        {
                                            fs.Write(arrMsg, 1, arrMsg.Length - 1);
                                            res = $"接收到文件，保存在{path}目录";
                                        }
                                    }
                                }), arrMsgRec);
                            }
                            Txt_RecInfo.AddInfo(res);
                        }
                    }
                }
            })
            { IsBackground = true };
            thread.Start(socketClient);
        }

        /// <summary>
        /// 消息框为焦点时，转移到信息输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_RecInfo_Enter(object sender, EventArgs e) => Txt_Sender.Focus();

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Sender_Click(object sender, EventArgs e)
        {
            byte[] arrMsg = Encoding.Default.GetBytes(Txt_Sender.Text);
            socketClient.Send(arrMsg);
        }

        private void FrmScoketClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            socketClient?.Close();
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Broke_Click(object sender, EventArgs e)
        {
            socketClient?.Close();
            socketClient = null;
        }
    }
}
