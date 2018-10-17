namespace CaylayTree
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.locationBar = new System.Windows.Forms.TrackBar();
            this.locationLabel = new System.Windows.Forms.Label();
            this.angleLabel1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.angleBox1 = new System.Windows.Forms.GroupBox();
            this.angleBar1 = new System.Windows.Forms.TrackBar();
            this.angleLabel2 = new System.Windows.Forms.Label();
            this.lengthLabel2 = new System.Windows.Forms.Label();
            this.lengthLabel1 = new System.Windows.Forms.Label();
            this.lengthBox1 = new System.Windows.Forms.GroupBox();
            this.lengthBar1 = new System.Windows.Forms.TrackBar();
            this.angleBox2 = new System.Windows.Forms.GroupBox();
            this.angleBar2 = new System.Windows.Forms.TrackBar();
            this.lengthBox2 = new System.Windows.Forms.GroupBox();
            this.lengthBar2 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.locationBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.angleBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleBar1)).BeginInit();
            this.lengthBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBar1)).BeginInit();
            this.angleBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleBar2)).BeginInit();
            this.lengthBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // locationBar
            // 
            this.locationBar.LargeChange = 100;
            this.locationBar.Location = new System.Drawing.Point(6, 24);
            this.locationBar.Maximum = 1000;
            this.locationBar.Name = "locationBar";
            this.locationBar.Size = new System.Drawing.Size(124, 56);
            this.locationBar.TabIndex = 1;
            this.locationBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.locationBar.Value = 618;
            this.locationBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.locationLabel.Location = new System.Drawing.Point(147, 32);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(47, 15);
            this.locationLabel.TabIndex = 2;
            this.locationLabel.Text = "0.618";
            // 
            // angleLabel1
            // 
            this.angleLabel1.AutoSize = true;
            this.angleLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.angleLabel1.Location = new System.Drawing.Point(147, 32);
            this.angleLabel1.Name = "angleLabel1";
            this.angleLabel1.Size = new System.Drawing.Size(23, 15);
            this.angleLabel1.TabIndex = 3;
            this.angleLabel1.Text = "30";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.locationLabel);
            this.groupBox1.Controls.Add(this.locationBar);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "位置系数";
            // 
            // angleBox1
            // 
            this.angleBox1.Controls.Add(this.angleBar1);
            this.angleBox1.Controls.Add(this.angleLabel1);
            this.angleBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.angleBox1.Location = new System.Drawing.Point(12, 12);
            this.angleBox1.Name = "angleBox1";
            this.angleBox1.Size = new System.Drawing.Size(200, 50);
            this.angleBox1.TabIndex = 5;
            this.angleBox1.TabStop = false;
            this.angleBox1.Text = "右子树角度";
            // 
            // angleBar1
            // 
            this.angleBar1.Location = new System.Drawing.Point(26, 24);
            this.angleBar1.Maximum = 90;
            this.angleBar1.Name = "angleBar1";
            this.angleBar1.Size = new System.Drawing.Size(104, 56);
            this.angleBar1.TabIndex = 4;
            this.angleBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.angleBar1.Value = 30;
            this.angleBar1.Scroll += new System.EventHandler(this.angleBar1_Scroll);
            // 
            // angleLabel2
            // 
            this.angleLabel2.AutoSize = true;
            this.angleLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.angleLabel2.Location = new System.Drawing.Point(132, 32);
            this.angleLabel2.Name = "angleLabel2";
            this.angleLabel2.Size = new System.Drawing.Size(23, 15);
            this.angleLabel2.TabIndex = 6;
            this.angleLabel2.Text = "20";
            // 
            // lengthLabel2
            // 
            this.lengthLabel2.AutoSize = true;
            this.lengthLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lengthLabel2.Location = new System.Drawing.Point(132, 32);
            this.lengthLabel2.Name = "lengthLabel2";
            this.lengthLabel2.Size = new System.Drawing.Size(31, 15);
            this.lengthLabel2.TabIndex = 7;
            this.lengthLabel2.Text = "0.7";
            // 
            // lengthLabel1
            // 
            this.lengthLabel1.AutoSize = true;
            this.lengthLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lengthLabel1.Location = new System.Drawing.Point(147, 32);
            this.lengthLabel1.Name = "lengthLabel1";
            this.lengthLabel1.Size = new System.Drawing.Size(31, 15);
            this.lengthLabel1.TabIndex = 8;
            this.lengthLabel1.Text = "0.6";
            // 
            // lengthBox1
            // 
            this.lengthBox1.Controls.Add(this.lengthLabel1);
            this.lengthBox1.Controls.Add(this.lengthBar1);
            this.lengthBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lengthBox1.Location = new System.Drawing.Point(12, 84);
            this.lengthBox1.Name = "lengthBox1";
            this.lengthBox1.Size = new System.Drawing.Size(200, 50);
            this.lengthBox1.TabIndex = 9;
            this.lengthBox1.TabStop = false;
            this.lengthBox1.Text = "右子树长度";
            // 
            // lengthBar1
            // 
            this.lengthBar1.LargeChange = 10;
            this.lengthBar1.Location = new System.Drawing.Point(16, 24);
            this.lengthBar1.Maximum = 100;
            this.lengthBar1.Name = "lengthBar1";
            this.lengthBar1.Size = new System.Drawing.Size(104, 56);
            this.lengthBar1.TabIndex = 0;
            this.lengthBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lengthBar1.Value = 60;
            this.lengthBar1.Scroll += new System.EventHandler(this.lengthBar1_Scroll);
            // 
            // angleBox2
            // 
            this.angleBox2.Controls.Add(this.angleBar2);
            this.angleBox2.Controls.Add(this.angleLabel2);
            this.angleBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.angleBox2.Location = new System.Drawing.Point(300, 12);
            this.angleBox2.Name = "angleBox2";
            this.angleBox2.Size = new System.Drawing.Size(200, 50);
            this.angleBox2.TabIndex = 10;
            this.angleBox2.TabStop = false;
            this.angleBox2.Text = "左子树角度";
            // 
            // angleBar2
            // 
            this.angleBar2.Location = new System.Drawing.Point(22, 24);
            this.angleBar2.Maximum = 90;
            this.angleBar2.Name = "angleBar2";
            this.angleBar2.Size = new System.Drawing.Size(104, 56);
            this.angleBar2.TabIndex = 1;
            this.angleBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.angleBar2.Value = 20;
            this.angleBar2.Scroll += new System.EventHandler(this.angleBar2_Scroll);
            // 
            // lengthBox2
            // 
            this.lengthBox2.Controls.Add(this.lengthLabel2);
            this.lengthBox2.Controls.Add(this.lengthBar2);
            this.lengthBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lengthBox2.Location = new System.Drawing.Point(300, 84);
            this.lengthBox2.Name = "lengthBox2";
            this.lengthBox2.Size = new System.Drawing.Size(200, 50);
            this.lengthBox2.TabIndex = 11;
            this.lengthBox2.TabStop = false;
            this.lengthBox2.Text = "左子树长度";
            // 
            // lengthBar2
            // 
            this.lengthBar2.LargeChange = 10;
            this.lengthBar2.Location = new System.Drawing.Point(22, 24);
            this.lengthBar2.Maximum = 100;
            this.lengthBar2.Name = "lengthBar2";
            this.lengthBar2.Size = new System.Drawing.Size(104, 56);
            this.lengthBar2.TabIndex = 1;
            this.lengthBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lengthBar2.Value = 70;
            this.lengthBar2.Scroll += new System.EventHandler(this.lengthBar2_Scroll);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(650, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 80);
            this.button2.TabIndex = 12;
            this.button2.Text = "Just Randomly Draw";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(916, 757);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.angleBox1);
            this.Controls.Add(this.lengthBox2);
            this.Controls.Add(this.angleBox2);
            this.Controls.Add(this.lengthBox1);
            this.Name = "Form1";
            this.Text = "CayleyTree";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.locationBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.angleBox1.ResumeLayout(false);
            this.angleBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleBar1)).EndInit();
            this.lengthBox1.ResumeLayout(false);
            this.lengthBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBar1)).EndInit();
            this.angleBox2.ResumeLayout(false);
            this.angleBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleBar2)).EndInit();
            this.lengthBox2.ResumeLayout(false);
            this.lengthBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar locationBar;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label angleLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox angleBox1;
        private System.Windows.Forms.TrackBar angleBar1;
        private System.Windows.Forms.Label angleLabel2;
        private System.Windows.Forms.Label lengthLabel2;
        private System.Windows.Forms.Label lengthLabel1;
        private System.Windows.Forms.GroupBox lengthBox1;
        private System.Windows.Forms.TrackBar lengthBar1;
        private System.Windows.Forms.GroupBox angleBox2;
        private System.Windows.Forms.TrackBar angleBar2;
        private System.Windows.Forms.GroupBox lengthBox2;
        private System.Windows.Forms.TrackBar lengthBar2;
        private System.Windows.Forms.Button button2;
    }
}

