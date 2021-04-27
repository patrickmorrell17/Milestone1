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

        string currentUserID;

        StringBuilder catString;
        public Form1()
        {
            this.catList = new List<string>();
            this.catString = new StringBuilder();
            InitializeComponent();
            this.AddState();
            this.AddColumns2Grid();
            this.Dock = DockStyle.Fill;
            this.latTextBox.Enabled = false;
            this.longTextBox.Enabled = false;
            this.currentUserID = string.Empty;
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone3; password = 17morrep";
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

            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Distance";
            col5.Width = 40;
            businessGrid.Columns.Add(col5);

            DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Stars";
            col6.Width = 40;
            businessGrid.Columns.Add(col6);

            DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "Number Of Tips";
            col7.Width = 70;
            businessGrid.Columns.Add(col7);

            DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
            col8.HeaderText = "Number of Checkins";
            col8.Width = 70;
            businessGrid.Columns.Add(col8);

            friendsDataGrid.Columns.Add("col1", "Name");
            friendsDataGrid.Columns.Add("col2", "Total Likes");
            friendsDataGrid.Columns.Add("col3", "Avg Stars");
            friendsDataGrid.Columns.Add("col4", "Yelping Since");

            latestTipsDataGrid.Columns.Add("col1", "User Name");
            latestTipsDataGrid.Columns.Add("col2", "Business");
            latestTipsDataGrid.Columns.Add("col3", "City");
            //latestTipsDataGrid.Columns.Add("col4", "Text");
            DataGridViewColumn text = new DataGridViewTextBoxColumn();
            text.HeaderText = "Text";
            text.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            latestTipsDataGrid.Columns.Add(text);
            latestTipsDataGrid.Columns.Add("col5", "Date");



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
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        0, reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c

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
                        0, reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c

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
                        0, reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c

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
            try
            {
                this.businessGrid.Rows.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        0, reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString()); // b s c
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
                //StringBuilder sb = new StringBuilder();
                //sb.Append(businessGrid.SelectedRows[0].Cells[0].Value.ToString());
                //sb.Append(", ");
                //sb.Append(businessGrid.SelectedRows[0].Cells[1].Value.ToString());
                DayOfWeek wk = DateTime.Today.DayOfWeek;
                string dayOfWeek = wk.ToString();
                string bid = businessGrid.SelectedRows[0].Cells[3].Value.ToString();
                var connection = new NpgsqlConnection();
                connection.ConnectionString = this.BuildConnectionString();
                connection.Open();
                var cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT business.businessname, business.businessaddress," +
                    "businesshours.opentime, businesshours.closetime FROM business " +
                    "INNER JOIN businesshours ON businesshours.businessid = business.businessid " +
                    "WHERE business.businessid = '" + bid + "' and " +
                    "businesshours.dayofweek = '" + dayOfWeek + "'";


                try
                {
                    //this.businessGrid.Rows.Clear();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        busNameTextBox.Text = reader.GetString(0);
                        busAddressTextBox.Text = reader.GetString(1);
                        busHoursTextBox.Text = "Today(" + dayOfWeek + ") Opens: " + reader.GetString(2) + " Closes: " + reader.GetString(3);
                    }
                }

                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                finally
                {
                    connection.Close();
                    this.PopulateBusinessCategories(bid);
                }
                //Form2 nWin = new Form2(bid);
                //nWin.Show();
            }
        }

        public void PopulateBusinessCategories(string bid)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT categories.categoryname FROM business" +
                " INNER JOIN categories on categories.businessid = business.businessid" +
                " where business.businessid = '" + bid + "'";
            try
            {
                this.busAttCatListBox.Items.Clear();
                this.busAttCatListBox.Items.Add("Categories:");
                //this.UserListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    this.busAttCatListBox.Items.Add("   " + reader.GetString(0));

                }
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.PopulateBusinessAttr(bid);
            }
        }

        public void PopulateBusinessAttr(string bid)
        {
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT attributes.nameofattribute FROM business" +
                " INNER JOIN attributes on attributes.businessid = business.businessid" +
                " where business.businessid = '" + bid + "' AND attributes.valueofattribute = 'True'";
            try
            {
                this.busAttCatListBox.Items.Add("Categories:");
                //this.UserListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    this.busAttCatListBox.Items.Add("   " + reader.GetString(0));

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

        private void searchUserButton_Click(object sender, EventArgs e)
        {
            string text = this.CurrentUserTextBox.Text;
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT userid FROM usertable WHERE username = '" + text + "' ORDER BY userid";
            try
            {
                this.UserListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.UserListBox.Items.Add(reader.GetString(0));

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
            // Display users with this name.
        }

        private void setAsCurrentUserButton_Click(object sender, EventArgs e)
        {
            string userid = this.UserListBox.SelectedItem.ToString();
            this.currentUserID = userid;
            this.PopulateUserFriendGrid(userid);
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM usertable WHERE userid = '" + userid + "'";
            try
            {
                //this.UserListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userInfoNameTextBox.Text = reader.GetString(3);
                    starsTextBox.Text = reader.GetDouble(4).ToString();
                    fansTextBox.Text = reader.GetInt32(9).ToString();
                    yelpingSinceTextBox.Text = reader.GetTimeStamp(7).ToString();
                    funnyTextBox.Text = reader.GetInt32(11).ToString();
                    coolTextBox.Text = reader.GetInt32(1).ToString();
                    usefulTextBox.Text = reader.GetInt32(10).ToString();
                    tipCountTextBox.Text = reader.GetInt32(2).ToString();
                    tipLikesTextBox.Text = reader.GetInt32(8).ToString();
                    latTextBox.Text = reader.GetDouble(5).ToString();
                    longTextBox.Text = reader.GetDouble(6).ToString();
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

        private void PopulateUserFriendGrid(string userid)
        {
            List<string> friendIDList = new List<string>();
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM friendship inner join usertable on userid  = seconduserid " +
                "where firstuserid = '" + userid + "'";
            try
            {
                //this.UserListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    friendIDList.Add(reader.GetString(2));
                    friendsDataGrid.Rows.Add(reader.GetString(5), reader.GetInt32(10).ToString(), reader.GetDouble(6).ToString(), reader.GetTimeStamp(9).ToString());
                }
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.PopulateRecentTips(friendIDList);
            }
        }

        private void PopulateRecentTips(List<string> userList)
        {
            foreach (string userid in userList)
            {
                var connection = new NpgsqlConnection();
                connection.ConnectionString = this.BuildConnectionString();
                connection.Open();
                var cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT usertable.username, business.businessname, business.city, tip.textoftip, tip.dateoftip" + 
                    " FROM tip INNER JOIN usertable ON" +
                    " usertable.userid = tip.userid INNER JOIN business ON business.businessid = tip.businessid" +
                    " WHERE tip.userid = '" + userid + "' ORDER BY tip.dateoftip DESC" +
                    " LIMIT 1";
                try
                {
                    //this.UserListBox.Items.Clear();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        this.latestTipsDataGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDate(4).ToString());
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
                tempSort = "Buisness Name";
            else
                tempSort = sortByComboBox.SelectedItem.ToString();
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

        private void editLocButton_Click(object sender, EventArgs e)
        {
            this.latTextBox.Enabled = true;
            this.longTextBox.Enabled = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string lattitude = this.latTextBox.Text;
            string longitude = this.longTextBox.Text;
            string userid = this.UserListBox.SelectedItem.ToString();
            var connection = new NpgsqlConnection();
            connection.ConnectionString = this.BuildConnectionString();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE usertable SET longitude = " + longitude.ToString() + 
                ", latitude = " + lattitude.ToString() + " WHERE userid = '" + userid + "'";
            try
            {
                //this.UserListBox.Items.Clear();
                var reader = cmd.ExecuteReader();
                
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
                this.latTextBox.Enabled = false;
                this.longTextBox.Enabled = false;
            }

        }
    }
}
