using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace spedytor
{
    static class Program
    {
        static Mutex mutex = new Mutex(false, "Spedytor - emkael.info");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                MessageBox.Show("Spedytor już działa! Może gdzieś w tle?", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
