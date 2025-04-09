using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Билет_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable rawDataTable = new DataTable("RawData");
            rawDataTable.Columns.Add("Маршрут", typeof(string));
            rawDataTable.Columns.Add("Расстояние", typeof(double));
            rawDataTable.Columns.Add("Время", typeof(int));
            rawDataTable.Columns.Add("Стоимость", typeof(double));
            rawDataTable.Columns.Add("Загруженность", typeof(int));

            rawDataTable.Rows.Add("A", 50, 60, 500, 40);
            rawDataTable.Rows.Add("B", 70, 90, 600, 60);
            rawDataTable.Rows.Add("C", 60, 70, 550, 50);

            dataGridView2.DataSource = rawDataTable;
            dataGridView1.Rows.Add("Растояние",0.3, "Нормализованное расстояние(меньше лучше)");
            dataGridView1.Rows.Add("Время доставки", 0.3, "Нормализованное время доставки (меньше лучше)");
            dataGridView1.Rows.Add("Стоимость доставки", 0.2, "Нормализованная стоимость доставки (меньше лучше)");
            dataGridView1.Rows.Add("Загруженность дороги", 0.1, "Уровень загруженности дороги (меньше лучше)");
            double w1 = 0.3;
            double w2 = 0.3;
            double w3 = 0.2;
            double w4 = 0.1;

            DataTable dt = dataGridView2.DataSource as DataTable;
            double maxDistance = Convert.ToDouble(dt.Compute("MAX(Расстояние)", ""));
            int maxTime = Convert.ToInt32(dt.Compute("MAX(Время)", ""));
            double maxCost = Convert.ToDouble(dt.Compute("MAX(Стоимость)", ""));
            int maxCongestion = Convert.ToInt32(dt.Compute("MAX(Загруженность)", ""));
            foreach (DataRow row in dt.Rows)
            {
                string route = row["Маршрут"].ToString();
                double distanceNorm = 1 - (double)row["Расстояние"] / maxDistance;
                double timeNorm = 1 - (int)row["Время"] / maxTime;
                double costNorm = 1 - (double)row["Стоимость"] / maxCost;
                double congestionNorm = 1 - (int)row["Загруженность"] / maxCongestion;
                double ob= distanceNorm*w1 + timeNorm*w2 + costNorm*w3+congestionNorm*w4;
                dataGridView3.Rows.Add(route, distanceNorm, timeNorm, costNorm, congestionNorm, ob);
                
            }
        }

        
    }
}
