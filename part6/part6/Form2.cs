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
    public partial class Form2 : Form
    {
        string businessID;
        public Form2(string bid)
        {
            this.businessID = bid;
            InitializeComponent();
            this.AddColumns2Grid();
            this.addData2Grid4();
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone2; password = password";
        }

        private void AddColumns2Grid()
        {
            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            //col1.Bind = new Binding("name");
            col1.HeaderText = "Date";
            col1.Width = 100;
            tipGrid.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Like Count";
            col2.Width = 60;
            tipGrid.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Tip comment";
            col3.Width = 500;
            tipGrid.Columns.Add(col3);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "UserID";
            col4.Width = 50;
            tipGrid.Columns.Add(col4);
        }

        private void addData2Grid4()
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT dateOfTip, likeCount, textOfTip, userID FROM tip " + 
                "WHERE businessID = '" + this.businessID + "' ORDER BY dateOfTip";
            try
            {
                this.tipGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NpgsqlTypes.NpgsqlDate date = reader.GetDate(0);
                    int likeCount = reader.GetInt32(1);
                    //Console.WriteLine(reader.GetDate(0).GetType().ToString());
                    tipGrid.Rows.Add(date.ToString(), likeCount.ToString(), reader.GetString(2), reader.GetString(3)); // b s c
                }
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
            }
        }

        private void submitTipButton_Click(object sender, EventArgs e)
        {
            NpgsqlTypes.NpgsqlDate date = new NpgsqlTypes.NpgsqlDate();
            date = NpgsqlTypes.NpgsqlDate.Today;
            string userID = "jRyO2V1pA4CdVVqCIOPc1Q";
            string tipText = this.textBox1.Text;
            int likeCount = 50;
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO tip (dateOfTip, likeCount, textOfTip, userID, businessID) " +
                "VALUES ('" + date.ToString() +"', " + likeCount + ", '" + tipText + "', '" + userID + "', '" + businessID + "')";
            try
            {
                this.tipGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    NpgsqlTypes.NpgsqlDate date = reader.GetDate(0);
                //    int likeCount = reader.GetInt32(1);
                //    Console.WriteLine(reader.GetDate(0).GetType().ToString());
                //    tipGrid.Rows.Add(date.ToString(), likeCount.ToString(), reader.GetString(2), reader.GetString(3)); // b s c
                //}
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.addData2Grid4();
            }
        }
    }
}
