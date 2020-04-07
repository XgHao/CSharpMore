namespace SocketTask
{
    partial class SocketServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_FilePath = new System.Windows.Forms.Label();
            this.Btn_SendFile = new System.Windows.Forms.Button();
            this.Btn_ChooseFile = new System.Windows.Forms.Button();
            this.Txt_Sender = new System.Windows.Forms.TextBox();
            this.Txt_RecInfo = new System.Windows.Forms.TextBox();
            this.Lb_OnlineList = new System.Windows.Forms.ListBox();
            this.Btn_OpenClient = new System.Windows.Forms.Button();
            this.Btn_Sender = new System.Windows.Forms.Button();
            this.Btn_Broke = new System.Windows.Forms.Button();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Txt_LocalPort = new System.Windows.Forms.TextBox();
            this.Txt_PublicIP = new System.Windows.Forms.TextBox();
            this.Txt_LocalIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_PublicIP = new System.Windows.Forms.Label();
            this.Lbl_LocalPort = new System.Windows.Forms.Label();
            this.Lbl_LocalIP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_FilePath
            // 
            this.Lbl_FilePath.AutoSize = true;
            this.Lbl_FilePath.Location = new System.Drawing.Point(142, 446);
            this.Lbl_FilePath.Name = "Lbl_FilePath";
            this.Lbl_FilePath.Size = new System.Drawing.Size(0, 12);
            this.Lbl_FilePath.TabIndex = 27;
            // 
            // Btn_SendFile
            // 
            this.Btn_SendFile.Location = new System.Drawing.Point(496, 441);
            this.Btn_SendFile.Name = "Btn_SendFile";
            this.Btn_SendFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_SendFile.TabIndex = 26;
            this.Btn_SendFile.Text = "发送文件";
            this.Btn_SendFile.UseVisualStyleBackColor = true;
            // 
            // Btn_ChooseFile
            // 
            this.Btn_ChooseFile.Location = new System.Drawing.Point(61, 441);
            this.Btn_ChooseFile.Name = "Btn_ChooseFile";
            this.Btn_ChooseFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_ChooseFile.TabIndex = 25;
            this.Btn_ChooseFile.Text = "选择文件";
            this.Btn_ChooseFile.UseVisualStyleBackColor = true;
            // 
            // Txt_Sender
            // 
            this.Txt_Sender.Location = new System.Drawing.Point(47, 219);
            this.Txt_Sender.Multiline = true;
            this.Txt_Sender.Name = "Txt_Sender";
            this.Txt_Sender.Size = new System.Drawing.Size(445, 166);
            this.Txt_Sender.TabIndex = 23;
            // 
            // Txt_RecInfo
            // 
            this.Txt_RecInfo.Location = new System.Drawing.Point(47, 32);
            this.Txt_RecInfo.Multiline = true;
            this.Txt_RecInfo.Name = "Txt_RecInfo";
            this.Txt_RecInfo.ReadOnly = true;
            this.Txt_RecInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_RecInfo.Size = new System.Drawing.Size(445, 166);
            this.Txt_RecInfo.TabIndex = 24;
            // 
            // Lb_OnlineList
            // 
            this.Lb_OnlineList.FormattingEnabled = true;
            this.Lb_OnlineList.ItemHeight = 12;
            this.Lb_OnlineList.Location = new System.Drawing.Point(608, 209);
            this.Lb_OnlineList.Name = "Lb_OnlineList";
            this.Lb_OnlineList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Lb_OnlineList.Size = new System.Drawing.Size(249, 100);
            this.Lb_OnlineList.TabIndex = 22;
            // 
            // Btn_OpenClient
            // 
            this.Btn_OpenClient.Location = new System.Drawing.Point(685, 458);
            this.Btn_OpenClient.Name = "Btn_OpenClient";
            this.Btn_OpenClient.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenClient.TabIndex = 20;
            this.Btn_OpenClient.Text = "打开客户端";
            this.Btn_OpenClient.UseVisualStyleBackColor = false;
            this.Btn_OpenClient.Click += new System.EventHandler(this.Btn_OpenClient_Click);
            // 
            // Btn_Sender
            // 
            this.Btn_Sender.Enabled = false;
            this.Btn_Sender.Location = new System.Drawing.Point(685, 402);
            this.Btn_Sender.Name = "Btn_Sender";
            this.Btn_Sender.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sender.TabIndex = 21;
            this.Btn_Sender.Text = "发送消息";
            this.Btn_Sender.UseVisualStyleBackColor = true;
            this.Btn_Sender.Click += new System.EventHandler(this.Btn_Sender_Click);
            // 
            // Btn_Broke
            // 
            this.Btn_Broke.Location = new System.Drawing.Point(685, 373);
            this.Btn_Broke.Name = "Btn_Broke";
            this.Btn_Broke.Size = new System.Drawing.Size(75, 23);
            this.Btn_Broke.TabIndex = 19;
            this.Btn_Broke.Text = "关闭服务";
            this.Btn_Broke.UseVisualStyleBackColor = true;
            this.Btn_Broke.Click += new System.EventHandler(this.Btn_Broke_Click);
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(685, 344);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start.TabIndex = 18;
            this.Btn_Start.Text = "启动服务";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Txt_LocalPort
            // 
            this.Txt_LocalPort.Location = new System.Drawing.Point(713, 134);
            this.Txt_LocalPort.Name = "Txt_LocalPort";
            this.Txt_LocalPort.Size = new System.Drawing.Size(144, 21);
            this.Txt_LocalPort.TabIndex = 17;
            this.Txt_LocalPort.Text = "1232";
            // 
            // Txt_PublicIP
            // 
            this.Txt_PublicIP.Location = new System.Drawing.Point(713, 88);
            this.Txt_PublicIP.Name = "Txt_PublicIP";
            this.Txt_PublicIP.Size = new System.Drawing.Size(144, 21);
            this.Txt_PublicIP.TabIndex = 16;
            // 
            // Txt_LocalIP
            // 
            this.Txt_LocalIP.Location = new System.Drawing.Point(713, 44);
            this.Txt_LocalIP.Name = "Txt_LocalIP";
            this.Txt_LocalIP.Size = new System.Drawing.Size(144, 21);
            this.Txt_LocalIP.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(617, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "在线列表：";
            // 
            // Lbl_PublicIP
            // 
            this.Lbl_PublicIP.AutoSize = true;
            this.Lbl_PublicIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_PublicIP.Location = new System.Drawing.Point(604, 89);
            this.Lbl_PublicIP.Name = "Lbl_PublicIP";
            this.Lbl_PublicIP.Size = new System.Drawing.Size(106, 22);
            this.Lbl_PublicIP.TabIndex = 12;
            this.Lbl_PublicIP.Text = "本机公网IP：";
            // 
            // Lbl_LocalPort
            // 
            this.Lbl_LocalPort.AutoSize = true;
            this.Lbl_LocalPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_LocalPort.Location = new System.Drawing.Point(620, 135);
            this.Lbl_LocalPort.Name = "Lbl_LocalPort";
            this.Lbl_LocalPort.Size = new System.Drawing.Size(90, 22);
            this.Lbl_LocalPort.TabIndex = 14;
            this.Lbl_LocalPort.Text = "本机端口：";
            // 
            // Lbl_LocalIP
            // 
            this.Lbl_LocalIP.AutoSize = true;
            this.Lbl_LocalIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_LocalIP.Location = new System.Drawing.Point(604, 45);
            this.Lbl_LocalIP.Name = "Lbl_LocalIP";
            this.Lbl_LocalIP.Size = new System.Drawing.Size(106, 22);
            this.Lbl_LocalIP.TabIndex = 11;
            this.Lbl_LocalIP.Text = "本机内网IP：";
            // 
            // SocketServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 525);
            this.Controls.Add(this.Lbl_FilePath);
            this.Controls.Add(this.Btn_SendFile);
            this.Controls.Add(this.Btn_ChooseFile);
            this.Controls.Add(this.Txt_Sender);
            this.Controls.Add(this.Txt_RecInfo);
            this.Controls.Add(this.Lb_OnlineList);
            this.Controls.Add(this.Btn_OpenClient);
            this.Controls.Add(this.Btn_Sender);
            this.Controls.Add(this.Btn_Broke);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Txt_LocalPort);
            this.Controls.Add(this.Txt_PublicIP);
            this.Controls.Add(this.Txt_LocalIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_PublicIP);
            this.Controls.Add(this.Lbl_LocalPort);
            this.Controls.Add(this.Lbl_LocalIP);
            this.Name = "SocketServer";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.SocketServer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_FilePath;
        private System.Windows.Forms.Button Btn_SendFile;
        private System.Windows.Forms.Button Btn_ChooseFile;
        private System.Windows.Forms.TextBox Txt_Sender;
        private System.Windows.Forms.TextBox Txt_RecInfo;
        private System.Windows.Forms.ListBox Lb_OnlineList;
        private System.Windows.Forms.Button Btn_OpenClient;
        private System.Windows.Forms.Button Btn_Sender;
        private System.Windows.Forms.Button Btn_Broke;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TextBox Txt_LocalPort;
        private System.Windows.Forms.TextBox Txt_PublicIP;
        private System.Windows.Forms.TextBox Txt_LocalIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_PublicIP;
        private System.Windows.Forms.Label Lbl_LocalPort;
        private System.Windows.Forms.Label Lbl_LocalIP;
    }
}

