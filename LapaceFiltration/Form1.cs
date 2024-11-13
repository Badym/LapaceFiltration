using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
<<<<<<< HEAD
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
=======
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
>>>>>>> origin/main
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
<<<<<<< HEAD
        static extern int ApplyLaplaceFilter(IntPtr input, IntPtr output, int width, int height, int start, int end);

        private Bitmap selectedBitmap;

        public Form1()
        {
            InitializeComponent();
            trackBar1.ValueChanged += TrackBar1_ValueChanged;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = $"Wybrane wątki: {trackBar1.Value}";
=======
        static extern int ApplyLaplaceFilter(IntPtr input, IntPtr output, int width, int height);
        public Form1()
        {
            InitializeComponent();
>>>>>>> origin/main
        }

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            // Tworzymy dialog do wyboru pliku BMP lub JPEG
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp;*.jpg)|*.bmp;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Wczytujemy obraz jako Bitmap, niezależnie od formatu wejściowego
                selectedBitmap = new Bitmap(openFileDialog.FileName);

                // Wyświetlanie oryginalnego obrazu w PictureBox1
                pictureBox1.Image = selectedBitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
=======
            // Przykład wywołania funkcji DLL w odpowiedzi na kliknięcie przycisku
            int resultASM = MyProc1(5, 3);
            int resultCPP = addingg(5, 3);

            // Wyświetlanie wyników w aplikacji okienkowej (np. w Label)
            label1.Text = $"ASM: {resultASM}, C++: {resultCPP}";
>>>>>>> origin/main
        }

        private void button2_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (selectedBitmap == null)
            {
                MessageBox.Show("Najpierw wybierz obraz za pomocą przycisku Button1.");
                return;
            }

            // Określenie liczby wątków, na których będzie działać filtr
            int numberOfThreads = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();

            // Dodajemy mierzenie czasu
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Przekazujemy bitmapę do funkcji modyfikującej
            Bitmap modifiedBitmap = ModifyImage(selectedBitmap, numberOfThreads);

            // Zatrzymujemy czas
            stopwatch.Stop();

            // Wyświetlanie zmodyfikowanego obrazu w PictureBox2
            pictureBox2.Image = modifiedBitmap;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            label2.Text = $"Czas przetwarzania: {stopwatch.ElapsedMilliseconds} ms";
        }

        public unsafe Bitmap ModifyImage(Bitmap bitmap, int threadCount)
=======
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
>>>>>>> origin/main
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

<<<<<<< HEAD
            // Krok 1: Zablokowanie danych bitmapy i pobranie wskaźników
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;
            int byteCount = stride * height;

            // Utworzenie bufora na dane wejściowe i wyjściowe
            byte[] inputBytes = new byte[byteCount];
            byte[] outputBytes = new byte[byteCount];

            // Skopiowanie danych bitmapy do bufora wejściowego
            Marshal.Copy(bitmapData.Scan0, inputBytes, 0, byteCount);
            bitmap.UnlockBits(bitmapData);

            // Użycie wskaźników do pracy bezpośrednio na pamięci
            fixed (byte* inputPtr = inputBytes)
            fixed (byte* outputPtr = outputBytes)
            {
                IntPtr inputIntPtr = (IntPtr)inputPtr;
                IntPtr outputIntPtr = (IntPtr)outputPtr;

                // Krok 2: Podzielenie przetwarzania na segmenty z użyciem Parallel.For
                int rowsPerThread = height / threadCount;
                int remainingRows = height % threadCount;

                Parallel.For(0, threadCount, i =>
                {
                    int startY = i * rowsPerThread;
                    int endY = (i == threadCount - 1) ? (startY + rowsPerThread + remainingRows) : (startY + rowsPerThread);

                    // Wywołanie funkcji C++ dla każdego segmentu
                    ApplyLaplaceFilter(inputIntPtr, outputIntPtr, width, height, startY, endY);
                });
            }

            // Krok 3: Utworzenie nowej bitmapy i skopiowanie danych wyjściowych do niej
            Bitmap resultBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(outputBytes, 0, resultData.Scan0, byteCount);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
=======
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






>>>>>>> origin/main
    }
}
