using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace part6
{
    public partial class Form3 : Form
    {
        string businessID;
        Form1 temp;
        private string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public Form3(string bid, Form1 form)
        {
            this.businessID = bid;
            InitializeComponent();
            addData2Chart();
            temp = form;
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone3; password = 17morrep";
        }

        private void addData2Chart()
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT to_char(checkintimestamp,'MM') as month FROM checkins WHERE businessid = '" + businessID + "' ORDER BY month";
            try
            {
                this.checkinchart.Series.Clear();
                this.checkinchart.Series.Add("# of Check-ins");

                var reader = cmd.ExecuteReader();
                int[] count = new int[12];
                while (reader.Read())
                {
                    count[int.Parse(reader.GetString(0)) - 1] += 1;
                }
                for (int i = 0; i < 12; i++)
                {
                    this.checkinchart.Series["# of Check-ins"].Points.AddXY(months[i], count[i]);
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void btncheckin_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            DateTime local = DateTime.Now;
            string datetime = local.ToString();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO checkins VALUES ('" + datetime + "','" + businessID + "')";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            addData2Chart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            temp.Show();
        }
    }
}
