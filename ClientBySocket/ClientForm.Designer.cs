namespace ClientBySocket
{
    partial class ClientForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lblClientIp = new System.Windows.Forms.Label();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.lblRemoteIp = new System.Windows.Forms.Label();
            this.lblRemotePort = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClientIps = new System.Windows.Forms.Label();
            this.lblClientPorts = new System.Windows.Forms.Label();
            this.lblRemoteIps = new System.Windows.Forms.Label();
            this.lblRemotePorts = new System.Windows.Forms.Label();
            this.lblStatuss = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConnected = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnchoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMsg.Location = new System.Drawing.Point(16, 18);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(623, 213);
            this.txtMsg.TabIndex = 0;
            // 
            // lblClientIp
            // 
            this.lblClientIp.AutoSize = true;
            this.lblClientIp.Location = new System.Drawing.Point(668, 21);
            this.lblClientIp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientIp.Name = "lblClientIp";
            this.lblClientIp.Size = new System.Drawing.Size(68, 15);
            this.lblClientIp.TabIndex = 1;
            this.lblClientIp.Text = "本机Ip：";
            // 
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Location = new System.Drawing.Point(668, 62);
            this.lblClientPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(82, 15);
            this.lblClientPort.TabIndex = 2;
            this.lblClientPort.Text = "本机端口：";
            // 
            // lblRemoteIp
            // 
            this.lblRemoteIp.AutoSize = true;
            this.lblRemoteIp.Location = new System.Drawing.Point(668, 102);
            this.lblRemoteIp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemoteIp.Name = "lblRemoteIp";
            this.lblRemoteIp.Size = new System.Drawing.Size(68, 15);
            this.lblRemoteIp.TabIndex = 3;
            this.lblRemoteIp.Text = "远端Ip：";
            // 
            // lblRemotePort
            // 
            this.lblRemotePort.AutoSize = true;
            this.lblRemotePort.Location = new System.Drawing.Point(668, 139);
            this.lblRemotePort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemotePort.Name = "lblRemotePort";
            this.lblRemotePort.Size = new System.Drawing.Size(82, 15);
            this.lblRemotePort.TabIndex = 4;
            this.lblRemotePort.Text = "远端端口：";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(668, 175);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "状态：";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(16, 249);
            this.txtSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(623, 102);
            this.txtSend.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 367);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 232);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(623, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "-----------------------------------------------------------------------------";
            // 
            // lblClientIps
            // 
            this.lblClientIps.AutoSize = true;
            this.lblClientIps.Location = new System.Drawing.Point(747, 21);
            this.lblClientIps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientIps.Name = "lblClientIps";
            this.lblClientIps.Size = new System.Drawing.Size(0, 15);
            this.lblClientIps.TabIndex = 9;
            // 
            // lblClientPorts
            // 
            this.lblClientPorts.AutoSize = true;
            this.lblClientPorts.Location = new System.Drawing.Point(748, 62);
            this.lblClientPorts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientPorts.Name = "lblClientPorts";
            this.lblClientPorts.Size = new System.Drawing.Size(0, 15);
            this.lblClientPorts.TabIndex = 10;
            // 
            // lblRemoteIps
            // 
            this.lblRemoteIps.AutoSize = true;
            this.lblRemoteIps.Location = new System.Drawing.Point(747, 102);
            this.lblRemoteIps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemoteIps.Name = "lblRemoteIps";
            this.lblRemoteIps.Size = new System.Drawing.Size(0, 15);
            this.lblRemoteIps.TabIndex = 11;
            // 
            // lblRemotePorts
            // 
            this.lblRemotePorts.AutoSize = true;
            this.lblRemotePorts.Location = new System.Drawing.Point(747, 139);
            this.lblRemotePorts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemotePorts.Name = "lblRemotePorts";
            this.lblRemotePorts.Size = new System.Drawing.Size(0, 15);
            this.lblRemotePorts.TabIndex = 12;
            // 
            // lblStatuss
            // 
            this.lblStatuss.AutoSize = true;
            this.lblStatuss.Location = new System.Drawing.Point(748, 175);
            this.lblStatuss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatuss.Name = "lblStatuss";
            this.lblStatuss.Size = new System.Drawing.Size(0, 15);
            this.lblStatuss.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(671, 249);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(187, 29);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "断开连接";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConnected
            // 
            this.btnConnected.Location = new System.Drawing.Point(671, 322);
            this.btnConnected.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.Size = new System.Drawing.Size(187, 29);
            this.btnConnected.TabIndex = 16;
            this.btnConnected.Text = "重新连接";
            this.btnConnected.UseVisualStyleBackColor = true;
            this.btnConnected.Click += new System.EventHandler(this.btnConnected_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(758, 368);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonsend_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(360, 372);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(250, 25);
            this.txtFileName.TabIndex = 17;
            // 
            // btnchoice
            // 
            this.btnchoice.Location = new System.Drawing.Point(636, 368);
            this.btnchoice.Margin = new System.Windows.Forms.Padding(4);
            this.btnchoice.Name = "btnchoice";
            this.btnchoice.Size = new System.Drawing.Size(100, 29);
            this.btnchoice.TabIndex = 7;
            this.btnchoice.Text = "选择";
            this.btnchoice.UseVisualStyleBackColor = true;
            this.btnchoice.Click += new System.EventHandler(this.buttonchoice_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 409);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnConnected);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatuss);
            this.Controls.Add(this.lblRemotePorts);
            this.Controls.Add(this.lblRemoteIps);
            this.Controls.Add(this.lblClientPorts);
            this.Controls.Add(this.lblClientIps);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnchoice);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRemotePort);
            this.Controls.Add(this.lblRemoteIp);
            this.Controls.Add(this.lblClientPort);
            this.Controls.Add(this.lblClientIp);
            this.Controls.Add(this.txtMsg);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label lblClientIp;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.Label lblRemoteIp;
        private System.Windows.Forms.Label lblRemotePort;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClientIps;
        private System.Windows.Forms.Label lblClientPorts;
        private System.Windows.Forms.Label lblRemoteIps;
        private System.Windows.Forms.Label lblRemotePorts;
        private System.Windows.Forms.Label lblStatuss;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConnected;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnchoice;
    }
}

