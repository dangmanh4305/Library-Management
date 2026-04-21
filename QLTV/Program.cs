using System;
using System.Windows.Forms;

namespace QLTV
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QLTV.Views.Auth.frmLogin());
        }
    }
}