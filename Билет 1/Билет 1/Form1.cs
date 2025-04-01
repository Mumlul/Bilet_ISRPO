using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Билет_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MySqlConnection conn;

        private string connstrign = "server=127.0.0.1;user=root;password=;database=b1";

        //Выбор офто преподавателя.
        string filename;
        private void Choose_photo(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            filename = ofd.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connstrign);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    Update_dat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_dat()
        {
            try
            {
                string qu = "Select * from pr";

                using (MySqlCommand command = new MySqlCommand(qu,conn))
                {
                    using(MySqlDataAdapter adapter=new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_bd(object sender, EventArgs e)
        {
            Update_dat();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string qu = $"INSERT INTO `pr`(`FIO`, `Dob`, `Adr`, `Tel`, `Photo`, `Predm`, `Grup`, `Class`, `kab`) VALUES ('{textBox1.Text}','{dateTimePicker1.Value.Date.ToShortDateString()}','{textBox2.Text}','{textBox3.Text}','{filename}','{textBox1.Text}','{textBox1.Text}','{textBox1.Text}','{textBox1.Text}')";

                using (MySqlCommand command = new MySqlCommand(qu, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
