using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.UI.Controls;
using InventoryManagementSystem.UI.Models;

namespace InventoryManagementSystem.UI
{
    public class AddProductForm : Form
    {
        private TextBox _nameTextBox;
        private TextBox _quantityTextBox;
        private TextBox _priceTextBox;
        private ComboBox _supplierComboBox;
        private ComboBox _productTypeComboBox;
        private TextBox _warrantyTextBox;
        private DateTimePicker _expiryDatePicker;
        private Label _warrantyLabel;
        private Label _expiryLabel;
        private Button3D _addButton;
        private Inventory _inventory;
        private List<Supplier> _suppliers;

        public AddProductForm(Inventory inventory)
        {
            _inventory = inventory;
            _suppliers = new List<Supplier>
            {
                new Supplier { SupplierId = 1, SupplierName = "Supplier A", Contact = "contactA@example.com" },
                new Supplier { SupplierId = 2, SupplierName = "Supplier B", Contact = "contactB@example.com" },
                new Supplier { SupplierId = 3, SupplierName = "Supplier C", Contact = "contactC@example.com" }
            };

            this.Text = "Add Product";
            this.Size = new Size(400, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(18, 18, 18);

            // Product Type
            _productTypeComboBox = new ComboBox { Location = new Point(50, 50), Size = new Size(300, 20) };
            _productTypeComboBox.Items.AddRange(new string[] { "Product", "ElectronicProduct", "GroceryProduct" });
            _productTypeComboBox.SelectedIndex = 0;
            _productTypeComboBox.SelectedIndexChanged += ProductTypeChanged;
            this.Controls.Add(new Label { Text = "Product Type:", ForeColor = Color.White, Location = new Point(50, 30) });
            this.Controls.Add(_productTypeComboBox);

            // Name
            _nameTextBox = new TextBox { Location = new Point(50, 100), Size = new Size(300, 20) };
            this.Controls.Add(new Label { Text = "Name:", ForeColor = Color.White, Location = new Point(50, 80) });
            this.Controls.Add(_nameTextBox);

            // Quantity
            _quantityTextBox = new TextBox { Location = new Point(50, 150), Size = new Size(300, 20) };
            this.Controls.Add(new Label { Text = "Quantity:", ForeColor = Color.White, Location = new Point(50, 130) });
            this.Controls.Add(_quantityTextBox);

            // Price
            _priceTextBox = new TextBox { Location = new Point(50, 200), Size = new Size(300, 20) };
            this.Controls.Add(new Label { Text = "Price:", ForeColor = Color.White, Location = new Point(50, 180) });
            this.Controls.Add(_priceTextBox);

            // Supplier
            _supplierComboBox = new ComboBox { Location = new Point(50, 250), Size = new Size(300, 20) };
            _supplierComboBox.DataSource = _suppliers;
            _supplierComboBox.DisplayMember = "SupplierName";
            this.Controls.Add(new Label { Text = "Supplier:", ForeColor = Color.White, Location = new Point(50, 230) });
            this.Controls.Add(_supplierComboBox);

            // Warranty (hidden initially)
            _warrantyTextBox = new TextBox { Location = new Point(50, 300), Size = new Size(300, 20), Visible = false };
            _warrantyLabel = new Label { Text = "Warranty Months:", ForeColor = Color.White, Location = new Point(50, 280), Visible = false };
            this.Controls.Add(_warrantyLabel);
            this.Controls.Add(_warrantyTextBox);

            // Expiry Date (hidden initially)
            _expiryDatePicker = new DateTimePicker { Location = new Point(50, 350), Size = new Size(300, 20), Visible = false };
            _expiryLabel = new Label { Text = "Expiry Date:", ForeColor = Color.White, Location = new Point(50, 330), Visible = false };
            this.Controls.Add(_expiryLabel);
            this.Controls.Add(_expiryDatePicker);

            // Add Button
            _addButton = new Button3D { Text = "Add", Location = new Point(150, 400), Size = new Size(100, 40) };
            _addButton.Click += AddButtonClick;
            this.Controls.Add(_addButton);
        }

        private void ProductTypeChanged(object sender, EventArgs e)
        {
            string type = _productTypeComboBox.SelectedItem.ToString();
            _warrantyTextBox.Visible = type == "ElectronicProduct";
            _warrantyLabel.Visible = type == "ElectronicProduct";
            _expiryDatePicker.Visible = type == "GroceryProduct";
            _expiryLabel.Visible = type == "GroceryProduct";
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_nameTextBox.Text) || !int.TryParse(_quantityTextBox.Text, out int quantity) || !double.TryParse(_priceTextBox.Text, out double price) || _supplierComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            Product newProduct;
            string type = _productTypeComboBox.SelectedItem.ToString();
            if (type == "ElectronicProduct")
            {
                if (!int.TryParse(_warrantyTextBox.Text, out int warranty))
                {
                    MessageBox.Show("Invalid warranty months.");
                    return;
                }
                newProduct = new ElectronicProduct
                {
                    ProductID = _inventory.GetProducts().Count + 1,
                    Name = _nameTextBox.Text,
                    Quantity = quantity,
                    Price = price,
                    Supplier = (Supplier)_supplierComboBox.SelectedItem,
                    WarrantyMonths = warranty
                };
            }
            else if (type == "GroceryProduct")
            {
                newProduct = new GroceryProduct
                {
                    ProductID = _inventory.GetProducts().Count + 1,
                    Name = _nameTextBox.Text,
                    Quantity = quantity,
                    Price = price,
                    Supplier = (Supplier)_supplierComboBox.SelectedItem,
                    ExpiryDate = _expiryDatePicker.Value
                };
            }
            else
            {
                newProduct = new Product
                {
                    ProductID = _inventory.GetProducts().Count + 1,
                    Name = _nameTextBox.Text,
                    Quantity = quantity,
                    Price = price,
                    Supplier = (Supplier)_supplierComboBox.SelectedItem
                };
            }

            _inventory.AddProduct(newProduct);
            MessageBox.Show("Product added successfully!");
            this.Close();
        }
    }
}
