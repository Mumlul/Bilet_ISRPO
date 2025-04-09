using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        string[] words = new string[] { "пидорасина","воробей","кукушка","марар","тетрогидрат","поровоз" };
        string[] net = new string[] { "Учись сука", "Боже нулевый бот", "Ебать тебя как девочку раздеваю", "Пошел нахуй отсюда тупое животное", "Ебать ты лох" };
        string word = "";
        int lives = 0;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            string rl = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            char[] rla = rl.ToCharArray();
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Clear(); 
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));
            }
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Clear(); 
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6));
            }
            int cou = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (cou < 32)
                    {
                        Button button = new Button();
                        button.Name = (cou - 1).ToString();
                        button.Text = rla[cou].ToString() ;
                        button.Dock = DockStyle.Fill;
                        button.Tag = rla[cou].ToString();
                        button.Click += Pr;
                        tableLayoutPanel1.Controls.Add(button,j,i);
                        cou++;   
                    }
                    else break;

                }
            }
            Random rnd = new Random();
            word = words[rnd.Next(0, 5)];
            lives = word.Length;
            label1.Text = "Жизней:"+lives.ToString();
            /*label2.Text = word;*/
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.ColumnCount = lives;
            tableLayoutPanel2.CellBorderStyle= TableLayoutPanelCellBorderStyle.Single;

            tableLayoutPanel2.ColumnStyles.Clear();

            for (int i = 0; i < lives; i++)
            {
                tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / lives));
            }

            for (int i = 0; i < lives; i++)
            {
                Label label = new Label();
                label.ForeColor = Color.White;
                label.Text= word[i].ToString();
                tableLayoutPanel2.Controls.Add(label, i, 1);
            }

            TableLayoutControlCollection controls = tableLayoutPanel2.Controls;
            
        }

        private void Pr(object sender, EventArgs e)
        {
            
            Button bt =sender as Button;
            Random rnd = new Random();
            if (!word.Contains(bt.Tag.ToString()))
            {

                MessageBox.Show(net[rnd.Next(0,5)]);
                lives--;
                label1.Text = "Жизней:" + lives.ToString();
                if (lives == 0) {this.Close(); return; }
            }
            else
            {
                TableLayoutControlCollection controls = tableLayoutPanel2.Controls;
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i] is Label l1)
                    {
                        if (l1.Text == bt.Tag.ToString())
                        {
                            l1.ForeColor=Color.Black;
                        }
                    }
                }
            }
            bt.Enabled = false;
            bool allLettersFound = true;
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                if (control is Label l1 && l1.ForeColor == Color.White)
                {
                    allLettersFound = false;
                    break;
                }
            }

            if (allLettersFound)
            {
                MessageBox.Show("Поздравляю! Ты угадал слово!");
            }
        }
    }
}
