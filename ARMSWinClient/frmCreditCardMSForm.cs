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
    public partial class frmCreditCardMSForm : Form
    {
        public frmCreditCardMSForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Declare object 
            frmCreditCardSearch objCCS = new frmCreditCardSearch();

            //Hide this form 
            this.Hide();

            //Display ERP System Form as Dialog Form
            //Dialog mode means program flow will STOP until the
            //ERP form Closes or Hides
            objCCS.ShowDialog();

            //Once the ERP System Form closes or hides,
            //Control goes back to this event-handler and this
            //FORM OBJECT needs to Display itself
            this.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
