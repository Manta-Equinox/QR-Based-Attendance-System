namespace AP_Project
{
    partial class ScannerControl
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastScan = new System.Windows.Forms.Label();
            this.lblParticipant = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCamera.Location = new System.Drawing.Point(43, 30);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(500, 350);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCamera.TabIndex = 0;
            this.pictureBoxCamera.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(56, 565);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 44);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelStatus.Controls.Add(this.lblParticipant);
            this.panelStatus.Controls.Add(this.label4);
            this.panelStatus.Controls.Add(this.lblLastScan);
            this.panelStatus.Controls.Add(this.lblEvent);
            this.panelStatus.Controls.Add(this.label3);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Controls.Add(this.label1);
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Location = new System.Drawing.Point(663, 30);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(479, 350);
            this.panelStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(128, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(86, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "{status}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "STATUS:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(201, 565);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 44);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(352, 565);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(120, 44);
            this.btnCapture.TabIndex = 4;
            this.btnCapture.Text = "CAPTURE";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(500, 565);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 44);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "EVENT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "PARTICIPANT:";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(133, 83);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(81, 25);
            this.lblEvent.TabIndex = 4;
            this.lblEvent.Text = "{event}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "LAST SCAN:";
            // 
            // lblLastScan
            // 
            this.lblLastScan.AutoSize = true;
            this.lblLastScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScan.Location = new System.Drawing.Point(173, 203);
            this.lblLastScan.Name = "lblLastScan";
            this.lblLastScan.Size = new System.Drawing.Size(112, 25);
            this.lblLastScan.TabIndex = 5;
            this.lblLastScan.Text = "{lastScan}";
            // 
            // lblParticipant
            // 
            this.lblParticipant.AutoSize = true;
            this.lblParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticipant.Location = new System.Drawing.Point(183, 150);
            this.lblParticipant.Name = "lblParticipant";
            this.lblParticipant.Size = new System.Drawing.Size(86, 25);
            this.lblParticipant.TabIndex = 7;
            this.lblParticipant.Text = "{status}";
            // 
            // ScannerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 698);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBoxCamera);
            this.Name = "ScannerControl";
            this.Text = "ScannerControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblParticipant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLastScan;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnClose;
    }
}