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
    public partial class frmERPSystemForm : Form
    {
        public frmERPSystemForm()
        {
            InitializeComponent();
        }

        private void btnCustomerFieldServicesMS_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit(object sender, EventArgs e)
        {
            //Close this form
            //program flow automatically goes back to Main Form
            //event-handler method which opened this form
            //aa a dialog form.
            this.Close();

        }

        private void btnCreditCardMS_Click(object sender, EventArgs e)
        {
            //Declare object of ERP Form
            frmCreditCardMSForm objCCMS = new frmCreditCardMSForm();

            //Hide this form (frmMainWelcomeForm)
            this.Hide();

            //Display ERP System Form as Dialog Form
            //Dialog mode means program flow will STOP until the
            //ERP form Closes or Hides
            objCCMS.ShowDialog();

            //Once the ERP System Form closes or hides,
            //Control goes back to this event-handler and this
            //FORM OBJECT needs to Display itself
            this.Show();
        }
    }
}
