namespace ScoketTcp
{
    partial class FrmScoketClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_Sender = new System.Windows.Forms.TextBox();
            this.Txt_RecInfo = new System.Windows.Forms.TextBox();
            this.Btn_Sender = new System.Windows.Forms.Button();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Txt_ServerPort = new System.Windows.Forms.TextBox();
            this.Txt_ServerIP = new System.Windows.Forms.TextBox();
            this.Lbl_ServerPort = new System.Windows.Forms.Label();
            this.Lbl_ServerIP = new System.Windows.Forms.Label();
            this.Btn_Broke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_Sender
            // 
            this.Txt_Sender.Location = new System.Drawing.Point(25, 215);
            this.Txt_Sender.Multiline = true;
            this.Txt_Sender.Name = "Txt_Sender";
            this.Txt_Sender.Size = new System.Drawing.Size(445, 166);
            this.Txt_Sender.TabIndex = 15;
            // 
            // Txt_RecInfo
            // 
            this.Txt_RecInfo.Location = new System.Drawing.Point(25, 28);
            this.Txt_RecInfo.Multiline = true;
            this.Txt_RecInfo.Name = "Txt_RecInfo";
            this.Txt_RecInfo.ReadOnly = true;
            this.Txt_RecInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_RecInfo.Size = new System.Drawing.Size(445, 166);
            this.Txt_RecInfo.TabIndex = 16;
            this.Txt_RecInfo.Enter += new System.EventHandler(this.Txt_RecInfo_Enter);
            // 
            // Btn_Sender
            // 
            this.Btn_Sender.Location = new System.Drawing.Point(673, 358);
            this.Btn_Sender.Name = "Btn_Sender";
            this.Btn_Sender.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sender.TabIndex = 13;
            this.Btn_Sender.Text = "发送消息";
            this.Btn_Sender.UseVisualStyleBackColor = true;
            this.Btn_Sender.Click += new System.EventHandler(this.Btn_Sender_Click);
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Location = new System.Drawing.Point(673, 213);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.Btn_Connect.TabIndex = 14;
            this.Btn_Connect.Text = "连接服务器";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Txt_ServerPort
            // 
            this.Txt_ServerPort.Location = new System.Drawing.Point(691, 130);
            this.Txt_ServerPort.Name = "Txt_ServerPort";
            this.Txt_ServerPort.Size = new System.Drawing.Size(144, 21);
            this.Txt_ServerPort.TabIndex = 11;
            // 
            // Txt_ServerIP
            // 
            this.Txt_ServerIP.Location = new System.Drawing.Point(691, 40);
            this.Txt_ServerIP.Name = "Txt_ServerIP";
            this.Txt_ServerIP.Size = new System.Drawing.Size(144, 21);
            this.Txt_ServerIP.TabIndex = 12;
            // 
            // Lbl_ServerPort
            // 
            this.Lbl_ServerPort.AutoSize = true;
            this.Lbl_ServerPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_ServerPort.Location = new System.Drawing.Point(598, 129);
            this.Lbl_ServerPort.Name = "Lbl_ServerPort";
            this.Lbl_ServerPort.Size = new System.Drawing.Size(106, 22);
            this.Lbl_ServerPort.TabIndex = 9;
            this.Lbl_ServerPort.Text = "服务器端口：";
            // 
            // Lbl_ServerIP
            // 
            this.Lbl_ServerIP.AutoSize = true;
            this.Lbl_ServerIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_ServerIP.Location = new System.Drawing.Point(614, 39);
            this.Lbl_ServerIP.Name = "Lbl_ServerIP";
            this.Lbl_ServerIP.Size = new System.Drawing.Size(90, 22);
            this.Lbl_ServerIP.TabIndex = 10;
            this.Lbl_ServerIP.Text = "服务器IP：";
            // 
            // Btn_Broke
            // 
            this.Btn_Broke.Location = new System.Drawing.Point(673, 260);
            this.Btn_Broke.Name = "Btn_Broke";
            this.Btn_Broke.Size = new System.Drawing.Size(75, 23);
            this.Btn_Broke.TabIndex = 14;
            this.Btn_Broke.Text = "断开服务器";
            this.Btn_Broke.UseVisualStyleBackColor = true;
            this.Btn_Broke.Click += new System.EventHandler(this.Btn_Broke_Click);
            // 
            // FrmScoketClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 479);
            this.Controls.Add(this.Txt_Sender);
            this.Controls.Add(this.Txt_RecInfo);
            this.Controls.Add(this.Btn_Sender);
            this.Controls.Add(this.Btn_Broke);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.Txt_ServerPort);
            this.Controls.Add(this.Txt_ServerIP);
            this.Controls.Add(this.Lbl_ServerPort);
            this.Controls.Add(this.Lbl_ServerIP);
            this.Name = "FrmScoketClient";
            this.Text = "FrmScoketClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScoketClient_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Sender;
        private System.Windows.Forms.TextBox Txt_RecInfo;
        private System.Windows.Forms.Button Btn_Sender;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.TextBox Txt_ServerPort;
        private System.Windows.Forms.TextBox Txt_ServerIP;
        private System.Windows.Forms.Label Lbl_ServerPort;
        private System.Windows.Forms.Label Lbl_ServerIP;
        private System.Windows.Forms.Button Btn_Broke;
    }
}