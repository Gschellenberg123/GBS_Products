using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_GSchellenbergM7
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxHelpOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbxHelpOption.SelectedIndex)
            {
                case 0:
                    lblHelpInfo.Text = "You Can Exit by simply clicking on the 'Exit' Button \n" +
                                       "back on the main form or you can simply close the \n" +
                                       "application and data will save properly\n";
                    break;
                case 1:
                    lblHelpInfo.Text = "The Shop is under the 'GoTo' Tab on the main page.\n" +
                                       "It works by simply clicking on the item you wish \n" +
                                       "to purchase then going to the dropdown labeled 'Stock' \n" +
                                       "Then Select the quantity you want, and finally click \n" +
                                       "the 'Add To Cart' button. To view your cart simply\n" +
                                       "click the 'View Cart' button. Pressing the 'Home' Button\n" +
                                       "Will close the shop tab";
                    break;
                case 2:
                    lblHelpInfo.Text = "To go back to the shop tab you click the 'Continue Shopping' \n" +
                                       "Button, if you wish to clear cart just click the 'Clear Cart'\n" +
                                       "Button and that will clear your entire cart. To remove a single\n" +
                                       "item just click on the item and click 'Remove' button but please \n" +
                                       "note that that will remove all of that item. To Check out click \n" +
                                       "the 'Checkout' Button.\n";
                    break;
                case 3:
                    lblHelpInfo.Text = "To finish checking out just simply answer the questions for your\n" +
                                       "account, you may choose no but you cant earn any loyalty points*\n" +
                                       "as well as it makes tracking your order harder.\n" +
                                       "\n" +
                                       "*Loyalty points cannot be redeemed at the moment\n(but should in the future)\n";
                    break;
            }
        }
    }
}
