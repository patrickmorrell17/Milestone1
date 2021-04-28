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
        string userID;
        public Form2(string bid, string userid)
        {
            this.businessID = bid;
            this.userID = userid;
            InitializeComponent();
            this.AddColumns2Grid();
            this.addData2Grid4();
            this.AddDataToFriendsTips();
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone3; password = 17morrep";
        }

        private void AddColumns2Grid()
        {
            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Date";
            col1.Width = 100;
            tipGrid.Columns.Add(col1);

            DataGridViewColumn col1a = new DataGridViewTextBoxColumn();
            col1a.HeaderText = "Date";
            col1a.Width = 100;
            friendsTipsDataGridView.Columns.Add(col1a);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Like Count";
            col2.Width = 60;
            tipGrid.Columns.Add(col2);

            DataGridViewColumn col2a = new DataGridViewTextBoxColumn();
            col2a.HeaderText = "Like Count";
            col2a.Width = 60;
            friendsTipsDataGridView.Columns.Add(col2a);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Tip comment";
            col3.Width = 500;
            tipGrid.Columns.Add(col3);

            DataGridViewColumn col3a = new DataGridViewTextBoxColumn();
            col3a.HeaderText = "Tip comment";
            col3a.Width = 500;
            friendsTipsDataGridView.Columns.Add(col3a);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "UserID";
            col4.Width = 50;
            tipGrid.Columns.Add(col4);

            DataGridViewColumn col4a = new DataGridViewTextBoxColumn();
            col4a.HeaderText = "UserID";
            col4a.Width = 50;
            friendsTipsDataGridView.Columns.Add(col4a);
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

        private void AddDataToFriendsTips()
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT tip.dateoftip, tip.likecount, tip.textoftip, usertable.username FROM friendship " +
                "inner join tip on friendship.seconduserid = tip.userid " +
                "inner join usertable on friendship.seconduserid = usertable.userid " +
                "where friendship.firstuserid = '" + userID + "' AND " +
                "tip.businessid = '" + businessID + "'";
            try
            {
                this.friendsTipsDataGridView.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NpgsqlTypes.NpgsqlDate date = reader.GetDate(0);
                    int likeCount = reader.GetInt32(1);
                    //Console.WriteLine(reader.GetDate(0).GetType().ToString());
                    friendsTipsDataGridView.Rows.Add(date.ToString(), likeCount.ToString(), reader.GetString(2), reader.GetString(3)); // b s c
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

        private void likeButton_Click(object sender, EventArgs e)
        {
            string uid = tipGrid.SelectedRows[0].Cells[3].Value.ToString();
            string date = tipGrid.SelectedRows[0].Cells[0].Value.ToString();
            string text = tipGrid.SelectedRows[0].Cells[2].Value.ToString();
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE tip SET likecount = likecount + 1 " +
                "WHERE userid = '" + uid + "' AND businessid = '" + this.businessID + "' " +
                "AND dateoftip = '" + date + "' AND textoftip = '" + text + "'";
            try
            {
                //this.friendsTipsDataGridView.Rows.Clear();
                var reader = cmd.ExecuteReader();
                
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
