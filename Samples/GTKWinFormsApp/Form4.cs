using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            button5.Text = "Font Dialog";
            button5.Click += button5_Click;
            button2.Text = "Close";
            button2.Click += (_, _) => this.Close();

            treeView1.AfterSelect += (_, e) => Debug.Print($"==>AfterSelect: FullPath={e.Node.FullPath}");
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
            if (MessageBox.Show("确定要关闭吗", "OnFormClosing",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
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
            if (MessageBox.Show("再次确定要关闭吗", "OnClosing",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
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

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg|*.jpg;png|*.png";
            ofd.Multiselect = true;
            ofd.Title = "测试打开文件";
            ofd.Description = "打开文件 decription";

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
            ofd.Multiselect = true;
            DialogResult dialogResult = ofd.ShowDialog();
            Console.WriteLine("dialogResult:" + dialogResult.ToString());
            foreach (string file in ofd.SelectedPaths)
            {
                Console.WriteLine("SelectedPaths:" + file);
            }
            Console.WriteLine("SelectedPath:" + ofd.SelectedPath);
        }

        private void button8_Click(object sender, EventArgs e)
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
        private void button5_Click(object sender, EventArgs e)
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
            treeView1.SelectedNode.Expand();
        }
       
    }
}
