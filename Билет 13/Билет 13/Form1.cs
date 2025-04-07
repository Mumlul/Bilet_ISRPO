using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "") 
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите первое действие");
                    return; 
                }
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите второе действие");
                    return; 
                }
                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double c = Convert.ToDouble(textBox3.Text);
                if (a == 0)
                {
                    MessageBox.Show("Коэффициент a не может быть равен 0");
                    return;
                }
                double disk = Math.Pow(b, 2) - (4 * a * c);
                if (disk < 0) label1.Text = "Корней нет";
                else if (disk == 0) label1.Text = $"x1,2={(b*-1)/(2*a)}";
                else label1.Text = $"x1={(b * -1+Math.Sqrt(disk)) / (2 * a)}\nx2={(b * -1 - Math.Sqrt(disk)) / (2 * a)}\n{disk}";
            }
            else
            {
                MessageBox.Show("Введите все переменные");
            }
        }

        private void Proverka(object sender, EventArgs e)
        {
            try
            {
                if (sender is TextBox tt)
                {
                    string res = "";
                    if (tt != null) 
                    {
                        if (tt.Text[0] == '-') res += '-';
                        foreach (char ch in tt.Text)
                        {
                            if (char.IsDigit(ch))
                            {
                                res += ch;
                            }
                        }
                        tt.Text = res;
                    }
                    
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
