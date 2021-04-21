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
        List<string> catList;
        List<string> attList;

        StringBuilder catString;
        StringBuilder attString;

        public Form1()
        {
            this.catList = new List<string>();
            this.attList = new List<string>();
            this.catString = new StringBuilder();
            this.attString = new StringBuilder();

            InitializeComponent();
            this.AddState();
            this.AddColumns2Grid();
            this.Dock = DockStyle.Fill;
        }

        private string BuildConnectionString()
        {
            //return "Host = localhost; Username = postgres; Database = milestone2b; password = 17morrep";
            return "Host = localhost; Username = postgres; Database = TermProjectTesting; password = Fayner29";
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
            col1.Width = 150;
            businessGrid.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "State";
            col2.Width = 40;
            businessGrid.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "City";
            col3.Width = 70;
            businessGrid.Columns.Add(col3);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "ID";
            col4.Width = 150;
            businessGrid.Columns.Add(col4);

            //adding new columns to the table
            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Stars";
            col5.Width = 40;
            businessGrid.Columns.Add(col5);

            DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Number Of Tips";
            col6.Width = 70;
            businessGrid.Columns.Add(col6);

            DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "Number of Checkins";
            col7.Width = 70;
            businessGrid.Columns.Add(col7);

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
                this.ClearData();
                this.busCatListBox.Items.Clear();
                this.cityComboBox.Items.Clear();
                this.cityComboBox.Text = " ";
                this.zipcodeComboBox.Items.Clear();
                this.zipcodeComboBox.Text = " ";
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
                this.ClearData();
                this.busCatListBox.Items.Clear();
                this.zipcodeComboBox.Items.Clear();
                this.zipcodeComboBox.Text = " ";
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
                this.ClearData();
                this.busCatListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.busCatListBox.Items.Add(reader.GetString(0));
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
        //These are just building and populating the combo boxes
        private void addRows2DataGrid1()
        {

            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct businessName, businessState, city, businessID, stars, numoftips, numofcheckin FROM business WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "'"; //stars added
            cmd.CommandText = CheckAttributeFilters(cmd.CommandText);
            cmd.CommandText = SortBySelector(cmd.CommandText);
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //int bStars = reader.GetInt32(4);
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), 
                        reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c

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
            cmd.CommandText = "SELECT distinct businessName, businessState, city, businessID, stars, numoftips, numofcheckin FROM business WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' AND city = '" + 
                cityComboBox.SelectedItem.ToString() + "'";
            cmd.CommandText = CheckAttributeFilters(cmd.CommandText);
            cmd.CommandText = SortBySelector(cmd.CommandText);
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c

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
            cmd.CommandText = "SELECT distinct businessName, businessState, city, businessID, stars, numoftips, numofcheckin FROM business WHERE"
                + " businessState = '" + stateComboBox.SelectedItem.ToString().ToUpper() + "' AND city = '" +
                cityComboBox.SelectedItem.ToString() + "' AND postalCode = '" +
                zipcodeComboBox.SelectedItem.ToString() + "'";
            cmd.CommandText = CheckAttributeFilters(cmd.CommandText);
            cmd.CommandText = SortBySelector(cmd.CommandText);
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c

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

        private void busCatbutton_Click(object sender, EventArgs e)
        {
            this.catList.Add(this.busCatListBox.SelectedItem.ToString());
            this.catString.Append(this.busCatListBox.SelectedItem.ToString() + ", ");
            this.currentCategoriesTextBox.Text = this.catString.ToString();
            this.addData2Grid4();
        }

        private void ClearData()
        {
            this.catList.Clear();
            this.catString.Clear();
            this.currentCategoriesTextBox.Text = "";
        }

        private void addData2Grid4()
        {
            string catString = this.BuildCatagoriesSql();
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT distinct business.businessName, business.businessState, business.city, business.businessID, business.stars, business.numoftips, business.numofcheckin FROM business" +
                " WHERE postalCode = '" +
                zipcodeComboBox.SelectedItem.ToString() + "' " + catString;
            // Check if each text box is checked
            cmd.CommandText = CheckAttributeFilters(cmd.CommandText);
            cmd.CommandText = SortBySelector(cmd.CommandText);
            //end of my modifications
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c
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

        private string BuildCatagoriesSql()
        {
            StringBuilder nstring = new StringBuilder();
            string and = "AND";
            for(int i = 0; i < catList.Count(); ++i)
            {
                nstring.Append(and);
                nstring.Append(" business.businessID IN (SELECT categories.businessID FROM categories " + 
                    "WHERE categories.categoryName = '" + this.catList[i] + "') ");
            }
            return nstring.ToString();
        }

        private void businessGrid_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = businessGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(businessGrid.SelectedRows[0].Cells[0].Value.ToString());
                sb.Append(", ");
                sb.Append(businessGrid.SelectedRows[0].Cells[1].Value.ToString());
                string bid = businessGrid.SelectedRows[0].Cells[3].Value.ToString();
                Form2 nWin = new Form2(bid);
                nWin.Show();
            }
        }

        //Alot of code that basically just checks for the check boxes
        private string CheckAttributeFilters(string cmdText)
        {
            if (price1CheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsPriceRange2' and valueofattribute='1') ";
            }
            if (price2CheckBox.Checked == true) //making it so it shows all of the ones in any of the categories
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsPriceRange2' and valueofattribute='2') ";
            }
            if (price3CheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsPriceRange2' and valueofattribute='3') ";
            }
            if (price4CheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsPriceRange2' and valueofattribute='4') ";
            }
            if (price4CheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsPriceRange2' and valueofattribute='4') ";
            }
            if (breakfastCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='breakfast' and valueofattribute='True') ";
            }
            if (brunchCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='brunch' and valueofattribute='True') ";
            }
            if (lunchCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='lunch' and valueofattribute='True') ";
            }
            if (dinnerCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='dinner' and valueofattribute='True') ";
            }
            if (dessertCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='dessert' and valueofattribute='True') ";
            }
            if (latenightCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='latenight' and valueofattribute='True') ";
            }

            if (acceptsCCCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='BusinessAcceptsCreditCards' and valueofattribute='True') ";
            }
            if (takesReservationsCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsReservations' and valueofattribute='True') ";
            }
            if (wheelchairAccessCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='WheelchairAccessible' and valueofattribute='True') ";
            }
            if (outdoorSeatingCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='OutdoorSeating' and valueofattribute='True') ";
            }
            if (goodForKidsCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='GoodForKids' and valueofattribute='True') ";
            }
            if (goodForGroupsCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsGoodForGroups' and valueofattribute='True') ";
            }
            if (deliveryCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsDelivery' and valueofattribute='True') ";
            }
            if (takeOutCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='RestaurantsTakeOut' and valueofattribute='True') ";
            }
            if (wifiCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='WiFi' and valueofattribute='free') ";
            }
            if (bikeParkingCheckBox.Checked == true)
            {
                cmdText += "and business.businessID IN (SELECT attributes.businessID FROM attributes " +
                    "WHERE nameofattribute='BikeParking' and valueofattribute='True') ";
            }

            return cmdText;
        }

        private void price1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void price2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void price3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void price4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }

        private void breakfastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void brunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void lunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void dinnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void dessertCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void latenightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }

        private void acceptsCCCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void takesReservationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void wheelchairAccessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void outdoorSeatingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void goodForKidsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void goodForGroupsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void deliveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void takeOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void wifiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void bikeParkingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private void sortByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedItem == null)
                return;
            else if (cityComboBox.SelectedItem == null)
                this.addRows2DataGrid1();
            else if (zipcodeComboBox.SelectedItem == null)
                this.addRows2DataGrid2();
            else
                this.addData2Grid4();
        }
        private string SortBySelector(string cmd)
        {
            string tempSort;
            if (sortByComboBox.SelectedItem == null)
                tempSort="Buisness Name";
            else
                tempSort=sortByComboBox.SelectedItem.ToString();
            cmd = cmd + "order by ";
            switch (tempSort)
            {
                case "Business Name":
                    cmd = cmd + "businessname";
                    break;
                case "Stars":
                    cmd = cmd + "stars desc";
                    break;
                case "Number Of Tips":
                    cmd = cmd + "numoftips desc";
                    break;
                case "Number Of Checkins":
                    cmd = cmd + "numofcheckin desc";
                    break;
                case "Nearest":
                    //cmd = cmd + ""
                    break;
                default:
                    cmd = cmd + "businessname";
                    break;
            }
            return cmd;
        }
    }
}
