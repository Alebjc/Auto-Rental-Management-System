using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public class CreditCardDTO
    {
        // *************************************** CreditCardDTO CLASS*******************************************************************//

//######################################################## IMPORTANT WARNING! #######################################################
//NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE CLASS. 
//THE CLASS HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################



        //====================== START of CreditCardDTO Class AUTOMATIC PROPERTIES CODE =======================================================


        #region "PUBLIC PROPERTIES DECLARATIONS"

        /******************************************************************
         Public PROPERTIES Declarations
        ******************************************************************/
        //Public INSTANCE Properties Declarations
        public string CreditCardNumber { get; set; }
        public string CreditCardOwnerName { get; set; }

        public byte CreditCardProcessingMerchantServiceCompanyCode { get; set; }
        public string CreditCardProcessingMerchantServiceCompanyName { get; set; }

        public byte CreditCardNetworkCompanyCode { get; set; }
        public string CreditCardNetworkCompanyName { get; set; }

        public byte CreditCardIssuingBankCode { get; set; }
        public string CreditCardIssuingBankName { get; set; }

        public byte CreditCardCorporateMerchantBankCode { get; set; }
        public string CreditCardCorporateMerchantBankName { get; set; }

        public DateTime ExpDate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public decimal CreditCardLimit { get; set; }
        public decimal CreditCardAvailableCredit { get; set; }

        public bool CreditCardActivationStatus { get; set; }


        #endregion "PUBLIC PROPERTIES DECLARATIONS"

        //====================== END of CreditCardDTO Class AUTOMATIC PROPERTIES CODE =======================================================

    }
}
