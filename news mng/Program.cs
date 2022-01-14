using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
       static void merge()
        {

            var dbnames = File.ReadAllLines("list.txt");
            foreach (string n in dbnames)
            {

                var f = n.Trim();
                if (f == "") continue;
                string connectionString = "Data Source = \"" + f + "\"; ";
                SQLiteConnection con = new SQLiteConnection(connectionString);
                con.Open();

                string queryString = "SELECT * FROM news";

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(queryString, con);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);




                foreach (DataRow r in ds.Tables[0].Rows)
                {


                    string SQLString = @"INSERT INTO news (source, bestar, titr,  mehvar,matn, yearr,monthh,  dayy,sehat,takmil) VALUES('" + r.ItemArray[0].ToString() + "','" + r.ItemArray[1] + "','" + r.ItemArray[2] + "','" + r.ItemArray[3] + "','" + r.ItemArray[4] + "','" + r.ItemArray[5] + "','" + r.ItemArray[6] + "','" + r.ItemArray[7] + "','" + r.ItemArray[8] + "','" + r.ItemArray[9] + "')";

                    var cmd = new SQLiteCommand(SQLString, utils.con);

                    cmd.ExecuteScalar();

                }


                con.Close();
            }


        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            
                utils.con.Open();

            //    merge();
              //  MessageBox.Show("خطا در اتصال به پایگاه داده");

             Application.Run(new mainform());

            //  merge();
            // MessageBox.Show(new reportform);

        }
    }
}
