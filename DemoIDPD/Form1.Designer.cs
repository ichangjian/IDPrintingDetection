namespace DemoIDPD
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_st = new System.Windows.Forms.TextBox();
            this.textBox_sh = new System.Windows.Forms.TextBox();
            this.button_select_st = new System.Windows.Forms.Button();
            this.button_select_sh = new System.Windows.Forms.Button();
            this.button_run = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "下膜原始图";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "下膜拍摄图";
            // 
            // textBox_st
            // 
            this.textBox_st.Location = new System.Drawing.Point(194, 40);
            this.textBox_st.Name = "textBox_st";
            this.textBox_st.ReadOnly = true;
            this.textBox_st.Size = new System.Drawing.Size(402, 25);
            this.textBox_st.TabIndex = 3;
            // 
            // textBox_sh
            // 
            this.textBox_sh.Location = new System.Drawing.Point(196, 91);
            this.textBox_sh.Name = "textBox_sh";
            this.textBox_sh.ReadOnly = true;
            this.textBox_sh.Size = new System.Drawing.Size(402, 25);
            this.textBox_sh.TabIndex = 3;
            // 
            // button_select_st
            // 
            this.button_select_st.Location = new System.Drawing.Point(613, 41);
            this.button_select_st.Name = "button_select_st";
            this.button_select_st.Size = new System.Drawing.Size(75, 23);
            this.button_select_st.TabIndex = 4;
            this.button_select_st.Text = "选图";
            this.button_select_st.UseVisualStyleBackColor = true;
            this.button_select_st.Click += new System.EventHandler(this.button_select_st_Click);
            // 
            // button_select_sh
            // 
            this.button_select_sh.Location = new System.Drawing.Point(614, 92);
            this.button_select_sh.Name = "button_select_sh";
            this.button_select_sh.Size = new System.Drawing.Size(75, 23);
            this.button_select_sh.TabIndex = 5;
            this.button_select_sh.Text = "选图";
            this.button_select_sh.UseVisualStyleBackColor = true;
            this.button_select_sh.Click += new System.EventHandler(this.button_select_sh_Click);
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(641, 303);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(75, 23);
            this.button_run.TabIndex = 6;
            this.button_run.Text = "RUN";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.button_select_sh);
            this.Controls.Add(this.button_select_st);
            this.Controls.Add(this.textBox_sh);
            this.Controls.Add(this.textBox_st);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "IDPD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_st;
        private System.Windows.Forms.TextBox textBox_sh;
        private System.Windows.Forms.Button button_select_st;
        private System.Windows.Forms.Button button_select_sh;
        private System.Windows.Forms.Button button_run;
    }
}

