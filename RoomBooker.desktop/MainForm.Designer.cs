namespace RoomBooker_Desktop
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPageCustomers = new TabPage();
            dataGridView1 = new DataGridView();
            customerBindingSource = new BindingSource(components);
            tabPageRooms = new TabPage();
            dataGridView2 = new DataGridView();
            iDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            roomNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pricePerNightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookingsDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            roomBindingSource = new BindingSource(components);
            tabPageBookings = new TabPage();
            dataGridView3 = new DataGridView();
            bookingBindingSource = new BindingSource(components);
            roomDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roomIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateToDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateFromDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            bookingsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabPageCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).BeginInit();
            tabPageRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomBindingSource).BeginInit();
            tabPageBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookingBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageCustomers);
            tabControl1.Controls.Add(tabPageRooms);
            tabControl1.Controls.Add(tabPageBookings);
            tabControl1.Location = new Point(37, 48);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(944, 473);
            tabControl1.TabIndex = 1;
            // 
            // tabPageCustomers
            // 
            tabPageCustomers.Controls.Add(dataGridView1);
            tabPageCustomers.Location = new Point(4, 29);
            tabPageCustomers.Name = "tabPageCustomers";
            tabPageCustomers.Padding = new Padding(3);
            tabPageCustomers.Size = new Size(936, 440);
            tabPageCustomers.TabIndex = 0;
            tabPageCustomers.Text = "Customers";
            tabPageCustomers.UseVisualStyleBackColor = true;
            tabPageCustomers.Click += tabPageCustomers_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, bookingsDataGridViewTextBoxColumn });
            dataGridView1.DataSource = customerBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(930, 434);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // customerBindingSource
            // 
            customerBindingSource.DataSource = typeof(RoomBooker.Models.Customer);
            // 
            // tabPageRooms
            // 
            tabPageRooms.Controls.Add(dataGridView2);
            tabPageRooms.Location = new Point(4, 29);
            tabPageRooms.Name = "tabPageRooms";
            tabPageRooms.Padding = new Padding(3);
            tabPageRooms.Size = new Size(936, 440);
            tabPageRooms.TabIndex = 1;
            tabPageRooms.Text = "Rooms";
            tabPageRooms.UseVisualStyleBackColor = true;
            tabPageRooms.Click += tabControl_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn1, roomNumberDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, pricePerNightDataGridViewTextBoxColumn, bookingsDataGridViewTextBoxColumn1 });
            dataGridView2.DataSource = roomBindingSource;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(930, 434);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            iDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            iDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // roomNumberDataGridViewTextBoxColumn
            // 
            roomNumberDataGridViewTextBoxColumn.DataPropertyName = "RoomNumber";
            roomNumberDataGridViewTextBoxColumn.HeaderText = "RoomNumber";
            roomNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            roomNumberDataGridViewTextBoxColumn.Name = "roomNumberDataGridViewTextBoxColumn";
            roomNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Type";
            typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.Width = 125;
            // 
            // pricePerNightDataGridViewTextBoxColumn
            // 
            pricePerNightDataGridViewTextBoxColumn.DataPropertyName = "PricePerNight";
            pricePerNightDataGridViewTextBoxColumn.HeaderText = "PricePerNight";
            pricePerNightDataGridViewTextBoxColumn.MinimumWidth = 6;
            pricePerNightDataGridViewTextBoxColumn.Name = "pricePerNightDataGridViewTextBoxColumn";
            pricePerNightDataGridViewTextBoxColumn.Width = 125;
            // 
            // bookingsDataGridViewTextBoxColumn1
            // 
            bookingsDataGridViewTextBoxColumn1.DataPropertyName = "Bookings";
            bookingsDataGridViewTextBoxColumn1.HeaderText = "Bookings";
            bookingsDataGridViewTextBoxColumn1.MinimumWidth = 6;
            bookingsDataGridViewTextBoxColumn1.Name = "bookingsDataGridViewTextBoxColumn1";
            bookingsDataGridViewTextBoxColumn1.Width = 125;
            // 
            // roomBindingSource
            // 
            roomBindingSource.DataSource = typeof(RoomBooker.Models.Room);
            // 
            // tabPageBookings
            // 
            tabPageBookings.Controls.Add(dataGridView3);
            tabPageBookings.Location = new Point(4, 29);
            tabPageBookings.Name = "tabPageBookings";
            tabPageBookings.Padding = new Padding(3);
            tabPageBookings.Size = new Size(936, 440);
            tabPageBookings.TabIndex = 1;
            tabPageBookings.Text = "Bookings";
            tabPageBookings.UseVisualStyleBackColor = true;
            tabPageBookings.Click += tabControl_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn2, dateFromDataGridViewTextBoxColumn, dateToDataGridViewTextBoxColumn, customerIdDataGridViewTextBoxColumn, roomIdDataGridViewTextBoxColumn, customerDataGridViewTextBoxColumn, roomDataGridViewTextBoxColumn });
            dataGridView3.DataSource = bookingBindingSource;
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(3, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(930, 434);
            dataGridView3.TabIndex = 0;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // bookingBindingSource
            // 
            bookingBindingSource.DataSource = typeof(RoomBooker.Models.Booking);
            // 
            // roomDataGridViewTextBoxColumn
            // 
            roomDataGridViewTextBoxColumn.DataPropertyName = "Room";
            roomDataGridViewTextBoxColumn.HeaderText = "Room";
            roomDataGridViewTextBoxColumn.MinimumWidth = 6;
            roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            roomDataGridViewTextBoxColumn.Width = 125;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn.MinimumWidth = 6;
            customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            customerDataGridViewTextBoxColumn.Width = 125;
            // 
            // roomIdDataGridViewTextBoxColumn
            // 
            roomIdDataGridViewTextBoxColumn.DataPropertyName = "RoomId";
            roomIdDataGridViewTextBoxColumn.HeaderText = "RoomId";
            roomIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            roomIdDataGridViewTextBoxColumn.Name = "roomIdDataGridViewTextBoxColumn";
            roomIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            customerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            customerIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateToDataGridViewTextBoxColumn
            // 
            dateToDataGridViewTextBoxColumn.DataPropertyName = "DateTo";
            dateToDataGridViewTextBoxColumn.HeaderText = "DateTo";
            dateToDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateToDataGridViewTextBoxColumn.Name = "dateToDataGridViewTextBoxColumn";
            dateToDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateFromDataGridViewTextBoxColumn
            // 
            dateFromDataGridViewTextBoxColumn.DataPropertyName = "DateFrom";
            dateFromDataGridViewTextBoxColumn.HeaderText = "DateFrom";
            dateFromDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateFromDataGridViewTextBoxColumn.Name = "dateFromDataGridViewTextBoxColumn";
            dateFromDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn2
            // 
            idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn2.HeaderText = "Id";
            idDataGridViewTextBoxColumn2.MinimumWidth = 6;
            idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            idDataGridViewTextBoxColumn2.Width = 125;
            // 
            // bookingsDataGridViewTextBoxColumn
            // 
            bookingsDataGridViewTextBoxColumn.DataPropertyName = "Bookings";
            bookingsDataGridViewTextBoxColumn.HeaderText = "Bookings";
            bookingsDataGridViewTextBoxColumn.MinimumWidth = 6;
            bookingsDataGridViewTextBoxColumn.Name = "bookingsDataGridViewTextBoxColumn";
            bookingsDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 920);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "RoomBooker";
            tabControl1.ResumeLayout(false);
            tabPageCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).EndInit();
            tabPageRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomBindingSource).EndInit();
            tabPageBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookingBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPageCustomers;
        private TabPage tabPageRooms;
        private TabPage tabPageBookings;
        private DataGridView dataGridView1;
        private BindingSource customerBindingSource;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn roomNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pricePerNightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bookingsDataGridViewTextBoxColumn1;
        private BindingSource roomBindingSource;
        private DataGridView dataGridView3;
        private BindingSource bookingBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bookingsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dateFromDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateToDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roomIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
    }
}