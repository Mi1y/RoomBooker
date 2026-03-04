using RoomBooker.Models;

namespace RoomBooker.desktop.Dialog
{
    public class CustomerDialog : Form
    {
        private readonly TextBox txtName;
        private readonly TextBox txtEmail;
        private readonly TextBox txtPhone;

        public Customer Customer { get; }

        public CustomerDialog(Customer? existing = null)
        {
            Customer = existing ?? new Customer();
            Text = Customer.Id == 0 ? "Add Customer" : "Edit Customer";
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
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            txtName = new TextBox { Dock = DockStyle.Fill, Text = Customer.Name };
            txtEmail = new TextBox { Dock = DockStyle.Fill, Text = Customer.Email };
            txtPhone = new TextBox { Dock = DockStyle.Fill, Text = Customer.Phone };

            layout.Controls.Add(new Label { Text = "Name:", Anchor = AnchorStyles.Left }, 0, 0);
            layout.Controls.Add(txtName, 1, 0);
            layout.Controls.Add(new Label { Text = "Email:", Anchor = AnchorStyles.Left }, 0, 1);
            layout.Controls.Add(txtEmail, 1, 1);
            layout.Controls.Add(new Label { Text = "Phone:", Anchor = AnchorStyles.Left }, 0, 2);
            layout.Controls.Add(txtPhone, 1, 2);

            var btnSave = new Button { Text = "Save", Width = 75 };
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

            btnSave.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Customer.Name = txtName.Text.Trim();
                Customer.Email = txtEmail.Text.Trim();
                Customer.Phone = txtPhone.Text.Trim();
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