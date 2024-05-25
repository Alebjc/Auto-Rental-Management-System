using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class Country 
    {


        public byte CountryID { get; set; }
        public string CountryCode2Char { get; set; }
        public string CountryCode3Char { get; set;  }
        public string CountryName { get; set; }

        public Country()
        {
            this.CountryID = 0;
            this.CountryCode2Char = " ";
            this.CountryCode3Char = "";
            this.CountryName = "";
        }


        public Country(byte CID, string CC2, string CC3, string CN)
        {
            this.CountryID = CID;
            this.CountryCode2Char = CC2;
            this.CountryCode3Char = CC3;
            this.CountryName = CN;
        }

        ~Country()
        {

        }


        public static List<Country> GetAllCountries()
        {
            try
            {
                // Call the DALayer method to get all credit card processing merchant service companies
                List<Country> countries = DALayer_GetAllCountries();

                // Return the list of companies if the method call was successful
                return countries ?? new List<Country>();
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                // Return null in case of an exception
                return null;
            }
        }

        protected static List<Country> DALayer_GetAllCountries()
        {
            //Step A-Start Error Trapping
            try
            {
                //Step 1-Use DAL object Factory Base Class POINTER to get the SQL Server FACTORY 
                //Data Access Object using POLYMORPHISM.
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work
                CountryDAO objCountryDAO = objDAOFactory.GetCountryDAO();

                //Step 3-call DAO object to do the work & return COLLECTION of Data Transfer Objects
                List<CountryDTO> objCountryDTOList = objCountryDAO.GetAllRecords();

                //Step 4- test if objCreditCardNetworkCompanyDTOList DTO collection exists (returned from DBMS) 
                if (objCountryDTOList != null)
                {

                    //Step 5-Create a LIST Collection of CreditCardNetworkCompany objects to populate with 
                    //the data from each DTO Object in of DTO collection
                    List<Country> objCountryList = new List<Country>();

                    //Step 6-Loop through the objCreditCardNetworkCompanyDTOList
                    //collection
                    foreach (CountryDTO objDTO in objCountryDTOList)
                    {
                        //Step 6a-Create new CreditCardNetworkCompany object
                        Country objCountry = new Country();
                        //Step 6b-get the data from DTO object and SET CreditCardNetworkCompany object
                        objCountry.CountryCode2Char = objDTO.CountryCode2Char;
                        objCountry.CountryCode3Char = objDTO.CountryCode3Char;
                        objCountry.CountryID = objDTO.CountryID;
                        objCountry.CountryName = objDTO.CountryName;

                        //Step 6c-Add CreditCardNetworkCompany Object to the objCreditCardNetworkCompanyList COLLECTION  
                        objCountryList.Add(objCountry);

                    }//End of foreach

                    //Step 6d-once copy process ends, Return objCreditCardMerchantList COLLECTION
                    return objCountryList;

                }//End of if

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
                throw new Exception("Unexpected Error in DALayer_GetAllCountries() Method: {0} " + objE.Message);

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
                    writer.WriteLine("Countries information:");
                    writer.WriteLine($"Country ID = {this.CountryID}");
                    writer.WriteLine($"Country Code 2 = {this.CountryCode2Char}");
                    writer.WriteLine($"Country Code 3 = {this.CountryCode3Char}");
                    writer.WriteLine($"Country Name = {this.CountryName}");

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



