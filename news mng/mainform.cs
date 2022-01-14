using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace WindowsFormsApplication1
{

    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }


        private void reportform_Load(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)button3.Image;
            bm.MakeTransparent(bm.GetPixel(0, 0));

            Bitmap bm2 = (Bitmap)button2.Image;
            bm2.MakeTransparent(bm2.GetPixel(0, 0));


            Bitmap bm1 = (Bitmap)button1.Image;
            bm1.MakeTransparent(bm1.GetPixel(0, 0));


            Bitmap bm4 = (Bitmap)button4.Image;
            bm4.MakeTransparent(bm4.GetPixel(0, 0));



            Bitmap bm6 = (Bitmap)button6.Image;
            bm6.MakeTransparent(bm6.GetPixel(0, 0));


            label1.AutoSize = false;
            label1.Height = 2;
            label1.Width = this.Width;
            label1.BorderStyle = BorderStyle.Fixed3D;

            find();
          //  merge();


        }


        void merge()
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

        //delete
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;


            DialogResult r = MessageBox.Show("آیا می خواهید حذف کنید؟", "هشدار", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count <= 0) return;
                

                try
                {

                     string SQLString = " DELETE FROM newss WHERE id = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
 

                     SQLiteCommand SQLCommand = new SQLiteCommand(SQLString, utils.con);
                     SQLCommand.ExecuteNonQuery();



                    //MessageBox.Show("رکورد حذف شد");



                }
                catch
                {

                    MessageBox.Show("خطا در حذف رکورد");
                } 

            }
        }
          





    


        //search
        private void button3_Click(object sender, EventArgs e)
        {


           
          
            find();


        }

          

        void find()
        {



            dataGridView1.DataSource = null;

            //if (textBox1.Text != "")
            //    queryString += "AND sehat='" + checkBox1.Checked + "' ";



            var queryString = userControl11.getQuerySimilarString();

       

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(queryString, utils.con);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];


                dataGridView1.Columns[0].HeaderText = "id";

                dataGridView1.Columns[1].HeaderText = "منبع";
                dataGridView1.Columns[2].HeaderText = "بستر";
                dataGridView1.Columns[3].HeaderText = "تیتر";



                dataGridView1.Columns[4].HeaderText = "محور";
                dataGridView1.Columns[5].HeaderText = "متن";

                dataGridView1.Columns[6].HeaderText = "سال";
                dataGridView1.Columns[7].HeaderText = "ماه";
                dataGridView1.Columns[8].HeaderText = "روز";
                


                dataGridView1.Columns[9].HeaderText = "صحت";
                dataGridView1.Columns[10].HeaderText = "اطلاعات تکمیلی"; 
 



            }
            else
            {


                MessageBox.Show("No item to show");
            }


            label3.Text = ds.Tables[0].Rows.Count.ToString();



        }


        //delete
        private void button2_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count <= 0) return;


            DialogResult r = MessageBox.Show("آیا می خواهید حذف کنید؟", "هشدار", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count <= 0) return;


                try
                {

                    string SQLString = " DELETE FROM news WHERE id = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                    SQLiteCommand SQLCommand = new SQLiteCommand(SQLString, utils.con);
                    SQLCommand.ExecuteNonQuery();



                    MessageBox.Show("رکورد حذف شد");



                }
                catch
                {

                    MessageBox.Show("خطا در حذف رکورد");
                }

                find();



            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //edit
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;

            var dr = dataGridView1.SelectedRows[0];

          


            string id = dr.Cells[0].Value.ToString();
            string source = dr.Cells[1].Value.ToString();
            string bestar = dr.Cells[2].Value.ToString();
            string titr = dr.Cells[3].Value.ToString();
            string mehvar = dr.Cells[4].Value.ToString();

            string matn = dr.Cells[5].Value.ToString();

            string yearr = dr.Cells[6].Value.ToString();
            string monthh = dr.Cells[7].Value.ToString();
            string dayy = dr.Cells[8].Value.ToString();
            string sehat = dr.Cells[9].Value.ToString();
            string takmil = dr.Cells[10].Value.ToString();


            add_update_form editfrm = new add_update_form();
            editfrm.setform4UPDATE();
            editfrm.populate_searchbar(id, source, bestar, titr, mehvar, yearr, monthh, dayy, sehat, takmil);
            editfrm.setrichtextbox(matn);


            editfrm.ShowDialog();

            find();




        }

        //new
        private void button5_Click(object sender, EventArgs e)
        {
            add_update_form adfrm = new add_update_form();
            adfrm.setform4NEW();
            adfrm.ShowDialog();
            find();
        }

        private void button6_Click(object sender, EventArgs e)
        {



            allcharts fchart = new allcharts();

            fchart.quer_sources = userControl11.getQueryGroupby("source");

            utils.draw(userControl11.getQueryGroupby("bestar"), fchart.getbestarchart(),100,40,"200");
            utils.draw(userControl11.getQueryGroupby("source"), fchart.getmanbachart(), 100, 40,"200");
            utils.draw(userControl11.getQueryGroupby("mehvar"), fchart.getmehvarchart(), 100, 40,"200");
            utils.draw(userControl11.getQueryGroupby("sehat"),  fchart.getsehatchart(), 100, 40,"200");



            fchart.ShowDialog();
        }
    }
}
