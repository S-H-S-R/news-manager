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
    public partial class allcharts  : Form
    {
      

        public allcharts()
        {
            InitializeComponent();
        }






        public Chart getmanbachart()
        {

            return chart1;



        }

     
        public Chart getbestarchart()
        {

            return chart2;



        }
        public Chart getmehvarchart()
        {

            return chart3;



        }

        public Chart getsehatchart()
        {

            return chart4;



        }
        private void allcharts_Load(object sender, EventArgs e)
        {

        }




        internal string quer_sources;

        //enlarge
        private void chart1_Click(object sender, EventArgs e)
        {
            chart_detail chrtdtl = new chart_detail();
             
           var legends= utils.draw(quer_sources, chrtdtl.getchart(), 20, 80,"500");

            chrtdtl.alllegend = legends;

            chrtdtl.Show();

        }










    }
}

