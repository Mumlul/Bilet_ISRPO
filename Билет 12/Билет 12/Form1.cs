using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace Билет_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string buffer = "";

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(this.Name+".txt",richTextBox1.Text);
            MessageBox.Show("Файл успешно сохранен");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx)|*.docx|Text and Word Files (*.txt; *.docx)|*.txt;*.docx";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            richTextBox1.Text= System.IO.File.ReadAllText(ofd.FileName);
        }

        private void Counting(object sender, EventArgs e)
        {
            label1.Text = "Кол-во символов:" + richTextBox1.TextLength;
            label2.Text = "Кол-во строк:" + richTextBox1.Lines.Length;
        }

        private void жирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font cur=richTextBox1.SelectionFont;
            if (cur.Style.HasFlag(FontStyle.Bold))
            {
                Font n = new Font(cur.FontFamily, cur.Size, cur.Style & ~FontStyle.Bold);
                richTextBox1.SelectionFont = n;
            }
            else
            {
                Font newFont = new Font(cur.FontFamily, cur.Size, cur.Style | FontStyle.Bold);
                richTextBox1.SelectionFont = newFont;
            }
            
        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font cur = richTextBox1.SelectionFont;
            if (cur.Style.HasFlag(FontStyle.Italic))
            {
                Font n = new Font(cur.FontFamily, cur.Size, cur.Style & ~FontStyle.Italic);
                richTextBox1.SelectionFont = n;
            }
            else
            {
                Font newFont = new Font(cur.FontFamily, cur.Size, cur.Style | FontStyle.Italic);
                richTextBox1.SelectionFont = newFont;
            }
        }

        private void стильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (richTextBox1.SelectedText != null) 
            {
                dlg.Font = richTextBox1.SelectionFont;
            }
            else
            {
                dlg.Font = richTextBox1.Font;
            }
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if(richTextBox1.SelectedText.Length >0)
                {
                    richTextBox1.SelectionFont = dlg.Font;
                }
                else richTextBox1.Font = dlg.Font;
                
            }

        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вставитьКартинкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File (*.png; *.jpg; *.bmp)|*.png;*.jpg;*.bmp";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(ofd.FileName);
                Clipboard.SetImage(image);
                richTextBox1.Paste();
            }
        }
    }
}
