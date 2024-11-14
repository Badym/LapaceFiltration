using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LaplaceFilter
{
    public partial class Form1 : Form
    {
    #if DEBUG
            [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAAsm.dll")]
    #else
            [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Release\\JAAsm.dll")]
    #endif
            static extern void ApplyLaplaceFilterAsm(IntPtr input, IntPtr output, int width, int height, int start, int end);

    #if DEBUG
            [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAcpp.dll")]
            #else
                    [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Release\\JAcpp.dll")]
            #endif
                    static extern int addingg(int a, int b);

            #if DEBUG
                    [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Debug\\JAcpp.dll")]
            #else
                    [DllImport("C:\\Users\\badim\\Desktop\\lapaceFiltration\\LapaceFiltration\\x64\\Release\\JAcpp.dll")]
            #endif
                    static extern void ApplyLaplaceFilter(IntPtr input, IntPtr output, int width, int height, int start, int end);


        private Bitmap selectedBitmap;
        private readonly int[] allowedValues = { 1, 2, 3, 4, 6, 8, 16, 32, 64 };

        public Form1()
        {
            InitializeComponent();
            trackBar1.ValueChanged += TrackBar1_ValueChanged;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            int newValue = FindClosestAllowedValue(trackBar1.Value);
            if (trackBar1.Value != newValue)
            {
                trackBar1.Value = newValue;
            }
            label3.Text = $"Wybrane wątki: {trackBar1.Value}";
        }

        private int FindClosestAllowedValue(int value)
        {
            return allowedValues.OrderBy(v => Math.Abs(v - value)).First();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp;*.jpg)|*.bmp;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedBitmap = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = selectedBitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedBitmap == null)
            {
                MessageBox.Show("Najpierw wybierz obraz za pomocą przycisku Button1.");
                return;
            }

            int numberOfThreads = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                Bitmap modifiedBitmap = ModifyImage(selectedBitmap, numberOfThreads);
                pictureBox2.Image = modifiedBitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                label2.Text = $"Czas przetwarzania: {stopwatch.ElapsedMilliseconds} ms";
        }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        public unsafe Bitmap ModifyImage(Bitmap bitmap, int threadCount)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;
            int byteCount = stride * height;

            byte[] inputBytes = new byte[byteCount];
            byte[] outputBytes = new byte[byteCount];

            Marshal.Copy(bitmapData.Scan0, inputBytes, 0, byteCount);
            bitmap.UnlockBits(bitmapData);

            fixed (byte* inputPtr = inputBytes)
            fixed (byte* outputPtr = outputBytes)
            {
                IntPtr inputIntPtr = (IntPtr)inputPtr;
                IntPtr outputIntPtr = (IntPtr)outputPtr;

                int rowsPerThread = height / threadCount;
                int remainingRows = height % threadCount;
                if (asmCheckBox.Checked)
                {
                    ApplyLaplaceFilterAsm(inputIntPtr, outputIntPtr, width, height, 0, 0); // Przykładowe wywołanie funkcji assemblerowej
                }
                else
                {
                    Parallel.For(0, threadCount, i =>
                    {
                        int startY = i * rowsPerThread;
                        int endY = (i == threadCount - 1) ? (startY + rowsPerThread + remainingRows) : (startY + rowsPerThread);

                        ApplyLaplaceFilter(inputIntPtr, outputIntPtr, width, height, startY, endY);

                    });
                }

            }

            Bitmap resultBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(outputBytes, 0, resultData.Scan0, byteCount);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private void asmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (asmCheckBox.Checked)
            {
                cppCheckBox.Checked = false;
            }
        }

        private void cppCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cppCheckBox.Checked)
            {
                asmCheckBox.Checked = false;
            }
        }
    }
}
