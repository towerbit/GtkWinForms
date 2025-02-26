using System.Drawing;
using System.Windows.Forms;

namespace GtkForm
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "运行环境测试程序";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("当前系统可以正常运行测试程序",
                new Font(this.Font.FontFamily, 36),
                new SolidBrush(Color.Blue),
                new Point(100, 230));
        }
    }
}
