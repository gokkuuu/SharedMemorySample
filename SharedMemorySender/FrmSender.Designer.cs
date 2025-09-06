namespace SharedMemoryTest
{
    partial class FrmSender
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShow = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblType = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSeparator5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblKBStep = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblKBStep = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(23, 497);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(88, 25);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Show image";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 420);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(23, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(88, 25);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.RoyalBlue;
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
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatus
            // 
            this.tlblStatus.ForeColor = System.Drawing.Color.White;
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(45, 19);
            this.tlblStatus.Text = "Status :";
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
            this.tlblSeparator1.Size = new System.Drawing.Size(10, 15);
            this.tlblSeparator1.Text = "|";
            // 
            // tlblWidth
            // 
            this.tlblWidth.ForeColor = System.Drawing.Color.White;
            this.tlblWidth.Name = "tlblWidth";
            this.tlblWidth.Size = new System.Drawing.Size(45, 15);
            this.tlblWidth.Text = "Width :";
            // 
            // slblWidth
            // 
            this.slblWidth.ForeColor = System.Drawing.Color.White;
            this.slblWidth.Name = "slblWidth";
            this.slblWidth.Size = new System.Drawing.Size(17, 15);
            this.slblWidth.Text = "--";
            // 
            // tlblSeparator2
            // 
            this.tlblSeparator2.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator2.Name = "tlblSeparator2";
            this.tlblSeparator2.Size = new System.Drawing.Size(10, 15);
            this.tlblSeparator2.Text = "|";
            // 
            // tlblHeight
            // 
            this.tlblHeight.ForeColor = System.Drawing.Color.White;
            this.tlblHeight.Name = "tlblHeight";
            this.tlblHeight.Size = new System.Drawing.Size(49, 15);
            this.tlblHeight.Text = "Height :";
            // 
            // slblHeight
            // 
            this.slblHeight.ForeColor = System.Drawing.Color.White;
            this.slblHeight.Name = "slblHeight";
            this.slblHeight.Size = new System.Drawing.Size(17, 15);
            this.slblHeight.Text = "--";
            // 
            // tlblSeparator3
            // 
            this.tlblSeparator3.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator3.Name = "tlblSeparator3";
            this.tlblSeparator3.Size = new System.Drawing.Size(10, 15);
            this.tlblSeparator3.Text = "|";
            // 
            // tlblType
            // 
            this.tlblType.ForeColor = System.Drawing.Color.White;
            this.tlblType.Name = "tlblType";
            this.tlblType.Size = new System.Drawing.Size(38, 15);
            this.tlblType.Text = "Type :";
            // 
            // slblType
            // 
            this.slblType.ForeColor = System.Drawing.Color.White;
            this.slblType.Name = "slblType";
            this.slblType.Size = new System.Drawing.Size(32, 15);
            this.slblType.Text = "bmp";
            // 
            // tlblSeparator4
            // 
            this.tlblSeparator4.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator4.Name = "tlblSeparator4";
            this.tlblSeparator4.Size = new System.Drawing.Size(10, 15);
            this.tlblSeparator4.Text = "|";
            // 
            // tlblSize
            // 
            this.tlblSize.ForeColor = System.Drawing.Color.White;
            this.tlblSize.Name = "tlblSize";
            this.tlblSize.Size = new System.Drawing.Size(33, 15);
            this.tlblSize.Text = "Size :";
            // 
            // slblSize
            // 
            this.slblSize.ForeColor = System.Drawing.Color.White;
            this.slblSize.Name = "slblSize";
            this.slblSize.Size = new System.Drawing.Size(45, 15);
            this.slblSize.Text = "slblSize";
            // 
            // tlblSeparator5
            // 
            this.tlblSeparator5.ForeColor = System.Drawing.Color.White;
            this.tlblSeparator5.Name = "tlblSeparator5";
            this.tlblSeparator5.Size = new System.Drawing.Size(10, 15);
            this.tlblSeparator5.Text = "|";
            // 
            // tlblKBStep
            // 
            this.tlblKBStep.ForeColor = System.Drawing.Color.White;
            this.tlblKBStep.Name = "tlblKBStep";
            this.tlblKBStep.Size = new System.Drawing.Size(53, 15);
            this.tlblKBStep.Text = "KB Step :";
            // 
            // slblKBStep
            // 
            this.slblKBStep.ForeColor = System.Drawing.Color.White;
            this.slblKBStep.Name = "slblKBStep";
            this.slblKBStep.Size = new System.Drawing.Size(62, 15);
            this.slblKBStep.Text = "slblKBStep";
            // 
            // FrmSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 573);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnShow);
            this.MaximizeBox = false;
            this.Name = "FrmSender";
            this.Text = "FrmSender";
            this.Load += new System.EventHandler(this.FrmSender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
        private System.Windows.Forms.ToolStripStatusLabel slblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tlblWidth;
        private System.Windows.Forms.ToolStripStatusLabel slblWidth;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel tlblHeight;
        private System.Windows.Forms.ToolStripStatusLabel slblHeight;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel tlblType;
        private System.Windows.Forms.ToolStripStatusLabel slblType;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel tlblSize;
        private System.Windows.Forms.ToolStripStatusLabel slblSize;
        private System.Windows.Forms.ToolStripStatusLabel tlblSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel tlblKBStep;
        private System.Windows.Forms.ToolStripStatusLabel slblKBStep;
    }
}

