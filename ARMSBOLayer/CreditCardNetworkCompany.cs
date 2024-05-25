using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class CreditCardNetworkCompany
    {
        //***************************************CREDIT CARD CLASS*******************************************************************

        //######################################################## IMPORTANT WARNING! #######################################################
        //NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE CLASS OR METHOD SHOWN HERE. 
        //FOR A CLASS, THE CLASS HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################


        public byte CreditCardNetworkCompanyCode { get; set; }
        public string CreditCardNetworkCompanyName { get; set; }

        //====================== START of Protected DALayer Methods SPRINT #2 =======================================================


        // #endregion "PUBLIC INSTANCE & STATIC DATA ACCESS METHODS"

        /******************************************************************
          Protected DATA ACCESS METHODS Declarations
         ******************************************************************/

        //=================================================================
        //Name:         STATIC DALayer_GetAllCreditCardNetworkCompanies() 
        //Purpose:      protected STATIC Data Access Method that executes the 
        //              fetching of all the Credit Card Network Company
        //              records from the database.
        //Algorithm:    Step 1-Calls the DALObjectFactoryBase
        //              GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER)  
        //              method in the Data Access Layer services
        //              using POLYMORPHISM to get a SQLServerDAOFactory Object.
        //              Uses the SQLServerDAOFactory Object GetCreditCardNetworkCompanyDAO()
        //              Method to GET a GetCreditCardNetworkCompanyDAO Object 
        //              to perform the data access by calling its GetAllRecords()
        //              Method to do the work and  
        //              query the database and return a LIST COLLECTION  
        //              of of all the Credit Card Network Companies 
        //              in the database table.
        //Parameter:    None.
        //Return Value: LIST COLLECTION with all the Credit Card
        //              Network Company records.
        public CreditCardNetworkCompany()
        {
            this.CreditCardNetworkCompanyCode = 0;
            this.CreditCardNetworkCompanyName = "";
        }

        public CreditCardNetworkCompany(byte CNCC, string CNCN)
        {
            this.CreditCardNetworkCompanyCode = CNCC;
            this.CreditCardNetworkCompanyName = CNCN;
        }
        ~CreditCardNetworkCompany()
        {

        }


        public static List<CreditCardNetworkCompany> GetAllCreditCardNetworkCompanies()
        {
            try
            {
                // Call the DALayer method to get all credit card processing merchant service companies
                List<CreditCardNetworkCompany> networkCompanies = DALayer_GetAllCreditCardNetworkCompanies();

                // Return the list of companies if the method call was successful
                return networkCompanies ?? new List<CreditCardNetworkCompany>();
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                // Return null in case of an exception
                return null;
            }
        }

        protected static List<CreditCardNetworkCompany> DALayer_GetAllCreditCardNetworkCompanies()
        {
            //Step A-Start Error Trapping
            try
            {
                //Step 1-Use DAL object Factory Base Class POINTER to get the SQL Server FACTORY 
                //Data Access Object using POLYMORPHISM.
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work
                CreditCardNetworkCompanyDAO objCreditCardNetworkCompanyDAO = objDAOFactory.GetCreditCardNetworkCompanyDAO();

                //Step 3-call DAO object to do the work & return COLLECTION of Data Transfer Objects
                List<CreditCardNetworkCompanyDTO> objCreditCardNetworkCompanyDTOList = objCreditCardNetworkCompanyDAO.GetAllRecords();

                //Step 4- test if objCreditCardNetworkCompanyDTOList DTO collection exists (returned from DBMS) 
                if (objCreditCardNetworkCompanyDTOList != null)
                {

                    //Step 5-Create a LIST Collection of CreditCardNetworkCompany objects to populate with 
                    //the data from each DTO Object in of DTO collection
                    List<CreditCardNetworkCompany> objCreditCardNetworkCompanyList = new List<CreditCardNetworkCompany>();

                    //Step 6-Loop through the objCreditCardNetworkCompanyDTOList
                    //collection
                    foreach (CreditCardNetworkCompanyDTO objDTO in objCreditCardNetworkCompanyDTOList)
                    {
                        //Step 6a-Create new CreditCardNetworkCompany object
                        CreditCardNetworkCompany objCreditCardNetworkCompany = new CreditCardNetworkCompany();

                        //Step 6b-get the data from DTO object and SET CreditCardNetworkCompany object
                        objCreditCardNetworkCompany.CreditCardNetworkCompanyCode = objDTO.CreditCardNetworkCompanyCode;
                        objCreditCardNetworkCompany.CreditCardNetworkCompanyName = objDTO.CreditCardNetworkCompanyName;

                        //Step 6c-Add CreditCardNetworkCompany Object to the objCreditCardNetworkCompanyList COLLECTION  
                        objCreditCardNetworkCompanyList.Add(objCreditCardNetworkCompany);

                    }//End of foreach

                    //Step 6d-once copy process ends, Return objCreditCardMerchantList COLLECTION
                    return objCreditCardNetworkCompanyList;

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

        }//End of method

        public void Print()
        {
            try
            {
                // Open or create Network_Printer.txt file for appending
                using (StreamWriter writer = File.AppendText("Network_Printer.txt"))
                {
                    // Write object's data to the file
                    writer.WriteLine("Network Company information:");
                    writer.WriteLine($"Network Company Code = {this.CreditCardNetworkCompanyCode}");
                    writer.WriteLine($"Network Company Name = {this.CreditCardNetworkCompanyName}");

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

        //#endregion






        //====================== END of Protected DALayer Methods in SPRINT #2 =======================================================










    }
}
