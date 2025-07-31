using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GtkForm
{
    public partial class frmControlDemo : Form
    {
        public frmControlDemo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            progressBar1.Value = 0; // 设置进度条初始值为50%
            numericUpDown1.ValueChanged += ValueChangedEventHandler;
            trackBar1.Scroll += ValueChangedEventHandler;
            hScrollBar1.ValueChanged += ValueChangedEventHandler;
            vScrollBar1.ValueChanged += ValueChangedEventHandler;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // 设置下拉框样式为只读
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0; // 默认选择第一个选项

            //this.ContextMenuStrip = contextMenuStrip1; // 设置右键菜单
            notifyIcon1.ContextMenuStrip = contextMenuStrip1; // 设置托盘图标的右键菜单
            // 注意：需要显式设置菜单项可见，才能正常加载托盘图标的右键菜单
            hideToolStripMenuItem.Visible = true; // 显示隐藏菜单项
            showToolStripMenuItem.Visible = true; // 显示显示菜单项
            toolStripMenuItem1.Visible = true; // 显示工具条菜单项
            exitToolStripMenuItem1.Visible = true; // 显示退出菜单项
            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.WindowState == FormWindowState.Minimized)
            {
                // 窗口最小化时隐藏窗口
                this.Visible = false;
                notifyIcon1.Visible = true; // 显示托盘图标
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // 窗口恢复时显示窗口
                if (!this.Visible) this.Visible = true;
                notifyIcon1.Visible = false; // 隐藏托盘图标
            }
        }

        private void ValueChangedEventHandler(object sender, EventArgs e)
        {
            int value = 0;
            switch (sender)
            {
                case NumericUpDown _:
                    value = (int)((NumericUpDown)sender).Value;
                    break;
                case TrackBar _:
                    value = (int)((TrackBar)sender).Value;
                    break;
                case HScrollBar _:
                    value = (int)((HScrollBar)sender).Value;
                    break;
                case VScrollBar _:
                    value = (int)((VScrollBar)sender).Value;
                    break;
            }
            numericUpDown1.Value = value; // 更新数值框的值
            progressBar1.Value = value; // 更新进度条的值
            trackBar1.Value = value; // 更新滑动条的值
            hScrollBar1.Value = value; // 更新水平滚动条的值
            vScrollBar1.Value = value; // 更新垂直滚动条的值
            toolStripProgressBar1.Value = value; // 更新工具条进度条的值
            toolStripProgressBar2.Value = value; // 更新工具条进度条的值
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using(var ofd = new OpenFileDialog())
            {
                ofd.Title = "选择文件";
                ofd.Filter = "图片文件(*.jpg;*.png;*.bmp;*.gif)|*.jpg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show($"选择的文件: {ofd.FileName}");
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是一个控件演示窗口。\n\n" +
                "可以通过按钮选择图片文件，并在PictureBox中显示。\n\n" +
                "请注意，GtkForm是一个基于GTK的Windows Forms实现，\n" +
                "因此某些功能可能与传统的WinForms有所不同。", 
                "控件演示信息", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void btnWarn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是一个警告消息框。\n\n" +
                "请注意，这只是一个演示，实际应用中请根据需要处理警告信息。",
                "警告",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是一个错误消息框。\n\n" +
                "请注意，这只是一个演示，实际应用中请根据需要处理错误信息。",
                "错误",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("这是一个问题消息框。\n\n" +
                "请注意，这只是一个演示，实际应用中请根据需要处理用户的选择。",
                "问题",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("您选择了“是”。", "选择结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("您选择了“否”。", "选择结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnOpen.Enabled = !checkBox1.Checked;
        }

        private void btnForm1_Click(object sender, EventArgs e)
        {
            using(var f = new Form1())
            {
                f.ShowDialog();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show 方法会再次触发 OnLoad 事件，改用 Visible 属性来控制窗口显示
            //this.Show(); // 显示窗口
            // 这里有问题，需要点击两次才能显示窗口
            this.Visible = true;
            this.WindowState = FormWindowState.Normal; // 恢复窗口状态
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Visible = false;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(this, $"你选中的字体是 '{fd.Font.Name}'", this.Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Font = fd.Font;
                    //_selectedFont = fd.Font;
                    //btnOpen.Font = new Font(new FontFamily(fd.Font.Name), 12F);
                    //Refresh();
                }
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog fd = new ColorDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(this, $"你选中的颜色是 '{fd.Color.Name}'", this.Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Font = fd.Font;
                    //_selectedFont = fd.Font;
                    //btnOpen.Font = new Font(new FontFamily(fd.Font.Name), 12F);
                    //Refresh();
                }
            }
        }

        private void btnDialog_Click(object sender, EventArgs e)
        {
            using (var f = new Form2())
            {
                // 通过 ShowDialog 打开 Form2，
                f.Text = "Form2 会随子窗体关闭后关闭";
                f.btnOpenDialog.Text = "打开子窗体对话框";
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Closed += (s1, e1) => this.Enabled = true;
            f.Text = "Form2 不会随子窗体关闭";
            f.Show();
            this.Enabled = false;
        }
    }
}
