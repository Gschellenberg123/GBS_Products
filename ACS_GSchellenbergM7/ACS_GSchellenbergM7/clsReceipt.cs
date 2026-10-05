using ACS_GSchellenbergM7;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace ACS_GSchellenbergM3
{
    internal class clsReceipt
    {
        private static StringBuilder html = new StringBuilder();
        private static StringBuilder css = new StringBuilder();

        public static StringBuilder GenergateReceipt(string title,string Subtotal, string TaxedAmount, string TotalDue,int AccountNum, int orderID)
        {
            css.AppendLine("<style>");
            css.AppendLine("td {padding: 5px; text-align:center; font-weight:bold; " +
                "text-align:center;}");
            css.AppendLine("h1 {color: blue;}");
            css.AppendLine("</style>");

            html.AppendLine($"<head>{css}<title>{title}</title></head>");
            html.AppendLine("<body>");
            html.AppendLine($"<h1>{title}</h1>");

            ReceiptDetails(Subtotal, TaxedAmount, TotalDue, AccountNum, orderID);
            
            html.AppendLine("</body></html>");
            return html;
        }
        public static void ReceiptDetails(string Subtotal, string TaxedAmount, string TotalDue, int AccountNum, int orderID)
        {
            DBConnect.SelectStatementReturnsDT($"SELECT FirstName, LastName FROM Orders AS O INNER JOIN Customers AS C ON O.CustID = C.CustID WHERE OrderID = '{orderID}'");
            string fname = "";
            string lname = "";

            foreach (DataRow row in DBConnect.DTTCGGenericTable.Rows)
            {
                fname = row["FirstName"].ToString();
                lname = row["LastName"].ToString();
            }

            html.AppendLine("<table>");
            html.AppendLine($"<tr><td>Name:</td><td>{fname} {lname}</td></tr>");
            html.AppendLine("<tr><td colspan=6><hr/></td></tr>");
            html.AppendLine($"<tr><td>Order ID:</td><td>{orderID}</td></tr>");
            html.AppendLine("<tr><td colspan=6><hr/></td></tr>");
            html.AppendLine("<tr><td>ProductUPC</td><td>Product Name</td><td>Price Per Unit</td><td>Quantity</td><td>Total</td></tr>");
            html.AppendLine("<tr><td colspan=6><hr/></td></tr>");
            for (int i = 0; i < DBConnect.DTTCGCartTable.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append($"<td>{DBConnect.DTTCGCartTable.Rows[i][2].ToString()}</td>");
                html.Append($"<td>{DBConnect.DTTCGCartTable.Rows[i][3].ToString()}</td>");
                html.Append($"<td>{DBConnect.DTTCGCartTable.Rows[i][4].ToString()}</td>");
                html.Append($"<td>{DBConnect.DTTCGCartTable.Rows[i][5].ToString()}</td>");
                html.Append($"<td>{DBConnect.DTTCGCartTable.Rows[i][6].ToString()}</td>");
                html.Append("</tr>");
                html.AppendLine("<tr><td colspan=6><hr/></td></tr>");
            }
            for (int i = 0; i < 3; i++)
            {
                html.Append("<tr>");
                switch (i)
                {
                    case 0:
                        html.Append($"<td> SubTotal: ${Subtotal}</td>");
                        break;
                    case 1:
                        html.Append($"<td>      Tax: ${TaxedAmount}</td>");
                        break;
                    case 2:
                        html.Append($"<td>Total Due: ${TotalDue}</td>");
                        break;
                }
                html.Append("</tr>");
                html.AppendLine("<tr><td colspan=6><hr/></td></tr>");
            }

            html.AppendLine("</table>");
        }

        public static void PrintReceipt(StringBuilder html)
        {
            try
            {
                DateTime today = DateTime.Now;
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    $"\\{today.ToString("yyyy-MM-dd-HHmmss")} - Reciept.html"))
                {
                    writer.WriteLine(html);
                }
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    $"\\{today.ToString("yyyy-MM-dd-HHmmss")} - Reciept.html");
            }
            catch (Exception)
            {
                MessageBox.Show("You Currently Dont Have Write Permissions for this feature.", "Error With System Permissions",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
