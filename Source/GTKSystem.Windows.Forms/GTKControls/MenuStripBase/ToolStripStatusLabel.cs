
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{

	public class ToolStripStatusLabel : ToolStripLabel
	{
        public ToolStripStatusLabel() : base() { }

		public ToolStripStatusLabel(string text) : base(text) { }

		public ToolStripStatusLabel(string text, Image image) : base(text, image) { }

		public ToolStripStatusLabel(string text, Image image, EventHandler onClick) : base(text, image, onClick) { }

		public ToolStripStatusLabel(string text, Image image, EventHandler onClick, string name) : base(text, image, onClick, name) { }
		

        [DefaultValue(Border3DStyle.Flat)]
        public Border3DStyle BorderStyle { get; set; }

        [DefaultValue(ToolStripStatusLabelBorderSides.None)]
        public ToolStripStatusLabelBorderSides BorderSides { get; set; }

        [DefaultValue(false)]
        public bool Spring { get; set; }
    }
}
