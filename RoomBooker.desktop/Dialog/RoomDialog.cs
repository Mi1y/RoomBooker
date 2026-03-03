using RoomBooker.Models;

namespace RoomBooker_Desktop.Dialog
{
    public class RoomDialog : Form
    {
        private readonly TextBox txtRoomNumber;
        private readonly TextBox txtType;
        private readonly TextBox txtPrice;

        public Room Room { get; }

        public RoomDialog(Room? existing = null)
        {
            Room = existing ?? new Room();
            Text = Room.ID == 0 ? "Add Room" : "Edit Room";
            Size = new Size(360, 215);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = MinimizeBox = false;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(12)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            txtRoomNumber = new TextBox { Dock = DockStyle.Fill, Text = Room.RoomNumber };
            txtType = new TextBox { Dock = DockStyle.Fill, Text = Room.Type };
            txtPrice = new TextBox { Dock = DockStyle.Fill, Text = Room.PricePerNight.ToString("F2") };

            layout.Controls.Add(new Label { Text = "Room No:", Anchor = AnchorStyles.Left }, 0, 0);
            layout.Controls.Add(txtRoomNumber, 1, 0);
            layout.Controls.Add(new Label { Text = "Type:", Anchor = AnchorStyles.Left }, 0, 1);
            layout.Controls.Add(txtType, 1, 1);
            layout.Controls.Add(new Label { Text = "Price/Night:", Anchor = AnchorStyles.Left }, 0, 2);
            layout.Controls.Add(txtPrice, 1, 2);

            var btnSave = new Button { Text = "Save", Width = 75 };
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

            btnSave.Click += (_, _) =>
            {
                if (!decimal.TryParse(txtPrice.Text, out var price) || price < 0)
                {
                    MessageBox.Show("Enter a valid price.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Room.RoomNumber = txtRoomNumber.Text.Trim();
                Room.Type = txtType.Text.Trim();
                Room.PricePerNight = price;
                DialogResult = DialogResult.OK;
            };

            var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            btnPanel.Controls.AddRange([btnCancel, btnSave]);
            layout.Controls.Add(btnPanel, 1, 3);

            Controls.Add(layout);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }
    }
}