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
            }
        }
    }
}
