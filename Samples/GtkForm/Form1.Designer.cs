namespace GtkForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)panel1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Image = Properties.Resources.logoY;
            panel1.Location = new System.Drawing.Point(98, 310);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(571, 128);
            panel1.TabIndex = 0;
            panel1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Red;
            label1.Location = new System.Drawing.Point(545, 329);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 17);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // Form1
            // 
            ////AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ////BackColor = System.Drawing.Color.FromArgb(243, 249, 255);
            ////ClientSize = new System.Drawing.Size(800, 450);
            ////Controls.Add(label1);
            ////Controls.Add(panel1);
            ////FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ////MaximizeBox = false;
            ////MinimizeBox = false;
            ////Name = "Form1";
            ////ShowIcon = false;
            ////Text = "Form1";
            ////Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(21, 64, 119);
            ClientSize = new System.Drawing.Size(800, 566);
            Controls.Add(label1);
            Controls.Add(panel1);
            //Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            //MaximizeBox = false;
            //MinimizeBox = false; 
            Name = "frmMenu";
            ShowIcon = false;
            Text = "武警部队执勤信息系统-指纹采集工具";
            
            ((System.ComponentModel.ISupportInitialize)panel1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox panel1;
        private System.Windows.Forms.Label label1;
    }
}