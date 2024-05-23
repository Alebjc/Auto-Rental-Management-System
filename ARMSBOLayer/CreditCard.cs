using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ARMSDALayer;

namespace ARMSBOLayer
{
    public class CreditCard
    {
        //***************************************CREDIT CARD CLASS*******************************************************************

        //######################################################## IMPORTANT WARNING! #######################################################
        //NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE CLASS OR METHOD SHOWN HERE. 
        //FOR A CLASS, THE CLASS HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################

        // Private data members
        private string m_creditCardNumber;
        private string m_creditCardOwnerName;
        private byte m_creditCardProcessingMerchantServiceCompanyCode;
        private string m_creditCardProcessingMerchantServiceCompanyName;
        private byte m_creditCardNetworkCompanyCode;
        private string m_creditCardNetworkCompanyName;
        private byte m_creditCardIssuingBankCode;
        private string m_creditCardIssuingBankName;
        private byte m_creditCardCorporateMerchantBankCode;
        private string m_creditCardCorporateMerchantBankName;
        private DateTime m_expDate;
        private string m_addressLine1;
        private string m_addressLine2;
        private string m_city;
        private string m_stateCode;
        private string m_zipCode;
        private string m_country;
        private decimal m_creditCardLimit;
        private decimal m_creditCardAvailableCredit;
        private bool m_creditCardActivationStatus;
        public readonly bool IsPopulated;

        // Public properties
        public string CreditCardNumber { get => m_creditCardNumber; set => m_creditCardNumber = value; }
        public string CreditCardOwnerName { get => m_creditCardOwnerName; set => m_creditCardOwnerName = value; }
        public byte CreditCardProcessingMerchantServiceCompanyCode { get => m_creditCardProcessingMerchantServiceCompanyCode; set => m_creditCardProcessingMerchantServiceCompanyCode = value; }
        public string CreditCardProcessingMerchantServiceCompanyName { get => m_creditCardProcessingMerchantServiceCompanyName; set => m_creditCardProcessingMerchantServiceCompanyName = value; }
        public byte CreditCardNetworkCompanyCode { get => m_creditCardNetworkCompanyCode; set => m_creditCardNetworkCompanyCode = value; }
        public string CreditCardNetworkCompanyName { get => m_creditCardNetworkCompanyName; set => m_creditCardNetworkCompanyName = value; }
        public byte CreditCardIssuingBankCode { get => m_creditCardIssuingBankCode; set => m_creditCardIssuingBankCode = value; }
        public string CreditCardIssuingBankName { get => m_creditCardIssuingBankName; set => m_creditCardIssuingBankName = value; }
        public byte CreditCardCorporateMerchantBankCode { get => m_creditCardCorporateMerchantBankCode; set => m_creditCardCorporateMerchantBankCode = value; }
        public string CreditCardCorporateMerchantBankName { get => m_creditCardCorporateMerchantBankName; set => m_creditCardCorporateMerchantBankName = value; }
        public DateTime ExpDate { get => m_expDate; set => m_expDate = value; }
        public string AddressLine1 { get => m_addressLine1; set => m_addressLine1 = value; }
        public string AddressLine2 { get => m_addressLine2; set => m_addressLine2 = value; }
        public string City { get => m_city; set => m_city = value; }
        public string StateCode { get => m_stateCode; set => m_stateCode = value; }
        public string ZipCode { get => m_zipCode; set => m_zipCode = value; }
        public string Country { get => m_country; set => m_country = value; }
        public decimal CreditCardLimit { get => m_creditCardLimit; set => m_creditCardLimit = value; }
        public decimal CreditCardAvailableCredit { get => m_creditCardAvailableCredit; set => m_creditCardAvailableCredit = value; }
        public bool CreditCardActivationStatus { get => m_creditCardActivationStatus; }

        // Constructors
        public CreditCard()
        {
            
        }

        // Default constructor
        ~CreditCard()
        {

        }

