﻿/*
 * 基于GTK组件开发，兼容原生C#控件winform界面的跨平台界面组件。
 * 使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows、linux、macos运行
 * 技术支持438865652@qq.com，https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 */

using Gtk;
using GTKSystem.Windows.Forms.GTKControls.ControlBase;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms
{
    [DesignerCategory("Form")]
    [DefaultEvent(nameof(Load)),
    InitializationEvent(nameof(Load))]
    public partial class Form: ContainerControl, IWin32Window
    {
        private Gtk.Application app = Application.Init();
        public FormBase self = new FormBase();
        public override object GtkControl { get => self; }
        private Gtk.Overlay _body = new Gtk.Overlay();
        private ObjectCollection _ObjectCollection;
        // 可复用基类的事件，注释掉此事件
        //public override event EventHandler SizeChanged;

        public Form() : base()
        {
            Init();
        }
        public Form(string title) : this()
        {
            self.Title = title;
        }
        private void Init()
        {
            this.SetScrolledWindow(self);
            _body.Valign = Gtk.Align.Fill;
            _body.Halign = Gtk.Align.Fill;
            _body.Hexpand = true;
            _body.Vexpand = true;
            _body.MarginBottom = 0;
            _body.MarginEnd = 0;
            _body.Add(new Gtk.Fixed() { Halign = Align.Fill, Valign = Align.Fill });
            self.ScrollView.Child = _body;
            _ObjectCollection = new ObjectCollection(this, _body);
            self.ResizeChecked += Self_ResizeChecked;
            //self.Shown += Control_Shown; // self.Shown 只要窗口显示就会触发
            self.Shown += (_, _) => OnVisibleChanged(EventArgs.Empty);
            self.Hidden += (_, _) => OnVisibleChanged(EventArgs.Empty);
            self.CloseWindowEvent += Self_CloseWindowEvent;

            self.Realized += (sender, e) => base.InitStyle((Gtk.Widget)sender);
            self.FocusInEvent += Self_FocusInEvent;
            self.FocusOutEvent += Self_FocusOutEvent;
            self.WindowStateEvent += Self_WindowStateEvent;
            self.ButtonReleaseEvent += Self_ButtonReleaseEvent;
        }

        private void Self_ResizeChecked(object sender, EventArgs e)
        {
            OnSizeChanged(EventArgs.Empty);
            OnResize(EventArgs.Empty);
        }


        /// <summary>
        /// 确保仅调用一次 OnShown 
        /// </summary>
        private bool _bShown = false;
        private void Self_FocusInEvent(object sender, FocusInEventArgs e)
        {
            if (!_bShown)
            {
                _bShown = true;
                _location = this.Location;
                ShownControlBoxes();
                OnShown(e);
            }
            OnActivated(e);
        }

        private void Self_FocusOutEvent(object sender, FocusOutEventArgs e)
        {
            OnDeactivate(e);
        }

        private void Self_WindowStateEvent(object sender, WindowStateEventArgs e)
        {
            var eventArgs = e.Args;
            foreach (var arg in eventArgs)
            {
                var ews = arg as Gdk.EventWindowState;
                if (ews != null)
                {
                    if (ews.NewWindowState.HasFlag(Gdk.WindowState.Maximized))
                        _windowState = FormWindowState.Maximized;
                    else if (ews.NewWindowState.HasFlag(Gdk.WindowState.Iconified))
                        _windowState = FormWindowState.Minimized;
                    else
                        _windowState = FormWindowState.Normal;
                    OnSizeChanged(EventArgs.Empty);
                    OnResize(EventArgs.Empty);
                }
            }
        }

        private void Self_ButtonReleaseEvent(object sender, ButtonReleaseEventArgs e)
        {
            // 判断是否发生窗口位置改变
            if (this.Location != _location)
            {
                _location = this.Location;
                OnLocationChanged(EventArgs.Empty);
                OnMove(EventArgs.Empty);
            }
        }

        private bool Self_CloseWindowEvent(object sender, EventArgs e)
        {
            FormClosingEventArgs closing = new FormClosingEventArgs(CloseReason.UserClosing, false);
            //if (FormClosing != null)
            //    FormClosing(this, closing);
            OnFormClosing(closing);
            if (closing.Cancel == false)
            {
                CancelEventArgs canceling = new CancelEventArgs(false);
                OnClosing(canceling);
                //if (FormClosed != null)
                //    FormClosed(this, new FormClosedEventArgs(CloseReason.UserClosing));
                if (canceling.Cancel == false)
                {
                    OnFormClosed(new FormClosedEventArgs(CloseReason.UserClosing));
                    OnClosed(new EventArgs());
                    self.Destroy(); // 当主窗体关闭时，确保 Application.Exit() 被调用
                    return true;
                }
            }
            //return closing.Cancel == false;
            return false;
        }
        private void ShownControlBoxes()
        {
            if (self.Titlebar is Gtk.HeaderBar titlebar)
            {
                titlebar.DecorationLayout = "menu:close";
                if (_formBorderStyle == FormBorderStyle.FixedToolWindow || _formBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                }
                else
                {
                    if (MaximizeBox == true)
                    {
                        Gtk.Button maximize = new Gtk.Button("window-maximize-symbolic", IconSize.SmallToolbar) { Name = "maximize", Visible = true, Relief = ReliefStyle.None, Valign = Align.Center, Halign = Align.Center };
                        maximize.StyleContext.AddClass("maximize");
                        maximize.StyleContext.AddClass("titlebutton");
                        maximize.Clicked += Maximize_Clicked;
                        titlebar.PackEnd(maximize);
                    }
                    if (MinimizeBox == true)
                    {
                        Gtk.Button minimize = new Gtk.Button("window-minimize-symbolic", IconSize.SmallToolbar) { Name = "minimize", Visible = true, Relief = ReliefStyle.None, Valign = Align.Center, Halign = Align.Center };
                        minimize.StyleContext.AddClass("minimize");
                        minimize.StyleContext.AddClass("titlebutton");
                        minimize.Clicked += Minimize_Clicked;
                        titlebar.PackEnd(minimize);
                    }
                }
            }
            //if (Shown != null)
            //    Shown(this, e);
        }

        //private void Close_Clicked(object sender, EventArgs e)
        //{
        //    self.CloseWindow();
        //}

        private void Maximize_Clicked(object sender, EventArgs e)
        {
            Gtk.Button maximize = (Gtk.Button)sender;
            if (maximize.Name == "restore")
            {
                self.Unmaximize();
                maximize.Image = Gtk.Image.NewFromIconName("window-maximize-symbolic", IconSize.SmallToolbar);
                maximize.Name = "maximize";
            }
            else
            {
                self.Maximize();
                maximize.Image = Gtk.Image.NewFromIconName("window-restore-symbolic", IconSize.SmallToolbar);
                maximize.Name = "restore";
            }
        }

        private void Minimize_Clicked(object sender, EventArgs e)
        {
            self.Iconify();
        }

        public override event ScrollEventHandler Scroll
        {
            add { self.Scroll += value; }
            remove { self.Scroll += value; }
        }
        //private void OnLoad()
        //{
        //    if (Load != null)
        //        Load(this, new EventArgs());
        //}

        public override void Show()
        {
            this.Show(null);
        }
        public void Show(IWin32Window owner)
        {
            if (owner == this)
            {
                throw new InvalidOperationException("OwnsSelfOrOwner");
            }

            if (base.Visible)
            {
                throw new InvalidOperationException("ShowDialogOnVisible");
            }

            if (!base.Enabled)
            {
                throw new InvalidOperationException("ShowDialogOnDisabled");
            }

            if (owner != null && owner is Form parent)
            {
                this.Parent = parent;
                self.SetPosition(WindowPosition.CenterOnParent);
                self.Activate();
            }

            if (self.IsVisible == false)
            {
                if (AutoScroll == true)
                {
                    self.ScrollView.HscrollbarPolicy = PolicyType.Automatic;
                    self.ScrollView.VscrollbarPolicy = PolicyType.Automatic;
                }
                else
                {
                    self.ScrollView.HscrollbarPolicy = PolicyType.Never;
                    self.ScrollView.VscrollbarPolicy = PolicyType.Never;
                }

                //this.FormBorderStyle = this.FormBorderStyle;
                if (this.MaximizeBox == false && this.MinimizeBox == false)
                {
                    self.TypeHint = Gdk.WindowTypeHint.Dialog;
                }
                else if (this.MaximizeBox == false && this.MinimizeBox == true)
                {
                    self.Resizable = false;
                }
                self.Resize(self.DefaultWidth, self.DefaultHeight);

                if (this.WindowState == FormWindowState.Maximized)
                {
                    self.Maximize();
                }
                else if (this.WindowState == FormWindowState.Minimized)
                {
                    self.Iconify();
                }
                try
                {
                    if (this.ShowIcon)
                    {
                        if (this.Icon != null)
                        {
                            if (this.Icon.Pixbuf != null)
                                self.Icon = this.Icon.Pixbuf;
                            else if (this.Icon.PixbufData != null)
                                self.Icon = new Gdk.Pixbuf(this.Icon.PixbufData);
                            else if (this.Icon.FileName != null && System.IO.File.Exists(this.Icon.FileName))
                                self.SetIconFromFile(this.Icon.FileName);
                            else if (this.Icon.FileName != null && System.IO.File.Exists("Resources\\" + this.Icon.FileName))
                                self.SetIconFromFile("Resources\\" + this.Icon.FileName);
                        }
                        Gtk.HeaderBar titlebar = (Gtk.HeaderBar)self.Titlebar;
                        Gtk.Image flag = new Gtk.Image(self.Icon);
                        flag.Visible = true;
                        titlebar.PackStart(flag);
                    }
                    else
                    {
                        self.Icon = new Gdk.Pixbuf(this.GetType().Assembly, "GTKSystem.Windows.Forms.Resources.System.view-more.png");
                    }

                }
                catch
                {

                }

                OnLoad(EventArgs.Empty);
            }
            self.ShowAll();
        }

        public DialogResult ShowDialog()
        {
            return ShowDialog(null);
        }
        public DialogResult ShowDialog(IWin32Window owner)
        {
            if (owner == this)
            {
                throw new ArgumentException("OwnsSelfOrOwner", "showDialog");
            }

            if (base.Visible)
            {
                throw new InvalidOperationException("ShowDialogOnVisible");
            }

            if (!base.Enabled)
            {
                throw new InvalidOperationException("ShowDialogOnDisabled");
            }
            Show(owner);
            // TODO: Setup a flag to disable ESC to close 
            int irun = self.Run();

            return this.DialogResult;
        }

        //public event EventHandler Shown;
        //public event FormClosingEventHandler FormClosing;
        //public event FormClosedEventHandler FormClosed;
        //public override event EventHandler Load;
        public override string Text { get { return self.Title; } set { self.Title = value; } }
        public override Size ClientSize
        {
            get
            {
                return new Size(self.AllocatedWidth, self.AllocatedHeight);
            }
            set
            {
                self.WidthRequest = -1;
                self.HeightRequest = -1;
                self.SetDefaultSize(value.Width, value.Height);
            }
        }
        public SizeF AutoScaleDimensions { get; set; }
        public AutoScaleMode AutoScaleMode { get; set; }
        private FormBorderStyle _formBorderStyle = FormBorderStyle.Sizable;
        public FormBorderStyle FormBorderStyle
        {
            get { return _formBorderStyle; }
            set {
                _formBorderStyle = value;
                self.Resizable = value == FormBorderStyle.Sizable || value == FormBorderStyle.SizableToolWindow;
                if (value == FormBorderStyle.None)
                {
                    self.Decorated = false; //删除工具栏
                }
                else if (value == FormBorderStyle.FixedToolWindow)
                {
                    self.Decorated = true;
                    self.TypeHint = Gdk.WindowTypeHint.Dialog;
                }
                else if (value == FormBorderStyle.SizableToolWindow)
                {
                    self.Decorated = true;
                    self.TypeHint = Gdk.WindowTypeHint.Dialog;
                }
                else
                {
                    self.Decorated = true;
                    self.TypeHint = Gdk.WindowTypeHint.Normal;
                }
            }
        }
        public FormStartPosition StartPosition { get; set; }
        private FormWindowState _windowState = FormWindowState.Normal;
        public FormWindowState WindowState {
            get { 
                return _windowState;
            } 
            set
            {
                _windowState = value;
                if (self.IsMapped)
                {
                    if (value == FormWindowState.Maximized)
                    {
                        self.Maximize();
                    }
                    else if (value == FormWindowState.Minimized)
                    {
                        self.Iconify();
                    }
                    else
                        self.Unmaximize();
                }
            } 
        }
        public DialogResult DialogResult { get; set; }
        public void Close() {
            if (self != null)
            {
                //self.CloseWindow();
                // self.CloseWindow() 不会触发 CloseWindowEvent
                // 改用 Respond 发送关闭消息
                self.Respond(ResponseType.DeleteEvent);
                //// 需要自己处理关闭相应的事件
                //var e1 = new FormClosingEventArgs(CloseReason.UserClosing, false);
                //OnFormClosing(e1);
                //if (e1.Cancel == false)
                //{
                //    var e2 = new CancelEventArgs(false);
                //    OnClosing(e2);
                //    if (e2.Cancel == false)
                //    {
                //        self.CloseWindow();

                //        var e3 = new FormClosedEventArgs(CloseReason.UserClosing);
                //        OnFormClosed(e3);
                //        OnClosed(EventArgs.Empty);

                //        // 对主窗体确保关闭时触发 Application.Exit(null)
                //        Widget.Destroy();
                //    }
                //}
            }
        }
        public override void Hide() => self?.Hide();

        public new ObjectCollection Controls { get { return _ObjectCollection; } }

        public bool MaximizeBox { get; set; } = true;
        public bool MinimizeBox { get; set; } = true;
        public double Opacity { get { return self.Opacity; } set { self.Opacity = value; } }
        public bool ShowIcon { get; set; } = true;
        public bool ShowInTaskbar { get { return self.SkipTaskbarHint == false; } set { self.SkipTaskbarHint = value == false; } }
        public System.Drawing.Icon Icon { get; set; }
        public override void SuspendLayout()
        {
            _Created = false;
        }
        public override void ResumeLayout(bool resume)
        {
            _Created = resume == false;
        }

        public override void PerformLayout()
        {
            _Created = true;
        }
        public bool Activate() => self?.Activate() ?? false;
        public MenuStrip MainMenuStrip { get; set; }

        public override IntPtr Handle => self.Handle;

        public class ObjectCollection : ControlCollection
        {
            Gtk.Container __owner;
            public ObjectCollection(Control control, Gtk.Container owner) : base(control, owner)
            {
                __owner = owner;
            }

        }

        public class MdiLayout
        {
        }

        #region 可重写的保护方法与对应的事件
        public event FormClosingEventHandler FormClosing;
        protected virtual void OnFormClosing(FormClosingEventArgs e) => FormClosing?.Invoke(this, e);
        public event FormClosedEventHandler FormClosed;
        protected virtual void OnFormClosed(FormClosedEventArgs e) => FormClosed?.Invoke(this, e);
        public event CancelEventHandler Closing;
        protected virtual void OnClosing(CancelEventArgs e) => Closing?.Invoke(this, e);
        public event EventHandler Closed;
        protected virtual void OnClosed(EventArgs e) => Closed?.Invoke(this, e);
        public event EventHandler Load;
        protected virtual void OnLoad(EventArgs e) => Load?.Invoke(this, e);
        public event EventHandler Activated;
        protected virtual void OnActivated(EventArgs e) => Activated?.Invoke(this, e);
        public event EventHandler Deactivate;
        protected virtual void OnDeactivate(EventArgs e) => Deactivate?.Invoke(this, e);
        /// <summary>
        /// 窗体首次显示时触发
        /// </summary>
        public event EventHandler Shown;
        protected virtual void OnShown(EventArgs e)=> Shown?.Invoke(this, e);
        #endregion

        #region 隐藏 Form 类不需要的父类方法, 并且不再触发事件
        protected sealed override void OnGotFocus(EventArgs e) { }
        protected sealed override void OnLostFocus(EventArgs e) { }

        public new event EventHandler GotFocus;
        public new event EventHandler LostFocus;
        #endregion

        #region 重写属性
        private Point _location;
        public override Point Location
        {
            get
            {
                Point ret = Point.Empty;
                if (!_bShown)
                    return _location;
                if (self.IsMapped)
                {
                    // Control.Location 始终是 (0,0),
                    // 这里用 Gtk.Window.GetPosition 返回窗口位置
                    self.GetPosition(out int x, out int y);
                    ret = new Point(x, y);
                }
                return ret;
            }
            set
            {
                if (!_bShown)
                    _location = value;
                else if (self.IsMapped)
                    self.Move(value.X, value.Y);
            }
        }
        public override int Left 
        {
            get => this.Location.X;
            set => this.Location = new Point(value, this.Location.Y);
        }

        public override int Top 
        {
            get => this.Location.Y;
            set => this.Location = new Point(this.Location.X, value);
        }

        #endregion
    }

    public class BindingContext : ContextBoundObject
    {
    }
}

