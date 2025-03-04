// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using GLib;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Gtk;

namespace System.Windows.Forms
{
    public class TreeNode: ICloneable, ISerializable, IEquatable<TreeNode>
    {
        //格式，各级索引并集：0,1,2,3....
        private string index = "";
        public string Index { get { return index; } internal set { index = value ?? ""; } }
        internal Gtk.TreeIter TreeIter = Gtk.TreeIter.Zero;
        private TreeNode _parent;
        private TreeView _treeView;
        public TreeView TreeView 
        {
            get
            {
                if (_treeView == null)
                {
                    _treeView = _parent?.TreeView;
                }
                return _treeView;
            }
            set => _treeView = value;
        }

        private TreeNodeCollection nodes;
        public TreeNode()
        {
            nodes = new TreeNodeCollection(this);
        }
        public TreeNode(string text) : this()
        {
            Text = text;
        }
        public TreeNode(string text, TreeNode[] children) : this()
        {
            Text = text;
            Nodes.AddRange(children);
        }
        public TreeNode(TreeView view) : this()
        {
            _treeView = view;
        }
        public TreeNode(TreeNode node) : this()
        {
            this._parent = node;
            _treeView = node.TreeView;
        }
        public TreeNode(string text, int pImageIndex, int pSelectedImageIndex) : this(text)
        {
            ImageIndex = pImageIndex;
            SelectedImageIndex = pSelectedImageIndex;
        }

        public TreeNodeCollection Nodes
        {
            get
            {
                return nodes;
            }
        }

        public TreeNode Parent
        {
            get
            {
                if (this.TreeView != null && _parent == this.TreeView.root)
                {
                    return null;
                }
                return _parent;
            }
            internal set { _parent = value; }
        }
        private string _text;
        public string Text
        {
            get=>_text;
            set {
                _text = value;
                TreeView?.NativeNodeText(this, value);
            }
        }


        public string ToolTipText
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
        private bool _IsChecked;
        public bool Checked
        {
            //get => _IsChecked; set { _IsChecked = value; TreeView?.SetChecked(this, value); }
            get => _IsChecked; set { _IsChecked = value; TreeView?.NativeNodeChecked(this, value); }
        }

        // 这是上游代码的实现
        //public string FullPath
        //{
        //    get
        //    {
        //        List<string> paths = new List<string>();
        //        GetFullPath(this, paths);
        //        return string.Join("/", paths);
        //    }
        //    set { }
        //}
        //protected void GetFullPath(TreeNode node, List<string> paths)
        //{
        //    paths.Add(node.Text);
        //    if (node.Parent != null && node.Parent.index != "-1")
        //    {
        //        GetFullPath(node.Parent, paths);
        //    }
        //}
        public string FullPath
        {
            get
            {
                string path = this.Text; 
                if (this.TreeView != null)
                {
                    // 注意：this.Text 中尽量不要使用 TreeView.PathSeparator 字符
                    path = string.Format("{0}{1}{2}", Parent?.FullPath ?? "", this.TreeView.PathSeparator, this.Text);
                    // 移除根分隔符，与 WinForms.TreeView.Node.FullPath 输出保持一致
                    if (path.StartsWith(this.TreeView.PathSeparator))
                        path = path.Substring(1);
                }
                return path;
            }
        }
        private bool _IsSelected = false;
        public bool IsSelected
        {
            get=> _IsSelected; 
            set { 
                _IsSelected = value;
                //TreeView?.SetSelected(this, value);
                TreeView?.NativeNodeSelected(this, value); 
            }
        }
        public bool IsExpanded
        {
            get
            {
                return TreeView?.GetNodeExpanded(this) == true;
            }
        }

        public int Level
        {
            get
            {
                if (_parent == null)
                    return 0;
                else if (TreeView != null && _parent.Equals(TreeView.root))
                    return 0;
                else
                    return _parent.Level + 1;
            }
        }
        private int _imageIndex;
        public int ImageIndex { 
            get=>_imageIndex; 
            set { _imageIndex = value; TreeView?.NativeNodeImage(this, value); }
        }
        private string _imageKey;
        public string ImageKey { 
            get => _imageKey; 
            set { _imageKey = value; TreeView?.NativeNodeImage(this, value); }
        }
        public int SelectedImageIndex { get; set; }
        public string SelectedImageKey { get; set; }
        public int StateImageIndex { get; set; }
        public string StateImageKey { get; set; }
        public object Tag { get; set; }

        public void Expand(){
            TreeView?.SetExpandNode(this, false);
        }
        public void ExpandAll()
        {
            TreeView?.SetExpandNode(this, true);
        }
        public void Collapse()
        {
            TreeView?.SetCollapseNode(this);
        }
        public void Remove()
        {
            TreeView?.RemoveNode(this);
        }
        public object Clone()
        {
            return null;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //throw new NotImplementedException();
        }

        public bool Equals([AllowNull] TreeNode other)
        {
            return other != null && other.Index == this.Index && other.Name == this.Name && other.Text == this.Text && other.Level == this.Level;
        }
    }
}