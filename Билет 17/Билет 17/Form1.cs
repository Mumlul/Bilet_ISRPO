using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap imgnew;
        string ss = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ss = openFileDialog.FileName;
            pictureBox1.Image=Image.FromFile(ss);
        }

        private void MLGMOMENT(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    imgnew = new Bitmap(ss);
                    for (int i = 0; i < imgnew.Width; i++)
                    {
                        for (int j = 0; j < imgnew.Height; j++)
                        {
                            Color pi=imgnew.GetPixel(i, j);
                            int grey = (int)(pi.R * 0.33+ pi.B * 0.33+pi.G * 0.33);
                            imgnew.SetPixel(i, j, Color.FromArgb(grey, grey, grey));
                        }
                    }
                    pictureBox1.Image = imgnew;
                    break;
                case 1:
                    imgnew = new Bitmap(ss);
                    for (int i = 0; i < imgnew.Width; i++)
                    {
                        for (int j = 0; j < imgnew.Height; j++)
                        {
                            Color pi = imgnew.GetPixel(i, j);
                            imgnew.SetPixel(i, j, Color.FromArgb(255-pi.R, 255 - pi.G, 255 - pi.B));
                        }
                    }
                    pictureBox1.Image = imgnew;
                    break;
                case 2:
                    break;
                case 3:
                    imgnew = new Bitmap(ss);
                    for (int i = 0; i < imgnew.Width; i++)
                    {
                        for (int j = 0; j < imgnew.Height; j++)
                        {
                            Color pi = imgnew.GetPixel(i, j);
                            imgnew.SetPixel(i, j, Color.FromArgb((int)(pi.R*0.3), (int)(pi.G * 0.3), (int)(pi.B * 0.3)));
                        }
                    }
                    pictureBox1.Image = imgnew;
                    break;
            }
        }
    }
}
