using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class USState 
    {


        public byte StateID { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }

        public USState()
        {
            this.StateID = 0;
            this.StateCode = "";
            this.StateName = "";
        }

        public USState(byte SID, string SC, string SN)
        {
            this.StateID = SID;
            this.StateCode = SC;
            this.StateName = SN;
        }

        ~USState()
        {

        }


        public static List<USState> GetAllUSStates()
        {
            try
            {
                // Call the DALayer method to get all credit card processing merchant service companies
                List<USState> usStates = DALayer_GetAllStates();

                // Return the list of companies if the method call was successful
                return usStates ?? new List<USState>();
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                // Return null in case of an exception
                return null;
            }
        }

        protected static List<USState> DALayer_GetAllStates()
        {
            //Step A-Start Error Trapping
            try
            {
                //Step 1-Use DAL object Factory Base Class POINTER to get the SQL Server FACTORY 
                //Data Access Object using POLYMORPHISM.
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work
                USStateDAO objUSStateDAO = objDAOFactory.GetUSStateDAO();

                //Step 3-call DAO object to do the work & return COLLECTION of Data Transfer Objects
                List<USStateDTO> objUSStateDTOList = objUSStateDAO.GetAllRecords();

                //Step 4- test if objCreditCardNetworkCompanyDTOList DTO collection exists (returned from DBMS) 
                if (objUSStateDTOList != null)
                {

                    //Step 5-Create a LIST Collection of CreditCardNetworkCompany objects to populate with 
                    //the data from each DTO Object in of DTO collection
                    List<USState> objUSStatesList = new List<USState>();

                    //Step 6-Loop through the objCreditCardNetworkCompanyDTOList
                    //collection
                    foreach (USStateDTO objDTO in objUSStateDTOList)
                    {
                        //Step 6a-Create new CreditCardNetworkCompany object
                        USState objUSState = new USState();
                        //Step 6b-get the data from DTO object and SET CreditCardNetworkCompany object
                        objUSState.StateID = objDTO.StateID;
                        objUSState.StateCode = objDTO.StateCode;
                        objUSState.StateName = objDTO.StateName;


                        //Step 6c-Add CreditCardNetworkCompany Object to the objCreditCardNetworkCompanyList COLLECTION  
                        objUSStatesList.Add(objUSState);

                    }//End of foreach

                    //Step 6d-once copy process ends, Return objCreditCardMerchantList COLLECTION
                    return objUSStatesList;

                }
                //End of if
                else
                {
                    //Step 6e- No DTO collection object returned from DALayer, return a null
                    return null;
                }

            }
            //End of try

            //Step B-Traps for general exception.  
            catch (Exception objE)
            {
                //Step C-Re-Throw a general exceptions
                throw new Exception("Unexpected Error in DALayer_GetAllStates() Method: {0} " + objE.Message);

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
                    writer.WriteLine("US State information:");
                    writer.WriteLine($"US State ID = {this.StateID}");
                    writer.WriteLine($"US State Code = {this.StateCode}");
                    writer.WriteLine($"US State Name = {this.StateName}");

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


