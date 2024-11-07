using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaplaceFilter
{
    public partial class Form1 : Form
    {
        [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAAsm.dll")]
        static extern int MyProc1(int a, int b);

        [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAcpp.dll")]
        static extern int addingg(int a, int b);

        [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAcpp.dll")]
        static extern int ApplyLaplaceFilter(IntPtr input, IntPtr output, int width, int height);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Przykład wywołania funkcji DLL w odpowiedzi na kliknięcie przycisku
            int resultASM = MyProc1(5, 3);
            int resultCPP = addingg(5, 3);

            // Wyświetlanie wyników w aplikacji okienkowej (np. w Label)
            label1.Text = $"ASM: {resultASM}, C++: {resultCPP}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tworzymy dialog do wyboru pliku BMP
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Wczytujemy obraz jako Bitmap
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);

                // Wyświetlanie oryginalnego obrazu w PictureBox1
                pictureBox1.Image = bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                // Przekazujemy bitmapę do funkcji modyfikującej
                Bitmap modifiedBitmap = ModifyImage(bitmap);

                // Wyświetlanie zmodyfikowanego obrazu w PictureBox2
                pictureBox2.Image = modifiedBitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private Bitmap ModifyImage(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            Bitmap modifiedBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            // Blokowanie dostępu do danych obrazu
            BitmapData bmpDataOriginal = bitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData bmpDataModified = modifiedBitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            // Uzyskaj wskaźniki na dane pikseli
            IntPtr ptrOriginal = bmpDataOriginal.Scan0;
            IntPtr ptrModified = bmpDataModified.Scan0;

            // Wywołaj funkcję w C++ (Laplace)
            ApplyLaplaceFilter(ptrOriginal, ptrModified, width, height);

            // Odblokowanie bitmap
            bitmap.UnlockBits(bmpDataOriginal);
            modifiedBitmap.UnlockBits(bmpDataModified);

            return modifiedBitmap;
        }






    }
}
