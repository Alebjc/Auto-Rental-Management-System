﻿using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class CreditCardProcessingMerchantServiceCompany
    {


        //***************************************CREDIT CARD CLASS*******************************************************************

        //######################################################## IMPORTANT WARNING! #######################################################
        //NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE CLASS OR METHOD SHOWN HERE. 
        //FOR A CLASS, THE CLASS HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################



        //====================== START of Protected DALayer Methods SPRINT #2 =======================================================

        


        public byte CreditCardProcessingMerchantServiceCompanyCode { get; set; }
        public string CreditCardProcessingMerchantServiceCompanyName { get; set; }

        public CreditCardProcessingMerchantServiceCompany()
        {
            this.CreditCardProcessingMerchantServiceCompanyCode = 0;
            this.CreditCardProcessingMerchantServiceCompanyName = "";
        }

        ~CreditCardProcessingMerchantServiceCompany()
        {

        }

        public CreditCardProcessingMerchantServiceCompany(byte creditCardProcessingMerchantServiceCompanyCode, string creditCardProcessingMerchantServiceCompanyName)
        {
            this.CreditCardProcessingMerchantServiceCompanyCode = creditCardProcessingMerchantServiceCompanyCode;
            this.CreditCardProcessingMerchantServiceCompanyName = creditCardProcessingMerchantServiceCompanyName;
        }

        #region "PROTECTED BUSINESS LAYER DATA ACCESS METHODS DECLARATIONS"

        /******************************************************************
          Protected DATA ACCESS METHODS Declarations
         ******************************************************************/

        //=================================================================
        //Name:         STATIC DALayer_GetAllCreditCardProcessingMerchantServiceCompanies() 
        //Purpose:      protected STATIC Data Access Method that executes the 
        //              fetching of all the Credit Card Processing Merchant
        //              Service Company records from the database.
        //Algorithm:    Step 1-Calls the DALObjectFactoryBase
        //              GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER)  
        //              method in the Data Access Layer services
        //              using POLYMORPHISM to get a SQLServerDAOFactory Object.
        //              Uses the SQLServerDAOFactory Object
        //              GetCreditCardProcessingMerchantServiceCompanyDAO() 
        //              to GET a CreditCardProcessingMerchantServiceCompanyDAO 
        //              Object to perform the data access by calling its
        //              GetAllRecords() Method to do the work and  
        //              query the database and return a LIST COLLECTION  
        //              of of all the Credit Card Processing Merchant 
        //              Companies in the database table.
        //Parameter:    None.
        //Return Value: LIST COLLECTION with all the Credit Card Processing
        //              Merchant Companu records.






        public static List<CreditCardProcessingMerchantServiceCompany> GetAllCreditCardProcessingMerchantServiceCompanies()
        {
            try
            {
                // Call the DALayer method to get all credit card processing merchant service companies
                List<CreditCardProcessingMerchantServiceCompany> merchantServiceCompanies = DALayer_GetAllCreditCardProcessingMerchantServiceCompanies();

                // Return the list of companies if the method call was successful
                return merchantServiceCompanies ?? new List<CreditCardProcessingMerchantServiceCompany>();
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                // Return null in case of an exception
                return null;
            }
        }


        protected static List<CreditCardProcessingMerchantServiceCompany> DALayer_GetAllCreditCardProcessingMerchantServiceCompanies()
        {
            //Step A-Start Error Trapping
            try
            {
                //Step 1-Use DAL object Factory Base Class POINTER to get the SQL Server FACTORY 
                //Data Access Object using POLYMORPHISM.
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work
                CreditCardProcessingMerchantServiceCompanyDAO objCreditCardProcessingMerchantServiceCompanyDAO = objDAOFactory.GetCreditCardProcessingMerchantServiceCompanyDAO();

                //Step 3-call DAO object to do the work & return COLLECTION of Data Transfer Objects
                List<CreditCardProcessingMerchantServiceCompanyDTO> objCreditCardProcessingMerchantServiceCompanyDTOList = objCreditCardProcessingMerchantServiceCompanyDAO.GetAllRecords();

                //Step 4- test if objCreditCardProcessingMerchantServiceCompanyDTOList DTO collection exists (returned from DBMS) 
                if (objCreditCardProcessingMerchantServiceCompanyDTOList != null)
                {
                    //Step 5-Create a LIST Collection of Credit Card Merchant objects to populate with 
                    //the data from each DTO Object in of DTO collection
                    List<CreditCardProcessingMerchantServiceCompany> objCreditCardProcessingMerchantServiceCompanyList = new List<CreditCardProcessingMerchantServiceCompany>();

                    //Step 6-Loop through the objCreditCardProcessingMerchantServiceCompanyDTOList collection
                    foreach (CreditCardProcessingMerchantServiceCompanyDTO objDTO in objCreditCardProcessingMerchantServiceCompanyDTOList)
                    {
                        //Step 6a-Create new CreditCardProcessingMerchantServiceCompany object
                        CreditCardProcessingMerchantServiceCompany objCreditCardProcessingMerchantServiceCompany = new CreditCardProcessingMerchantServiceCompany();

                        //Step 6b-get the data from DTO object and SET Credit Card Merchant object
                        objCreditCardProcessingMerchantServiceCompany.CreditCardProcessingMerchantServiceCompanyCode = objDTO.CreditCardProcessingMerchantServiceCompanyCode;
                        objCreditCardProcessingMerchantServiceCompany.CreditCardProcessingMerchantServiceCompanyName = objDTO.CreditCardProcessingMerchantServiceCompanyName;

                        //Step 6c-Add CreditCardMerchant Object to the objCreditCardProcessingMerchantServiceCompanyList COLLECTION  
                        objCreditCardProcessingMerchantServiceCompanyList.Add(objCreditCardProcessingMerchantServiceCompany);

                    }//End of foreach

                    //Step 6d-once copy process ends, Return objCreditCardMerchantList COLLECTION
                    return objCreditCardProcessingMerchantServiceCompanyList;

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
                throw new Exception("Unexpected Error in DALayer_GetAllCreditCardProcessingMerchantServiceCompanies() Method: {0} " + objE.Message);

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
                    writer.WriteLine("Merchant Information");
                    writer.WriteLine($"Merchant Code = {this.CreditCardProcessingMerchantServiceCompanyCode}");
                    writer.WriteLine($"Merchant Name = {this.CreditCardProcessingMerchantServiceCompanyName}");
                    
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


        #endregion



        //====================== END of Protected DALayer Methods in SPRINT #2 =======================================================










    }
}
