
using System.Windows.Forms;

namespace GTKWinFormsApp
{
    partial class Form4
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
            components = new System.ComponentModel.Container();
            TreeNode treeNode6 = new TreeNode("节点3");
            TreeNode treeNode7 = new TreeNode("节点2", new TreeNode[] { treeNode6 });
            TreeNode treeNode8 = new TreeNode("节点4");
            TreeNode treeNode9 = new TreeNode("节点0", new TreeNode[] { treeNode7, treeNode8 });
            TreeNode treeNode10 = new TreeNode("节点1");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            button2 = new Button();
            button1 = new Button();
            button10 = new Button();
            hScrollBar1 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            button11 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            treeView1 = new TreeView();
            imageList1 = new ImageList(components);
            button5 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            test1ToolStripMenuItem = new ToolStripMenuItem();
            test12ToolStripMenuItem = new ToolStripMenuItem();
            test21ToolStripMenuItem = new ToolStripMenuItem();
            test22ToolStripMenuItem = new ToolStripMenuItem();
            test13ToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new System.Drawing.Point(0, 43);
            splitContainer1.Margin = new Padding(2, 3, 2, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            splitContainer1.Panel1.Controls.Add(tabControl1);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(button10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(hScrollBar1);
            splitContainer1.Panel2.Controls.Add(vScrollBar1);
            splitContainer1.Panel2.Controls.Add(button11);
            splitContainer1.Panel2.Controls.Add(button9);
            splitContainer1.Panel2.Controls.Add(button8);
            splitContainer1.Panel2.Controls.Add(button7);
            splitContainer1.Panel2.Controls.Add(button6);
            splitContainer1.Panel2.Controls.Add(treeView1);
            splitContainer1.Panel2.Controls.Add(button5);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(button3);
            
            splitContainer1.Size = new System.Drawing.Size(992, 441);
            splitContainer1.SplitterDistance = 265;
            splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(19, 84);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(226, 253);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Location = new System.Drawing.Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(218, 223);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new System.Drawing.Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(218, 223);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(23, 48);
            button2.Margin = new Padding(2, 3, 2, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(93, 30);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(23, 3);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(222, 39);
            button1.TabIndex = 0;
            button1.Text = "测试按钮1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button10.Location = new System.Drawing.Point(152, 48);
            button10.Margin = new Padding(2, 3, 2, 3);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(93, 30);
            button10.TabIndex = 2;
            button10.Text = "button10";
            button10.Click += button10_Click;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new System.Drawing.Point(209, 311);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new System.Drawing.Size(311, 26);
            hScrollBar1.TabIndex = 8;
            hScrollBar1.ValueChanged += hScrollBar1_ValueChanged;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new System.Drawing.Point(179, 143);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new System.Drawing.Size(26, 184);
            vScrollBar1.TabIndex = 7;
            vScrollBar1.ValueChanged += vScrollBar1_ValueChanged;
            // 
            // button11
            // 
            button11.Location = new System.Drawing.Point(179, 287);
            button11.Margin = new Padding(2, 3, 2, 3);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(232, 40);
            button11.TabIndex = 8;
            button11.Text = "【选择字体】按钮置顶";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(464, 72);
            button9.Margin = new Padding(2, 3, 2, 3);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(73, 25);
            button9.TabIndex = 6;
            button9.Text = "警告消息";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(359, 72);
            button8.Margin = new Padding(2, 3, 2, 3);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(73, 25);
            button8.TabIndex = 5;
            button8.Text = "选择颜色";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(249, 72);
            button7.Margin = new Padding(2, 3, 2, 3);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(73, 25);
            button7.TabIndex = 4;
            button7.Text = "浏览文件夹";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(147, 72);
            button6.Margin = new Padding(2, 3, 2, 3);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(73, 25);
            button6.TabIndex = 3;
            button6.Text = "保存文件";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // treeView1
            // 
            treeView1.ImageKey = "010.jpg";
            treeView1.ImageList = imageList1;
            treeView1.Location = new System.Drawing.Point(49, 154);
            treeView1.Margin = new Padding(2, 3, 2, 3);
            treeView1.Name = "treeView1";
            treeNode6.Name = "节点3";
            treeNode6.Text = "节点3";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "节点2";
            treeNode7.Text = "节点2";
            treeNode8.Name = "节点4";
            treeNode8.Text = "节点4";
            treeNode9.Name = "节点0";
            treeNode9.Text = "节点0";
            treeNode10.ImageIndex = 1;
            treeNode10.Name = "节点1";
            treeNode10.Text = "节点1";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode9, treeNode10 });
            treeView1.SelectedImageIndex = 0;
            treeView1.Size = new System.Drawing.Size(118, 103);
            treeView1.TabIndex = 2;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "010.jpg");
            imageList1.Images.SetKeyName(1, "timg2.jpg");
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            button5.ContextMenuStrip = contextMenuStrip1;
            button5.Dock = DockStyle.Top;
            //button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new System.Drawing.Point(0, 0);
            button5.Margin = new Padding(2, 3, 2, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(573, 42);
            button5.TabIndex = 2;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { test1ToolStripMenuItem, test12ToolStripMenuItem, test13ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(112, 70);
            // 
            // test1ToolStripMenuItem
            // 
            test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            test1ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            test1ToolStripMenuItem.Text = "test1";
            // 
            // test12ToolStripMenuItem
            // 
            test12ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { test21ToolStripMenuItem, test22ToolStripMenuItem });
            test12ToolStripMenuItem.Name = "test12ToolStripMenuItem";
            test12ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            test12ToolStripMenuItem.Text = "test12";
            // 
            // test21ToolStripMenuItem
            // 
            test21ToolStripMenuItem.Name = "test21ToolStripMenuItem";
            test21ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            test21ToolStripMenuItem.Text = "test21";
            // 
            // test22ToolStripMenuItem
            // 
            test22ToolStripMenuItem.Name = "test22ToolStripMenuItem";
            test22ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            test22ToolStripMenuItem.Text = "test22";
            // 
            // test13ToolStripMenuItem
            // 
            test13ToolStripMenuItem.Name = "test13ToolStripMenuItem";
            test13ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            test13ToolStripMenuItem.Text = "test13";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button4);
            panel1.Location = new System.Drawing.Point(209, 150);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(202, 107);
            panel1.TabIndex = 1;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(48, 17);
            button4.Margin = new Padding(2, 3, 2, 3);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(73, 25);
            button4.TabIndex = 0;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(49, 72);
            button3.Margin = new Padding(2, 3, 2, 3);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(73, 25);
            button3.TabIndex = 0;
            button3.Text = "打开文件";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(842, 43);
            label1.TabIndex = 1;
            label1.Text = "横幅栏";

            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new System.Drawing.Point(0, 396);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(842, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(131, 17);
            toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // Form4
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(842, 418);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form4";
            Text = "Form4";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test21ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test22ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test13ToolStripMenuItem;
        
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.ImageList imageList1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}