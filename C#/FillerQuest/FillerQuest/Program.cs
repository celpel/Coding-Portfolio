using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WelcomeScreen w = new WelcomeScreen();
            w.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(w);
        }
    }
}
