using ARMSBOLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARMSWinClient
{
    public partial class frmCreditCardSearch : Form
    {
        public frmCreditCardSearch()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCreditCardNumber_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            CreditCard cc = new CreditCard();

            try
            {
                if(cc!= null && cc.Load(txtBoxCCNumber.Text) == true)
                {
                    cc.Print();
                    MessageBox.Show("Credit Card information has printed succesfully");
                }
                else
                {
                    MessageBox.Show("Please Search for a Credit Card Before Printing");
                }
            }
            catch(System.Exception)
            {
                MessageBox.Show("Print unsuccesfully");
            }

        }
            
        

        private void frmCreditCardSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                // Step A - Create a CreditCard Object
                CreditCard creditCard = new CreditCard();

                // Step2 - Call CreditCard Object Load(ID) method
                string creditCardNumber = txtBoxCC.Text; // Assuming txtBoxCC is the textbox for entering card number
                if (creditCard.DALayer_Load(creditCardNumber))
                {
                    // Step4 - Populate Form's Textboxes
                    txtBoxCC.Text = creditCard.CreditCardNumber;
                    // Populate other textboxes...
                    txtBoxCCNumber.Text = creditCard.CreditCardNumber;
                    txtBoxCCName.Text = creditCard.CreditCardOwnerName;
                    txtBoxServiceCompanyName.Text = creditCard.CreditCardProcessingMerchantServiceCompanyName;
                    txtBoxCCompanyName.Text = creditCard.CreditCardNetworkCompanyName;
                    txtBoxIssuingName.Text = creditCard.CreditCardIssuingBankName;
                    txtBoxBankName.Text = creditCard.CreditCardCorporateMerchantBankName;
                    txtBoxExpDate.Text = creditCard.ExpDate.ToString("Y");
                    txtBoxAddress1.Text = creditCard.AddressLine1;
                    txtBoxAddress2.Text = creditCard.AddressLine2;
                    txtBoxCity.Text = creditCard.City;
                    txtBoxState.Text = creditCard.StateCode;
                    txtBoxZipCode.Text = creditCard.ZipCode;
                    txtBoxCountry.Text = creditCard.Country;
                    txtBoxCardLimit.Text = creditCard.CreditCardLimit.ToString("");
                    txtBoxAvailableCredit.Text = creditCard.CreditCardAvailableCredit.ToString("");
                    txtBoxActivationStatus.Text = creditCard.CreditCardActivationStatus.ToString();

                }
                else
                {
                    // Step5 - Display message box if record not found
                    MessageBox.Show("Record not found.");

                    
                }
            }
                
          
            catch (System.Exception)
            {
                MessageBox.Show("Error in search");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClear(object sender, EventArgs e)
        {
            try
            {
                CreditCard creditCard = new CreditCard();
                // Step A - Start Exception handling using try statement

                //Clear all text boxes by setting their text property to blank
                txtBoxCC.Text = " ";
                txtBoxCCNumber.Text = " ";
                txtBoxCCName.Text = " ";
                txtBoxServiceCompanyName.Text = " ";
                txtBoxCCompanyName.Text = " ";
                txtBoxIssuingName.Text = " ";
                txtBoxBankName.Text = " ";
                txtBoxExpDate.Text = " ";
                txtBoxAddress1.Text = " ";
                txtBoxAddress2.Text = " ";
                txtBoxCity.Text = " ";
                txtBoxState.Text = " ";
                txtBoxZipCode.Text = " ";
                txtBoxCountry.Text = " ";
                txtBoxCardLimit.Text = " ";
                txtBoxAvailableCredit.Text = " ";
                txtBoxActivationStatus.Text = " ";

                //Set the Modular-Level CreditCard Pointer to NULL
                creditCard = null;

                // End of try statement
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An error occurred while clearing the text boxes: {ex.Message}");
                // End of catch statement and end of error handling
            }
        }
    }
    
}
