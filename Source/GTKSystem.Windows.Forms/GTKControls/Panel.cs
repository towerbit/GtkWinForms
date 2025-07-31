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
    public partial class Panel : ScrollableControl
    {
        public readonly PanelBase self = new PanelBase();
        public override object GtkControl => self;
        public Gtk.Overlay contaner = new Gtk.Overlay();
        private ControlCollection _controls;
        public Panel() : base()
        {
            _controls = new ControlCollection(this, contaner);
            contaner.Margin = 0;
            contaner.Halign = Align.Fill;
            contaner.Valign = Align.Fill;
            contaner.Hexpand = false;
            contaner.Vexpand = false;
            contaner.BorderWidth = 0;
            contaner.Add(new Gtk.Fixed() { Halign = Align.Fill, Valign = Align.Fill });
            self.Add(contaner);
        }
        public override ControlCollection Controls => _controls;
        public override Padding Padding
        {
            get => base.Padding;
            set
            {
                base.Padding = value;
                contaner.MarginStart = value.Left;
                contaner.MarginTop = value.Top;
                contaner.MarginEnd = value.Right;
                contaner.MarginBottom = value.Bottom;
            }
        }

        #region TODO: 动态修改后支持刷新显示
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e); // 这个保护方法，基类尚未调用
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        /// <summary>
        /// 重写属性，解决运行时修改图片后无法刷新显示的问题
        /// 这个办法对动态改变 BackgroundImage 显示无效，
        /// 更好的方案是重写 OnPaint() 中完成绘图
        /// </summary>
        public override Drawing.Image Image
        {
            get => base.Image;
            set
            {
                ControlCollection? controls = null;
                switch (this.Parent)
                {
                    case Form form: controls = form.Controls; break;
                    case Panel panel: controls = panel.Controls; break;
                    case FlowLayoutPanel flpanel: controls = flpanel.Controls; break;
                    case TableLayoutPanel tlpanel: controls = tlpanel.Controls; break;
                    case TabPage page: controls = page.Controls; break;
                    case GroupBox gBox: controls = gBox.Controls; break;
                    default:
                        Debug.Print("直接更换图像可能没有效果");
                        break;
                }
                controls?.Remove(this);
                base.Image = value;
                controls?.Add(this);
            } 
        }
        #endregion
    }
}
