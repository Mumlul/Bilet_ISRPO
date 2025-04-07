using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Билет_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string connst = "server=127.0.0.1;user=root;password=;database=auto";
        private MySqlConnection conn;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connst);
            try
            {
                if(conn.State != ConnectionState.Open) 
                    conn.Open();
                string query = "Select * from cars";
                using (MySqlCommand command=new MySqlCommand(query,conn))
                {
                    using (MySqlDataAdapter adapter=new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void показатьХозяинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connst);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string query = $"SELECT client.name,client.adr,cars.name FROM `cars` INNER JOIN client on cars.idc=client.idr WHERE client.idr={dataGridView1.SelectedRows[0].Cells[3].Value?.ToString()};";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = dt;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connst);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string query = $"INSERT INTO `cars`(`name`, `gosn`, `nomer`, `idc`) VALUES ('asd','-','-','1')";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
