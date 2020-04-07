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

namespace SocketTask
{
    public partial class SocketServer : Form
    {
        public SocketServer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当第一次加载窗体的时候，尝试获取公网及本地IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SocketServer_Shown(object sender, EventArgs e)
        {
            #region 本地IP
            string localName = Dns.GetHostName();
            var IPaddress = Dns.GetHostAddresses(localName).Where(ip => ip.AddressFamily.ToString().Equals("InterNetwork")).FirstOrDefault();
            Txt_LocalIP.SetText(IPaddress.ToString());
            #endregion

            #region 公网IP
            //两秒后自动取消
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(8));

            //在取消任务调用
            tokenSource.Token.Register(() =>
            {
                if (Txt_PublicIP.Text.Length == 0)
                    Txt_PublicIP.SetText("获取公网IP失败，请检查网络连接");
            });

            //查询公共IP
            Task Task_GetPublicIP = Task.Factory.StartNew(() =>
            {
                using (var s = WebRequest.Create("https://www.ipip5.com/").GetResponse().GetResponseStream())
                {
                    using (var stream = new StreamReader(s, Encoding.UTF8))
                    {
                        var str = stream.ReadToEnd();
                        int first = str.IndexOf("<span class=\"c-ip\">") + 19;
                        int last = str.IndexOf("</span>", first);
                        var pip = str.Substring(first, last - first);
                        Txt_PublicIP.SetText(str.Substring(first, last - first));
                    }
                }
            }, tokenSource.Token);

            #endregion

        }


        //全局变量
        private static Socket socketSvr = null;  //当前服务端的Socket对象
        private static List<Socket> sockets = new List<Socket>();      //连接socket集合
        private static CancellationTokenSource TokenSource = null;     //停止任务标记

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (socketSvr != null ) 
            {
                MessageBox.Show("服务已存在，无需再次启动");
                return; 
            }

            //创建当前服务端中负责监听的套接字
            socketSvr = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            //根据ip及port创建IP终结点对象
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(Txt_LocalIP.Text), int.Parse(Txt_LocalPort.Text));

            try
            {
                //尝试将Socket绑定该终结点
                socketSvr.Bind(iPEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"开启服务失败，错误原因：{ex.Message}");
                socketSvr = null;
                return;
            }

            //最大监听数
            socketSvr.Listen(10);

            //开启任务-监听
            //任务类型[LongRunning]
            TokenSource = new CancellationTokenSource();
            TokenSource.Token.Register(() =>
            {
                if (socketSvr == null) 
                {
                    MessageBox.Show("你关闭了服务");
                }
            });
            Task Task_Listening = Task.Factory.StartNew(() =>
            {
                while (!TokenSource.IsCancellationRequested)
                {
                    //如果监听到一个连接，则新建一个对象的socket
                    Socket sClient = socketSvr.Accept();

                    //获取该socket的终结点
                    string clientIP = sClient.RemoteEndPoint.ToString();

                    //添加到字典
                    //SClientDic.Add(clientIP, sClient);
                        sockets.Add(sClient);

                    //显示连接信息
                    Lb_OnlineList.RefrshItem(clientIP, true);
                    Txt_RecInfo.AddInfo($"{clientIP}上线");


                    //开启新任务-监听已连接的通讯
                    Task Task_ListenMsg = Task.Factory.StartNew(scip =>
                    {
                        //Socket scobj = SClientDic[scip.ToString()];
                        Socket scobj = scip as Socket;
                        while (!TokenSource.IsCancellationRequested)
                        {
                            //数据缓冲区
                            byte[] arrMsg = new byte[1024 * 1024 * 2];

                            //获取数据
                            int len = -1;
                            try
                            {
                                len = scobj.Receive(arrMsg);
                            }
                            catch (SocketException)
                            {
                                //主机断开连接
                                Lb_OnlineList.RefrshItem(scobj.RemoteEndPoint.ToString(), false);
                                Txt_RecInfo.AddInfo($"{scobj.RemoteEndPoint}离线");
                                break;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"出错，{ex.Message}");
                                break;
                            }

                            if (len > 0)
                            {
                                Txt_RecInfo.AddInfo($"来自{scobj.RemoteEndPoint}的消息：{Encoding.Default.GetString(arrMsg, 0, len)}");
                            }
                            else
                            {
                                //主机断开连接
                                Lb_OnlineList.RefrshItem(scobj.RemoteEndPoint.ToString(), false);
                                Txt_RecInfo.AddInfo($"{scobj.RemoteEndPoint}离线");
                                break;
                            }
                        }

                    }, sClient);
                }
            }, TokenSource.Token);

            Btn_Start.Enabled = false;
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Broke_Click(object sender, EventArgs e)
        {
            TokenSource.Cancel();
            //释放资源
            socketSvr.Dispose(); 
            socketSvr = null;
            foreach (var item in sockets)
            {
                item?.Dispose();
            }
            Btn_Start.Enabled = true;
        }

        /// <summary>
        /// 打开客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OpenClient_Click(object sender, EventArgs e)
        {
        }

        private void Btn_Sender_Click(object sender, EventArgs e)
        {

        }
    }
}
