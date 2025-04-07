using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        char[] digits = Enumerable.Range('0', 10).Select(i => (char)i).ToArray();
        char[] allEnglishLetters = Alphabet('A', 26).Concat(Alphabet('a', 26)).ToArray();
        char[] specialChars = Enumerable.Range('!', 47 - 33 + 1)
                .Concat(Enumerable.Range(':', 64 - 58 + 1))
                .Concat(Enumerable.Range('[', 96 - 91 + 1))
                .Concat(Enumerable.Range('{', 126 - 123 + 1))
                .Select(i => (char)i)
                .ToArray();
        
        private void Generate(object sender, EventArgs e)
        {
            char[] allChars = digits.Concat(allEnglishLetters).Concat(specialChars).ToArray();
            Random random = new Random();
            string password;
            do
            {
                password = new string(Enumerable.Repeat(allChars, Convert.ToInt32(numericUpDown1.Value))
                .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (!PR(password, textBox1.Text));
            label1.Text = password;


        }

        private bool PR(string tt,string log)
        {
            if (!string.IsNullOrEmpty(log) && tt == log) return false;
            if (!UL(tt)) return false;
            if (!LD(tt)) return false;

            return true;
        }
        private bool UL(string tt)
        {
            bool fl1 = false;
            bool fl2 = false;
            foreach (char c in tt) 
            { 
                if(char.IsUpper(c)) fl1 = true;
                if (char.IsLower(c)) fl2 = true ;
                if(fl1 && fl2) return true;
            }
            return false;
        }
        private bool LD(string tt)
        {
            foreach (char c in tt)
            {
                if(!char.IsLetterOrDigit(c)) return true;
            }
            return false;
        }

        public static char[] Alphabet(int startCode, int count)
        {
            return Enumerable.Range(startCode, count).Select(i => (char)i).ToArray();
        }


    }
}
