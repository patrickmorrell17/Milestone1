
namespace part6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.zipcodeComboBox = new System.Windows.Forms.ComboBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.businessCatLabel = new System.Windows.Forms.Label();
            this.businessGrid = new System.Windows.Forms.DataGridView();
            this.busCatListBox = new System.Windows.Forms.ListBox();
            this.busCatbutton = new System.Windows.Forms.Button();
            this.searchbutton = new System.Windows.Forms.Button();
            this.currentCategoriesTextBox = new System.Windows.Forms.TextBox();
            this.currentCatlabel = new System.Windows.Forms.Label();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.sortByComboBox = new System.Windows.Forms.ComboBox();
            this.filterByPriceLabel = new System.Windows.Forms.Label();
            this.price1CheckBox = new System.Windows.Forms.CheckBox();
            this.price2CheckBox = new System.Windows.Forms.CheckBox();
            this.price4CheckBox = new System.Windows.Forms.CheckBox();
            this.price3CheckBox = new System.Windows.Forms.CheckBox();
            this.filterAttributeLabel = new System.Windows.Forms.Label();
            this.takeOutCheckBox = new System.Windows.Forms.CheckBox();
            this.outdoorSeatingCheckBox = new System.Windows.Forms.CheckBox();
            this.deliveryCheckBox = new System.Windows.Forms.CheckBox();
            this.wheelchairAccessCheckBox = new System.Windows.Forms.CheckBox();
            this.goodForGroupsCheckBox = new System.Windows.Forms.CheckBox();
            this.takesReservationsCheckBox = new System.Windows.Forms.CheckBox();
            this.goodForKidsCheckBox = new System.Windows.Forms.CheckBox();
            this.acceptsCCCheckBox = new System.Windows.Forms.CheckBox();
            this.wifiCheckBox = new System.Windows.Forms.CheckBox();
            this.bikeParkingCheckBox = new System.Windows.Forms.CheckBox();
            this.MealLabel = new System.Windows.Forms.Label();
            this.latenightCheckBox = new System.Windows.Forms.CheckBox();
            this.lunchCheckBox = new System.Windows.Forms.CheckBox();
            this.dessertCheckBox = new System.Windows.Forms.CheckBox();
            this.brunchCheckBox = new System.Windows.Forms.CheckBox();
            this.dinnerCheckBox = new System.Windows.Forms.CheckBox();
            this.breakfastCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // stateComboBox
            // 
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Location = new System.Drawing.Point(128, 14);
            this.stateComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(136, 28);
            this.stateComboBox.TabIndex = 0;
            this.stateComboBox.SelectionChangeCommitted += new System.EventHandler(this.stateComboBox_SelectionChangeCommitted);
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(128, 68);
            this.cityComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(136, 28);
            this.cityComboBox.TabIndex = 1;
            this.cityComboBox.SelectionChangeCommitted += new System.EventHandler(this.cityComboBox_SelectionChangeCommitted);
            // 
            // zipcodeComboBox
            // 
            this.zipcodeComboBox.FormattingEnabled = true;
            this.zipcodeComboBox.Location = new System.Drawing.Point(128, 128);
            this.zipcodeComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zipcodeComboBox.Name = "zipcodeComboBox";
            this.zipcodeComboBox.Size = new System.Drawing.Size(136, 28);
            this.zipcodeComboBox.TabIndex = 2;
            this.zipcodeComboBox.SelectionChangeCommitted += new System.EventHandler(this.zipcodeComboBox_SelectionChangeCommitted);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(32, 14);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(74, 29);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "State:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(37, 68);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(59, 29);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City:";
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeLabel.Location = new System.Drawing.Point(11, 123);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(118, 29);
            this.zipCodeLabel.TabIndex = 5;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // businessCatLabel
            // 
            this.businessCatLabel.AutoSize = true;
            this.businessCatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessCatLabel.Location = new System.Drawing.Point(577, 10);
            this.businessCatLabel.Name = "businessCatLabel";
            this.businessCatLabel.Size = new System.Drawing.Size(241, 29);
            this.businessCatLabel.TabIndex = 7;
            this.businessCatLabel.Text = "Business Categories:";
            // 
            // businessGrid
            // 
            this.businessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.businessGrid.Location = new System.Drawing.Point(216, 347);
            this.businessGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.RowHeadersWidth = 51;
            this.businessGrid.RowTemplate.Height = 24;
            this.businessGrid.Size = new System.Drawing.Size(842, 322);
            this.businessGrid.TabIndex = 8;
            this.businessGrid.SelectionChanged += new System.EventHandler(this.businessGrid_SelectionChanged);
            // 
            // busCatListBox
            // 
            this.busCatListBox.FormattingEnabled = true;
            this.busCatListBox.ItemHeight = 20;
            this.busCatListBox.Location = new System.Drawing.Point(583, 104);
            this.busCatListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.busCatListBox.Name = "busCatListBox";
            this.busCatListBox.Size = new System.Drawing.Size(222, 184);
            this.busCatListBox.TabIndex = 9;
            // 
            // busCatbutton
            // 
            this.busCatbutton.Location = new System.Drawing.Point(583, 55);
            this.busCatbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.busCatbutton.Name = "busCatbutton";
            this.busCatbutton.Size = new System.Drawing.Size(172, 41);
            this.busCatbutton.TabIndex = 10;
            this.busCatbutton.Text = "Add Category";
            this.busCatbutton.UseVisualStyleBackColor = true;
            this.busCatbutton.Click += new System.EventHandler(this.busCatbutton_Click);
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(465, 300);
            this.searchbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(340, 39);
            this.searchbutton.TabIndex = 11;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            // 
            // currentCategoriesTextBox
            // 
            this.currentCategoriesTextBox.Location = new System.Drawing.Point(829, 104);
            this.currentCategoriesTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.currentCategoriesTextBox.Multiline = true;
            this.currentCategoriesTextBox.Name = "currentCategoriesTextBox";
            this.currentCategoriesTextBox.Size = new System.Drawing.Size(205, 104);
            this.currentCategoriesTextBox.TabIndex = 12;
            // 
            // currentCatlabel
            // 
            this.currentCatlabel.AutoSize = true;
            this.currentCatlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCatlabel.Location = new System.Drawing.Point(822, 74);
            this.currentCatlabel.Name = "currentCatlabel";
            this.currentCatlabel.Size = new System.Drawing.Size(255, 22);
            this.currentCatlabel.TabIndex = 13;
            this.currentCatlabel.Text = "Currently Selected Categories:";
            // 
            // sortByLabel
            // 
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortByLabel.Location = new System.Drawing.Point(289, 265);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(96, 29);
            this.sortByLabel.TabIndex = 14;
            this.sortByLabel.Text = "Sort By:";
            // 
            // sortByComboBox
            // 
            this.sortByComboBox.FormattingEnabled = true;
            this.sortByComboBox.Items.AddRange(new object[] {
            "Business Name",
            "Stars",
            "Number Of Tips",
            "Number Of Checkins",
            "Nearest"});
            this.sortByComboBox.Location = new System.Drawing.Point(271, 306);
            this.sortByComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sortByComboBox.Name = "sortByComboBox";
            this.sortByComboBox.Size = new System.Drawing.Size(136, 28);
            this.sortByComboBox.TabIndex = 15;
            this.sortByComboBox.SelectedIndexChanged += new System.EventHandler(this.sortByComboBox_SelectedIndexChanged);
            // 
            // filterByPriceLabel
            // 
            this.filterByPriceLabel.AutoSize = true;
            this.filterByPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterByPriceLabel.Location = new System.Drawing.Point(289, 14);
            this.filterByPriceLabel.Name = "filterByPriceLabel";
            this.filterByPriceLabel.Size = new System.Drawing.Size(156, 29);
            this.filterByPriceLabel.TabIndex = 16;
            this.filterByPriceLabel.Text = "filter by price:";
            // 
            // price1CheckBox
            // 
            this.price1CheckBox.AutoSize = true;
            this.price1CheckBox.Location = new System.Drawing.Point(294, 55);
            this.price1CheckBox.Name = "price1CheckBox";
            this.price1CheckBox.Size = new System.Drawing.Size(44, 24);
            this.price1CheckBox.TabIndex = 17;
            this.price1CheckBox.Text = "$";
            this.price1CheckBox.UseVisualStyleBackColor = true;
            this.price1CheckBox.CheckedChanged += new System.EventHandler(this.price1CheckBox_CheckedChanged);
            // 
            // price2CheckBox
            // 
            this.price2CheckBox.AutoSize = true;
            this.price2CheckBox.Location = new System.Drawing.Point(401, 55);
            this.price2CheckBox.Name = "price2CheckBox";
            this.price2CheckBox.Size = new System.Drawing.Size(53, 24);
            this.price2CheckBox.TabIndex = 18;
            this.price2CheckBox.Text = "$$";
            this.price2CheckBox.UseVisualStyleBackColor = true;
            this.price2CheckBox.CheckedChanged += new System.EventHandler(this.price2CheckBox_CheckedChanged);
            // 
            // price4CheckBox
            // 
            this.price4CheckBox.AutoSize = true;
            this.price4CheckBox.Location = new System.Drawing.Point(401, 85);
            this.price4CheckBox.Name = "price4CheckBox";
            this.price4CheckBox.Size = new System.Drawing.Size(71, 24);
            this.price4CheckBox.TabIndex = 19;
            this.price4CheckBox.Text = "$$$$";
            this.price4CheckBox.UseVisualStyleBackColor = true;
            this.price4CheckBox.CheckedChanged += new System.EventHandler(this.price4CheckBox_CheckedChanged);
            // 
            // price3CheckBox
            // 
            this.price3CheckBox.AutoSize = true;
            this.price3CheckBox.Location = new System.Drawing.Point(294, 85);
            this.price3CheckBox.Name = "price3CheckBox";
            this.price3CheckBox.Size = new System.Drawing.Size(62, 24);
            this.price3CheckBox.TabIndex = 20;
            this.price3CheckBox.Text = "$$$";
            this.price3CheckBox.UseVisualStyleBackColor = true;
            this.price3CheckBox.CheckedChanged += new System.EventHandler(this.price3CheckBox_CheckedChanged);
            // 
            // filterAttributeLabel
            // 
            this.filterAttributeLabel.AutoSize = true;
            this.filterAttributeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterAttributeLabel.Location = new System.Drawing.Point(12, 179);
            this.filterAttributeLabel.Name = "filterAttributeLabel";
            this.filterAttributeLabel.Size = new System.Drawing.Size(188, 29);
            this.filterAttributeLabel.TabIndex = 21;
            this.filterAttributeLabel.Text = "filter by attribute:";
            // 
            // takeOutCheckBox
            // 
            this.takeOutCheckBox.AutoSize = true;
            this.takeOutCheckBox.Location = new System.Drawing.Point(17, 421);
            this.takeOutCheckBox.Name = "takeOutCheckBox";
            this.takeOutCheckBox.Size = new System.Drawing.Size(100, 24);
            this.takeOutCheckBox.TabIndex = 22;
            this.takeOutCheckBox.Text = "Take Out";
            this.takeOutCheckBox.UseVisualStyleBackColor = true;
            this.takeOutCheckBox.CheckedChanged += new System.EventHandler(this.takeOutCheckBox_CheckedChanged);
            // 
            // outdoorSeatingCheckBox
            // 
            this.outdoorSeatingCheckBox.AutoSize = true;
            this.outdoorSeatingCheckBox.Location = new System.Drawing.Point(17, 301);
            this.outdoorSeatingCheckBox.Name = "outdoorSeatingCheckBox";
            this.outdoorSeatingCheckBox.Size = new System.Drawing.Size(152, 24);
            this.outdoorSeatingCheckBox.TabIndex = 23;
            this.outdoorSeatingCheckBox.Text = "Outdoor Seating";
            this.outdoorSeatingCheckBox.UseVisualStyleBackColor = true;
            this.outdoorSeatingCheckBox.CheckedChanged += new System.EventHandler(this.outdoorSeatingCheckBox_CheckedChanged);
            // 
            // deliveryCheckBox
            // 
            this.deliveryCheckBox.AutoSize = true;
            this.deliveryCheckBox.Location = new System.Drawing.Point(16, 391);
            this.deliveryCheckBox.Name = "deliveryCheckBox";
            this.deliveryCheckBox.Size = new System.Drawing.Size(90, 24);
            this.deliveryCheckBox.TabIndex = 24;
            this.deliveryCheckBox.Text = "Delivery";
            this.deliveryCheckBox.UseVisualStyleBackColor = true;
            this.deliveryCheckBox.CheckedChanged += new System.EventHandler(this.deliveryCheckBox_CheckedChanged);
            // 
            // wheelchairAccessCheckBox
            // 
            this.wheelchairAccessCheckBox.AutoSize = true;
            this.wheelchairAccessCheckBox.Location = new System.Drawing.Point(17, 271);
            this.wheelchairAccessCheckBox.Name = "wheelchairAccessCheckBox";
            this.wheelchairAccessCheckBox.Size = new System.Drawing.Size(194, 24);
            this.wheelchairAccessCheckBox.TabIndex = 25;
            this.wheelchairAccessCheckBox.Text = "Wheelchair Accessible";
            this.wheelchairAccessCheckBox.UseVisualStyleBackColor = true;
            this.wheelchairAccessCheckBox.CheckedChanged += new System.EventHandler(this.wheelchairAccessCheckBox_CheckedChanged);
            // 
            // goodForGroupsCheckBox
            // 
            this.goodForGroupsCheckBox.AutoSize = true;
            this.goodForGroupsCheckBox.Location = new System.Drawing.Point(16, 361);
            this.goodForGroupsCheckBox.Name = "goodForGroupsCheckBox";
            this.goodForGroupsCheckBox.Size = new System.Drawing.Size(160, 24);
            this.goodForGroupsCheckBox.TabIndex = 26;
            this.goodForGroupsCheckBox.Text = "Good For Groups";
            this.goodForGroupsCheckBox.UseVisualStyleBackColor = true;
            this.goodForGroupsCheckBox.CheckedChanged += new System.EventHandler(this.goodForGroupsCheckBox_CheckedChanged);
            // 
            // takesReservationsCheckBox
            // 
            this.takesReservationsCheckBox.AutoSize = true;
            this.takesReservationsCheckBox.Location = new System.Drawing.Point(17, 241);
            this.takesReservationsCheckBox.Name = "takesReservationsCheckBox";
            this.takesReservationsCheckBox.Size = new System.Drawing.Size(175, 24);
            this.takesReservationsCheckBox.TabIndex = 27;
            this.takesReservationsCheckBox.Text = "Takes Reservations";
            this.takesReservationsCheckBox.UseVisualStyleBackColor = true;
            this.takesReservationsCheckBox.CheckedChanged += new System.EventHandler(this.takesReservationsCheckBox_CheckedChanged);
            // 
            // goodForKidsCheckBox
            // 
            this.goodForKidsCheckBox.AutoSize = true;
            this.goodForKidsCheckBox.Location = new System.Drawing.Point(17, 331);
            this.goodForKidsCheckBox.Name = "goodForKidsCheckBox";
            this.goodForKidsCheckBox.Size = new System.Drawing.Size(137, 24);
            this.goodForKidsCheckBox.TabIndex = 28;
            this.goodForKidsCheckBox.Text = "Good For Kids";
            this.goodForKidsCheckBox.UseVisualStyleBackColor = true;
            this.goodForKidsCheckBox.CheckedChanged += new System.EventHandler(this.goodForKidsCheckBox_CheckedChanged);
            // 
            // acceptsCCCheckBox
            // 
            this.acceptsCCCheckBox.AutoSize = true;
            this.acceptsCCCheckBox.Location = new System.Drawing.Point(17, 211);
            this.acceptsCCCheckBox.Name = "acceptsCCCheckBox";
            this.acceptsCCCheckBox.Size = new System.Drawing.Size(185, 24);
            this.acceptsCCCheckBox.TabIndex = 29;
            this.acceptsCCCheckBox.Text = "Accepts Credit Cards";
            this.acceptsCCCheckBox.UseVisualStyleBackColor = true;
            this.acceptsCCCheckBox.CheckedChanged += new System.EventHandler(this.acceptsCCCheckBox_CheckedChanged);
            // 
            // wifiCheckBox
            // 
            this.wifiCheckBox.AutoSize = true;
            this.wifiCheckBox.Location = new System.Drawing.Point(16, 451);
            this.wifiCheckBox.Name = "wifiCheckBox";
            this.wifiCheckBox.Size = new System.Drawing.Size(61, 24);
            this.wifiCheckBox.TabIndex = 30;
            this.wifiCheckBox.Text = "Wifi";
            this.wifiCheckBox.UseVisualStyleBackColor = true;
            this.wifiCheckBox.CheckedChanged += new System.EventHandler(this.wifiCheckBox_CheckedChanged);
            // 
            // bikeParkingCheckBox
            // 
            this.bikeParkingCheckBox.AutoSize = true;
            this.bikeParkingCheckBox.Location = new System.Drawing.Point(16, 481);
            this.bikeParkingCheckBox.Name = "bikeParkingCheckBox";
            this.bikeParkingCheckBox.Size = new System.Drawing.Size(123, 24);
            this.bikeParkingCheckBox.TabIndex = 31;
            this.bikeParkingCheckBox.Text = "Bike Parking";
            this.bikeParkingCheckBox.UseVisualStyleBackColor = true;
            this.bikeParkingCheckBox.CheckedChanged += new System.EventHandler(this.bikeParkingCheckBox_CheckedChanged);
            // 
            // MealLabel
            // 
            this.MealLabel.AutoSize = true;
            this.MealLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MealLabel.Location = new System.Drawing.Point(289, 124);
            this.MealLabel.Name = "MealLabel";
            this.MealLabel.Size = new System.Drawing.Size(155, 29);
            this.MealLabel.TabIndex = 32;
            this.MealLabel.Text = "filter by meal:";
            // 
            // latenightCheckBox
            // 
            this.latenightCheckBox.AutoSize = true;
            this.latenightCheckBox.Location = new System.Drawing.Point(400, 211);
            this.latenightCheckBox.Name = "latenightCheckBox";
            this.latenightCheckBox.Size = new System.Drawing.Size(96, 24);
            this.latenightCheckBox.TabIndex = 33;
            this.latenightCheckBox.Text = "latenight";
            this.latenightCheckBox.UseVisualStyleBackColor = true;
            this.latenightCheckBox.CheckedChanged += new System.EventHandler(this.latenightCheckBox_CheckedChanged);
            // 
            // lunchCheckBox
            // 
            this.lunchCheckBox.AutoSize = true;
            this.lunchCheckBox.Location = new System.Drawing.Point(294, 211);
            this.lunchCheckBox.Name = "lunchCheckBox";
            this.lunchCheckBox.Size = new System.Drawing.Size(73, 24);
            this.lunchCheckBox.TabIndex = 34;
            this.lunchCheckBox.Text = "lunch";
            this.lunchCheckBox.UseVisualStyleBackColor = true;
            this.lunchCheckBox.CheckedChanged += new System.EventHandler(this.lunchCheckBox_CheckedChanged);
            // 
            // dessertCheckBox
            // 
            this.dessertCheckBox.AutoSize = true;
            this.dessertCheckBox.Location = new System.Drawing.Point(400, 184);
            this.dessertCheckBox.Name = "dessertCheckBox";
            this.dessertCheckBox.Size = new System.Drawing.Size(88, 24);
            this.dessertCheckBox.TabIndex = 35;
            this.dessertCheckBox.Text = "dessert";
            this.dessertCheckBox.UseVisualStyleBackColor = true;
            this.dessertCheckBox.CheckedChanged += new System.EventHandler(this.dessertCheckBox_CheckedChanged);
            // 
            // brunchCheckBox
            // 
            this.brunchCheckBox.AutoSize = true;
            this.brunchCheckBox.Location = new System.Drawing.Point(294, 184);
            this.brunchCheckBox.Name = "brunchCheckBox";
            this.brunchCheckBox.Size = new System.Drawing.Size(84, 24);
            this.brunchCheckBox.TabIndex = 36;
            this.brunchCheckBox.Text = "brunch";
            this.brunchCheckBox.UseVisualStyleBackColor = true;
            this.brunchCheckBox.CheckedChanged += new System.EventHandler(this.brunchCheckBox_CheckedChanged);
            // 
            // dinnerCheckBox
            // 
            this.dinnerCheckBox.AutoSize = true;
            this.dinnerCheckBox.Location = new System.Drawing.Point(400, 156);
            this.dinnerCheckBox.Name = "dinnerCheckBox";
            this.dinnerCheckBox.Size = new System.Drawing.Size(79, 24);
            this.dinnerCheckBox.TabIndex = 37;
            this.dinnerCheckBox.Text = "dinner";
            this.dinnerCheckBox.UseVisualStyleBackColor = true;
            this.dinnerCheckBox.CheckedChanged += new System.EventHandler(this.dinnerCheckBox_CheckedChanged);
            // 
            // breakfastCheckBox
            // 
            this.breakfastCheckBox.AutoSize = true;
            this.breakfastCheckBox.Location = new System.Drawing.Point(294, 156);
            this.breakfastCheckBox.Name = "breakfastCheckBox";
            this.breakfastCheckBox.Size = new System.Drawing.Size(102, 24);
            this.breakfastCheckBox.TabIndex = 38;
            this.breakfastCheckBox.Text = "breakfast";
            this.breakfastCheckBox.UseVisualStyleBackColor = true;
            this.breakfastCheckBox.CheckedChanged += new System.EventHandler(this.breakfastCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 684);
            this.Controls.Add(this.breakfastCheckBox);
            this.Controls.Add(this.dinnerCheckBox);
            this.Controls.Add(this.brunchCheckBox);
            this.Controls.Add(this.dessertCheckBox);
            this.Controls.Add(this.lunchCheckBox);
            this.Controls.Add(this.latenightCheckBox);
            this.Controls.Add(this.MealLabel);
            this.Controls.Add(this.bikeParkingCheckBox);
            this.Controls.Add(this.wifiCheckBox);
            this.Controls.Add(this.acceptsCCCheckBox);
            this.Controls.Add(this.goodForKidsCheckBox);
            this.Controls.Add(this.takesReservationsCheckBox);
            this.Controls.Add(this.goodForGroupsCheckBox);
            this.Controls.Add(this.wheelchairAccessCheckBox);
            this.Controls.Add(this.deliveryCheckBox);
            this.Controls.Add(this.outdoorSeatingCheckBox);
            this.Controls.Add(this.takeOutCheckBox);
            this.Controls.Add(this.filterAttributeLabel);
            this.Controls.Add(this.price3CheckBox);
            this.Controls.Add(this.price4CheckBox);
            this.Controls.Add(this.price2CheckBox);
            this.Controls.Add(this.price1CheckBox);
            this.Controls.Add(this.filterByPriceLabel);
            this.Controls.Add(this.sortByComboBox);
            this.Controls.Add(this.sortByLabel);
            this.Controls.Add(this.currentCatlabel);
            this.Controls.Add(this.currentCategoriesTextBox);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.busCatbutton);
            this.Controls.Add(this.busCatListBox);
            this.Controls.Add(this.businessGrid);
            this.Controls.Add(this.businessCatLabel);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.zipcodeComboBox);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.stateComboBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.ComboBox zipcodeComboBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label zipCodeLabel;
        private System.Windows.Forms.Label businessCatLabel;
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.ListBox busCatListBox;
        private System.Windows.Forms.Button busCatbutton;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.TextBox currentCategoriesTextBox;
        private System.Windows.Forms.Label currentCatlabel;
        private System.Windows.Forms.Label sortByLabel;
        private System.Windows.Forms.ComboBox sortByComboBox;
        private System.Windows.Forms.Label filterByPriceLabel;
        private System.Windows.Forms.CheckBox price1CheckBox;
        private System.Windows.Forms.CheckBox price2CheckBox;
        private System.Windows.Forms.CheckBox price4CheckBox;
        private System.Windows.Forms.CheckBox price3CheckBox;
        private System.Windows.Forms.Label filterAttributeLabel;
        private System.Windows.Forms.CheckBox takeOutCheckBox;
        private System.Windows.Forms.CheckBox outdoorSeatingCheckBox;
        private System.Windows.Forms.CheckBox deliveryCheckBox;
        private System.Windows.Forms.CheckBox wheelchairAccessCheckBox;
        private System.Windows.Forms.CheckBox goodForGroupsCheckBox;
        private System.Windows.Forms.CheckBox takesReservationsCheckBox;
        private System.Windows.Forms.CheckBox goodForKidsCheckBox;
        private System.Windows.Forms.CheckBox acceptsCCCheckBox;
        private System.Windows.Forms.CheckBox wifiCheckBox;
        private System.Windows.Forms.CheckBox bikeParkingCheckBox;
        private System.Windows.Forms.Label MealLabel;
        private System.Windows.Forms.CheckBox latenightCheckBox;
        private System.Windows.Forms.CheckBox lunchCheckBox;
        private System.Windows.Forms.CheckBox dessertCheckBox;
        private System.Windows.Forms.CheckBox brunchCheckBox;
        private System.Windows.Forms.CheckBox dinnerCheckBox;
        private System.Windows.Forms.CheckBox breakfastCheckBox;
    }
}

