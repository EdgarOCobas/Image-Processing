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
using Emgu.CV.Structure;

namespace Projekt_APO_2022
{
    public partial class Edge : Form
    {
        Image<Bgr, byte> _imgInput;
        public Edge()
        {
            InitializeComponent();
        }

        private void SetImage(OpenFileDialog file)
        {
            pictureBox1.Image = new Bitmap(file.OpenFile());
            var newBitmap = new Bitmap(file.FileName);
            pictureBox1.Height = pictureBox1.Image.Height;
            pictureBox1.Width = pictureBox1.Image.Width;
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Obrazy (*.jpg;*.gif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imgInput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = _imgInput.ToBitmap();
                pictureBox1.Height = pictureBox1.Image.Height;
                pictureBox1.Width = pictureBox1.Image.Width;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz wyjść z aplikacji?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_imgInput == null)
            {
                return;
            }
            Image<Gray, byte> imgCanny = new Image<Gray, byte>( _imgInput.Width, _imgInput.Height, new Gray(0));
            imgCanny = _imgInput.Canny(50, 20);
            pictureBox1.Image = imgCanny.ToBitmap();
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_imgInput == null)
            {
                return;
            }
            Image<Gray, byte> imgGray = _imgInput.Convert<Gray, byte>();
            Image<Gray, float> imgSobel = new Image<Gray, float>(_imgInput.Width, _imgInput.Height, new Gray(0));
            imgSobel = imgGray.Sobel(1,1,3);
            pictureBox1.Image = imgSobel.ToBitmap();
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_imgInput == null)
            {
                return;
            }
            Image<Gray, byte> imgGray = _imgInput.Convert<Gray, byte>();
            Image<Gray, float> imgLaplacian = new Image<Gray, float>(_imgInput.Width, _imgInput.Height, new Gray(0));
            imgLaplacian = imgGray.Laplace(3);
            pictureBox1.Image = imgLaplacian.ToBitmap();
        }
    }
}
