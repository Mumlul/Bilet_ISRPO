using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Task> tasks = new List<Task>();
        int id = 1;

        private void Add_task(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("звполните все поля");
            }
            else
            {
                tasks.Add(new Task(id,textBox1.Text, textBox2.Text, textBox3.Text));
                id++;
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        private void Change_St(object sender, EventArgs e)
        {
            Panel panel=sender as Panel;
            foreach (Task task in tasks)
            {
                if (task.Id.ToString() == panel.Tag.ToString())
                {
                    switch (task.Status)
                    {
                        case "-":
                            task.Status = "+";
                            
                            break;
                        case "+":
                            task.Status = "=";
                            
                            break;
                            
                    }
                }
            }
            
            UTL();

        }


        private void UTL()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            int curY1 = 0;
            int curY2 = 0;
            int curY3 = 0;
            foreach (Task task in tasks)
            {
                switch (task.Status)
                {
                    case "-":
                       
                        int y = 0;
                        Panel panel = new Panel();
                        panel.Tag = task.Id;
                        panel.MouseDoubleClick += Change_St;
                        panel.Size = new Size(panel1.Width, 100);
                        panel.Location = new Point(0, curY1);
                        curY1 += 110;
                        panel.BackColor = Color.Aqua;
                        Label l1 = new Label();
                        l1.Location = new Point(0, y);
                        y += l1.Height;
                        l1.Text = task.Name;
                        Label l2 = new Label();
                        l2.Location = new Point(0, y);
                        y += l2.Height;
                        l2.Text = task.Isp;
                        Label l3 = new Label();
                        l3.Location = new Point(0, y);
                        l3.Text = task.Status;
                        y += l3.Height + 10;
                        panel.Height = y;
                        panel.Controls.Add(l1);
                        panel.Controls.Add(l2);
                        panel.Controls.Add(l3);
                        panel1.Controls.Add(panel);
                        break;
                    case "+":
                       
                        int y_ = 0;
                        Panel panel_ = new Panel();
                        panel_.Size = new Size(panel1.Width,110);
                        panel_.BackColor = Color.Red;
                        panel_.Tag = task.Id;
                        panel_.MouseDoubleClick += Change_St;
                        panel_.Location = new Point(0, curY2);
                        curY2 += 110;
                        Label l1_ = new Label();
                        l1_.Location= new Point(0, y_);
                        y_ += l1_.Height;
                        l1_.Text = task.Name;
                        Label l2_ = new Label();
                        l2_.Location = new Point(0, y_);
                        y_ += l2_.Height;
                        l2_.Text = task.Isp;
                        Label l3_ = new Label();
                        l3_.Text = task.Status;
                        l3_.Location = new Point(0, y_);
                        y_ += l3_.Height;
                        panel_.Controls.Add(l1_);
                        panel_.Controls.Add(l2_);
                        panel_.Controls.Add(l3_);
                        panel2.Controls.Add(panel_);
                        break;
                    case "=":
                       
                        int y__ = 0;
                        Panel panel__ = new Panel();
                        panel__.Size = new Size(panel1.Width, 110);
                        panel__.BackColor = Color.Yellow;
                        panel__.MouseDoubleClick += Change_St;
                        panel__.Location = new Point(0, curY3);
                        curY3 += 110;
                        Label l1__ = new Label();
                        l1__.Location = new Point(0, y__);
                        y__ += l1__.Height;
                        l1__.Text = task.Name;
                        Label l2__ = new Label();
                        l2__.Location = new Point(0, y__);
                        y__ += l2__.Height;
                        l2__.Text = task.Isp;
                        Label l3__ = new Label();
                        l3__.Text = task.Status;
                        l3__.Location = new Point(0, y__);
                        y__ += l3__.Height;
                        panel__.Controls.Add(l1__);
                        panel__.Controls.Add(l2__);
                        panel__.Controls.Add(l3__);
                        panel3.Controls.Add(panel__);
                        break;
                }
            }
        }


        private void Update_task_Lsit(object sender, EventArgs e)
        {
            UTL();
        }
    }
}
