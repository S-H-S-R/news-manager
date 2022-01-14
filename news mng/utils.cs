using System;
using System.Collections.Generic;
using System.Data.OleDb;

using System.Linq;
using System.Text;

using System.Windows.Forms.DataVisualization.Charting;


using System.Data.SQLite;
using System.Drawing;
using System.Data;

namespace WindowsFormsApplication1
{
  

    class utils
    {
        public static List<string> seriesArray = new List<string>();
        public static List<double> pointsArray = new List<double>();
       public static List<double> percentArray = new List<double>();

        // static string  connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +  "db.mdb" + ";Jet OLEDB:Database Password=uaredb1132;";


        static string connectionString = "Data Source = all.db; ";



        public static SQLiteConnection con = new SQLiteConnection(connectionString);

        public static bool validatephone(string number)
        {
            bool isn = true;
            char[] arr = number.ToCharArray();
            foreach (char ch in arr)
                if (!char.IsDigit(ch))
                    isn = false;




            if (number.Length != 11)
                isn = false;







            return isn;
        }

         

        public static List<string>   draw(string querygroupby, Chart chart, int YAxisMaximum, float fontsize, string barwidth)
        {
            seriesArray.Clear();
            pointsArray.Clear();
            percentArray.Clear();

            var queryString = querygroupby;
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(queryString, utils.con);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            chart.Series.Clear();
            chart.Titles.Clear();

            





            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                seriesArray.Add(dr[0].ToString());
                int temp; int.TryParse(dr[1].ToString(), out temp);
                pointsArray.Add(temp);

            }

            seriesArray = seriesArray.Select(x => x.Replace("false", "نادرست")).ToList();
            seriesArray = seriesArray.Select(x => x.Replace("true", "صحیح")).ToList();
            //  seriesArray = seriesArray.Select(x => x.Replace(string.Empty, "نامعلوم")).ToList();


            //chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            //chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            //chart.ChartAreas[0].AxisX.IntervalOffset = 50;
          //  chart.ChartAreas[0].AxisX.poi = 50;

          //  chart.ChartAreas[0].AxisX. = 50;

            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{00.00} %";
            chart.ChartAreas[0].AxisY.LabelStyle.Interval = 10;
            chart.ChartAreas[0].AxisY.Maximum = YAxisMaximum;


            chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;

            //chart.Legends.Clear();
            //  chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            //chartArea1.AxisY.LabelStyle.Interval = 10;      //Label the axis every #
            //chartArea1.AxisY.MajorGrid.Interval = 5;        //Grid line every #
            //  chart.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
            //chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            //chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
          
            chart.ChartAreas[0].AxisX.Interval = 1;





            var total = pointsArray.Sum(x => x);
            for (int i = 0; i < pointsArray.Count; i++)
            {
                percentArray.Add((pointsArray[i] * 100.0) / total);

            }




            // Set palette
            chart.Palette = ChartColorPalette.EarthTones;

            // Set title
            //  chart.Titles.Add(column);

            // Add series.
            for (int i = 0; i < seriesArray.Count; i++)
            {
                Series series = chart.Series.Add(seriesArray[i]);
               // series["MinPixelPointWidth"] = "80";
                series.IsVisibleInLegend = true;
                series.XAxisType = AxisType.Primary;
                //  series.Points.AddXY(pointsArray[i]);

                series.Font = new Font("tahoma", fontsize); //changes nothing
                series.Points.Add(pointsArray[i]);

              
                chart.Series[i]["MinPixelPointWidth"] = barwidth;
                //chart.Series[i]["PixelPointWidth"] = "100";
              
             


            }


            return seriesArray;

        }

         


        public static bool validateprice (string number)
        {

            if (number == "")
                return false;



            bool isn = true;
            char[] arr = number.ToCharArray();
            foreach (char ch in arr)
                if (!char.IsDigit(ch))
                    isn = false;
              
            return isn;
        }





    }
}
