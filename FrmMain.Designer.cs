namespace VideoSuperResolution {
    partial class FrmMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.PicVidIn = new System.Windows.Forms.PictureBox();
            this.PicVidOut = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicVidIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVidOut)).BeginInit();
            this.SuspendLayout();
            // 
            // PicVidIn
            // 
            this.PicVidIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicVidIn.Location = new System.Drawing.Point(31, 27);
            this.PicVidIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PicVidIn.Name = "PicVidIn";
            this.PicVidIn.Size = new System.Drawing.Size(295, 309);
            this.PicVidIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicVidIn.TabIndex = 0;
            this.PicVidIn.TabStop = false;
            // 
            // PicVidOut
            // 
            this.PicVidOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicVidOut.Location = new System.Drawing.Point(394, 27);
            this.PicVidOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PicVidOut.Name = "PicVidOut";
            this.PicVidOut.Size = new System.Drawing.Size(295, 309);
            this.PicVidOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicVidOut.TabIndex = 1;
            this.PicVidOut.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "⇒";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnFile
            // 
            this.BtnFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFile.Location = new System.Drawing.Point(268, 437);
            this.BtnFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BtnFile.Name = "BtnFile";
            this.BtnFile.Size = new System.Drawing.Size(182, 50);
            this.BtnFile.TabIndex = 3;
            this.BtnFile.Text = "Choose Video File";
            this.BtnFile.UseVisualStyleBackColor = true;
            this.BtnFile.Click += new System.EventHandler(this.BtnFile_ClickAsync);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(658, 37);
            this.progressBar1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(26, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "0/0 - 00%";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PicVidOut);
            this.Controls.Add(this.PicVidIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Video Super-Resolution";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicVidIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVidOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicVidIn;
        private System.Windows.Forms.PictureBox PicVidOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
    }
}

