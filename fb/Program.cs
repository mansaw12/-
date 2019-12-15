using System;
using System.Windows.Forms;

namespace fb
{
    internal static class Program
    {
        [STAThread]
        [Obsolete]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form)new Form1());
        }
    }
}
