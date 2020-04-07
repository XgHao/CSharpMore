namespace ScoketTcp
{
    partial class FrmScoket
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
            this.Lbl_LocalIP = new System.Windows.Forms.Label();
            this.Lbl_LocalPort = new System.Windows.Forms.Label();
            this.Txt_LocalIP = new System.Windows.Forms.TextBox();
            this.Txt_LocalPort = new System.Windows.Forms.TextBox();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Lb_OnlineList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_RecInfo = new System.Windows.Forms.TextBox();
            this.Txt_Sender = new System.Windows.Forms.TextBox();
            this.Lbl_PublicIP = new System.Windows.Forms.Label();
            this.Txt_PublicIP = new System.Windows.Forms.TextBox();
            this.Btn_Sender = new System.Windows.Forms.Button();
            this.Btn_OpenClient = new System.Windows.Forms.Button();
            this.Btn_Broke = new System.Windows.Forms.Button();
            this.Btn_ChooseFile = new System.Windows.Forms.Button();
            this.Lbl_FilePath = new System.Windows.Forms.Label();
            this.Btn_SendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_LocalIP
            // 
            this.Lbl_LocalIP.AutoSize = true;
            this.Lbl_LocalIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_LocalIP.Location = new System.Drawing.Point(595, 40);
            this.Lbl_LocalIP.Name = "Lbl_LocalIP";
            this.Lbl_LocalIP.Size = new System.Drawing.Size(106, 22);
            this.Lbl_LocalIP.TabIndex = 0;
            this.Lbl_LocalIP.Text = "本机内网IP：";
            // 
            // Lbl_LocalPort
            // 
            this.Lbl_LocalPort.AutoSize = true;
            this.Lbl_LocalPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_LocalPort.Location = new System.Drawing.Point(611, 130);
            this.Lbl_LocalPort.Name = "Lbl_LocalPort";
            this.Lbl_LocalPort.Size = new System.Drawing.Size(90, 22);
            this.Lbl_LocalPort.TabIndex = 0;
            this.Lbl_LocalPort.Text = "本机端口：";
            // 
            // Txt_LocalIP
            // 
            this.Txt_LocalIP.Location = new System.Drawing.Point(704, 39);
            this.Txt_LocalIP.Name = "Txt_LocalIP";
            this.Txt_LocalIP.Size = new System.Drawing.Size(144, 23);
            this.Txt_LocalIP.TabIndex = 1;
            // 
            // Txt_LocalPort
            // 
            this.Txt_LocalPort.Location = new System.Drawing.Point(704, 129);
            this.Txt_LocalPort.Name = "Txt_LocalPort";
            this.Txt_LocalPort.Size = new System.Drawing.Size(144, 23);
            this.Txt_LocalPort.TabIndex = 1;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(676, 339);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start.TabIndex = 2;
            this.Btn_Start.Text = "启动服务";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Lb_OnlineList
            // 
            this.Lb_OnlineList.FormattingEnabled = true;
            this.Lb_OnlineList.ItemHeight = 17;
            this.Lb_OnlineList.Location = new System.Drawing.Point(599, 204);
            this.Lb_OnlineList.Name = "Lb_OnlineList";
            this.Lb_OnlineList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Lb_OnlineList.Size = new System.Drawing.Size(249, 106);
            this.Lb_OnlineList.TabIndex = 3;
            this.Lb_OnlineList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanSenderMsg);
            this.Lb_OnlineList.Validated += new System.EventHandler(this.CanSenderMsg);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(608, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "在线列表：";
            // 
            // Txt_RecInfo
            // 
            this.Txt_RecInfo.Location = new System.Drawing.Point(38, 27);
            this.Txt_RecInfo.Multiline = true;
            this.Txt_RecInfo.Name = "Txt_RecInfo";
            this.Txt_RecInfo.ReadOnly = true;
            this.Txt_RecInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_RecInfo.Size = new System.Drawing.Size(445, 166);
            this.Txt_RecInfo.TabIndex = 8;
            this.Txt_RecInfo.Enter += new System.EventHandler(this.Txt_RecInfo_Enter);
            // 
            // Txt_Sender
            // 
            this.Txt_Sender.Location = new System.Drawing.Point(38, 214);
            this.Txt_Sender.Multiline = true;
            this.Txt_Sender.Name = "Txt_Sender";
            this.Txt_Sender.Size = new System.Drawing.Size(445, 166);
            this.Txt_Sender.TabIndex = 4;
            this.Txt_Sender.Validated += new System.EventHandler(this.CanSenderMsg);
            // 
            // Lbl_PublicIP
            // 
            this.Lbl_PublicIP.AutoSize = true;
            this.Lbl_PublicIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_PublicIP.Location = new System.Drawing.Point(595, 84);
            this.Lbl_PublicIP.Name = "Lbl_PublicIP";
            this.Lbl_PublicIP.Size = new System.Drawing.Size(106, 22);
            this.Lbl_PublicIP.TabIndex = 0;
            this.Lbl_PublicIP.Text = "本机公网IP：";
            // 
            // Txt_PublicIP
            // 
            this.Txt_PublicIP.Location = new System.Drawing.Point(704, 83);
            this.Txt_PublicIP.Name = "Txt_PublicIP";
            this.Txt_PublicIP.Size = new System.Drawing.Size(144, 23);
            this.Txt_PublicIP.TabIndex = 1;
            // 
            // Btn_Sender
            // 
            this.Btn_Sender.Enabled = false;
            this.Btn_Sender.Location = new System.Drawing.Point(676, 397);
            this.Btn_Sender.Name = "Btn_Sender";
            this.Btn_Sender.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sender.TabIndex = 2;
            this.Btn_Sender.Text = "发送消息";
            this.Btn_Sender.UseVisualStyleBackColor = true;
            this.Btn_Sender.Click += new System.EventHandler(this.Btn_Sender_Click);
            // 
            // Btn_OpenClient
            // 
            this.Btn_OpenClient.Location = new System.Drawing.Point(676, 453);
            this.Btn_OpenClient.Name = "Btn_OpenClient";
            this.Btn_OpenClient.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenClient.TabIndex = 2;
            this.Btn_OpenClient.Text = "打开客户端";
            this.Btn_OpenClient.UseVisualStyleBackColor = false;
            this.Btn_OpenClient.Click += new System.EventHandler(this.Btn_OpenClient_Click);
            // 
            // Btn_Broke
            // 
            this.Btn_Broke.Location = new System.Drawing.Point(676, 368);
            this.Btn_Broke.Name = "Btn_Broke";
            this.Btn_Broke.Size = new System.Drawing.Size(75, 23);
            this.Btn_Broke.TabIndex = 2;
            this.Btn_Broke.Text = "关闭服务";
            this.Btn_Broke.UseVisualStyleBackColor = true;
            this.Btn_Broke.Click += new System.EventHandler(this.Btn_Broke_Click);
            // 
            // Btn_ChooseFile
            // 
            this.Btn_ChooseFile.Location = new System.Drawing.Point(52, 436);
            this.Btn_ChooseFile.Name = "Btn_ChooseFile";
            this.Btn_ChooseFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_ChooseFile.TabIndex = 9;
            this.Btn_ChooseFile.Text = "选择文件";
            this.Btn_ChooseFile.UseVisualStyleBackColor = true;
            this.Btn_ChooseFile.Click += new System.EventHandler(this.Btn_ChooseFile_Click);
            // 
            // Lbl_FilePath
            // 
            this.Lbl_FilePath.AutoSize = true;
            this.Lbl_FilePath.Location = new System.Drawing.Point(133, 441);
            this.Lbl_FilePath.Name = "Lbl_FilePath";
            this.Lbl_FilePath.Size = new System.Drawing.Size(0, 17);
            this.Lbl_FilePath.TabIndex = 10;
            // 
            // Btn_SendFile
            // 
            this.Btn_SendFile.Location = new System.Drawing.Point(487, 436);
            this.Btn_SendFile.Name = "Btn_SendFile";
            this.Btn_SendFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_SendFile.TabIndex = 9;
            this.Btn_SendFile.Text = "发送文件";
            this.Btn_SendFile.UseVisualStyleBackColor = true;
            this.Btn_SendFile.Click += new System.EventHandler(this.Btn_SendFile_Click);
            // 
            // FrmScoket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(871, 502);
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
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmScoket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scoket通讯";
            this.Shown += new System.EventHandler(this.GetIP);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_LocalIP;
        private System.Windows.Forms.Label Lbl_LocalPort;
        private System.Windows.Forms.TextBox Txt_LocalIP;
        private System.Windows.Forms.TextBox Txt_LocalPort;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.ListBox Lb_OnlineList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_RecInfo;
        private System.Windows.Forms.TextBox Txt_Sender;
        private System.Windows.Forms.Label Lbl_PublicIP;
        private System.Windows.Forms.TextBox Txt_PublicIP;
        private System.Windows.Forms.Button Btn_Sender;
        private System.Windows.Forms.Button Btn_OpenClient;
        private System.Windows.Forms.Button Btn_Broke;
        private System.Windows.Forms.Button Btn_ChooseFile;
        private System.Windows.Forms.Label Lbl_FilePath;
        private System.Windows.Forms.Button Btn_SendFile;
    }
}

