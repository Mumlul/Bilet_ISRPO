using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Pen green = new Pen(Color.Green);
        Pen v = new Pen(Color.Black);
        Pen redPen = new Pen(Color.Red);
        Timer timer = new Timer();

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            timer.Interval = 100;
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        int co = 0;
        bool pr = true;
        //true-left false-right
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
          
            g.Clear(Color.White);
            g.DrawRectangle(green, this.Width / 2 - 2, this.Height / 2 - 2, Convert.ToInt32(numericUpDown1.Value) * 2, Convert.ToInt32(numericUpDown1.Value) + 4);
            int coords = this.Width / 2 + co;
            g.DrawEllipse(redPen, coords, this.Height / 2, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value));
            if (coords == this.Width / 2)
                pr=true;
            else if (coords == (this.Width / 2)+(numericUpDown1.Value)) pr=false;
            if (pr == true) co += 5;
            else co -= 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
