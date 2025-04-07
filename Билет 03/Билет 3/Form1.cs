using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string,int> Currency=new Dictionary<string, int>() { {"Dollar",90 },{"Euro",120 },{"Yan",11 } };

        private void button1_Click(object sender, EventArgs e)
        {
            int start=0, end=0;
            if (Currency.ContainsKey(comboBox1.SelectedItem.ToString()))
            {
                start = Currency[comboBox1.SelectedItem.ToString()];
                if (Currency.ContainsKey(comboBox2.SelectedItem.ToString()))
                {
                    end = Currency[comboBox2.SelectedItem.ToString()];
                    int rubls = Convert.ToInt32(numericUpDown1.Value) * start;
                    numericUpDown2.Value = rubls / end;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls) 
            {
                if (control is ComboBox cb) {
                    foreach(string kk in Currency.Keys)
                    {
                        cb.Items.Add(kk);
                    }
                }
            }
        }
    }
}
