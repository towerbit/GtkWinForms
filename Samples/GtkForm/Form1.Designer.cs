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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnShowDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = global::GtkForm.Properties.Resources.logoY;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(98, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 128);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::GtkForm.Properties.Resources.logoY;
            this.pictureBox1.Location = new System.Drawing.Point(98, 290);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(547, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(60, 50);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(190, 50);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Call OpenFileDialog";
            this.btnOpen.UseVisualStyleBackColor = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(309, 50);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(202, 50);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Show Form";
            this.btnShow.UseVisualStyleBackColor = false;
            // 
            // btnShowDialog
            // 
            this.btnShowDialog.Location = new System.Drawing.Point(571, 50);
            this.btnShowDialog.Name = "btnShowDialog";
            this.btnShowDialog.Size = new System.Drawing.Size(179, 50);
            this.btnShowDialog.TabIndex = 4;
            this.btnShowDialog.Text = "ShowDialog Form";
            this.btnShowDialog.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(64)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnShowDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "武警部队执勤信息系统-指纹采集工具";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnShowDialog;
    }
}