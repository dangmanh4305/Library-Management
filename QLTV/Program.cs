using LibraryManagement.UI.Views.Librarian;
using QLTV.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new frmQuanLyMuonTra());
=======
            Application.Run(new frmLogin());
>>>>>>> 808357d7c9c26c6a6fc0bd4d501e34cbc394e30d
        }
    }
}
