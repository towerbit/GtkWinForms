using System.Drawing;
using System.Windows.Forms;

namespace GtkForm
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "运行环境测试程序";

            // 将显示在 PictureBox 之上，且支持背景透明
            label1.BringToFront();

            var btnOpen = new Button();
            btnOpen.Text = "Call OpenFileDialog";
            btnOpen.SetBounds(50, 50, 200, 50);
            //btnOpen.Size = new Size(200, 50);
            //btnOpen.Location = new Point(50, 50);
            Controls.Add(btnOpen);
            btnOpen.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new())
                {
                    ofd.Filter = "Python files|*.py|Source files|*.cs;*.py|Html files|*.html;*.htm;*.json|Image files|*.BMP;*.JPG;*.GIF|All files|*.*";
                    ofd.CheckFileExists = true;
                    ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (ofd.ShowDialog() == DialogResult.OK)
                        MessageBox.Show(this, $"你选中的文件是 '{ofd.FileName}'", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            //this.MaximizeBox = false;
            this.MinimizeBox = false; // 两个按钮都隐藏，Raspbian 上打开子窗口会闪退

            var btnShow = new Button();
            btnShow.Text = "Show Form";
            btnShow.SetBounds(300, 50, 200, 50);
            Controls.Add(btnShow);
            btnShow.Click += (s, e) =>
            {
                var f = new Form2();
                f.Closed += (s, e) => this.Enabled = true;
                f.Text = "Form2 不会随子窗体关闭";
                f.Show();
                this.Enabled = false;
            };

            var btnShowDialog = new Button();
            btnShowDialog.Text = "ShowDialog Form";
            btnShowDialog.SetBounds(550, 50, 200, 50);
            Controls.Add(btnShowDialog);
            btnShowDialog.Click += (s, e) =>
            {
                using (var f = new Form2())
                {
                    // 通过 ShowDialog 打开 Form2，
                    f.Text = "Form2 会随子窗体关闭后关闭";
                    f.btnOpen.Text = "打开子窗体后无响应挂起";
                    f.ShowDialog();
                }
            };

            this.Paint += (s, e) =>
            {
                var brush = new SolidBrush(Color.Red);
                e.Graphics.DrawString("GtkForm Test OK 测试通过",
                    new Font("Sans", 36), // <- 字体找不到，会无法显示
                    brush,
                    new Point(100, 230));
            };
        }

        private class Form2 : Form
        {
            public Button btnOpenDialog;
            public Button btnOpen;
            public Form2()
            {
                btnOpenDialog = new Button();
                SuspendLayout();
                // 
                // btnOpenDialog
                // 
                btnOpenDialog.Location = new Point(0, 0);
                btnOpenDialog.Name = "btnOpenDialog";
                btnOpenDialog.Size = new Size(200, 35);
                btnOpenDialog.TabIndex = 0;
                btnOpenDialog.Text = "Open Child Dialog";
                btnOpenDialog.UseVisualStyleBackColor = true;
                btnOpenDialog.Click += (s, e) =>
                {
                    using (Form f = new Form())
                    {
                        f.Text = "Dialog";
                        f.ShowDialog();
                    }
                };
                // 
                // btnOpen
                // 
                btnOpen = new Button();
                btnOpen.Location = new Point(220, 0);
                btnOpen.Name = "btnOpen";
                btnOpen.Size = new Size(200, 35);
                btnOpen.TabIndex = 0;
                btnOpen.Text = "Open Child Form";
                btnOpen.UseVisualStyleBackColor = true;
                btnOpen.Click += (s, e) =>
                {
                    Form f = new Form();
                    f.Size = new Size(320, 240);
                    f.Text = "Form";
                    f.Closed += (s, e) => 
                        this.Enabled = true;
                    f.Show();
                    this.Enabled = false;
                };
                // 
                // Form2
                // 
                ClientSize = new System.Drawing.Size(640, 400);
                Controls.Add(btnOpenDialog);
                Controls.Add(btnOpen);
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                MaximizeBox = false;
                MinimizeBox = false;
                Name = "Form2";
                Text = "Form2";
                ResumeLayout(false);
            }
        }
    }
}
