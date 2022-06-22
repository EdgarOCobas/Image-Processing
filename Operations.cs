using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Projekt_APO_2022
{
    public partial class Operations : Form
    {

        Image<Bgr, byte> src1;
        Image<Bgr, byte> src2;
        Image file;
        Image file2;
        Bitmap newBitmap;
        Bitmap newBitmap2;
        Mat mat1;
        Mat mat2;

        string filename1;
        string filename2;

        private void loadBtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "Obrazy (*.jpg;*.gif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                file2 = Image.FromFile(dlg.FileName);
                //picBox2.Image = new Bitmap(dlg.OpenFile());
                newBitmap2 = new Bitmap(dlg.FileName);
                src2 = new Image<Bgr, byte>(dlg.FileName);
                picBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                filename2 = dlg.FileName;
            } else
            {
                return;
            }
            mat2 = CvInvoke.Imread(filename2, ImreadModes.Grayscale);
            var result = mat2.ToImage<Bgr, byte>();
            var resultGray = result.Convert<Gray, byte>();
            picBox2.Image = resultGray.ToBitmap();
        }

        public Operations()
        {
            InitializeComponent();
        }

        private void loadBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "Obrazy (*.jpg;*.gif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(dlg.FileName);
                //picBox1.Image = new Bitmap(dlg.OpenFile());
                filename1 = dlg.FileName;
                newBitmap = new Bitmap(dlg.FileName);
                src1 = new Image<Bgr, byte>(dlg.FileName);
                picBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            } else
            {
                return;
            }
            //grayImg1 = src1.Convert<Gray, byte>();
            //Mat mat1 = grayImg1.Copy().Mat;

            mat1 = CvInvoke.Imread(filename1, ImreadModes.Grayscale);
            var result = mat1.ToImage<Bgr, byte>();
            var resultGray = result.Convert<Gray, byte>();
            picBox1.Image = resultGray.ToBitmap();
        }

        private void subtractBtn_Click(object sender, EventArgs e)
        {
            Mat mat3 = new Mat();
            try
            {
                CvInvoke.Add(mat1, mat2, mat3);
                var result = mat3.ToImage<Gray, byte>();
                picBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox3.Image = result.ToBitmap();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void andBtn_Click(object sender, EventArgs e)
        {
            if (picBox1.Image == null || picBox2.Image == null)
            {
                return;
            }
            Mat mat3 = new Mat();
            try
            {
                CvInvoke.BitwiseAnd(mat1, mat2, mat3);
                var result = mat3.ToImage<Gray, byte>();
                picBox3.Image = result.ToBitmap();
                picBox3.SizeMode= PictureBoxSizeMode.StretchImage;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void notBtn_Click(object sender, EventArgs e)
        {
            if (picBox1.Image == null)
            {
                return;
            }
            Mat mat3 = new Mat();
            CvInvoke.BitwiseNot(mat1, mat3);
            var result = mat3.ToImage<Gray, byte>();
            picBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox3.Image = result.ToBitmap();
            
        }

        private void orBtn_Click(object sender, EventArgs e)
        {
            if (picBox1.Image == null || picBox2.Image == null)
            {
                return;
            }
            Mat mat3 = new Mat();
            try
            {
                CvInvoke.BitwiseOr(mat1, mat2, mat3);
                var result = mat3.ToImage<Gray, byte>();
                picBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox3.Image = result.ToBitmap();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xorBtn_Click(object sender, EventArgs e)
        {
            if (picBox1.Image == null || picBox2.Image == null)
            {
                return;
            }
            Mat mat3 = new Mat();
            try
            {
                CvInvoke.BitwiseXor(mat1, mat2, mat3);
                var result = mat3.ToImage<Gray, byte>();
                picBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox3.Image = result.ToBitmap();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void blendBtn_Click(object sender, EventArgs e)
        {
            if (picBox1.Image == null)
            {
                return;
            }
            Mat mat3 = new Mat();
            try
            {
                CvInvoke.AddWeighted(mat1, 0.7, mat2, 0.5, -100, mat3);
                var result = mat3.ToImage<Gray, byte>();
                picBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox3.Image = result.ToBitmap();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*public void LoadOriginalImage(string Img)
        {
            src1 = Cv.LoadImage(Img, LoadMode.Color);
            Cv.SaveImage(Img, src1);
        }

        public void LoadOriginalImage2(string img)
        {
            src2 = Cv.LoadImage(img, LoadMode.Color);
            Cv.SaveImage(img, src2);
        }

        public void convertToGrayScaleImg1()
        {
            grayImg1 = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            Cv.CvtColor(src1, grayImg1, ColorConversion.RgbToGray);
            Cv.SaveImage("gray.jpg", grayImg1);
        }

        public void convertToGrayScaleImg2()
        {
            grayImg2 = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            Cv.CvtColor(src1, grayImg2, ColorConversion.RgbToGray);
            Cv.SaveImage("gray2.jpg", grayImg2);
        }

        public void convertToBitwiseNot()
        {
            tmp = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            convertToGrayScaleImg1();
            Cv.Not(grayImg1, tmp);
            Cv.SaveImage("pic.jpg", tmp);
        }

        public void convertToBitwiseAnd()
        {
            tmp = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            convertToGrayScaleImg1();
            convertToGrayScaleImg2();
            Cv.And(grayImg1, grayImg2, tmp);
            Cv.SaveImage("pic.jpg", tmp);
        }

        public void convertToBitwiseOr()
        {
            tmp = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            convertToGrayScaleImg1();
            convertToGrayScaleImg2();
            Cv.Or(grayImg1, grayImg2, tmp);
            Cv.SaveImage("pic,jpg", tmp);
        }

        public void convertToBitwiseXor()
        {
            tmp = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            convertToGrayScaleImg1();
            convertToGrayScaleImg2();
            Cv.Xor(grayImg1, grayImg2, tmp);
            Cv.SaveImage("pic,jpg", tmp);
        }

        public void blendingImg()
        {
            tmp = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            convertToGrayScaleImg1();
            convertToGrayScaleImg2();
            Cv.AddWeighted(grayImg1, 0.7, grayImg2, 0.3, 0, tmp);
            Cv.SaveImage("pic.jpg", tmp);
        }

        public void subtractLogo()
        {
            tmp = Cv.CreateImage(src1.Size, BitDepth.U8, 1);
            convertToGrayScaleImg1();
            convertToGrayScaleImg2();
            Cv.Or(grayImg1, grayImg2, tmp);
            Cv.SaveImage("pic,jpg", tmp);
        }*/
    }
}
