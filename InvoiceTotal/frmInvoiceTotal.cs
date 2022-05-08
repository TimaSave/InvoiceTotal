using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customerType = txtCustomerType.Text;
            decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
            //decimal discountPercent = GetInvoiceAmounts(string customerType, decimal subtotal);

            //decimal discountAmount = subtotal * discountPercent;
            var Calculations = GetInvoiceAmounts(customerType, subtotal);
            decimal invoiceTotal = subtotal - Calculations.discountAmount;
            txtDiscountPercent.Text = Calculations.discountPercent.ToString("p1");
            txtDiscountAmount.Text = Calculations.discountAmount.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            txtCustomerType.Focus();
        }
        // method using a tuple
        private (decimal discountPercent, decimal discountAmount)
            GetInvoiceAmounts(string customerType, decimal subtotal)
        {
            decimal discountPercent = .0m;

            if (customerType == "R")
            {
                if (subtotal < 100)
                    discountPercent = .0m;
                else if (subtotal >= 100 && subtotal < 250)
                    discountPercent = .1m;
                else if (subtotal >= 250)
                    discountPercent = .25m;
            }
            else if (customerType == "C")
            {
                if (subtotal < 250)
                    discountPercent = .2m;
                else
                    discountPercent = .3m;
            }
            else
            {
                discountPercent = .4m;
            }
            decimal discountAmount = subtotal * discountPercent;
            return (discountPercent, discountAmount);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
