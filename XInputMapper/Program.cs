using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XInputMapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XController _controller = new XController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _controller.Initialize();
            // Show the system tray icon.					
            using (ProcessIcon pi = new ProcessIcon())
            {
                pi.Display();
                //Start Application
                Application.Run();
            }

            
        }
    }
}
