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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AddState();
            this.AddColumns2Grid();
            this.Dock = DockStyle.Fill;
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone2db; password = 17morrep";
        }

        private void AddState()
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct businessState FROM business ORDER BY businessState";
            try
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.stateComboBox.Items.Add(reader.GetString(0));
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void AddColumns2Grid()
        {
            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            //col1.Bind = new Binding("name");
            col1.HeaderText = "BusinessName";
            col1.Width = 255;
            businessGrid.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "State";
            col2.Width = 60;
            businessGrid.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "City";
            col3.Width = 150;
            businessGrid.Columns.Add(col3);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "ID";
            col4.Width = 15;
            businessGrid.Columns.Add(col4);

        }

        private void stateComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct city FROM business WHERE businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' ORDER BY city";
            try
            {
                this.cityComboBox.Items.Clear();
                this.cityComboBox.Text = " ";
                this.zipcodeComboBox.Items.Clear();
                this.zipcodeComboBox.Text = " ";
                this.businessCatComboBox.Items.Clear();
                this.businessCatComboBox.Text = " ";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    this.cityComboBox.Items.Add(reader.GetString(0));
                }
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.addRows2DataGrid1();
            }
        }

        private void cityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct postalCode FROM business WHERE businessState = '" + 
                stateComboBox.SelectedItem.ToString().ToUpper() + "' AND city = '" + cityComboBox.SelectedItem.ToString() + "' ORDER BY postalCode";
            try
            {
                this.zipcodeComboBox.Items.Clear();
                this.zipcodeComboBox.Text = " ";
                this.businessCatComboBox.Items.Clear();
                this.businessCatComboBox.Text = " ";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    this.zipcodeComboBox.Items.Add(reader.GetString(0));
                }
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.addRows2DataGrid2();
            }
        }

        private void zipcodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct categories.categoryName FROM business" +  
                " INNER JOIN categories on business.businessID = categories.businessID WHERE business.postalCode = '" +
                 zipcodeComboBox.SelectedItem.ToString() + "' ORDER BY categories.categoryName";
            try
            {
                this.businessCatComboBox.Items.Clear();
                this.businessCatComboBox.Text = " ";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    this.businessCatComboBox.Items.Add(reader.GetString(0));
                }
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.addRows2DataGrid3();
            }
        }

        private void addRows2DataGrid1()
        {

            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct businessName, businessState, city, businessID FROM business WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' ORDER BY businessName";
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)); // b s c

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

        private void addRows2DataGrid2()
        {

            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct businessName, businessState, city, businessID FROM business WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' AND city = '" + 
                cityComboBox.SelectedItem.ToString() + "' ORDER BY businessName";
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)); // b s c

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

        private void addRows2DataGrid3()
        {

            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct businessName, businessState, city, businessID FROM business WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' AND city = '" +
                cityComboBox.SelectedItem.ToString() + "' AND postalCode = '" +
                zipcodeComboBox.SelectedItem.ToString() + "' ORDER BY businessName";
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)); // b s c

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

        private void businessCatComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct business.businessName, business.businessState, business.city, business.businessID FROM business" +
                " INNER JOIN categories on categories.businessID = business.businessID WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' AND city = '" +
                cityComboBox.SelectedItem.ToString() + "' AND postalCode = '" +
                zipcodeComboBox.SelectedItem.ToString() + "' AND categories.categoryName = '" + businessCatComboBox.SelectedItem.ToString()  + 
                "' ORDER BY businessName";
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)); // b s c

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
    }
}
