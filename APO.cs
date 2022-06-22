using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using AForge.Imaging.Filters;

namespace Projekt_APO_2022
{
    public partial class APO : Form
    {
        public int[] red = null;
        public int[] green = null;
        public int[] blue = null;
        bool opened = false;

        Image<Bgr, byte> imgInput;
        Image file;
        Bitmap newBitmap;
        public APO()
        {
            InitializeComponent();
        }

        private void zachowajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void otToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "Obrazy (*.jpg;*.gif;*tif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp;*tif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(dlg.FileName);
                imageBox.Image = new Bitmap(dlg.OpenFile());
                newBitmap = new Bitmap(dlg.FileName);
                opened = true;
                imgInput = new Image<Bgr, byte>(dlg.FileName);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDlg = new SaveFileDialog();
            sDlg.Title = "Zapisz obraz jako";
            sDlg.Filter = "Obrazy (*.jpg;*.gif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp";
            if (sDlg.ShowDialog() == DialogResult.OK)
            {
                if (opened)
                {
                    if (sDlg.FileName.Substring(sDlg.FileName.Length - 3).ToLower() == "bmp")
                    {
                        imageBox.Image.Save(sDlg.FileName, ImageFormat.Bmp);
                    }

                    if (sDlg.FileName.Substring(sDlg.FileName.Length - 3).ToLower() == "jpg")
                    {
                        imageBox.Image.Save(sDlg.FileName, ImageFormat.Jpeg);
                    }

                    if (sDlg.FileName.Substring(sDlg.FileName.Length - 3).ToLower() == "png")
                    {
                        imageBox.Image.Save(sDlg.FileName, ImageFormat.Png);
                    }

                    if (sDlg.FileName.Substring(sDlg.FileName.Length - 3).ToLower() == "gif")
                    {
                        imageBox.Image.Save(sDlg.FileName, ImageFormat.Gif);
                    }

                } else
                {
                    MessageBox.Show("Otwórz najpierw plik");
                }
            }
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < newBitmap.Width; ++x)
            {
                for (int y = 0; y < newBitmap.Height; ++y)
                {
                    Color originalColor = newBitmap.GetPixel(x, y);

                    int greyscale = (int)((originalColor.R * .3) + (originalColor.G * .59) + (originalColor.B * .11));
                    Color newColor = Color.FromArgb(greyscale, greyscale, greyscale);

                    newBitmap.SetPixel(x, y, newColor);
                }
            }
            imageBox.Image = newBitmap;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 1; x < newBitmap.Width-1; x++)
            {
                for (int y = 1; y < newBitmap.Height-1; y++)
                {
                    try
                    {
                        Color prevX = newBitmap.GetPixel(x - 1, y);
                        Color nextX = newBitmap.GetPixel(x + 1, y);
                        Color prevY = newBitmap.GetPixel(x, y - 1);
                        Color nextY = newBitmap.GetPixel(x, y + 1);
                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4);
                        int avgB = (int)((prevX.B + nextX.B + prevY.B + nextY.B) / 4);

                        newBitmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }
            }
            imageBox.Image = newBitmap;
        }

        private int[] calculateLUT(int[] values)
        {
            // Wartosc minimalna
            int minValue = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (values[i] != 0)
                {
                    minValue = i;
                    break;
                }
            }

            //Wartosc maksymalna
            int maxValue = 255;
            for (int i = 255; i >= 0; i--)
            {
                if (values[i] != 0)
                {
                    maxValue = i;
                    break;
                }
            }

            // Tablica

            int[] result = new int[256];
            double a = 255.0 / (maxValue - minValue);
            for (int i = 0; i < 256; i++)
            {
                result[i] = (int)(a * (i - minValue));
            }
            return result;
        }

        // Equalizacja histogramu



        // Gaussian Blur
        public static double[,] GaussianBlur(int length, double weight)
        {
            double[,] kernel = new double[length, length];
            double kernelSum = 0;
            int foff = (length - 1) / 2;
            double distance = 0;
            double constant = 1d / (2 * Math.PI * weight * weight);
            for (int y = -foff; y <= foff; y++)
            {
                for (int x = -foff; x <= foff; x++)
                {
                    distance = ((y * y) + (x * x)) / (2 * weight * weight);
                    kernel[y + foff, x + foff] = constant * Math.Exp(-distance);
                    kernelSum += kernel[y + foff, x + foff];
                }
            }
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    kernel[y, x] = kernel[y, x] * 1d / kernelSum;
                }
            }
            return kernel;
        }

        public static Bitmap Convolve(Bitmap srcImage, double[,] kernel)
        {
            int width = srcImage.Width;
            int height = srcImage.Height;
            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = srcData.Stride * srcData.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);
            srcImage.UnlockBits(srcData);
            int colorChannels = 3;
            double[] rgb = new double[colorChannels];
            int foff = (kernel.GetLength(0) - 1) / 2;
            int kcenter = 0;
            int kpixel = 0;
            for (int y = foff; y < height - foff; y++)
            {
                for (int x = foff; x < width - foff; x++)
                {
                    for (int c = 0; c < colorChannels; c++)
                    {
                        rgb[c] = 0.0;
                    }
                    kcenter = y * srcData.Stride + x * 4;
                    for (int fy = -foff; fy <= foff; fy++)
                    {
                        for (int fx = -foff; fx <= foff; fx++)
                        {
                            kpixel = kcenter + fy * srcData.Stride + fx * 4;
                            for (int c = 0; c < colorChannels; c++)
                            {
                                rgb[c] += (double)(buffer[kpixel + c]) * kernel[fy + foff, fx + foff];
                            }
                        }
                    }
                    for (int c = 0; c < colorChannels; c++)
                    {
                        if (rgb[c] > 255)
                        {
                            rgb[c] = 255;
                        }
                        else if (rgb[c] < 0)
                        {
                            rgb[c] = 0;
                        }
                    }
                    for (int c = 0; c < colorChannels; c++)
                    {
                        result[kcenter + c] = (byte)rgb[c];
                    }
                    result[kcenter + 3] = 255;
                }
            }
            Bitmap resultImage = new Bitmap(width, height);
            BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, resultData.Scan0, bytes);
            resultImage.UnlockBits(resultData);
            return resultImage;
        }

        private void rozciaganieHistogramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var histForm = new Histogram();
            var histogramChart = histForm.histChart;
            red = new int[256];
            green = new int[256];
            blue = new int[256];

            for (int x = 0; x < imageBox.Image.Width; ++x)
            {
                for (int y = 0; y < imageBox.Image.Height; ++y)
                {
                    Color pixel = ((Bitmap)imageBox.Image).GetPixel(x, y);
                    red[pixel.R]++;
                    green[pixel.G]++;
                    blue[pixel.B]++;
                }
            }

            histogramChart.Series["red"].Points.Clear();
            histogramChart.Series["green"].Points.Clear();
            histogramChart.Series["blue"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                histogramChart.Series["red"].Points.AddXY(i, red[i]);
                histogramChart.Series["green"].Points.AddXY(i, green[i]);
                histogramChart.Series["blue"].Points.AddXY(i, blue[i]);
            }
            histogramChart.Invalidate();
            histForm.Show();
        }

        private void rozciaganieHistogramuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (red == null)
            {
                return;
            }

            // Tablica LUT

            int[] LUTred = calculateLUT(red);
            int[] LUTgreen = calculateLUT(green);
            int[] LUTblue = calculateLUT(blue);

            // Nowy histogram

            red = new int[256];
            green = new int[256];
            blue = new int[256];
            Bitmap oldBitmap = (Bitmap)imageBox.Image;
            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height, PixelFormat.Format24bppRgb);
            for (int x = 0; x < imageBox.Image.Width; ++x)
            {
                for (int y = 0; y < imageBox.Image.Height; ++y)
                {
                    Color pixel = oldBitmap.GetPixel(x, y);
                    Color newPixel = Color.FromArgb(LUTred[pixel.R], LUTgreen[pixel.G], LUTblue[pixel.B]);
                    newBitmap.SetPixel(x, y, newPixel);
                    red[newPixel.R]++;
                    green[newPixel.G]++;
                    blue[newPixel.B]++;
                }
            }
            imageBox.Image = newBitmap;

            var histForm = new Histogram();
            var histogramChart = histForm.histChart;

            histogramChart.Series["red"].Points.Clear();
            histogramChart.Series["green"].Points.Clear();
            histogramChart.Series["blue"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                histogramChart.Series["red"].Points.AddXY(i, red[i]);
                histogramChart.Series["green"].Points.AddXY(i, green[i]);
                histogramChart.Series["blue"].Points.AddXY(i, blue[i]);
            }
            histogramChart.Invalidate();
            histForm.Show();
            file = imageBox.Image;
        }

        private void gaussianblurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var kernel = GaussianBlur(3, 1);
            imageBox.Image = Convolve((Bitmap)imageBox.Image, kernel);
        }

        public static Bitmap Negate(Bitmap image)
        {
            var image1 = image;

            int x, y;

            // Loop through the images pixels to reset color.
            for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0xff - pixelColor.R
                    , 0xff - pixelColor.G, 0xff - pixelColor.B);
                    image1.SetPixel(x, y, newColor);
                }
            }
            return image1;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = Negate((Bitmap)imageBox.Image);
        }
        public static Bitmap GlobalThresholding(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            //Getting threshold intensity value
            int[] converted = buffer.Select(x => (int)x).ToArray();
            int init = converted.Sum() / bytes;
            int delta = 1;

            while (delta > 0)
            {
                int[] histogram = new int[255];
                for (int i = 0; i < bytes; i += 3)
                {
                    histogram[buffer[i]]++;
                }

                int mean1 = 0;
                int mean2 = 0;
                int sum1 = 0;
                int sum2 = 0;

                for (int i = 0; i < 255; i++)
                {
                    if (i <= init)
                    {
                        mean1 += histogram[i] * i;
                        sum1 += histogram[i];
                    }
                    else
                    {
                        mean2 += histogram[i] * i;
                        sum2 += histogram[i];
                    }
                }

                mean1 /= sum1;
                mean2 /= sum2;
                delta = init;
                init = (mean1 + mean2) / 2;
                delta = Math.Abs(delta - init);
            }

            //Thresholding
            for (int i = 0; i < bytes; i++)
            {
                result[i] = (byte)(buffer[i] >= init ? 255 : 0);
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }


        private void edgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var edge = new Edge();
            edge.Show();
        }

        private void operatonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bitwise = new Operations();
            bitwise.Show();
        }

        
        public static Bitmap MedianFilter(Bitmap sourceBitmap,
                                            int matrixSize,
                                              int bias = 0,
                                    bool grayscale = false)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];


            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            if (grayscale == true)
            {
                float rgb = 0;


                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }


            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;


            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;


            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;


                    neighbourPixels.Clear();


                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {


                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                (filterY * sourceData.Stride);


                            neighbourPixels.Add(BitConverter.ToInt32(
                                             pixelBuffer, calcOffset));
                        }
                    }


                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(
                                       neighbourPixels[filterOffset]);


                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);


            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);


            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);


            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }

        public static Bitmap VariableThresholdingLocalProperties(Bitmap image, double a, double b)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            //Get global mean - this works only for grayscale images
            double mg = 0;
            for (int i = 0; i < bytes; i += 3)
            {
                mg += buffer[i];
            }
            mg /= (w * h);

            for (int x = 1; x < w - 1; x++)
            {
                for (int y = 1; y < h - 1; y++)
                {
                    int position = x * 3 + y * image_data.Stride;
                    double[] histogram = new double[256];

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nposition = position + i * 3 + j * image_data.Stride;
                            histogram[buffer[nposition]]++;
                        }
                    }

                    histogram = histogram.Select(l => l / (w * h)).ToArray();

                    double mean = 0;
                    for (int i = 0; i < 256; i++)
                    {
                        mean += i * histogram[i];
                    }

                    double std = 0;
                    for (int i = 0; i < 256; i++)
                    {
                        std += Math.Pow(i - mean, 2) * histogram[i];
                    }
                    std = Math.Sqrt(std);

                    double threshold = a * std + b * mg;
                    for (int c = 0; c < 3; c++)
                    {
                        result[position + c] = (byte)((buffer[position] > threshold) ? 255 : 0);
                    }
                }
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = MedianFilter((Bitmap)imageBox.Image, 3, 0, false);
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = MedianFilter((Bitmap)imageBox.Image, 5, 0, false);
        }

        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = MedianFilter((Bitmap)imageBox.Image, 7, 0, false);
        }

        private void thresholdingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imageBox.Image = GlobalThresholding((Bitmap)imageBox.Image);
        }

        private void adaptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = VariableThresholdingLocalProperties((Bitmap)imageBox.Image, 0, 1);
        }

        public static Bitmap OtsuThresholding(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            //Get histogram values
            double[] histogram = new double[256];
            for (int i = 0; i < bytes; i += 3)
            {
                histogram[buffer[i]]++;
            }

            //Normalize histogram
            histogram = histogram.Select(x => (x / (w * h))).ToArray();

            //Global mean
            double mg = 0;
            for (int i = 0; i < 255; i++)
            {
                mg += i * histogram[i];
            }

            //Get max between-class variance
            double bcv = 0;
            int threshold = 0;
            for (int i = 0; i < 256; i++)
            {
                double cs = 0;
                double m = 0;
                for (int j = 0; j < i; j++)
                {
                    cs += histogram[j];
                    m += j * histogram[j];
                }

                if (cs == 0)
                {
                    continue;
                }

                double old_bcv = bcv;
                bcv = Math.Max(bcv, Math.Pow(mg * cs - m, 2) / (cs * (1 - cs)));

                if (bcv > old_bcv)
                {
                    threshold = i;
                }
            }

            for (int i = 0; i < bytes; i++)
            {
                result[i] = (byte)((buffer[i] > threshold) ? 255 : 0);
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }



        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = OtsuThresholding((Bitmap)imageBox.Image);
        }

        private void watershedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (imageBox.Image == null) return;

                var img = new Bitmap(imageBox.Image)
                    .ToImage<Bgr, byte>();
                var mask = img.Convert<Gray, byte>()
                    .ThresholdBinaryInv(new Gray(150), new Gray(255));
                Mat distanceTransform = new Mat();
                CvInvoke.DistanceTransform(mask, distanceTransform, null, Emgu.CV.CvEnum.DistType.L2, 3);
                CvInvoke.Normalize(distanceTransform, distanceTransform, 0, 255, Emgu.CV.CvEnum.NormType.MinMax);
                var markers = distanceTransform.ToImage<Gray, byte>()
                    .ThresholdBinary(new Gray(50), new Gray(255));
                CvInvoke.ConnectedComponents(markers, markers);
                var finalMarkers = markers.Convert<Gray, Int32>();

                CvInvoke.Watershed(img, finalMarkers);

                Image<Gray, byte> boundaries = finalMarkers.Convert<byte>(delegate (Int32 x)
                {
                    return (byte)(x == -1 ? 255 : 0);
                });

                boundaries._Dilate(1);
                img.SetValue(new Bgr(0, 255, 0), boundaries);

                imageBox.Image = markers.ToBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            Watershed();
        }
        public void Watershed()
        {
            if (imageBox.Image == null) return;

            Bitmap bmpRef = (Bitmap)imageBox.Image;
            Bitmap sourceBitmap = (Bitmap)bmpRef.Clone();

            Image<Bgr, byte> img = sourceBitmap.ToImage<Bgr, byte>();
            var mask = img.Convert<Gray, byte>()
                   .ThresholdBinaryInv(new Gray(150), new Gray(255));
            Mat distanceTransofrm = new Mat();
            CvInvoke.DistanceTransform(mask, distanceTransofrm, null, Emgu.CV.CvEnum.DistType.L2, 3);
            CvInvoke.Normalize(distanceTransofrm, distanceTransofrm, 0, 255, Emgu.CV.CvEnum.NormType.MinMax);
            var markers = distanceTransofrm.ToImage<Gray, byte>()
                .ThresholdBinary(new Gray(50), new Gray(255));
            CvInvoke.ConnectedComponents(markers, markers);
            var finalMarkers = markers.Convert<Gray, Int32>();

            CvInvoke.Watershed(img, finalMarkers);

            Image<Gray, byte> boundaries = finalMarkers.Convert<byte>(delegate (Int32 x)
            {
                return (byte)(x == -1 ? 255 : 0);
            });

            boundaries._Dilate(1);
            img.SetValue(new Bgr(0, 255, 0), boundaries);
            imageBox.Image = img.ToBitmap();
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            imageBox.Image = imgInput.Erode(1).ToBitmap();
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            //var grayImginput = imgInput.Convert<Gray, byte>();
            imageBox.Image = imgInput.Dilate(1).ToBitmap();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5,5), new Point(-1, -1));
            imageBox.Image = imgInput.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Open, kernel,new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0)).ToBitmap();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
            imageBox.Image = imgInput.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0)).ToBitmap();
        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
            imageBox.Image = imgInput.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Gradient, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0)).ToBitmap();
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
            imageBox.Image = imgInput.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Tophat, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0)).ToBitmap();
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null) return;
            Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
            imageBox.Image = imgInput.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Blackhat, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0)).ToBitmap();
        }

        private int[] calculateLUT(int[] values, int size)
        {
            //poszukaj wartości minimalnej - czyli pierwszej niezerowej wartosci dystrybuanty
            double minValue = 0;
            for (int i = 0; i < 256; i++)
            {
                if (values[i] != 0)
                {
                    minValue = values[i];
                    break;
                }
            }

            //przygotuj tablice zgodnie ze wzorem
            int[] result = new int[256];
            double sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += values[i];
                result[i] = (int)(((sum - minValue) / (size - minValue)) * 255.0);
            }

            return result;
        }

        private void wyrownanieHistogramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (red == null)
            {
                return;
            }

            //Tablice LUT dla skladowych
            int[] LUTred = calculateLUT(red, imageBox.Image.Width * imageBox.Image.Height);
            int[] LUTgreen = calculateLUT(green, imageBox.Image.Width * imageBox.Image.Height);
            int[] LUTblue = calculateLUT(blue, imageBox.Image.Width * imageBox.Image.Height);

            //Przetworz obraz i oblicz nowy histogram
            red = new int[256];
            green = new int[256];
            blue = new int[256];
            Bitmap oldBitmap = (Bitmap)imageBox.Image;
            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height, PixelFormat.Format24bppRgb);
            for (int x = 0; x < imageBox.Image.Width; x++)
            {
                for (int y = 0; y < imageBox.Image.Height; y++)
                {
                    Color pixel = oldBitmap.GetPixel(x, y);
                    Color newPixel = Color.FromArgb(LUTred[pixel.R], LUTgreen[pixel.G], LUTblue[pixel.B]);
                    newBitmap.SetPixel(x, y, newPixel);
                    red[newPixel.R]++;
                    green[newPixel.G]++;
                    blue[newPixel.B]++;
                }
            }
            imageBox.Image = newBitmap;

            var histForm = new Histogram();
            var histogramChart = histForm.histChart;

            histogramChart.Series["red"].Points.Clear();
            histogramChart.Series["green"].Points.Clear();
            histogramChart.Series["blue"].Points.Clear();
            
            for (int i = 0; i < 256; i++)
            {
                histogramChart.Series["red"].Points.AddXY(i, red[i]);
                histogramChart.Series["green"].Points.AddXY(i, green[i]);
                histogramChart.Series["blue"].Points.AddXY(i, blue[i]);
            }
            histogramChart.Invalidate();
            histForm.Show();
        }
        public static Bitmap sharpen(Bitmap image)
        {
            Bitmap sharpenImage = new Bitmap(image.Width, image.Height);

            int filterWidth = 3;
            int filterHeight = 3;
            int w = image.Width;
            int h = image.Height;

            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;

            double factor = 1.0;
            double bias = 0.0;

            Color[,] result = new Color[image.Width, image.Height];

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    
                    // Color must be read per filter entry, not per image pixel.
                    Color imageColor = image.GetPixel(x, y);
                    

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + w) % w;
                            int imageY = (y - filterHeight / 2 + filterY + h) % h;

                            
                            Color imageColorr = image.GetPixel(imageX, imageY);
                            

                            red += imageColorr.R * filter[filterX, filterY];
                            green += imageColorr.G * filter[filterX, filterY];
                            blue += imageColorr.B * filter[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    sharpenImage.SetPixel(i, j, result[i, j]);
                }
            }
            return sharpenImage;
        }

        private void imageSharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = sharpen((Bitmap)imageBox.Image);
            imageBox.Image = result;
        }

        private void reduceGrayLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void PosterizeImage()
        {
            if (imageBox.Image == null) return;
            Bitmap bmpRef = (Bitmap)imageBox.Image;
            Bitmap bmp = (Bitmap)bmpRef.Clone();

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pix = bmp.GetPixel(i, j);
                    int red = pix.R;
                    int green = pix.G;
                    int blue = pix.B;

                    if (red <= 63 && red >= 0)
                    {
                        red = 32;

                    }
                    else if (red <= 127 && red >= 64)
                    {
                        red = 96;
                    }

                    else if (red <= 191 && red >= 128)
                    {
                        red = 160;
                    }
                    else
                    {
                        red = 224;
                    }

                    if (green <= 63 && green >= 0)
                    {
                        green = 32;
                    }
                    else if (green <= 127 && green >= 64)
                    {
                        green = 96;
                    }
                    else if (green <= 191 && green >= 128)
                    {
                        green = 160;
                    }
                    else
                    {
                        green = 224;
                    }

                    if (blue <= 63 && blue >= 0)
                    {
                        blue = 32;
                    }
                    else if (blue <= 127 && blue >= 64)
                    {
                        blue = 96;
                    }
                    else if (blue <= 191 && blue >= 128)
                    {
                        blue = 160;
                    }
                    else
                    {
                        blue = 224;
                    }
                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
            imageBox.Image = bmp;
        }

        private Bitmap CorrectPixelFormat(Bitmap image)
        {
            Bitmap originalBmp = image;

            // Create a blank bitmap with the same dimensions
            Bitmap tempBitmap = new Bitmap(originalBmp.Width, originalBmp.Height);

            // From this bitmap, the graphics can be obtained, because it has the right PixelFormat
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                g.DrawImage(originalBmp, 0, 0);
            }

            // Use tempBitmap as you would have used originalBmp
            return tempBitmap;
        }
        private void posteryzacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PosterizeImage();
        }

        private void skeletonizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = Skeletonize((Bitmap)imageBox.Image);
            imageBox.Image = result;
        }
        public static Bitmap Skeletonize(Bitmap image)
        {
            Image<Gray, byte> imgOld = image.ToImage<Gray, byte>();
            Image<Gray, byte> img2 = (new Image<Gray, byte>(imgOld.Width, imgOld.Height, new Gray(255))).Sub(imgOld);
            Image<Gray, byte> eroded = new Image<Gray, byte>(img2.Size);
            Image<Gray, byte> temp = new Image<Gray, byte>(img2.Size);
            Image<Gray, byte> skel = new Image<Gray, byte>(img2.Size);
            skel.SetValue(0);
            CvInvoke.Threshold(img2, img2, 127, 256, 0);
            var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(3, 3), new Point(-1, -1));
            bool done = false;

            while (!done)
            {
                CvInvoke.Erode(img2, eroded, element, new Point(-1, -1), 1, BorderType.Reflect, default(MCvScalar));
                CvInvoke.Dilate(eroded, temp, element, new Point(-1, -1), 1, BorderType.Reflect, default(MCvScalar));
                CvInvoke.Subtract(img2, temp, temp);
                CvInvoke.BitwiseOr(skel, temp, skel);
                eroded.CopyTo(img2);
                if (CvInvoke.CountNonZero(img2) == 0) done = true;
            }
            return skel.ToBitmap();
        }
        public static Bitmap HysteresisThreshold(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            //Get normalized histogram
            double[] histogram = new double[256];
            for (int i = 0; i < bytes; i += 3)
            {
                histogram[buffer[i]]++;
            }
            histogram = histogram.Select(x => x / (w * h)).ToArray();

            //Get global mean
            double mg = 0;
            for (int i = 0; i < 256; i++)
            {
                mg += histogram[i] * i;
            }

            int[] thresholds = new int[2];
            double bcv = 0;
            for (int i = 1; i < 254; i++)
            {
                double cs1 = 0;
                double m1 = 0;
                for (int j = 0; j < i; j++)
                {
                    cs1 += histogram[j];
                    m1 += j * histogram[j];
                }
                m1 /= cs1;

                for (int j = i + 1; j < 253; j++)
                {
                    double cs2 = 0;
                    double m2 = 0;
                    for (int k = i; k < j; k++)
                    {
                        cs2 += histogram[k];
                        m2 += k * histogram[k];
                    }
                    m2 /= cs2;

                    double new_bcv = cs1 * Math.Pow(m1 - mg, 2) + cs2 * Math.Pow(m2 - mg, 2);
                    if (new_bcv > bcv)
                    {
                        bcv = new_bcv;
                        thresholds[0] = i;
                        thresholds[1] = j;
                    }
                }
            }

            for (int i = 0; i < bytes; i++)
            {
                if (buffer[i] < thresholds[0])
                {
                    result[i] = 0;
                }

                else if (buffer[i] >= thresholds[0] && buffer[i] < thresholds[1])
                {
                    result[i] = 128;
                }

                else if (buffer[i] > thresholds[1])
                {
                    result[i] = 255;
                }
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }

        private void multilevelThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = HysteresisThreshold((Bitmap)imageBox.Image);
            imageBox.Image = result;
        }

        private void previttToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var kernelN = new int[3,3] { { 1, 1, 1 }, { 1, -2, 1 }, { -1, -1, -1 } };
            var kernelS = new int[3,3] { { -1, -1, -1 }, { 1, -2, 1 }, { 1, 1, 1 } };
            var kernelW = new int[3,3] { { 1, 1, -1 }, { 1, -2, -1 }, { 1, 1, -1 } };
            var kernelE = new int[3,3] { { -1, 1, 1 }, { -1, -2, 1 }, { -1, 1, 1 } };
        }
    }

}