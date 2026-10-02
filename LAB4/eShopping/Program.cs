using System;
using System.Windows.Forms;
using eShopping.Forms;
using eShopping.Tests;

namespace eShopping
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0 && args[0] == "--selftest")
            {
                MessageBox.Show(SelfTest.Run(), "e-SHOPPING self-test");
                return;
            }
            Application.Run(new FrmMain());
        }
    }
}
