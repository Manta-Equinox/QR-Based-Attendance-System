namespace AP_Project
{
    partial class AttendanceLogControl
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
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AllowUserToResizeColumns = false;
            this.dgvAttendance.AllowUserToResizeRows = false;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Location = new System.Drawing.Point(118, 112);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAttendance.RowTemplate.Height = 24;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(933, 445);
            this.dgvAttendance.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(118, 594);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(129, 43);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AttendanceLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 698);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvAttendance);
            this.Name = "AttendanceLogControl";
            this.Text = "x";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Button btnRefresh;
    }
}