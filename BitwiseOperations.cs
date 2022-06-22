using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Projekt_APO_2022
{
    public class BitwiseOperations
    {
        IplImage src1, src2;
        IplImage grayImg1, grayImg2;
        IplImage tmp;

        public void LoadOriginalImage(string Img)
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
        }
    }
}
