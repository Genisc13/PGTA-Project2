using System;
using System.Windows.Forms;

namespace ProyectoPGTA_P2
{
    //Comentario
    static class Program
    {
        /// <summary>
        /// Entry point of the aplication, it opens the Form1()
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
