using ACS_GSchellenbergM3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_GSchellenbergM7
{
    public partial class Cart : Form
    {

        public string Subtotal,TaxedAmount,TotalDue;

        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            ReloadCartDB();
        }

        private void ReloadCartDB()
        {
            DBConnect.DatabaseCommandTCGCart(lbxCart, "SELECT * FROM Cart;");
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            double subtotal = 0;
            const double TAX_AMOUNT = 0.0825;
            double taxedAmount = 0;
            double totalDue = 0;

            foreach (DataRow row in DBConnect.DTTCGCartTable.Rows)
            {
                // Safely check for null and convert to string
                string totalStr = row["Total"]?.ToString();

                if (double.TryParse(totalStr, out double total))
                {
                    subtotal += total;
                }
                else
                {
                    MessageBox.Show("Error calculating total: " + totalStr);
                }
            }

            taxedAmount = TAX_AMOUNT * subtotal;
            totalDue = subtotal + taxedAmount;

            Subtotal = subtotal.ToString("0.00");
            TaxedAmount = taxedAmount.ToString("0.00");
            TotalDue = totalDue.ToString("0.00");

            lblWriteSubtotal.Text = Subtotal.ToString();
            lblWriteTaxAmount.Text = TaxedAmount.ToString();
            lblWriteTotalDue.Text = TotalDue.ToString();

        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Close();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in DBConnect.DTTCGCartTable.Rows)
            {
                // Initialize new builders for each row
                StringBuilder ProductUPCsb = new StringBuilder();
                StringBuilder StockSB = new StringBuilder();
                StringBuilder CartIDSB = new StringBuilder();

                StockSB.Append(row["Quantity"].ToString());
                CartIDSB.Append(row["CartID"].ToString());

                foreach (DataRow row2 in DBConnect.DTTCGStoreTable.Rows)
                {
                    if (row["ProductUPC"].ToString().Equals(row2["ProductUPC"].ToString()))
                    {
                        ProductUPCsb.Append(row2["ProductUPC"].ToString());
                    }
                }

                if (int.TryParse(StockSB.ToString(), out int Stock))
                {
                    if (int.TryParse(CartIDSB.ToString(), out int CartID))
                    {
                        // Only calls if match was found in nested loop
                        if (ProductUPCsb.Length > 0)
                        {
                            ReturnItems(ProductUPCsb.ToString(), Stock, CartID);
                        }
                    }
                }
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxCart.SelectedIndex != 0 && lbxCart.SelectedIndex % 2 == 0)
            {
                //Gets Name
                string clickedItem = lbxCart.SelectedItem.ToString();
                string[] clickedItemparts = clickedItem.Split('|');
                string productName = clickedItemparts[0].Trim();



                foreach (DataRow row in DBConnect.DTTCGCartTable.Rows)
                {
                    StringBuilder ProductUPCsb = new StringBuilder();
                    StringBuilder StockSB = new StringBuilder();
                    StringBuilder CartIDSB = new StringBuilder();
                    StringBuilder ProductNameSB = new StringBuilder();

                    ProductNameSB.Append(row["ProductName"].ToString());
                    StockSB.Append(row["Quantity"].ToString());
                    CartIDSB.Append(row["CartID"].ToString());

                    foreach (DataRow row2 in DBConnect.DTTCGStoreTable.Rows)
                    {
                        if (row["ProductUPC"].ToString().Equals(row2["ProductUPC"].ToString()))
                        {
                            ProductUPCsb.Append(row2["ProductUPC"].ToString());
                        }

                    }

                    if (ProductNameSB.ToString().Equals(productName))
                    {
                        if (int.TryParse(StockSB.ToString(), out int Stock))
                        {
                            if (int.TryParse(CartIDSB.ToString(), out int CartID))
                            {
                                if (ProductUPCsb.Length > 0)
                                {
                                    ReturnItems(ProductUPCsb.ToString(), Stock, CartID);
                                }
                                else
                                {
                                    MessageBox.Show("Error ProductUPC not availible");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ReturnItems(string productUPC, int returnableStock, int CartID)
        {
            int NewProductStock = 0;
            if (returnableStock > 0)
            {
                StringBuilder productStockSB = new StringBuilder();
                StringBuilder PNameSB = new StringBuilder();
                DataRow[] StoreRow;
                DataRow[] CartRow;

                //cant find column
                StoreRow = DBConnect.DTTCGStoreTable.Select("ProductUPC = '" + productUPC.Replace("'", "''") + "'");
                CartRow = DBConnect.DTTCGCartTable.Select("ProductUPC = '" + productUPC + "'");

                foreach (DataRow row in CartRow)
                {
                    foreach (DataRow row2 in StoreRow)
                    {
                        productStockSB.Append(row2["Stock"].ToString());
                    }
                    //allows data out of foreach loop
                    PNameSB.Append(row["ProductName"].ToString());
                }
                if (int.TryParse(productStockSB.ToString(), out int ProductStock))
                {
                    NewProductStock = ProductStock + returnableStock;
                    DBConnect.SelectStatementReturnsDT("DELETE FROM Cart WHERE CartID = '" + CartID + "';");
                    DBConnect.SelectStatementReturnsDT("UPDATE Products SET Stock = '" + NewProductStock + "' WHERE ProductUPC = '" + productUPC + "';");
                    ReloadCartDB();
                    returnableStock = 0;
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (DBConnect.DTTCGCartTable.Rows.Count > 0) 
            {
                int accountnum;

                DialogResult result = MessageBox.Show("Do you wish to login/create an account?", "User Login", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    accountnum = LogIntoAccount();
                }
                else
                {//guest account num
                    accountnum = 1;
                }

                int orderID = CreateOrder(accountnum);

                CreateReceipt(accountnum, orderID);
                ReloadCartDB();
            }
            else
            {
                MessageBox.Show("Sorry you cant check out without items in your cart");
            }
        }

        private int LogIntoAccount()
        {
            DialogResult result = MessageBox.Show("Do you have an account?", "User Login", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                AccountCreation();
            }
            AccountLogin login = new AccountLogin(0); 
            login.ShowDialog();
            return AccountLogin.AccountNum;
        }

        private void AccountCreation()
        {
            AccountLogin login = new AccountLogin(1);
            login.ShowDialog();
        }

        private void CreateReceipt(int AccountNumber, int orderID)
        {
            string title = "Receipt";

            DBConnect.SelectStatementReturnsDT("SELECT * FROM Cart");

            clsReceipt.PrintReceipt(clsReceipt.GenergateReceipt(title, Subtotal, TaxedAmount, TotalDue,AccountNumber,  orderID));
            clsReceipt.GenergateReceipt(title, Subtotal, TaxedAmount, TotalDue, AccountNumber, orderID).Clear();
        }

        private int CreateOrder(int CustomerNumber)
        {
            //if had payments would make payment method
            //
            double total = 0;
            double loyaltyPoints = 0;
            int OrderID =0;
            foreach (DataRow row in DBConnect.DTTCGCartTable.Rows)
            {
                total += double.Parse(row["Total"].ToString());
                int ProductUPC = int.Parse(row["ProductUPC"].ToString());
                int OrderQuantity = int.Parse(row["Quantity"].ToString());
                
                DBConnect.SelectStatementReturnsDT($"INSERT INTO Orders (ProductUPC, CustID) OUTPUT INSERTED.OrderID VALUES ('{ProductUPC}','{CustomerNumber}');");
                
                foreach(DataRow row2 in DBConnect.DTTCGGenericTable.Rows)
                {
                    OrderID = int.Parse(row2["OrderID"].ToString());
                    DBConnect.SelectStatementReturnsDT($"INSERT INTO OrderDetails (OrderID, ProductUPC, OrderQuantity) Values ('{OrderID}','{ProductUPC}','{OrderQuantity}')");
                }
            }

            loyaltyPoints = total / 100;

            string formattedPoints = loyaltyPoints.ToString("F2");

            loyaltyPoints = double.Parse(formattedPoints);

            DBConnect.SelectStatementReturnsDT($"UPDATE Customers SET LoyaltyPoints = LoyaltyPoints + '{loyaltyPoints}'");
            DBConnect.SelectStatementReturnsDT("DELETE FROM Cart;");
            //if its NOT the guest Account
            if (CustomerNumber != 1)
            {
                MessageBox.Show($"You've Earned {loyaltyPoints} Loyalty Points");
            }
            return OrderID;
        }
    }
}
