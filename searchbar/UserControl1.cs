using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace searchbar
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        public void reset()
        {

            comboBox1.SelectedIndex = 0;
            textBox3.Text = textBox1.Text = textBox2.Text = textBox6.Text = textBox5.Text = "";
            numericUpDown1.Value = numericUpDown2.Value = numericUpDown3.Value = 0;
        }








        public string getQueryGroupby(string column)
        {






            var queryString = "SELECT " + column + ",count(*) as num FROM  news  WHERE 1=1 ";


            if (textBox1.Text != "")
                queryString += "AND source='" + textBox1.Text + "' ";

            if (textBox2.Text != "")
                queryString += "AND bestar='" + textBox2.Text + "' ";




            if (numericUpDown3.Value != 0)
                queryString += "AND dayy='" + numericUpDown3.Value.ToString() + "' ";

            if (numericUpDown2.Value != 0)
                queryString += "AND monthh='" + numericUpDown2.Value.ToString() + "' ";

            if (numericUpDown1.Value != 0)
                queryString += "AND yearr='" + numericUpDown1.Value.ToString() + "' ";




            if (textBox6.Text != "")
                queryString += "AND titr='" + textBox6.Text + "' ";

            if (textBox5.Text != "")
                queryString += "AND mehvar='" + textBox5.Text + "' ";

            if (textBox3.Text != "")
                queryString += "AND takmil='" + textBox3.Text + "' ";




            queryString += "GROUP BY " + column;


            return queryString;


        }

        public void Populate(string source, string bestar, string titr, string mehvar, string yearr, string monthh, string dayy, string sehat, string takmil)
        {




            textBox1.Text = source;


            textBox2.Text = bestar;



            int temp = 0;


            int.TryParse(dayy, out temp);
            numericUpDown3.Value = temp;



            int.TryParse(monthh, out temp);
            numericUpDown2.Value = temp;



            int.TryParse(yearr, out temp);
            numericUpDown1.Value = temp;




            textBox6.Text = titr;


            textBox5.Text = mehvar;


            textBox3.Text = takmil;


            

            if (sehat == "true")
            {
                comboBox1.SelectedIndex=1;

            } else if (sehat == "false")
            {
                comboBox1.SelectedIndex = 2;

            }
            else { 

            }

          




        }

        public string getQuerySimilarString()
        { 



            string queryString = "SELECT * FROM news WHERE 1=1 ";

            if (textBox1.Text != "")
                queryString += "AND source LIKE '%" + textBox1.Text + "%' ";

            if (textBox2.Text != "")
                queryString += "AND bestar LIKE '" + textBox2.Text + "' ";

            //------------------------


            if (numericUpDown3.Value != 0)
                queryString += "AND dayy='" + numericUpDown3.Value.ToString() + "' ";

            if (numericUpDown2.Value != 0)
                queryString += "AND monthh='" + numericUpDown2.Value.ToString() + "' ";

            if (numericUpDown1.Value != 0)
                queryString += "AND yearr='" + numericUpDown1.Value.ToString() + "' ";

            //------------------------


            if (textBox6.Text != "")
                queryString += "AND titr LIKE '%" + textBox6.Text + "%' ";

            if (textBox5.Text != "")
                queryString += "AND mehvar LIKE '" + textBox5.Text + "' ";

            if (textBox3.Text != "")
                queryString += "AND takmil LIKE '%" + textBox3.Text + "%' ";


            //------------------------


            if (comboBox1.SelectedIndex != 0)
            {
                if (comboBox1.SelectedIndex == 1) { queryString += "AND sehat= 'true' "; }


                if (comboBox1.SelectedIndex == 2) { queryString += "AND sehat= 'false' "; }
                 
            }

            //------------------------
            
            


            return queryString;





        }

        public string getSaveCommand(string matn)
        {

            string sehat = "";

            if (comboBox1.SelectedIndex == 0) sehat = "null";
            if (comboBox1.SelectedIndex == 1) sehat = "'true'";
            if (comboBox1.SelectedIndex == 2) sehat = "'false'";


            string SQLString = @"INSERT INTO news (takmil ,sehat, source, bestar,titr, mehvar, matn, yearr,monthh,dayy) VALUES('" + textBox3.Text + "'," + sehat + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + matn + "','" + numericUpDown1.Value + "','" + numericUpDown2.Value + "','" + numericUpDown3.Value + "')";


            return SQLString;


        }


        public string getUpdateCommand(string matn, string id)
        {

            string sehat = "";

            if (comboBox1.SelectedIndex == 0) sehat = "null";
            if (comboBox1.SelectedIndex == 1) sehat = "true";
            if (comboBox1.SelectedIndex == 2) sehat = "false";

 
            string SQLString = @"UPDATE news SET   source='" + textBox1.Text + "'," + "bestar='" + textBox2.Text + "'," + "titr='" + textBox6.Text + "'," + "mehvar='" + textBox5.Text + "'," + "matn='" + matn + "'," + "yearr='" + numericUpDown1.Value + "'," + "monthh='" + numericUpDown2.Value + "'," + "dayy='" + numericUpDown3.Value + "'," + "sehat='" + sehat + "'," + "takmil='" + textBox3.Text + "' WHERE id=" + id;

            return SQLString;


        }




        private void UserControl1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {

            //using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
            //                                                     Color.Blue,
            //                                                     Color.White,
            //                                                     90F))
            //{
            //    e.Graphics.FillRectangle(brush, this.ClientRectangle);
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}