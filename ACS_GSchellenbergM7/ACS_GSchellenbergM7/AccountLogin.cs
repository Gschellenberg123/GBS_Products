using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_GSchellenbergM7
{
    public partial class AccountLogin : Form
    {
        //getter setter
        public static int AccountNum { get ; private set; }
        public static bool IsLoggedIn { get; private set; }



        public int OptionNum;
        public AccountLogin(int optionNum)
        {
            OptionNum = optionNum;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //login
            if(OptionNum == 0)
            {
                LogIn();
            }
            //Creation
            else if(OptionNum == 1)
            {
                CreateAccount();
            }

        }

        private void LogIn()
        {
            if (!HasInvalidCharacters())
            {
                string fname = tbxFirstName.Text;
                string lname = tbxLastName.Text;
                DataTable Account;
                Account = DBConnect.SelectStatementReturnsDT($"SELECT * FROM Customers WHERE LOWER(TRIM(FirstName)) = LOWER(TRIM('{fname}')) AND LOWER(TRIM(LastName)) = LOWER(TRIM('{lname}'))");
                try
                {
                    foreach (DataRow row in Account.Rows)
                    {
                        if (int.TryParse(row["CustID"].ToString(), out int custID))
                        {
                            AccountNum = custID;
                            MessageBox.Show("account logged in");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Account Does Not Exist");
                }
                this.Close();
            }
        }

        private void CreateAccount()
        {
            if(!HasInvalidCharacters())
            {
                string fname = tbxFirstName.Text;
                string lname = tbxLastName.Text;
                DBConnect.SelectStatementReturnsDT($"INSERT INTO Customers (FirstName,LastName) Value ('{fname}','{lname}')");
                LogIn();
                this.Close();
            }
        }

        private bool HasInvalidCharacters()
        {
            tbxFirstName.Text.Trim();
            tbxLastName.Text.Trim();
            if (tbxFirstName.Text.Length > 0 && tbxLastName.Text.Length > 0)
            {
                char[] searchChars = { '<', '>', '(', ')', '{', '}', '[', ']', '\\', '|', '*', '?', '~', '^', '\'', '"', ';', ':' };
                var message = string.Join(", ", searchChars);

                bool fnameContainsChar = tbxFirstName.Text.IndexOfAny(searchChars) >= 0;
                if (fnameContainsChar)
                {
                    MessageBox.Show("Please do not add any of these characters \n" + message);
                    tbxFirstName.Focus();
                    return true;
                }
                else
                {
                    bool lnameContainsChar = tbxLastName.Text.IndexOfAny(searchChars) >= 0;
                    if (lnameContainsChar)
                    {
                        MessageBox.Show("Please do not add any of these characters \n" + message);
                        tbxFirstName.Focus();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Fill out both the first and last name fields");
                return true;
            }
        }

    }
}
