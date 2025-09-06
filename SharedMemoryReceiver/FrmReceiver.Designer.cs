namespace SharedMemoryReceiver
{
    partial class FrmReceiver
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
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkOneShot = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblKBStep = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblKBStep = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblType = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblType = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator3 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(22, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 25);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 420);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 497);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(116, 40);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 25);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(564, 497);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkOneShot
            // 
            this.chkOneShot.AutoSize = true;
            this.chkOneShot.Location = new System.Drawing.Point(556, 44);
            this.chkOneShot.Name = "chkOneShot";
            this.chkOneShot.Size = new System.Drawing.Size(96, 17);
            this.chkOneShot.TabIndex = 8;
            this.chkOneShot.Text = "Oneshot Mode";
            this.chkOneShot.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(164)))), ((int)(((byte)(57)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus,
            this.slblStatus,
            this.tlblSeparator1,
            this.tlblWidth,
            this.slblWidth,
            this.tlblSeparator2,
            this.tlblHeight,
            this.slblHeight,
            this.tlblSeparator3,
            this.tlblType,
            this.slblType,
            this.tlblSeparator4,
            this.tlblSize,
            this.slblSize,
            this.tlblSeparator5,
            this.tlblKBStep,
            this.slblKBStep});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblStatus
            // 
            this.slblStatus.AutoSize = false;
            this.slblStatus.ForeColor = System.Drawing.Color.White;
            this.slblStatus.Name = "slblStatus";
            this.slblStatus.Size = new System.Drawing.Size(630, 19);
            this.slblStatus.Text = "Ready";
            // 
            // tlblSeparator1
            // 
            this.tlblSeparator1.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator1.Name = "tlblSeparator1";
            this.tlblSeparator1.Size = new System.Drawing.Size(10, 17);
            this.tlblSeparator1.Text = "|";
            // 
            // tlblSize
            // 
            this.tlblSize.ForeColor = System.Drawing.Color.White;
            this.tlblSize.Name = "tlblSize";
            this.tlblSize.Size = new System.Drawing.Size(33, 17);
            this.tlblSize.Text = "Size :";
            // 
            // slblSize
            // 
            this.slblSize.ForeColor = System.Drawing.Color.White;
            this.slblSize.Name = "slblSize";
            this.slblSize.Size = new System.Drawing.Size(45, 17);
            this.slblSize.Text = "slblSize";
            // 
            // tlblSeparator5
            // 
            this.tlblSeparator5.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator5.Name = "tlblSeparator5";
            this.tlblSeparator5.Size = new System.Drawing.Size(10, 17);
            this.tlblSeparator5.Text = "|";
            // 
            // tlblKBStep
            // 
            this.tlblKBStep.ForeColor = System.Drawing.Color.White;
            this.tlblKBStep.Name = "tlblKBStep";
            this.tlblKBStep.Size = new System.Drawing.Size(53, 17);
            this.tlblKBStep.Text = "KB Step :";
            // 
            // tlblStatus
            // 
            this.tlblStatus.ForeColor = System.Drawing.Color.White;
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(45, 17);
            this.tlblStatus.Text = "Status :";
            // 
            // slblKBStep
            // 
            this.slblKBStep.ForeColor = System.Drawing.Color.White;
            this.slblKBStep.Name = "slblKBStep";
            this.slblKBStep.Size = new System.Drawing.Size(62, 17);
            this.slblKBStep.Text = "slblKBStep";
            // 
            // tlblSeparator4
            // 
            this.tlblSeparator4.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator4.Name = "tlblSeparator4";
            this.tlblSeparator4.Size = new System.Drawing.Size(10, 17);
            this.tlblSeparator4.Text = "|";
            // 
            // tlblType
            // 
            this.tlblType.ForeColor = System.Drawing.Color.White;
            this.tlblType.Name = "tlblType";
            this.tlblType.Size = new System.Drawing.Size(38, 19);
            this.tlblType.Text = "Type :";
            // 
            // slblType
            // 
            this.slblType.ForeColor = System.Drawing.Color.White;
            this.slblType.Name = "slblType";
            this.slblType.Size = new System.Drawing.Size(32, 17);
            this.slblType.Text = "bmp";
            // 
            // slblWidth
            // 
            this.slblWidth.ForeColor = System.Drawing.Color.White;
            this.slblWidth.Name = "slblWidth";
            this.slblWidth.Size = new System.Drawing.Size(17, 17);
            this.slblWidth.Text = "--";
            // 
            // tlblWidth
            // 
            this.tlblWidth.ForeColor = System.Drawing.Color.White;
            this.tlblWidth.Name = "tlblWidth";
            this.tlblWidth.Size = new System.Drawing.Size(45, 19);
            this.tlblWidth.Text = "Width :";
            // 
            // tlblHeight
            // 
            this.tlblHeight.ForeColor = System.Drawing.Color.White;
            this.tlblHeight.Name = "tlblHeight";
            this.tlblHeight.Size = new System.Drawing.Size(49, 17);
            this.tlblHeight.Text = "Height :";
            // 
            // slblHeight
            // 
            this.slblHeight.ForeColor = System.Drawing.Color.White;
            this.slblHeight.Name = "slblHeight";
            this.slblHeight.Size = new System.Drawing.Size(17, 17);
            this.slblHeight.Text = "--";
            // 
            // tlblSeparator2
            // 
            this.tlblSeparator2.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator2.Name = "tlblSeparator2";
            this.tlblSeparator2.Size = new System.Drawing.Size(10, 17);
            this.tlblSeparator2.Text = "|";
            // 
            // tlblSeparator3
            // 
            this.tlblSeparator3.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator3.Name = "tlblSeparator3";
            this.tlblSeparator3.Size = new System.Drawing.Size(10, 17);
            this.tlblSeparator3.Text = "|";
            // 
            // FrmReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 573);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkOneShot);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmReceiver";
            this.Text = "FrmReceiver";
            this.Load += new System.EventHandler(this.FrmReceiver_Load);
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.FrmReceiver_DpiChanged);
            this.DpiChangedBeforeParent += new System.EventHandler(this.FrmReceiver_DpiChangedBeforeParent);
            this.DpiChangedAfterParent += new System.EventHandler(this.FrmReceiver_DpiChangedAfterParent);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkOneShot;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tlblSize;
        private System.Windows.Forms.ToolStripStatusLabel slblSize;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel tlblKBStep;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
        private System.Windows.Forms.ToolStripStatusLabel slblKBStep;
        private System.Windows.Forms.ToolStripStatusLabel tlblType;
        private System.Windows.Forms.ToolStripStatusLabel slblType;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel tlblWidth;
        private System.Windows.Forms.ToolStripStatusLabel slblWidth;
        private System.Windows.Forms.ToolStripStatusLabel tlblHeight;
        private System.Windows.Forms.ToolStripStatusLabel slblHeight;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator3;
    }
}