        public CreditCard(string creditCardNumber, string creditCardOwnerName, byte processingCompanyCode,
                          string processingCompanyName, byte networkCompanyCode, string networkCompanyName,
                          byte issuingBankCode, string issuingBankName, byte corporateMerchantBankCode,
                          string corporateMerchantBankName, DateTime expDate, string addressLine1,
                          string addressLine2, string city, string stateCode, string zipCode, string country)                     
        {
            m_creditCardNumber = creditCardNumber;
            m_creditCardOwnerName = creditCardOwnerName;
            m_creditCardProcessingMerchantServiceCompanyCode = processingCompanyCode;
            m_creditCardProcessingMerchantServiceCompanyName = processingCompanyName;
            m_creditCardNetworkCompanyCode = networkCompanyCode;
            m_creditCardNetworkCompanyName = networkCompanyName;
            m_creditCardIssuingBankCode = issuingBankCode;
            m_creditCardIssuingBankName = issuingBankName;
            m_creditCardCorporateMerchantBankCode = corporateMerchantBankCode;
            m_creditCardCorporateMerchantBankName = corporateMerchantBankName;
            m_expDate = expDate;
            m_addressLine1 = addressLine1;
            m_addressLine2 = addressLine2;
            m_city = city;
            m_stateCode = stateCode;
            m_zipCode = zipCode;
            m_country = country;
            m_creditCardLimit =  3000.0M;
            m_creditCardAvailableCredit =  3000.0M;
            m_creditCardActivationStatus = true;

            // Set default values for other properties
            m_creditCardProcessingMerchantServiceCompanyName = "";
            m_creditCardNetworkCompanyName = "";
            m_creditCardIssuingBankName = "";
            m_creditCardCorporateMerchantBankName = "";
        }

        //====================== START of Protected DALayer Methods =======================================================


        #region "PROTECTED INSTANCE & STATIC DATA ACCESS METHODS"

        /******************************************************************
          Protected DATA ACCESS METHODS Declarations
         ******************************************************************/

        //=================================================================
        //Name:        DALayer_Load(key) Method
        //Purpose:      Method that CALLS the Data Access Layer services 
        //              to do the work and query the database.
        //Algorithm:    Calls the Data Access Layer to do the work
        //Parameter:    The key or ID of the object to load.
        //Return Value: Boolean true if found and retrieved from database, false 
        //              otherwise.
        public bool DALayer_Load(string key)
        {
            //1.CREATE DATA ACCESS LAYER CLASS OBJECT objDALayer.
            //2.CALLS DATA ACCESS LAYER DATA ACCESS OBJECT objDAO.DALCustomerLoad(key) Method
            //to do the work which returns a POPULATED DATA TRANSBER OBJECT with the CreditCard’s record.
            //3.Consume the DTO Object RETURNED by the objDAO.DALCreditCardLoad(key) Method by GETTING all
            //the properties from the returned object and SETTING all the Properties / Data of THIS class
            //DATA or PROPERTIES.When done, THIS class OBJECT now contains the Customer’s DATA thus
            //represents the customer.
            //4. Return TRUE if table record data was returned from call to objDALayer.DALCreditCardLoad(key) Method
            //or FALSE if no data indicating the record was not found in the database.
            //6	Add Error-Handling code using Try-Catch-Finally to handle all required
            //Unique OR/AND GENERAL Exception & Re-Throw the Exception

            try
            {
                //STEP 1 - Use a POLYMORPHISM BASED CLASS DAL POINTER to get SQL Server Factory Data Access Object
                //via the  Factory to get the DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER)
                //Method, passign the SQLSERVER Constant which = 1.
                DALObjectFactoryBase objSQLDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Call the correct Data Access Object to perform the Data Access
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();

                //Call the CreditCardDAO Data Access Object to do the work 
                CreditCardDTO objDTO = objCreditCardDAO.GetRecordByID(key);

                //Check if DTO object exists & populate this objct with DTO object's properties
                if (objDTO != null)
                {
                    //Get the data from the Data Transfer Object
                    this.CreditCardNumber = objDTO.CreditCardNumber;
                    this.CreditCardOwnerName = objDTO.CreditCardOwnerName;
                    this.CreditCardProcessingMerchantServiceCompanyCode = objDTO.CreditCardProcessingMerchantServiceCompanyCode;
                    this.CreditCardProcessingMerchantServiceCompanyName = objDTO.CreditCardProcessingMerchantServiceCompanyName;
                    this.CreditCardNetworkCompanyCode = objDTO.CreditCardNetworkCompanyCode;
                    this.CreditCardNetworkCompanyName = objDTO.CreditCardNetworkCompanyName;
                    this.CreditCardIssuingBankCode = objDTO.CreditCardIssuingBankCode;
                    this.CreditCardIssuingBankName = objDTO.CreditCardIssuingBankName;
                    this.CreditCardCorporateMerchantBankCode = objDTO.CreditCardCorporateMerchantBankCode;
                    this.CreditCardCorporateMerchantBankName = objDTO.CreditCardCorporateMerchantBankName;
                    this.ExpDate = objDTO.ExpDate;
                    this.AddressLine1 = objDTO.AddressLine1;
                    this.AddressLine2 = objDTO.AddressLine2;
                    this.City = objDTO.City;
                    this.StateCode = objDTO.StateCode;
                    this.ZipCode = objDTO.ZipCode;
                    this.Country = objDTO.Country;
                    this.CreditCardLimit = objDTO.CreditCardLimit;
                    this.CreditCardAvailableCredit = objDTO.CreditCardAvailableCredit;


                    //Handle activation status
                    if (objDTO.CreditCardActivationStatus == true)
                        this.Activate();
                    else
                        this.Deactivate();
                    //since it has been populated, return true
                    return true;
                }
                else
                {
                    //if null or no object returned from DALayer, return false
                    return false;
                }
            }//End of try 
            catch (Exception objE)
            {
                //Rethrow general exceptions
                throw new Exception("Unexpected Error is DALayer_Load(key) Method: {0} " + objE.Message);
            }
        }//End of method


