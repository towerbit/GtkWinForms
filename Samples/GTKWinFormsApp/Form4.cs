using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GTKWinFormsApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            // GotFocus 事件不会触发
            this.GotFocus += (_, _) => throw new InvalidOperationException();
            this.Shown += Form4_Shown;
            this.Paint += (s, e) =>
            {
                Debug.Print("=> this.Paint 晚于 OnPaint()");
                //e.Graphics.Clear(Color.Blue);
            };
            button5.Text = "Font Dialog";
            button5.Click += button5_Click;

            button5.MouseDown += (s, e) =>
            {
                var msg = e.Button == MouseButtons.Left ? "left" : "right";
                MessageBox.Show(msg);
            };

            button2.Text = "Close";
            button2.Click += (_, _) => this.Close();

            treeView1.AfterSelect += (_, e) => Debug.Print($"==>AfterSelect: FullPath={e.Node.FullPath}");

            // 清除原有的状态栏组件成员
            statusStrip1.Items.Clear();
            // 添加新创建的状态栏标签组件
            //List<ToolStripItem> ssLabels = new();
            for (int i = 0; i < 3; i++)
                //ssLabels.Add(new ToolStripStatusLabel($"Status{i:00}"));
                statusStrip1.Items.Add(new ToolStripStatusLabel($"Status{i:00}"));
            //statusStrip1.Items.AddRange(ssLabels);

            // 都可以移除组件，
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.Controls.Remove(tabPage2);
            // 都可以添加组件
            tabControl1.TabPages.Add(new TabPage()
            {
                Name = "tabPage3",
                Text = "tabPage3"
            });
            tabControl1.Controls.Add(new TabPage()
            {
                Name = "tabPage4",
                Text = "tabPage4"
            });

            button4.Click += Button4_Click;
        }

        private void Button4_Click(object? sender, EventArgs e)
        {
            //propertyGrid1.SelectedObject = sender;
            splitContainer1.Panel1.Controls.Add(new Button() { Location = new Point(200, 100), Size = new Size(160, 30), Text = "testtest", Dock=DockStyle.Fill });
        }

        Point panel1Location = new Point();
        private void Form4_Shown(object? sender, EventArgs e)
        {
            panel1Location.X = panel1.Widget.MarginStart;
            panel1Location.Y = panel1.Widget.MarginTop;

        }

        #region 保护方法调用
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Debug.Print($"==> OnFormClosing");
            var result = MessageBox.Show("确定要关闭吗", "OnFormClosing",
                                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if( result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Debug.Print($"==> OnFormClosed");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Debug.Print($"==> OnClosing");
            var result = MessageBox.Show("再次确定要关闭吗", "OnClosing",
                                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Debug.Print($"==> OnClosed");
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Debug.Print($"==> OnMove: {this.Location}");
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    Debug.Print($"==> OnResize: {this.Size}");
        //    Debug.Print($"this.WindowState ={this.WindowState}");
        //}

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            Debug.Print($"==> OnVisibleChanged: Visible={this.Visible}");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Debug.Print("==> OnShown");
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Debug.Print("==> OnActivated");
            Debug.Print($"ClientSize = {this.ClientSize}, Size = {this.Size}, Width = {this.Width}, Height = {this.Height}");
            Debug.Print($"Location = {this.Location}, Left = {this.Left}, Top = {this.Top}");
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Debug.Print("==> OnDeactivate");
        }

        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    Debug.Print("==> OnSizeChanged");
        //    Debug.Print($"Size = {this.Size}");
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Debug.Print("==> OnLoad");
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Debug.Print("==> OnLocationChanged");
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Debug.Print("==> OnMouseUp");
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Debug.Print("==> OnMouseDown");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Debug.Print("==> OnPaint 先于 Paint Event");
            //e.Graphics.Clear(Color.Pink);
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图像文件(.jpg)|*.jpg;图像文件(.png)|*.png";
            ofd.Multiselect = true;
            ofd.Title = "测试打开文件";
            ofd.Description = "打开文件 decription";

            ofd.DefaultExt = ".jpg";
            DialogResult dialogResult = ofd.ShowDialog(this);
            Console.WriteLine("dialogResult:" + dialogResult.ToString());
            Console.WriteLine("FileName:" + ofd.FileName);
            foreach (string file in ofd.FileNames)
            {
                Console.WriteLine("FileNames:" + file);
            }
            Console.WriteLine("SafeFileName:" + ofd.SafeFileName);
            foreach (string file in ofd.SafeFileNames)
            {
                Console.WriteLine("SafeFileNames:" + file);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "jpg|*.jpg;png|*.png";
            ofd.Title = "测试保存文件";
            ofd.Description = " 保存文件 decription";

            DialogResult dialogResult = ofd.ShowDialog();
            Console.WriteLine("dialogResult:" + dialogResult.ToString());
            Console.WriteLine("FileName:" + ofd.FileName);
            foreach (string file in ofd.FileNames)
            {
                Console.WriteLine("FileNames:" + file);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.Title = "测试浏览文件夹";
            ofd.Description = "浏览文件夹 decription";
            //ofd.Multiselect = true;
            DialogResult dialogResult = ofd.ShowDialog();
            Console.WriteLine("dialogResult:" + dialogResult.ToString());
            foreach (string file in ofd.SelectedPaths)
            {
                Console.WriteLine("SelectedPaths:" + file);
            }
            Console.WriteLine("SelectedPath:" + ofd.SelectedPath);
            //foreach (string file in ofd.SelectedPaths)
            //{
            //    Console.WriteLine("SelectedPaths:" + file);
            //}
        }

        private void button8_Click(object? sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            //FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowDialog();

            //Graphics g = CreateGraphics();
            //// g.DrawString("ddddddddd", new Font(FontFamily.GenericSansSerif, 16), new SolidBrush(Color.Red), 0, 0);
            //g.DrawRectangle(new Pen(new SolidBrush(Color.Red),2), new Rectangle(110, 110, 200, 200));


        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test message test message test messagetest message test message test message test messagetest message test message test message test messagetest message test message test message test messagetest message test message test message test messagetest message", "疑问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            MessageBox.Show("test message test message \ntest messagetest message", "警告", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        }

        private bool isBringToFront = false;
        private void button5_Click(object? sender, EventArgs e)
        {
            Debug.Print(Control.ModifierKeys.ToString());

            //FontDialog fontDialog = new FontDialog();
            //fontDialog.Font = button5.Font;
            //if (fontDialog.ShowDialog() == DialogResult.OK)
            //    button5.Font = fontDialog.Font;
            if (isBringToFront)
            {
                hScrollBar1.SendToBack();
                isBringToFront = false;
            }
            else
            {
                hScrollBar1.BringToFront();
                isBringToFront = true;
            }

        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Widget.MarginTop = panel1Location.Y + vScrollBar1.Value;


        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {

            panel1.Widget.MarginStart = panel1Location.X + hScrollBar1.Value;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hScrollBar1.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode?.Expand();
        }
       
    }
}
