using RoomBooker.Models;

namespace RoomBooker.desktop.Dialog
{
    public class BookingDialog : Form
    {
        private readonly ComboBox cboCustomer;
        private readonly ComboBox cboRoom;
        private readonly DateTimePicker dtpFrom;
        private readonly DateTimePicker dtpTo;

        public Booking Booking { get; }

        public BookingDialog(IList<Customer> customers, IList<Room> rooms, Booking? existing = null)
        {
            Booking = existing ?? new Booking();
            Text = Booking.Id == 0 ? "Add Booking" : "Edit Booking";
            Size = new Size(380, 255);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = MinimizeBox = false;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
                Padding = new Padding(12)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            cboCustomer = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList,
            DataSource = customers, DisplayMember = "Name", ValueMember = "Id" };
            
            cboRoom = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList,
            DataSource = rooms, DisplayMember = "RoomNumber", ValueMember = "ID" };
            dtpFrom = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };
            dtpTo = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };

            if (existing is not null)
            {
                cboCustomer.SelectedValue = existing.CustomerId;
                cboRoom.SelectedValue = existing.RoomId;
                if (existing.DateFrom.HasValue)
                    dtpFrom.Value = existing.DateFrom.Value.ToDateTime(TimeOnly.MinValue);
                if (existing.DateTo.HasValue)
                    dtpTo.Value = existing.DateTo.Value.ToDateTime(TimeOnly.MinValue);
            }

            layout.Controls.Add(new Label { Text = "Customer:", Anchor = AnchorStyles.Left }, 0, 0);
            layout.Controls.Add(cboCustomer, 1, 0);
            layout.Controls.Add(new Label { Text = "Room:", Anchor = AnchorStyles.Left }, 0, 1);
            layout.Controls.Add(cboRoom, 1, 1);
            layout.Controls.Add(new Label { Text = "From:", Anchor = AnchorStyles.Left }, 0, 2);
            layout.Controls.Add(dtpFrom, 1, 2);
            layout.Controls.Add(new Label { Text = "To:", Anchor = AnchorStyles.Left }, 0, 3);
            layout.Controls.Add(dtpTo, 1, 3);

            var btnSave = new Button { Text = "Save", Width = 75 };
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

            btnSave.Click += (_, _) =>
            {
                if (cboCustomer.SelectedValue is null || cboRoom.SelectedValue is null)
                {
                    MessageBox.Show("Select a customer and a room.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpTo.Value.Date <= dtpFrom.Value.Date)
                {
                    MessageBox.Show("Check-out must be after check-in.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Booking.CustomerId = (int)cboCustomer.SelectedValue;
                Booking.RoomId = (int)cboRoom.SelectedValue;
                Booking.DateFrom = DateOnly.FromDateTime(dtpFrom.Value);
                Booking.DateTo = DateOnly.FromDateTime(dtpTo.Value);
                DialogResult = DialogResult.OK;
            };

            var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            btnPanel.Controls.AddRange([btnCancel, btnSave]);
            layout.Controls.Add(btnPanel, 1, 4);

            Controls.Add(layout);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }
    }
}