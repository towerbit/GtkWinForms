using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GtkForm
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
#if GTKFORM
            int major = (int)Gtk.Global.MajorVersion;
            int minor = (int)Gtk.Global.MinorVersion;
            int micro = (int)Gtk.Global.MicroVersion;
            // 输出 GTK 版本
            Console.WriteLine($"GTK Runtime Version: {major}.{minor}.{micro}");

            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
