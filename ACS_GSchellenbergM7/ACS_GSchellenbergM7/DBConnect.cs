using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_GSchellenbergM7
{
    internal class DBConnect
    {
        static bool isOpen = false;

        //connection String
        private const string CONNECT_STRING = @"Server=3.130.26.194; " +
                "Database=TradingCardShopSchellenbergGsp26; User Id=gschellenberg2353sp26; password=Gs6xWysge3GN$";

        //build a connection to TCGStore db
        private static SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
        //command object
        private static SqlCommand _sqlTCGStoreCommand;
        private static SqlCommand _sqlTCGCartCommand;
        private static SqlCommand _sqlTCGGenericCommand;
        //Data adapter
        private static SqlDataAdapter _daTCGStore = new SqlDataAdapter();
        private static SqlDataAdapter _daTCGCart = new SqlDataAdapter();
        private static SqlDataAdapter _daTCGGeneric = new SqlDataAdapter();
        //data Tables
        private static DataTable _dtTCGStoreTable = new DataTable();
        private static DataTable _dtTCGCartTable = new DataTable();
        private static DataTable _dtTCGGenericTable = new DataTable();

        private static StringBuilder errorMessages = new StringBuilder();

        //Getter setters
        public static DataTable DTTCGStoreTable
        {
            get { return _dtTCGStoreTable; }
            set { _dtTCGStoreTable = value; }
        }
        public static DataTable DTTCGCartTable
        {
            get { return _dtTCGCartTable; }
            set { _dtTCGCartTable = value; }
        }
        public static DataTable DTTCGGenericTable
        {
            get { return _dtTCGGenericTable; }
            set { _dtTCGGenericTable = value; }
        }

        public static void OpenDatabase()
        {
            try
            {
                //method opens db and allow data use
                //open connection to db
                if (isOpen == false)
                {
                    _cntDatabase.Open();
                    MessageBox.Show("Connection to database was successfully opened");
                    isOpen = true;
                }

            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    MessageBox.Show(errorMessages.ToString(), "Error on Open Database",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error On Open Database", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        public static void CloseDatabase()
        {
            try
            {
                if (isOpen == true)
                {
                    //close data
                    _cntDatabase.Close();
                    //dispose data
                    _cntDatabase.Dispose();
                    //dispose of all
                    _sqlTCGStoreCommand.Dispose();
                    _daTCGStore.Dispose();
                    _dtTCGStoreTable.Dispose();
                    _sqlTCGCartCommand.Dispose();
                    _daTCGCart.Dispose();
                    _dtTCGCartTable.Dispose();
                    MessageBox.Show("Connection to database was successfully Closed");
                    isOpen = false;
                }

            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    MessageBox.Show(errorMessages.ToString(), "Error on Close Database",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error On Close Database", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }
        public static void DatabaseCommandTCGStore(DataGridView dataGridView1, string query)
        {
            try
            {
                //establish command obj
                _sqlTCGStoreCommand = new SqlCommand(query, _cntDatabase);
                //establish data obj
                _daTCGStore = new SqlDataAdapter();
                _daTCGStore.SelectCommand = _sqlTCGStoreCommand;
                //fill data table
                _dtTCGStoreTable = new DataTable();
                _daTCGStore.Fill(_dtTCGStoreTable);
                //bind controlls to datatable 
                _dtTCGStoreTable.Columns["ImageID"].ColumnMapping = MappingType.Hidden;
                dataGridView1.DataSource = _dtTCGStoreTable;
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    MessageBox.Show(errorMessages.ToString(), "Error on DatabaseCommand",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error On DatabaseCommand", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        public static void DatabaseCommandTCGCart(ListBox lbxCart, string query)
        {
            try
            {
                lbxCart.Items.Clear();
                //establish command obj
                _sqlTCGCartCommand = new SqlCommand(query, _cntDatabase);
                //establish data obj
                _daTCGCart = new SqlDataAdapter();
                _daTCGCart.SelectCommand = _sqlTCGCartCommand;
                //fill data table
                _dtTCGCartTable = new DataTable();
                _daTCGCart.Fill(_dtTCGCartTable);


                //make header
                string header = string.Format("{0,-50} | {1,10} | {2,8} | {3,10}",
                                _dtTCGCartTable.Columns["ProductName"].ToString(), _dtTCGCartTable.Columns["PPU"].ToString(), _dtTCGCartTable.Columns["Quantity"].ToString(), _dtTCGCartTable.Columns["Total"].ToString());
                lbxCart.Items.Add(header);
                lbxCart.Items.Add(new string('-', 75)); // Separator

                // Adds the value from rows Then Columns
                foreach (DataRow row in _dtTCGCartTable.Rows)
                {
                    string productName = row["ProductName"].ToString();
                    string price = row["PPU"].ToString();
                    string quantity = row["Quantity"].ToString();
                    string total = row["Total"].ToString();

                    string line = string.Format("{0,-50} | {1,10} | {2,8} | {3,10}",
                                                productName, price, quantity, total);
                    lbxCart.Items.Add(line);
                    lbxCart.Items.Add(new string('-', 75)); // Separator

                }
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    MessageBox.Show(errorMessages.ToString(), "Error on DatabaseCommand",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error On DatabaseCommand", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }
        
        public static DataTable SelectStatementReturnsDT(string query)
        {
            //establish command obj
            _sqlTCGGenericCommand = new SqlCommand(query, _cntDatabase);
            //establish data obj
            _daTCGGeneric = new SqlDataAdapter();
            _daTCGGeneric.SelectCommand = _sqlTCGGenericCommand;
            //fill data table
            _dtTCGGenericTable = new DataTable();
            _daTCGGeneric.Fill(_dtTCGGenericTable);

            return _dtTCGGenericTable;
            
        }
    }
}
