using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//not copy

namespace ACS_GSchellenbergM7
{
    public partial class Shop : Form
    {
        //public because it is used and modified quickly(and would save alot of repedative code)
        Object upcNum;
        DataRow[] CurrentRow;


        public Shop()
        {
            InitializeComponent();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            this.Close();
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            DBConnect.OpenDatabase();
            ReloadStoreDB();
        }

        public void ReloadStoreDB()
        {
            DBConnect.DatabaseCommandTCGStore(dataGridView1, "SELECT * FROM Products;");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowImage()
        {
            //finds location of folder "Images" and saves it
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

            //This is the match save
            string correctImagePath = null;

            StringBuilder imageIDSB = new StringBuilder();

            foreach (DataRow row in CurrentRow)
            {
                //allows data out of foreach loop
                imageIDSB.Append(row["ImageID"].ToString());
            }
            //saves image link to string
            string imageID = imageIDSB.ToString();

            //checks if directory exists to the path
            if (Directory.Exists(imagePath))
            {   //gets all images from file
                string[] files = Directory.GetFiles(imagePath);

                //looks through files
                foreach (string filePath in files)
                {   //puts file name to a string for comparason
                    string fileName = Path.GetFileName(filePath);

                    //compares needed file to current file
                    if (fileName.Contains(imageID))
                    {   //if correct saves the file path
                        correctImagePath = filePath;
                        break;
                    }
                }
                try
                {
                    //trys to put image to pic box
                    pictureBox1.Image = System.Drawing.Image.FromFile(correctImagePath);
                }
                catch (Exception ex)
                {   // if has error, tells user
                    MessageBox.Show("Image Not Found, Please Contact Support");
                }


            }
        }

        private void ShowStock()
        {
            cbxStock.Items.Clear();
            StringBuilder StockSB = new StringBuilder();

            foreach (DataRow row in CurrentRow)
            {
                //allows data out of foreach loop
                StockSB.Append(row["Stock"].ToString());
            }
            if (int.TryParse(StockSB.ToString(), out int Stock))
            {
                for (int i = 0; i <= Stock; i++)
                {
                    cbxStock.Items.Add(i);
                }
            }
            cbxStock.SelectedIndex = 0;
        }

        private void UpdateStock(int NewStockAmount)
        {
            cbxStock.Items.Clear();
            for (int i = 0; i <= NewStockAmount; i++)
            {
                cbxStock.Items.Add(i);
            }
            cbxStock.SelectedIndex = 0;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                StringBuilder ProductUPCsb = new StringBuilder();
                StringBuilder StockSB = new StringBuilder();

                foreach (DataRow row in CurrentRow)
                {
                    ProductUPCsb.Clear();
                    StockSB.Clear();
                    //allows data out of foreach loop
                    StockSB.Append(row["Stock"].ToString());
                    ProductUPCsb.Append(row["ProductUPC"].ToString());
                }
                if (int.TryParse(StockSB.ToString(), out int Stock))
                {
                    if (int.TryParse(cbxStock.SelectedIndex.ToString(), out int ChosenStock))
                    {
                        if (Stock >= ChosenStock)
                        {
                            int LeftOverStock = Stock - ChosenStock;
                            AddAmountToCart(ChosenStock, ProductUPCsb.ToString());
                            UpdateStock(LeftOverStock);
                            ReloadStoreDB();
                        }
                        else
                        {
                            MessageBox.Show("Not Enough Stock Please Try Again");
                            cbxStock.SelectedIndex = 0;
                        }
                        ChosenStock = 0;
                    }
                    Stock = 0;
                }
            }
        }
        private void AddAmountToCart(int cartStock, string productUPC)
        {
            int NewProductStock = 0;
            if (cartStock > 0)
            {
                StringBuilder PStockSB = new StringBuilder();
                StringBuilder PNameSB = new StringBuilder();

                DataRow[] NewRow = DBConnect.DTTCGStoreTable.Select("ProductUPC = '" + productUPC + "'");

                foreach (DataRow row in NewRow)
                {
                    
                    //allows data out of foreach loop
                    PStockSB.Append(row["Stock"].ToString());
                    PNameSB.Append(row["ProductName"].ToString());
                }
                if (int.TryParse(PStockSB.ToString(), out int ProductStock))
                {
                    NewProductStock = ProductStock - cartStock;
                    DBConnect.SelectStatementReturnsDT("INSERT INTO Cart (ProductUPC, Quantity) " +
                        "VALUES (" + productUPC + ", " + cartStock + ");");
                    DBConnect.SelectStatementReturnsDT("UPDATE Products SET Stock = '" + NewProductStock + "' WHERE ProductUPC = '" + productUPC + "';");
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                int gridSize = dataGridView1.Rows.Count - 1;

                if (rowIndex >= 0 && rowIndex < gridSize)
                {
                    //saves the row you clicked on
                    upcNum = dataGridView1.Rows[rowIndex].Cells["ProductUPC"].Value;

                    //gets the pk of the row for further use
                    CurrentRow = DBConnect.DTTCGStoreTable.Select("ProductUPC = '" + upcNum.ToString().Replace("'", "''") + "'");

                    ShowImage();
                    ShowStock();
                }
            }
        }
    }
}
