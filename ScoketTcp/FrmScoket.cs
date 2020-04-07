using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScoketTcp.Common;

namespace ScoketTcp
{
    public partial class FrmScoket : Form
    {
        //全局变量
        Socket socket = null;
        public IPAddress LocalIP { get; set; }
        public IPAddress PublicIP { get; set; }
        private Dictionary<string, Socket> Clients = new Dictionary<string, Socket>();
        Thread SvrThread = null;    //服务线程

        public FrmScoket()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (socket != null) 
            {
                MessageBox.Show($"连接已存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //创建负责监听的套接字
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
                //根据IP地址转为IPAddress对象
                IPAddress iPAddress = IPAddress.Parse(Txt_LocalIP.Text.Trim());

                //根据IPAddress以及端口号创建IPE对象
                IPEndPoint endPoint = new IPEndPoint(iPAddress, int.Parse(Txt_LocalPort.Text));

                socket.Bind(endPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"开始服务失败，错误信息：{ex.Message}");
                throw;
            }

            socket.Listen(2);

            //开启线程-监听对象端口
            SvrThread = new Thread(() =>
            {
                while (true)
                {
                    //如果监听到一个客户端，则新建一个对应的Socket
                    Socket socketClient = socket.Accept();

                    //添加到Clients字典
                    Clients.Add(socketClient.RemoteEndPoint.ToString(), socketClient);

                    //显示连接信息
                    Lb_OnlineList.RefrshInfo(socketClient.RemoteEndPoint.ToString(), true);
                    Txt_RecInfo.AddInfo($"{socketClient.RemoteEndPoint}上线");

                    //开启线程-监听已连接的通讯
                    Thread threadMsg = new Thread((sc) =>
                    {
                        Socket sclient = sc as Socket;
                        while (true)
                        {
                            //定义一个缓冲区-用于接收数据
                            byte[] arrMsgRec = new byte[Const.BufferByteSize];

                            //根据收到返回的字节数判断是否连接断开
                            int len = -1;
                            try
                            {
                                len = sclient.Receive(arrMsgRec);
                            }
                            catch (SocketException)
                            {
                                Lb_OnlineList.RefrshInfo(sclient.RemoteEndPoint.ToString(), false);
                                Txt_RecInfo.AddInfo($"{sclient.RemoteEndPoint}离线");
                                break;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show($"出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                            if (len > 0)
                            {
                                //传输数据
                                Txt_RecInfo.AddInfo($"{sclient.RemoteEndPoint}：{Encoding.Default.GetString(arrMsgRec, 0, len)}");
                            }
                        }
                    })
                    { IsBackground = true };
                    threadMsg.Start(socketClient);
                }
            })
            { IsBackground = true };
            SvrThread.Start();

            Btn_Start.Enabled = false;
        }

        /// <summary>
        /// 断开服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Broke_Click(object sender, EventArgs e)
        {
            if (socket == null) 
            {
                MessageBox.Show($"连接不存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 获取本地IP及公网IP
        /// </summary>
        private void GetIP(object sender, EventArgs e)
        {
            LocalIP = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily.ToString().Equals("InterNetwork")).FirstOrDefault();

            using (var s = WebRequest.Create("https://www.ipip5.com/").GetResponse().GetResponseStream())
            {
                using (var stream = new StreamReader(s, Encoding.UTF8))
                {
                    var str = stream.ReadToEnd();
                    int first = str.IndexOf("<span class=\"c-ip\">") + 19;
                    int last = str.IndexOf("</span>", first);
                    var pip = str.Substring(first, last - first);
                    PublicIP = IPAddress.Parse(str.Substring(first, last - first));
                }
            }

            Txt_LocalIP.Text = LocalIP.ToString();
            Txt_LocalPort.Text = "1232";
        }

        /// <summary>
        /// 消息框为焦点时，转移到信息输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_RecInfo_Enter(object sender, EventArgs e) => Txt_Sender.Focus();

        private void CanSenderMsg(object sender, EventArgs e)
        {
            //如果没有选中则禁用发送按钮
            Btn_Sender.Enabled = Lb_OnlineList.SelectedItems.Count != 0 && Txt_Sender.Text.Trim().Length != 0;
        }

        private void Btn_Sender_Click(object sender, EventArgs e)
        {
            //获取消息信息
            byte[] arrMsg = Encoding.Default.GetBytes(Txt_Sender.Text);

            //遍历所有选中的Socket
            foreach (string item in Lb_OnlineList.SelectedItems)
            {
                //发送数据
                Clients[item].Send(arrMsg.ToTxt());
            }
        }

        private void Btn_OpenClient_Click(object sender, EventArgs e)
        {
            FrmScoketClient frmScoketClient = new FrmScoketClient(Txt_LocalIP.Text, Txt_LocalPort.Text);
            frmScoketClient.Show();
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChooseFile_Click(object sender, EventArgs e)
        {
                //打开文件敞口
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                Lbl_FilePath.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SendFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Lbl_FilePath.Text))
            {
                MessageBox.Show("请先选择要发送的文件");
                return;
            }
            if (Lb_OnlineList.SelectedItems.Count == 0) 
            {
                MessageBox.Show("请选择要发送的对象");
                return;
            }

            //发送文件
            FileStream fs = null;
            try
            {
                fs = new FileStream(Lbl_FilePath.Text, FileMode.Open);
                byte[] arrFileSend = new byte[Const.BufferByteSize];
                int len = fs.Read(arrFileSend, 0, arrFileSend.Length);

                //遍历发送
                foreach (string item in Lb_OnlineList.SelectedItems)
                {
                    Clients[item].Send(arrFileSend.ToFile());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"出错：{ex.Message}");
            }
            finally
            {
                fs?.Dispose();
            }
        }
    }
}
