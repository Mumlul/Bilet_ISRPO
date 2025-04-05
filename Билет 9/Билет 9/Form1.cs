using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Билет_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string old = openFileDialog.FileName;
            string text=File.ReadAllText(openFileDialog.FileName);
            string[] new_=old.Split('.');
            string all = "";
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                case 0:
                    all += new_[0]+" new" + ".txt";
                    break;
                case 1:
                    all += new_[0] + " new" + ".docx";
                    break;
                case 2:
                    all += new_[0] + " new" + ".pdf";
                    break;


            }
            System.IO.File.WriteAllText(all, text, System.Text.Encoding.UTF8);
            //Файл создается но не нельзя открыть
        }
    }
}
