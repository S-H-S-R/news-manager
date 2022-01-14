using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApplication1
{
    public partial class chart_detail : Form
    {
       

        public chart_detail()
        {
            InitializeComponent();
        }


        public Chart getchart()
        {


            return this.chart2;


        }

        internal List<string> alllegend;


        private void chart_detail_Load(object sender, EventArgs e)
        {
            chart2.ChartAreas[0].AxisY.Maximum = (double)numericUpDown1.Value;
            chart2.Legends[0].Docking = Docking.Bottom;


            DataTable dt = new DataTable();


             dt.Columns.Add("خبرگذاری");
            dt.Columns.Add("درصد");
            dt.Columns.Add("تعداد");
         



            for (int i = 0; i < chart2.Series.Count; i++)
            {
                //  chart2.Series[i].IsVisibleInLegend = true;
               // var v = chart2.Series[i].Points[0];

                //    rep +=alllegend[i] +": " + chart2.Series[i].LegendText + "\r\n";
                //  = "mmmm";

                var dr = dt.NewRow();
                dr[0] = alllegend[i];
                dr[2] = utils.pointsArray[i].ToString();//.Substring(0, 5);
                dr[1] = utils.percentArray[i].ToString().Substring(0, 5);
                dt.Rows.Add(dr); 

               


            }



        
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
           
            //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dataGridView1.Font = new Font("tahoma", 8);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            chart2.ChartAreas[0].AxisY.Maximum = (double)numericUpDown1.Value;

            //  chart2.Legends[0]...LegendStyle = LegendStyle.Column;
            //chart2.Legends[0].

            //chart1.Series["Series1"].LegendText = "Name";
            //chart1.Series["EmptySeries1"].LegendText = "99";
            //chart1.Series["EmptySeries2"].LegendText
            // chart.Series[0].LegendText = "dddddddd";

           
            // richTextBox1.Text = rep;
            //.Alignment = StringAlignment.Far;




        }

        private void chart2_Paint(object sender, PaintEventArgs e)
        {


          


          

        }
    }
}
