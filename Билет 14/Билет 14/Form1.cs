using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Poverk(object sender, EventArgs e)
        {
            if (All(textBox2.Text, textBox1.Text)) MessageBox.Show("Все отлично");
            else MessageBox.Show("Исправляй даун");
        }

        private bool All(string tt, string log)
        {
            if (!Osn(tt, log)) return false; 
            if (!Upper(tt)) return false;   
            if (!Digit(tt)) return false;   
            if (!Spsm(tt)) return false;    

            return true;
        }
        private bool Upper(string tt)
        {
            bool fl1=false;
            bool fl2 = false;
            foreach (char ch in tt)
            {
                if (char.IsUpper(ch)) fl1 = true;
                if (char.IsLower(ch)) fl2 = true;
                if (fl1 && fl2) return true;
            }
            return false;
        }

        private bool Digit(string tt)
        {
            foreach (char ch in tt)
            {
                if (char.IsDigit(ch)) return true;
            }
            return false;
        }

        private bool Spsm(string tt)
        {
            foreach (char ch in tt)
            {
                if (!char.IsLetterOrDigit(ch)) return true;
            }
            return false;
        }

        private bool Osn(string tt,string log)
        {
            if(string.IsNullOrEmpty(tt)) return false;
            if (tt != log && tt.Length > 8) return true;
            return false;
        }
    }
}
