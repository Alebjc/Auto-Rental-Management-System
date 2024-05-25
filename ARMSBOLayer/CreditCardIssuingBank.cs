using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class CreditCardIssuingBank

    {

        public byte CreditCardIssuingBankCode { get; set; }
        public string CreditCardIssuingBankName { get; set; }

        public CreditCardIssuingBank()
        {
            this.CreditCardIssuingBankCode = 0;
            this.CreditCardIssuingBankName = "";
        }

        public CreditCardIssuingBank(byte CIB, string CIN)
        {
            this.CreditCardIssuingBankCode = CIB;
            this.CreditCardIssuingBankName = CIN;
        }




        public static List<CreditCardIssuingBank> GetAllCreditCardIssuingBanks()
        {
            try
            {
                // Call the DALayer method to get all credit card processing merchant service companies
                List<CreditCardIssuingBank> issuingBanks = DALayer_GetAllCreditCardIssuingBank();

                // Return the list of companies if the method call was successful
                return issuingBanks ?? new List<CreditCardIssuingBank>();
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                // Return null in case of an exception
                return null;
            }
        }


        protected static List<CreditCardIssuingBank> DALayer_GetAllCreditCardIssuingBank()
        {
            try
            {
                //Step 1-Use DAL object Factory Base Class POINTER to get the SQL Server FACTORY 
                //Data Access Object using POLYMORPHISM.
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work
                CreditCardIssuingBankDAO objCreditCardIssuingBankDAO = objDAOFactory.GetCreditCardIssuingBankDAO(); 

                //Step 3-call DAO object to do the work & return COLLECTION of Data Transfer Objects
                List<CreditCardIssuingBankDTO> objCreditCardIssuingBankDTOList = objCreditCardIssuingBankDAO.GetAllRecords();

                //Step 4- test if objCreditCardNetworkCompanyDTOList DTO collection exists (returned from DBMS) 
                if (objCreditCardIssuingBankDTOList != null)
                {

                    //Step 5-Create a LIST Collection of CreditCardNetworkCompany objects to populate with 
                    //the data from each DTO Object in of DTO collection
                    List<CreditCardIssuingBank> objCreditCardIssuingBankList = new List<CreditCardIssuingBank>();

                    //Step 6-Loop through the objCreditCardNetworkCompanyDTOList
                    //collection
                    foreach (CreditCardIssuingBankDTO objDTO in objCreditCardIssuingBankDTOList)
                    {
                        //Step 6a-Create new CreditCardNetworkCompany object
                        CreditCardIssuingBank objCreditCardIssuingBank = new CreditCardIssuingBank();

                        //Step 6b-get the data from DTO object and SET CreditCardNetworkCompany object
                        objCreditCardIssuingBank.CreditCardIssuingBankCode = objDTO.CreditCardIssuingBankCode;
                        objCreditCardIssuingBank.CreditCardIssuingBankName = objDTO.CreditCardIssuingBankName;

                        //Step 6c-Add CreditCardNetworkCompany Object to the objCreditCardNetworkCompanyList COLLECTION  
                        objCreditCardIssuingBankList.Add(objCreditCardIssuingBank);

                    }//End of foreach

                    //Step 6d-once copy process ends, Return objCreditCardMerchantList COLLECTION
                    return objCreditCardIssuingBankList;

                }//End of if
                else
                {
                    //Step 6e- No DTO collection object returned from DALayer, return a null
                    return null;
                }

            }//End of try

            //Step B-Traps for general exception.  
            catch (Exception objE)
            {
                //Step C-Re-Throw a general exceptions
                throw new Exception("Unexpected Error in DALayer_GetAllCreditCardNetworkCompanies() Method: {0} " + objE.Message);

            }
        }


        public void Print()
        {
            try
            {
                // Open or create Network_Printer.txt file for appending
                using (StreamWriter writer = File.AppendText("Network_Printer.txt"))
                {
                    // Write object's data to the file
                    writer.WriteLine("Issuing Bank information:");
                    writer.WriteLine($"Issuing Bank Code = {this.CreditCardIssuingBankCode}");
                    writer.WriteLine($"Issuing Bank Name = {this.CreditCardIssuingBankName}");

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


    }
}


