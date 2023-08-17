using System;
using System.Windows.Forms;

namespace LunchOrdersGUI01
{
    public partial class frmLunchOrders : Form
    {
        public frmLunchOrders()
        {
            InitializeComponent();
        }

        // Declare and initialize global program constants.
        const decimal tax = 0.0775m;

        private void frmLunchOrders_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void rdoHamburger_CheckedChanged(object sender, EventArgs e)
        {
            ClearAddOns();
            ClearTotals();
            AddNewHamburgerAddOns();
        }

        private void rdoPizza_CheckedChanged(object sender, EventArgs e)
        {
            ClearAddOns();
            ClearTotals();
            AddNewPizzaAddOns();
        }

        private void chkOne_CheckedChanged(object sender, EventArgs e)
        {
            ClearTotals();
        }

        private void chkTwo_CheckedChanged(object sender, EventArgs e)
        {
            ClearTotals();
        }

        private void chkThree_CheckedChanged(object sender, EventArgs e)
        {
            ClearTotals();
        }

        private void rdoSalad_CheckedChanged(object sender, EventArgs e)
        {
            ClearAddOns();
            ClearTotals();
            AddNewSaladAddOns();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            CalculateAndDisplayTotals();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            rdoHamburger.Checked = true;

            ClearAddOns();
            ClearTotals();

            rdoHamburger.Focus();
        }

        private void ClearAddOns()
        {
              chkOne.Checked = false;
              chkTwo.Checked = false;
            chkThree.Checked = false;
        }

        private void ClearTotals()
        {
            txtSubtotal.Text = "";
                 txtTax.Text = "";
               txtTotal.Text = "";
        }

        private void AddNewHamburgerAddOns()
        {
            gbAddOns.Text = "Add-On Items ($1.75/ each)";

              chkOne.Text = "Lettuce, Tomato, Onions";
              chkTwo.Text =  "Ketchup, Mustard, Mayo";
            chkThree.Text =            "French Fries";
        }

        private void AddNewPizzaAddOns()
        {
            gbAddOns.Text = "Add-On Items ($0.75/ each)";

              chkOne.Text = "Pepperoni";
              chkTwo.Text =   "Sausage";
            chkThree.Text =    "Olives";
        }

        private void AddNewSaladAddOns()
        {
            gbAddOns.Text = "Add-On Items ($0.50/ each)";

              chkOne.Text =     "Croutons";
              chkTwo.Text =   "Bacon Bits";
            chkThree.Text = "Bread Sticks";
        }

        private void CalculateAndDisplayTotals()
        {
            decimal mainCourse = 0m;
            decimal subtotal   = 0m;
            decimal taxTotal   = 0m;
            decimal orderTotal = 0m;

            // If the hamburger option is selected, check for selected add-ons, then add 1.75 to the subtotal per
            // add-on. 
            if (rdoHamburger.Checked)
            {
                mainCourse = 7.95m;

                if (chkOne.Checked)
                {
                    subtotal += 1.75m;
                }

                if (chkTwo.Checked)
                {
                    subtotal += 1.75m;
                }

                if (chkThree.Checked)
                {
                    subtotal += 1.75m;
                }
            }

            // If the pizza option is selected, check for selected add-ons, then add 0.75 to the subtotal per add-on. 
            if (rdoPizza.Checked)
            {
                mainCourse = 6.95m;

                if (chkOne.Checked)
                {
                    subtotal += .75m;
                }

                if (chkTwo.Checked)
                {
                    subtotal += .75m;
                }

                if (chkThree.Checked)
                {
                    subtotal += .75m;
                }
            }

            // If the salad option is selected, check for selected add-ons, then add 0.50 to the subtotal per add-on. 
            if (rdoSalad.Checked)
            {
                mainCourse = 5.75m;

                if (chkOne.Checked)
                {
                    subtotal += .5m;
                }

                if (chkTwo.Checked)
                {
                    subtotal += .5m;
                }

                if (chkThree.Checked)
                {
                    subtotal += .5m;
                }
            }

            subtotal  += mainCourse;
            taxTotal   = subtotal * tax;
            orderTotal = taxTotal + subtotal;

            txtSubtotal.Text = subtotal.ToString("c");
                 txtTax.Text = taxTotal.ToString("c");
               txtTotal.Text = orderTotal.ToString("c");
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want To Exit The Program?",
                                                  "Exit Now?",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
