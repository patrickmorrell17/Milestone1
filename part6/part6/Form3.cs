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
        private string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September","October","November","December"};
   
        public Form3(string bid)
        {
            this.businessID = bid;
            InitializeComponent();
            addData2Chart();
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone2; password = password";
        }

        private void addData2Chart()
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT to_char(checkintimestamp,'MM') as month FROM checkins WHERE businessid = " + businessID + " ORDER BY month";
            try
            {
                this.checkinchart.Series.Clear();
                var reader = cmd.ExecuteReader();
                int[] count = new int[12];
                while (reader.Read())
                {
                    count[reader.GetInt32(0)] += 1;
                }
                for(int i = 0; i < 12; i++)
                {
                    this.checkinchart.Series["# of Check-ins"].Points.AddXY(months[i], count[i]);
                }
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
