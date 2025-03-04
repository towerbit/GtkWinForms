﻿/*
 * 基于GTK组件开发，兼容原生C#控件winform界面的跨平台界面组件。
 * 使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows、linux、macos运行
 * 技术支持438865652@qq.com，https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 * author:chenhongjin
 */
using GTKSystem.Windows.Forms.GTKControls.ControlBase;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    [DesignerCategory("Component")]
    public partial class LinkLabel: Control
    {
        public readonly LinkLabelBase self = new LinkLabelBase();
        public override object GtkControl => self;
        public LinkLabel():base()
        {
            self.Clicked += LinkLabel_Click;
            self.ActivateLink += LinkLabel_ActivateLink;
        }

        private void LinkLabel_ActivateLink(object o, Gtk.ActivateLinkArgs args)
        {
            if (LinkClicked != null)
            {
                LinkClicked(this, new LinkLabelLinkClickedEventArgs(new Link() { Description = self.Label, LinkData = self.Uri }));
            }
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("LinkLabel_Click");
            if (Click != null)
            {
                Click(this, e);
            }
        }
        public override event EventHandler Click;
        public override string Text { get { return string.IsNullOrEmpty(self.Label)? self.Uri : self.Label; } set { self.Label = value; self.Uri = value; } }
        public override RightToLeft RightToLeft { get { return self.Direction == Gtk.TextDirection.Rtl ? RightToLeft.Yes : RightToLeft.No; } set { self.Direction = value == RightToLeft.Yes ? Gtk.TextDirection.Rtl : Gtk.TextDirection.Ltr; } }
        private System.Drawing.ContentAlignment textAlign;
        public System.Drawing.ContentAlignment TextAlign
        {
            get { return textAlign; }
            set
            {
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


        public event LinkLabelLinkClickedEventHandler LinkClicked;

        public bool LinkVisited { get; set; }

        public LinkCollection Links { get; }

        public Color LinkColor { get; set; }


        //public LinkBehavior LinkBehavior { get; set; }

        //public LinkArea LinkArea { get; set; }

        public FlatStyle FlatStyle { get; set; }


        public Color DisabledLinkColor { get; set; }

        public Color ActiveLinkColor { get; set; }

        public Color VisitedLinkColor { get; set; }
        public bool UseCompatibleTextRendering { get; set; }


        public class Link
        {
            public Link()
            {
            }

            public Link(int start, int length)
            {

            }

            public Link(int start, int length, object linkData)
            {

            }
            public string Description { get; set; }
            [DefaultValue(null)]
            public object LinkData { get; set; }
        }
        public class LinkCollection : IList
        {
            private readonly LinkLabel owner;
            private bool linksAdded = false;   
            private int lastAccessedIndex = -1;

            public LinkCollection(LinkLabel owner)
            {
                this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            }

            public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool IsFixedSize => throw new NotImplementedException();

            public bool IsReadOnly => throw new NotImplementedException();

            public int Count => throw new NotImplementedException();

            public bool IsSynchronized => throw new NotImplementedException();

            public object SyncRoot => throw new NotImplementedException();

            public int Add(object value)
            {
                if(value is Label)
                {
                    owner.Text = ((Label)value).Text;
                }
                else
                {
                    owner.Text = value?.ToString();
                }
                return 1;
            }

            public void Clear()
            {
                owner.Text = "";
            }

            public bool Contains(object value)
            {
                return owner.Text.Contains(value.ToString());
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(object value)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public void Remove(object value)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }
        }
    }
}
