using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GtkForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOpenDialog_Click(object sender, System.EventArgs e)
        {
            using (var f = new Form())
                f.ShowDialog();
        }
    }
}
