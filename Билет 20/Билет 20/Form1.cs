using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        bool dot = false; 

        private void Proverka(object sender, EventArgs e)
        {
            TextBox tt = sender as TextBox;
            if (tt == null) return; 
            string res = "";
            bool newDot = false; 
            foreach (char ch in tt.Text)
            {
                if (ch == '.' && !newDot) 
                {
                    res += ch;
                    newDot = true; 
                }
                else if (char.IsDigit(ch)) 
                {
                    res += ch;
                }
            }
            dot = newDot;
            if (tt.Text != res)
            {
                tt.Text = res;
                tt.SelectionStart = tt.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==-1&&comboBox2.SelectedIndex==-1)
            {
                MessageBox.Show("Даун выбери велечину");
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == ".")
            {
                MessageBox.Show("Даун введи велечину");
                return;
            }
            double[] factors = { 10, 1, 0.01, 0.00001 }; 
            double baseValue = Convert.ToDouble(textBox1.Text) / factors[comboBox1.SelectedIndex];
            textBox2.Text= (baseValue * factors[comboBox2.SelectedIndex]).ToString();




        }
    }
}
