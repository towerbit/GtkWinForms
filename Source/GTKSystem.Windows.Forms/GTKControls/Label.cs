/*
 * 基于GTK组件开发，兼容原生C#控件winform界面的跨平台界面组件。
 * 使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows、linux、macos运行
 * 技术支持438865652@qq.com，https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 * author:chenhongjin
 */
using Gtk;
using GTKSystem.Windows.Forms.GTKControls.ControlBase;
using System.ComponentModel;
using System.Diagnostics;

namespace System.Windows.Forms
{
    [DesignerCategory("Component")]
    public partial class Label : Control
    {
        public readonly LabelBase self = new LabelBase();
        public override object GtkControl => self;
        public Label() : base() {
      
        }
        public override string Text { get => self.Text; set { self.Text = value; } }
        public override RightToLeft RightToLeft { get { return self.Direction == Gtk.TextDirection.Rtl ? RightToLeft.Yes : RightToLeft.No; } set { self.Direction = value == RightToLeft.Yes ?  Gtk.TextDirection.Rtl : Gtk.TextDirection.Ltr; } }
        public System.Drawing.ContentAlignment TextAlign { 
            get { return textAlign; } 
            set { 
                textAlign = value;
                if (value == System.Drawing.ContentAlignment.TopLeft)
                {
                    self.Xalign = 0.0f;
                    self.Yalign = 0.0f;
                }
                else if (value == System.Drawing.ContentAlignment.TopCenter)
                {
                    self.Xalign = 0.5f;
                    self.Yalign = 0.0f;
                }
                else if (value == System.Drawing.ContentAlignment.TopRight)
                {
                    self.Xalign = 1.0f;
                    self.Yalign = 0.0f;
                }
                else if (value == System.Drawing.ContentAlignment.MiddleLeft)
                {
                    self.Xalign = 0.0f;
                    self.Yalign = 0.5f;
                }
                else if (value == System.Drawing.ContentAlignment.MiddleCenter)
                {
                    self.Xalign = 0.5f;
                    self.Yalign = 0.5f;
                }
                else if (value == System.Drawing.ContentAlignment.MiddleRight)
                {
                    self.Xalign = 1.0f;
                    self.Yalign = 0.5f;
                }
                else if (value == System.Drawing.ContentAlignment.BottomLeft)
                {
                    self.Xalign = 0.0f;
                    self.Yalign = 1.0f;
                }
                else if (value == System.Drawing.ContentAlignment.BottomCenter)
                {
                    self.Xalign = 0.5f;
                    self.Yalign = 1.0f;
                }
                else if (value == System.Drawing.ContentAlignment.BottomRight)
                {
                    self.Xalign = 1.0f;
                    self.Yalign = 1.0f;
                }

            }
        }
        private System.Drawing.ContentAlignment textAlign;

        /// <summary>
        /// 重写属性，解决运行时换图不会刷新显示的问题，参见 Panel 中的相关代码
        /// </summary>
        public override Drawing.Image Image
        {
            get => base.Image;
            set
            {
                ControlCollection controls = null;
                switch (this.Parent)
                {
                    case Form form: controls = form.Controls; break;
                    case Panel panel: controls = panel.Controls; break;
                    case FlowLayoutPanel flpanel: controls = flpanel.Controls; break;
                    case TableLayoutPanel tlpanel: controls = tlpanel.Controls; break;
                    case TabPage page: controls = page.Controls; break;
                    case GroupBox gBox: controls = gBox.Controls; break;
                    default:
                        Debug.Print("运行时更换图像可能没有效果");
                        break;
                }
                controls?.Remove(this);
                base.Image = value;
                controls?.Add(this);
            }
        }
    }
}
