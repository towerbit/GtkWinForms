namespace GtkForm
{
    partial class Form2
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
            btnOpenDialog = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnOpenDialog
            // 
            btnOpenDialog.Location = new System.Drawing.Point(255, 177);
            btnOpenDialog.Name = "btnOpenDialog";
            btnOpenDialog.Size = new System.Drawing.Size(102, 34);
            btnOpenDialog.TabIndex = 0;
            btnOpenDialog.Text = "Open Dialog";
            btnOpenDialog.UseVisualStyleBackColor = true;
            btnOpenDialog.Click += btnOpenDialog_Click;
            // 
            // Form2
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(21, 64, 119);
            ClientSize = new System.Drawing.Size(640, 400);
            Controls.Add(btnOpenDialog);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnOpenDialog;
    }
}