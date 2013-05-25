using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Runner
{
    static class Program
    {
        public static int f = 0;
        public static int Poeni=0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
