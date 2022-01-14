using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class add_update_form :Form
    {
        public add_update_form()
        {


            InitializeComponent();
        }




        string id4edit = "";
        public void populate_searchbar(string id, string source, string bestar, string titr, string mehvar, string yearr, string monthh, string dayy, string sehat, string takmil)
        {
            id4edit = id;
            userControl11.Populate(source, bestar, titr, mehvar, yearr, monthh, dayy, sehat, takmil);



        }
        public void setform4UPDATE()
        {
            button1.Hide();
            this.Text = "فرم ویرایش";
            userControl11.comboBox1.Enabled=false;

        }





        //--------------------------------------------

        public void setform4NEW()
        {
            button3.Hide();
            this.Text = "فرم ایجاد";

        }


        //add
        private void button1_Click(object sender, EventArgs e)
        { 
             




            //string errormsg = "";



            //if (textBox1.Text == "")
            //{

            //    errormsg = "نام تحویل دهنده خالی است ";
            //    MessageBox.Show(errormsg); return;


            //}


            //if (!utils.validatephone(textBox2.Text))
            //{

            //    errormsg = "شماره تماس معتبر نیست";
            //    MessageBox.Show(errormsg); return;

            //}



            //if (richTextBox1.Text == "")
            //{

            //    errormsg = "آدرس تحویل دهنده خالی است ";
            //    MessageBox.Show(errormsg); return;

            //}






            //if (textBox6.Text == "")
            //{

            //    errormsg = "نام دستگاه خالی است";
            //    MessageBox.Show(errormsg); return;

            //}

            //if (textBox5.Text == "")
            //{

            //    errormsg = "مدل دستگاه خالی است";
            //    MessageBox.Show(errormsg); return;

            //}


            //if (textBox4.Text == "")
            //{

            //    errormsg = "شماره سریال دستگاه خالی است";
            //    MessageBox.Show(errormsg); return;

            //}



            //if (richTextBox2.Text == "")
            //{

            //    errormsg = "شرح خرابی خالی است";
            //    MessageBox.Show(errormsg); return;

            //}








            //if (numericUpDown1.Value < 0)
            //{

            //    errormsg = ".سال بايد مثبت باشد";
            //    MessageBox.Show(errormsg); return;
            //}
            //if (!(numericUpDown2.Value >= 1 && numericUpDown2.Value <= 12))
            //{

            //    errormsg = ".ماه بايد بين 1 تا 12 باشد";
            //    MessageBox.Show(errormsg); return;
            //}
            //if (!(numericUpDown3.Value >= 1 && numericUpDown3.Value <= 31))
            //{

            //    errormsg = ".روز بايد بين 1 تا 31 باشد";
            //    MessageBox.Show(errormsg); return;
            //}





            //add
           try
            {
                var SQLString = userControl11.getSaveCommand(richTextBox2.Text);



                var cmd = new SQLiteCommand(SQLString, utils.con);


                cmd.ExecuteScalar();



                // string SQLString = @"INSERT INTO tools (source, bestar,titr, mehvar, matn, yearr,monthh,dayy) VALUES('" + textBox1.Text + "','" + richTextBox2.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" +  richTextBox2.Text + "','" +  numericUpDown1.Value + "','" + numericUpDown2.Value + "','" + numericUpDown3.Value + "')";
                //   OleDbCommand SQLCommand = new OleDbCommand(SQLString, utils.con);

                //  MessageBox.Show(SQLString.ToString());
                //   int response = SQLCommand.ExecuteNonQuery();



                //   MessageBox.Show("با موفقیت ذخیره شد");




            }
             catch
            {

                MessageBox.Show("خطا در ذخیره سازی");

            }




        }

         


        //cancel

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         
      


      



        private void Form1_Load(object sender, EventArgs e)
        {
          

            Bitmap bm2 = (Bitmap)button2.Image;
            bm2.MakeTransparent(bm2.GetPixel(0, 0));

            Bitmap bm1= (Bitmap)button1.Image;
            bm1.MakeTransparent(bm1.GetPixel(0, 0));


            Bitmap bm3 = (Bitmap)button3.Image;
            bm3.MakeTransparent(bm3.GetPixel(0, 0));


            label2.AutoSize = false;
            label2.Height = 2;
            label2.Width = this.Width;
            label2.BorderStyle = BorderStyle.Fixed3D;

             
             
        }

         


        private void addform_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            //LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.ForwardDiagonal);
            //g.FillRectangle(brush, rect);
            //brush.Dispose();
        }
         
     

        internal void setrichtextbox(string v)
        {
            richTextBox2.Text = v;
        }


        //update
        private void button3_Click(object sender, EventArgs e)
        {

           var SQLString= userControl11.getUpdateCommand(richTextBox2.Text,id4edit );



            try
            {

               


                SQLiteCommand SQLCommand = new SQLiteCommand(SQLString, utils.con);
                SQLCommand.ExecuteNonQuery();



                MessageBox.Show("رکورد ویرایش شد");
                



            }
            catch
            {

                MessageBox.Show("خطا در ویرایش رکورد");
            }

            
             

         
    }
    }
}
