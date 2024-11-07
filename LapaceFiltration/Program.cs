using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaplaceFilter
{
    internal static class Program
    {

        [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAAsm.dll")]

        static extern int MyProc1(int a, int b);

        [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAcpp.dll")]
        static extern int adding(int a, int b);
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
         
        static void Main()
        {


            //int x = 5, y = 3;
            //int retVal = MyProc1(x, y);
            //Console.Write("Moja pierwsza wartość obliczona w asm to:");
            //Console.WriteLine(retVal);
            //Console.ReadLine();
            //int rer = adding(x, y);
            //Console.Write("Moja pierwsza wartość obliczona w c++ to:");
            //Console.WriteLine(rer);
            //Console.ReadLine();


            // Ustawienia dla aplikacji okienkowej
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Uruchomienie okna głównego (Form1)
            Application.Run(new Form1());
        }
    }
}
