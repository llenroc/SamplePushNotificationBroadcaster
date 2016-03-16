namespace SamplePushNotificationBroadcaster
{
    partial class Form
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtDeviceToken = new System.Windows.Forms.TextBox();
            this.rbAndroid = new System.Windows.Forms.RadioButton();
            this.rbiOS = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.lblDeviceToken = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblBadge = new System.Windows.Forms.Label();
            this.txtBadge = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblJobId = new System.Windows.Forms.Label();
            this.txtJobId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(160, 287);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(131, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send Notification";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtDeviceToken
            // 
            this.txtDeviceToken.Location = new System.Drawing.Point(73, 114);
            this.txtDeviceToken.Name = "txtDeviceToken";
            this.txtDeviceToken.Size = new System.Drawing.Size(375, 20);
            this.txtDeviceToken.TabIndex = 1;
            // 
            // rbAndroid
            // 
            this.rbAndroid.AutoSize = true;
            this.rbAndroid.Location = new System.Drawing.Point(73, 193);
            this.rbAndroid.Name = "rbAndroid";
            this.rbAndroid.Size = new System.Drawing.Size(61, 17);
            this.rbAndroid.TabIndex = 2;
            this.rbAndroid.TabStop = true;
            this.rbAndroid.Text = "Android";
            this.rbAndroid.UseVisualStyleBackColor = true;
            // 
            // rbiOS
            // 
            this.rbiOS.AutoSize = true;
            this.rbiOS.Location = new System.Drawing.Point(73, 216);
            this.rbiOS.Name = "rbiOS";
            this.rbiOS.Size = new System.Drawing.Size(42, 17);
            this.rbiOS.TabIndex = 3;
            this.rbiOS.TabStop = true;
            this.rbiOS.Text = "iOS";
            this.rbiOS.UseVisualStyleBackColor = true;
            // 
            // rbWindows
            // 
            this.rbWindows.AutoSize = true;
            this.rbWindows.Location = new System.Drawing.Point(73, 239);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(69, 17);
            this.rbWindows.TabIndex = 4;
            this.rbWindows.TabStop = true;
            this.rbWindows.Text = "Windows";
            this.rbWindows.UseVisualStyleBackColor = true;
            // 
            // lblDeviceToken
            // 
            this.lblDeviceToken.AutoSize = true;
            this.lblDeviceToken.Location = new System.Drawing.Point(12, 117);
            this.lblDeviceToken.Name = "lblDeviceToken";
            this.lblDeviceToken.Size = new System.Drawing.Size(55, 13);
            this.lblDeviceToken.TabIndex = 5;
            this.lblDeviceToken.Text = "Device ID";
            this.lblDeviceToken.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(8, 197);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(45, 13);
            this.lblPlatform.TabIndex = 6;
            this.lblPlatform.Text = "Platform";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 332);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(432, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.Location = new System.Drawing.Point(11, 91);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(38, 13);
            this.lblBadge.TabIndex = 9;
            this.lblBadge.Text = "Badge";
            // 
            // txtBadge
            // 
            this.txtBadge.Location = new System.Drawing.Point(72, 88);
            this.txtBadge.Name = "txtBadge";
            this.txtBadge.Size = new System.Drawing.Size(375, 20);
            this.txtBadge.TabIndex = 8;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 65);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(73, 62);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(375, 20);
            this.txtMessage.TabIndex = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(73, 36);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(375, 20);
            this.txtTitle.TabIndex = 12;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(11, 144);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(43, 13);
            this.lblUserId.TabIndex = 15;
            this.lblUserId.Text = "User ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(72, 141);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(375, 20);
            this.txtUserId.TabIndex = 14;
            // 
            // lblJobId
            // 
            this.lblJobId.AutoSize = true;
            this.lblJobId.Location = new System.Drawing.Point(11, 170);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(38, 13);
            this.lblJobId.TabIndex = 17;
            this.lblJobId.Text = "Job ID";
            // 
            // txtJobId
            // 
            this.txtJobId.Location = new System.Drawing.Point(72, 167);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(375, 20);
            this.txtJobId.TabIndex = 16;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 396);
            this.Controls.Add(this.lblJobId);
            this.Controls.Add(this.txtJobId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblBadge);
            this.Controls.Add(this.txtBadge);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.lblDeviceToken);
            this.Controls.Add(this.rbWindows);
            this.Controls.Add(this.rbiOS);
            this.Controls.Add(this.rbAndroid);
            this.Controls.Add(this.txtDeviceToken);
            this.Controls.Add(this.btnSend);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "SamplePushNotificationBroadcaster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtDeviceToken;
        private System.Windows.Forms.RadioButton rbAndroid;
        private System.Windows.Forms.RadioButton rbiOS;
        private System.Windows.Forms.RadioButton rbWindows;
        private System.Windows.Forms.Label lblDeviceToken;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblBadge;
        private System.Windows.Forms.TextBox txtBadge;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblJobId;
        private System.Windows.Forms.TextBox txtJobId;
    }
}

