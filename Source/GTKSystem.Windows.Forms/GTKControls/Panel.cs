﻿//基于GTK3.24.24.34版本组件开发，兼容原生C#控件winform界面的跨平台界面组件。
//使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows和linux运行
//技术支持438865652@qq.com，https://www.cnblogs.com/easywebfactory
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace System.Windows.Forms
{
    [DesignerCategory("Component")]
    public partial class Panel : WidgetControl<Gtk.Viewport>
    {
        private Gtk.Layout contaner;
        private ControlCollection _controls;

        public Panel() : base()
        {
            Widget.StyleContext.AddClass("Panel");
            base.Control.Margin = 0;
            base.Control.MarginStart = 0;
            base.Control.MarginTop = 0;
            base.Control.ShadowType = Gtk.ShadowType.In;
            base.Control.BorderWidth = 1;
            contaner = new Gtk.Layout(new Gtk.Adjustment(IntPtr.Zero), new Gtk.Adjustment(IntPtr.Zero));
            contaner.Margin = 0;
            contaner.MarginStart = 0;
            contaner.MarginTop = 0;
            _controls = new ControlCollection(contaner);

            base.Control.Add(contaner);
        }

        public BorderStyle BorderStyle { get { return base.Control.ShadowType == Gtk.ShadowType.None ? BorderStyle.None : BorderStyle.FixedSingle; } set { base.Control.BorderWidth = 1; base.Control.ShadowType = Gtk.ShadowType.In; } }
        public override ControlCollection Controls => _controls;
    }
}