        //====================== START of Protected DALayer Methods =======================================================

        public bool Load(string key)
        {
            // Call the DALayer_Load method to do the work
            return DALayer_Load(key);
        }


        public void Print()
        {
            try
            {
                // Open or create Network_Printer.txt file for appending
                using (StreamWriter writer = File.AppendText("Network_Printer.txt"))
                {
                    // Write object's data to the file
                    writer.WriteLine("Credit Card information:");
                    writer.WriteLine($"Credit Card Number = {m_creditCardNumber}");
                    writer.WriteLine($"Credit Card Owner Name = {m_creditCardOwnerName}");
                    //writer.WriteLine($"Credit Card Processing Merchant Service Company Code = {m_creditCardProcessingMerchantServiceCompanyCode}");
                    writer.WriteLine($"Credit Card Processing Merchant Service Company Name = {m_creditCardProcessingMerchantServiceCompanyName}");
                    //writer.WriteLine($"Credit Card Network Company Code = {m_creditCardNetworkCompanyCode}");
                    writer.WriteLine($"Credit Card Network Company Name = {m_creditCardNetworkCompanyName}");
                    //writer.WriteLine($"Credit Card Issuing Bank Code = {m_creditCardIssuingBankCode}");
                    writer.WriteLine($"Credit Card Issuing Bank Name = {m_creditCardIssuingBankName}");
                    //writer.WriteLine($"Credit Card Corporate Merchant Bank Code = {m_creditCardCorporateMerchantBankCode}");
                    writer.WriteLine($"Credit Card Corporate Merchant Bank Name = {m_creditCardCorporateMerchantBankName}");
                    writer.WriteLine($"Expiration Date = {m_expDate.ToShortDateString()}");
                    writer.WriteLine($"AddressLine1 = {m_addressLine1}");
                    writer.WriteLine($"AddressLine2 = {m_addressLine2}");
                    writer.WriteLine($"City = {m_city}");
                    writer.WriteLine($"State Code = {m_stateCode}");
                    writer.WriteLine($"Zip code = {m_zipCode}");
                    writer.WriteLine($"Country = {m_country}");
                    writer.WriteLine($"Credit Card Limit = {m_creditCardLimit}");
                    writer.WriteLine($"Credit Card Available Credit = {m_creditCardAvailableCredit}");
                    writer.WriteLine($"Credit Card Activation Status = {m_creditCardActivationStatus}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"An error occurred while printing the credit card information: {ex.Message}");
                // Re-throw the exception
                throw;
            }
        }

        public bool Activate()
        {
            // Set the activation status to true
            m_creditCardActivationStatus = true;
            // Return the activation status
            return m_creditCardActivationStatus;
        }


        public bool Deactivate()
        {
            // Set the activation status to false
            m_creditCardActivationStatus = false;
            // Return the activation status
            return m_creditCardActivationStatus;
        }



    }
    #endregion
}