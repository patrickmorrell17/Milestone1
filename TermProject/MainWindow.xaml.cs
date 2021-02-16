using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace TermProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Business
        {
            public string name { get; set; }
            public string state { get; set; }
            public string city { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            addState();
            addColumns();
        }

        private string buildConnectionString()
        {
            // NOTE MAY HAVE TO CHANGE PARAMETERS IN FUTURE - ESPECIALLY USERNAME / PASSWORD
            return "Host = localhost; Username = postgres; Databasse = milestone1db; password = password";
        }

        private void addState()
        {
            //cBoxState.Items.Add("WA");
            //cBoxState.Items.Add("CA");
            //cBoxState.Items.Add("ID");
            //cBoxState.Items.Add("NV");
            //cBoxState.Items.Add("OR");
            var connection = new NpgsqlConnection(buildConnectionString());
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct state FROM business ORDER BY state";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cBoxState.Items.Add(reader.GetString(0));
        }

        private void addCity()
        {
            var connection = new NpgsqlConnection(buildConnectionString());
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct city FROM business ORDER BY city";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cBoxCity.Items.Add(reader.GetString(0));
        }

        private void addColumns()
        {
            DataGridTextColumn col1 = new DataGridTextColumn();
            col1.Header = "BusinessName";
            col1.Binding = new Binding("name");
            col1.Width = 270;

            DataGridTextColumn col2 = new DataGridTextColumn();
            col2.Header = "State";
            col2.Binding = new Binding("state");
            col2.Width = 70;

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "City";
            col3.Binding = new Binding("city");
            col3.Width = 150;

            dGridBusiness.Columns.Add(col1);
            dGridBusiness.Columns.Add(col2);
            dGridBusiness.Columns.Add(col3);

            dGridBusiness.Items.Add(new Business() { name = "Business1", state = "WA", city = "Pullman" });
            dGridBusiness.Items.Add(new Business() { name = "Business2", state = "CA", city = "San Francisco" });
            dGridBusiness.Items.Add(new Business() { name = "Business3", state = "NV", city = "Las Vegas" });
        }

    }
}
