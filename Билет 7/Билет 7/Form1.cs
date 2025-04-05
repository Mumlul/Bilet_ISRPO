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

namespace Билет_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conn;

        private string strcon = "server=127.0.0.1;user=root;password=;database=Math";



        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(strcon);
            try
            {
                conn.Open();
                Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Update()
        {
            try
            {
                string query = "Select * from Tasks";
                using (MySqlCommand command=new MySqlCommand(query,conn))
                {
                    using (MySqlDataAdapter adapter=new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = new DataTable();
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Tasks WHERE 1=1 ";

                if ((comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex == 0) &&
                    (comboBox2.SelectedIndex == -1 || comboBox2.SelectedIndex == 0))
                {
                    Update();
                    return;
                }
                if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedIndex != 0)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 1:
                            query += " AND Slozh = 'Легкая'";
                            break;
                        case 2:
                            query += " AND Slozh = 'Средняя'";
                            break;
                        case 3:
                            query += " AND Slozh = 'Сложная'";
                            break;
                        case 4:
                            query += " AND Slozh = 'Невозможная'";
                            break;
                    }
                }
                if (comboBox2.SelectedIndex != -1 && comboBox2.SelectedIndex != 0)
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1:
                            query += " AND Tip = 'Пример'";
                            break;
                        case 2:
                            query += " AND Tip = 'Уравнение'";
                            break;
                        case 3:
                            query += " AND Tip = 'Задача'";
                            break;
                    }
                }
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        
                        if (dataGridView1.DataSource is DataTable dataTable)
                        {
                            dataTable.Clear();
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        string answ = "";

        private void Random_quest(object sender, EventArgs e)
        {
            try
            {
                string query = "Select * from Tasks";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        Random random = new Random();
                        int randomIndex = random.Next(dt.Rows.Count);

                        DataRow randomRow = dt.Rows[randomIndex];

                        label1.Text = randomRow["Body"].ToString();
                        answ= randomRow["Reshenie"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == answ)
            {
                label2.Text = "Молодец";
            }
            else
            {
                label2.Text = "Sorry, ты даун";
            }
        }
    }
}
