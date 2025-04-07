using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int number = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Rndn();
        }

        private void Rndn()
        {
            Random rnd = new Random();
            number = rnd.Next(0, 101);
            MessageBox.Show(number.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) < number) MessageBox.Show("Больше");
            else if (Convert.ToInt32(textBox1.Text) > number) MessageBox.Show("Меньше");
            else
            {
                MessageBox.Show("Победа");
                DialogResult result = MessageBox.Show(
                    "Начнем заново?",
                    "Выбери",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Начали");
                    Rndn();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void OnlyDigit(object sender, EventArgs e)
        {
            if (sender is TextBox tt)
            {
                string result = "";
                foreach (char ch in tt.Text)
                {
                    if (char.IsDigit(ch)) result += ch;
                }
                textBox1.Text = result;
            }
        }
        

    }
}
