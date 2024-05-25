using ARMSBOLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARMSWinClient
{
    public partial class frmCreditCardRegistration : Form
    {
        public frmCreditCardRegistration()
        {
            InitializeComponent();
        }

        private void frmCreditCardRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                //BINDING cbCreditCardProcessingMerchantServiceCompany ComboBox to the CreditCardProcessingMerchantServiceCompany Class GetAllCreditCardMerchants Static Method
                cbCreditCardProcessingMerchantServiceCompanyName.DataSource = CreditCardProcessingMerchantServiceCompany.GetAllCreditCardProcessingMerchantServiceCompanies();
                //Set DisplayMember property to indicate which property gets displayed on the combobox
                //Set ValueMember Property to indicate which property to get data from in the code
                cbCreditCardProcessingMerchantServiceCompanyName.DisplayMember = "CreditCardProcessingMerchantServiceCompanyName";
                cbCreditCardProcessingMerchantServiceCompanyName.ValueMember = "CreditCardProcessingMerchantServiceCompanyCode";
                //in this case we return the code
                //=====================================================================================================================================
                //BINDING cbCreditCardNetworkCompanyName ComboBox to the CreditCardNetworkCompnay Class GetCreditCardNetworkCompanies Static Method
                cbCreditCardNetworkCompanyName.DataSource = CreditCardNetworkCompany.GetAllCreditCardNetworkCompanies();
                //Set DisplayMember property to indicate which property gets displayed on the combobox
                //Set ValueMember Property to indicate which property to get data from in the code
                cbCreditCardNetworkCompanyName.DisplayMember = "CreditCardNetworkCompanyName";
                cbCreditCardNetworkCompanyName.ValueMember = "CreditCardNetworkCompanyCode"; //in this case we return the code
                //=====================================================================================================================================
                //BINDING cbCreditCardIssuingBankName ComboBox to the CreditCardCreditCardIssuingBank Class GetCreditCardIssuingBanks Static Method
                cbCreditCardIssuingBankName.DataSource = CreditCardIssuingBank.GetAllCreditCardIssuingBanks();
                //Set DisplayMember property to indicate which property gets displayed on the combobox
                //Set ValueMember Property to indicate which property to get data from in the code
                cbCreditCardIssuingBankName.DisplayMember = "CreditCardIssuingBankName";
                cbCreditCardIssuingBankName.ValueMember = "CreditCardIssuingBankCode"; //in this case we return the code
                //=====================================================================================================================================
                //BINDING cbCreditCardCorporateMerchantBankName ComboBox to the CreditCardCorporateMerchantBank Class GetCreditCardCorporateMerchantBanks Static Method
                cbCreditCardCorporateMerchantBankName.DataSource = CreditCardCorporateMerchantBank.GetAllCreditCardMerchantBanks();
                //Set DisplayMember property to indicate which property gets displayed on the combobox
                //Set ValueMember Property to indicate which property to get data from in the code
                cbCreditCardCorporateMerchantBankName.DisplayMember = "CreditCardCorporateMerchantBankName";
                cbCreditCardCorporateMerchantBankName.ValueMember = "CreditCardCorporateMerchantBankCode"; //in this case we return the code

                //BINDING State ComboBox to the USState Class GetAllUSStates Static Method
                cbStateCode.DataSource = USState.GetAllUSStates();
                //Set DisplayMember property to indicate which property gets displayed on the combobox 
                //Set ValueMember Property to indicate which property to get data from in the code
                cbStateCode.DisplayMember = "StateName";
                cbStateCode.ValueMember = "StateCode"; //in this case we return the state code
                //===================================================================================================================================== 
                //BINDING Country ComboBox to the Country Class GetAllCountry Static Method
                cbCountry.DataSource = Country.GetAllCountries();
                //Set DisplayMember property to indicate which property gets displayed on the combobox 
                //Set ValueMember Property to indicate which property is GOTTEN to used in the code
                cbCountry.DisplayMember = "CountryName";
                cbCountry.ValueMember = "CountryName";
                //in this case we return the country name since the CreditCard Class stores the //Name
                //===================================================================================================================================== 
                //Initialized Credit Card Limit & Credit Card Available Credit Text boxes 
                //Create Default object & set text boxes with properties from object
                CreditCard objCreditCard = new CreditCard();
                //SET textboxes text properties with content from temp creditcard object
                txtCreditCardLimit.Text = Convert.ToString(objCreditCard.CreditCardLimit);
                txtCreditCardAvailableCredit.Text = Convert.ToString(objCreditCard.CreditCardAvailableCredit);
                //===================================================================================================================================== 
                //Programmatically set the properties to the Activation Status Combo Box 
                //and ADD the activated and deactivated items to the Combo Box
                cbActivationStatus.Items.Add("Activate");
                cbActivationStatus.Items.Add("Deactivate");
                //SET SELECTED TEXT Property of ComboBox to Activate which is default status
                cbActivationStatus.SelectedItem = "Activate";

            }
            catch (Exception objE)
            {
                MessageBox.Show("Unexpected error in Form_Load Event-Handler, please contact administrator " + objE);
            }
        }








        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Create a LOCAL-LEVEL CreditCard object
                CreditCard objCreditCard = new CreditCard();

                // Step 2: Set properties from TextBox data
                objCreditCard.CreditCardNumber = txtBoxCreditCardNumber.Text;
                objCreditCard.CreditCardOwnerName = txtBoxCCName.Text;

                // Step 3-6: Extract data from ComboBoxes and set properties
                objCreditCard.CreditCardProcessingMerchantServiceCompanyCode = Convert.ToByte(cbCreditCardProcessingMerchantServiceCompanyName.SelectedValue);
                objCreditCard.CreditCardNetworkCompanyCode = Convert.ToByte(cbCreditCardNetworkCompanyName.SelectedValue);
                objCreditCard.CreditCardIssuingBankCode = Convert.ToByte(cbCreditCardIssuingBankName.SelectedValue);
                objCreditCard.CreditCardCorporateMerchantBankCode = Convert.ToByte(cbCreditCardCorporateMerchantBankName.SelectedValue);

                // Step 7: Set properties from TextBox and DateTimePicker data
                objCreditCard.ExpDate = dtpExpDate.Value;
                objCreditCard.AddressLine1 = txtBoxAddress1.Text;
                objCreditCard.AddressLine2 = txtBoxAddress2.Text;
                objCreditCard.City = txtBoxCity.Text;
                objCreditCard.StateCode = cbStateCode.SelectedValue.ToString();
                objCreditCard.ZipCode = txtBoxZipCode.Text;
                objCreditCard.Country = cbCountry.SelectedValue.ToString();

                // Step 11: Set limit and available credit from TextBox data
                objCreditCard.CreditCardLimit = Convert.ToDecimal(txtCreditCardLimit.Text);
                objCreditCard.CreditCardAvailableCredit = Convert.ToDecimal(txtCreditCardAvailableCredit.Text);

                // Step 12: Handle activation status
                string activationStatus = cbActivationStatus.SelectedItem.ToString();
                if (activationStatus == "Activate")
                {
                    objCreditCard.Activate();
                }
                else if (activationStatus == "Deactivate")
                {
                    objCreditCard.Deactivate();
                }

                // Step 14: Insert the credit card record
                bool result = objCreditCard.Insert();

                // Step 15: Show result message
                if (result)
                {
                    MessageBox.Show("Credit Card successfully inserted");
                }
                else
                {
                    MessageBox.Show("Unexpected error registering the credit card, please contact administrator");
                }

                // Step 16: Clear controls
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Registration Error! Contact the IT Support Desk! Error: " + ex.Message);
            }


        }

        // Method to clear the form inputs
        private void ClearForm()
        {
            // Clear TextBox, ComboBox, etc.
            txtBoxCreditCardNumber.Clear();
            txtBoxCCName.Clear();
            txtBoxAddress1.Clear();
            txtBoxAddress2.Clear();
            txtBoxCity.Clear();
            txtBoxZipCode.Clear();
            txtCreditCardLimit.Clear();
            txtCreditCardAvailableCredit.Clear();
            cbCreditCardProcessingMerchantServiceCompanyName.SelectedIndex = -1;
            cbCreditCardNetworkCompanyName.SelectedIndex = -1;
            cbCreditCardIssuingBankName.SelectedIndex = -1;
            cbCreditCardCorporateMerchantBankName.SelectedIndex = -1;
            cbStateCode.SelectedIndex = -1;
            cbCountry.SelectedIndex = -1;
            cbActivationStatus.SelectedIndex = -1;
            dtpExpDate.Value = DateTime.Now;
        }
    


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {


            // Clear all text boxes
                txtBoxCreditCardNumber.Text = "";
                txtBoxCCName.Text = "";
                txtBoxAddress1.Text = "";
                txtBoxAddress2.Text = "";
                txtBoxCity.Text = "";
                txtBoxZipCode.Text = "";
                txtCreditCardLimit.Text = "";
                txtCreditCardAvailableCredit.Text = "";

                // Reset combo boxes to their default values
                cbCreditCardProcessingMerchantServiceCompanyName.SelectedIndex = -1; // No selection
                cbCreditCardNetworkCompanyName.SelectedIndex = -1; // No selection
                cbCreditCardIssuingBankName.SelectedIndex = -1; // No selection
                cbCreditCardCorporateMerchantBankName.SelectedIndex = -1; // No selection
                cbStateCode.SelectedIndex = -1; // No selection
                cbCountry.SelectedIndex = -1; // No selection
                cbActivationStatus.SelectedIndex = -1; // No selection

                // Reset date picker to current date
                dtpExpDate.Value = DateTime.Now;
            

        }

        private void txtBoxCreditCardNumber_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
