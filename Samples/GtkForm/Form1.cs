using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GtkForm
{
    public partial class Form1: Form
    {
        

        public Form1()
        {
            InitializeComponent();
            this.Text = "运行环境测试程序";

            BindingEventHandler();

            // 最大化和最小化两个按钮都隐藏，Raspbian 上打开子窗口会闪退
            //this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // GTK 将显示在 PictureBox 之上，且支持背景透明
            label1.BringToFront();
        }

        private void BindingEventHandler()
        {
            panel1.MouseClick += (s, e) => Debug.Print($"panel1.MouseClick: {e.Button}");
            
            // 以下代码不会触发, 鼠标事件穿透到了 Form 上
            pictureBox1.MouseClick += (s, e) => Debug.Print($"pictureBox1.MouseClick: {e.Button}");
            
            btnOpen.Click += btnOpenClickEvnetHandler;
            btnShow.Click += btnShowEventHandler;
            btnShowDialog.Click += btnShowDialogEventHandler;

            this.MouseClick +=(s, e) => Debug.Print($">>>>>  this.MouseClick: {e.Button}");
            this.Paint += (s, e) => { };

            btnOpen.MouseClick +=(s, e) =>
                 Debug.Print($">>>>>  btnOpen.MouseClick: {e.Button}");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Debug.Print(">>>>> OnShown: ClientSize={0}", this.ClientSize.ToString());
        }

        /// <summary>
        /// Form.OnPaintBackground 暂不支持调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Debug.Print(">>>>> Form1.OnPaintBackground");
        }

        private class panelEx : Panel
        {
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                base.OnPaintBackground(e);
            }
        }

        private class picboxEx : PictureBox
        {
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                base.OnPaintBackground(pevent);
            }
        }

        private class labelEx : System.Windows.Forms.Label
        {
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                base.OnPaintBackground(pevent);
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Debug.Print(">>>>> Form1.OnPaint");
            //e.Graphics.DrawString("GtkForm Test OK 测试通过",
            //                      btnOpen.Font,
            //                      new SolidBrush(Color.Red),
            //                      new Point(100, 230));
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Debug.Print($"----- Form1.OnMouseClick: {e.Button}");
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Debug.Print($"----- Form1.OnMouseDown: {e.Button}");
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Debug.Print($"----- Form1.OnMouseUp: {e.Button}");
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            Debug.Print($">>>>> OnMouseDoubleClick: {e.Button}");
        }

        private void btnShowDialogEventHandler(object sender, EventArgs e)
        {
            using (var f = new Form2())
            {
                // 通过 ShowDialog 打开 Form2，
                f.Text = "Form2 会随子窗体关闭后关闭";
                f.btnOpenDialog.Text = "打开子窗体对话框";
                f.ShowDialog();
            }
        }

        private void btnShowEventHandler(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Closed += (s1, e1) => this.Enabled = true;
            f.Text = "Form2 不会随子窗体关闭";
            f.Show();
            this.Enabled = false;
        }

        private void btnOpenClickEvnetHandler(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Python files|*.py|Source files|*.cs;*.py|Html files|*.html;*.htm;*.json|Image files|*.BMP;*.JPG;*.GIF|All files|*.*";
                ofd.CheckFileExists = true;
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (ofd.ShowDialog() == DialogResult.OK)
                    MessageBox.Show(this, $"你选中的文件是 '{ofd.FileName}'", this.Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            using (FontDialog fd = new FontDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(this, $"你选中的字体是 '{fd.Font.Name}'", this.Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Font = fd.Font;
                    //_selectedFont = fd.Font;
                    btnOpen.Font = new Font(new FontFamily(fd.Font.Name), 12F);
                    Refresh();
                }
            }

            var bmp = Image.FromFile("d:\\c_users_liutao\\Pictures\\earth.png");
            //pictureBox1.BackgroundImage = pictureBox1.Image;
            var bg = new Bitmap(panel1.Width, panel1.Height);
            using (var g = Graphics.FromImage(bg))
            {
                //g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, panel1.Width, panel1.Height));
                //g.Clear(Color.Transparent);
                //g.Clear(SystemColors.Control);
                g.Clear(this.BackColor);
                g.DrawImage(bmp, 0, 0);
                g.DrawString("这是新背景", new Font("STKaiti", 32F), new SolidBrush(Color.Red), new Point(2, 2));
                g.Flush();
            }
            pictureBox1.Image = bg;

            // Panel 运行时换图刷新
            //this.Controls.Remove(panel1);
            //panel1.BackgroundImage = bg;
            panel1.Image = bg;
            //panel1.Refresh();
            //this.Controls.Add(panel1);
        }
    }
}
