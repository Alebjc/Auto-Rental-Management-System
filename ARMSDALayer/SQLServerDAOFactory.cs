using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public class SQLServerDAOFactory : DALObjectFactoryBase
    {
        //public override CreditCardProcessingMerchantServiceCompanyDAO CreditCardProcessingMerchantServiceCompanyDAO => throw new NotImplementedException();

        //*************************************** SQLServerDAOFactory CLASS *******************************************************************

        //######################################################## IMPORTANT WARNING! #######################################################
        //NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE CLASS. 
        //THE CLASS HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################




        //====================== START of SQLServerDAOFactory CLASS CODE Declaration =======================================================


        //=================================================================
        //Name:         ConnectionString() Method
        //Purpose:      Centralized method that returns the Connection  
        //              String for MS SQLServer data access.
        //Parameter:    None.
        //Return Value: string that contains the connection string.
        public static string ConnectionString()
        {
            return "Data Source =.\\SQLExpress; Initial Catalog = EZRentalDB; Integrated Security = True";

        }


        //=================================================================
        //Name:         GetCreditCardDAO() Method
        //Purpose:      Method that returns the CreditCardDAO Data Access Object 
        //              that handles the data access for the CreditCard 
        //              class in the business object Layer.
        //Parameter:    None.
        //Return Value: a new CreditCardDAO object.

        public override CreditCardDAO GetCreditCardDAO()
        {
            //return CreditCardDAO Data Access Object to perform CreditCard class Data Access
            return new CreditCardDAO();

        }
        public override CreditCardIssuingBankDAO GetCreditCardIssuingBankDAO()
        {
            return new CreditCardIssuingBankDAO();
        }

        public override CreditCardNetworkCompanyDAO GetCreditCardNetworkCompanyDAO()
        {
            return new CreditCardNetworkCompanyDAO();
        }

        public override CountryDAO GetCountryDAO()
        {
            return new CountryDAO();
        }

        public override CreditCardCorporateMerchantBankDAO GetCreditCardCorporateMerchantBankDAO()
        {
            return new CreditCardCorporateMerchantBankDAO();
        }

        public override USStateDAO GetUSStateDAO()
        {
            return new USStateDAO();
        }

        public override CreditCardProcessingMerchantServiceCompanyDAO GetCreditCardProcessingMerchantServiceCompanyDAO()
        {
            return new CreditCardProcessingMerchantServiceCompanyDAO();
        }













        //====================== END of SQLServerDAOFactory CLASS CODE Declaration =======================================================







    }
}
