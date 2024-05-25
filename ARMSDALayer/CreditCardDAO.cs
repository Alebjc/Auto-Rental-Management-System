using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARMSDALayer
{
    public class CreditCardDAO: ICreditCardDAO
    {
        //***************************************CREDITCARDDAO CLASS CODE *******************************************************************

        //######################################################## IMPORTANT WARNING! #######################################################
        //NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE CLASS. 
        //THE CLASS HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################




        //====================== START of CREDITCARDDAO Class DATA ACCESS METHOD GetRecordByID(key) =======================================================


        //=================================================================
        //Name:         GetRecordByID(key) Method
        //Purpose:      Methods that performs the LOADING of Data Access  
        //              using ADO.NET Library. The Method retrieves a 
        //              CreditCard RECORD based on Credit Card Number ID 
        //              or primary key as parameter which is used to construct 
        //              the SELECT query.
        //Parameter:    The key/ID of the object to load. Credit Card Number.
        //Return Value: A populated Data Transfer Object POINTER if record  
        //              loaded from database, or a NULL otherwise.
        //Error-code:   Trap for GENERAL EXCEPTION? 
        //              and RE-TROW EXCEPTION so that calling program can handle
        public CreditCardDTO GetRecordByID(string key)
        {

            //Step 1-GET the Connection from SQLServerDAOFactory Object & Create ADO SqlConnection Object
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());

            //Step A-Start Error Trapping
            try
            {
                //Step 2-Open connection
                objConn.Open();

                //Step 3-Create SQL string
                //string strSQL = "SELECT * FROM CreditCard WHERE CreditCardNumber = @CreditCardNumber;";

                string strSQL = "SELECT CREDITCARD.CreditCardNumber, " +
                "CREDITCARD.CreditCardOwnerName, " +
                "CREDITCARD.CreditCardProcessingMerchantServiceCompanyCode, " +
                "CREDITCARDPROCESSINGMERCHANTSERVICECOMPANY.CreditCardProcessingMerchantServiceCompanyName, " +
                "CREDITCARD.CreditCardNetworkCompanyCode, CREDITCARDNETWORKCOMPANY.CreditCardNetworkCompanyName, " +
                "CREDITCARD.CreditCardIssuingBankCode, CREDITCARDISSUINGBANK.CreditCardIssuingBankName,  " +
                "CREDITCARD.CreditCardCorporateMerchantBankCode, " +
                "CREDITCARDCORPORATEMERCHANTBANK.CreditCardCorporateMerchantBankName, " +
                "CREDITCARD.ExpDate, CREDITCARD.AddressLine1, CREDITCARD.AddressLine2, CREDITCARD.City, " +
                "CREDITCARD.StateCode, CREDITCARD.ZipCode, CREDITCARD.Country, " +
                "CREDITCARD.CreditCardLimit, CREDITCARD.CreditCardAvailableCredit, CREDITCARD.ActivationStatus " +
                "FROM CREDITCARD, CREDITCARDPROCESSINGMERCHANTSERVICECOMPANY, " +
                "CREDITCARDNETWORKCOMPANY, CREDITCARDISSUINGBANK, CREDITCARDCORPORATEMERCHANTBANK " +
                "WHERE CREDITCARD.CreditCardProcessingMerchantServiceCompanyCode = " +
                "CREDITCARDPROCESSINGMERCHANTSERVICECOMPANY.CreditCardProcessingMerchantServiceCompanyCode AND " +
                "CREDITCARD.CreditCardNetworkCompanyCode = CREDITCARDNETWORKCOMPANY.CreditCardNetworkCompanyCode AND " +
                "CREDITCARD. CreditCardIssuingBankCode = CREDITCARDISSUINGBANK.CreditCardIssuingBankCode AND " +
                "CREDITCARD.CreditCardCorporateMerchantBankCode = CREDITCARDCORPORATEMERCHANTBANK.CreditCardCorporateMerchantBankCode AND " +
                "CREDITCARD.CreditCardNumber = @CreditCardNumber;";

                //Step 4-Create Command object, pass query and connection object
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                //Step 5-SET CommandType Property to text since we have a query string & NOT a Stored-Procedure
                //For stored procedures syntax is objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandType = CommandType.Text;

                //Step 6-Add Parameter to. NOTE WE ARE ASSIGNING METHOD PARAMETER
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = key;

                //Step 7-Create DATAREADER POINTER & Execute Query via
                //COMMAND OBJECT ExecuteReader Method which returns a populated
                //DATAREADER OBJECT with the results of the query
                SqlDataReader objDR = objCmd.ExecuteReader();

                //Step 8-Test to make sure there is data in the DataReader Object
                if (objDR.HasRows)
                {
                    //Create Data Transfer Object
                    CreditCardDTO objDTO = new CreditCardDTO();

                    //Step 8a-Call Read() Method to point and read the first record
                    objDR.Read();

                    //Step 8b-Extract data from a row s Object Populates itself.
                    //IMPORTANT! Note that data must be extracted in the ORDER 
                    //in which the QUERY RETURNS THE DATA.
                    objDTO.CreditCardNumber = objDR.GetString(0);
                    objDTO.CreditCardOwnerName = objDR.GetString(1);
                    objDTO.CreditCardProcessingMerchantServiceCompanyCode = objDR.GetByte(2);
                    objDTO.CreditCardProcessingMerchantServiceCompanyName = objDR.GetString(3);
                    objDTO.CreditCardNetworkCompanyCode = objDR.GetByte(4);
                    objDTO.CreditCardNetworkCompanyName = objDR.GetString(5);
                    objDTO.CreditCardIssuingBankCode = objDR.GetByte(6);
                    objDTO.CreditCardIssuingBankName = objDR.GetString(7);
                    objDTO.CreditCardCorporateMerchantBankCode = objDR.GetByte(8);
                    objDTO.CreditCardCorporateMerchantBankName = objDR.GetString(9);
                    objDTO.ExpDate = objDR.GetDateTime(10);
                    objDTO.AddressLine1 = objDR.GetString(11);
                    objDTO.AddressLine2 = objDR.GetString(12);
                    objDTO.City = objDR.GetString(13);
                    objDTO.StateCode = objDR.GetString(14);
                    objDTO.ZipCode = objDR.GetString(15);
                    objDTO.Country = objDR.GetString(16);
                    objDTO.CreditCardLimit = objDR.GetDecimal(17);
                    objDTO.CreditCardAvailableCredit = objDR.GetDecimal(18);
                    objDTO.CreditCardActivationStatus = objDR.GetBoolean(19);

                    //Step 8b- Return Data Transfer Object
                    return objDTO;

                }

                //Step 9 - Terminate ADO Objects
                objDR.Close();
                objDR = null;
                objCmd.Dispose();
                objCmd = null;

                //Step10- return null since no data found
                return null;

            }//End of try

            //Step B-Trap for BO, App & General Exceptions
            catch (Exception objE)
            {
                //Step C- throw system exception since run time error has occurred.
                throw new Exception("Unexpected Error in CreditCardADO GetRecordByID(key) Method: {0}" + objE.Message);
            }
            finally
            {
                //Step 11-Terminate connection
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }//End of GetRecordByID

       

        public bool Insert(CreditCardDTO objDTO)
        {

            //Step 1-GET the Connection from SQLServerDAOFactory Object & Create ADO SqlConnection Object
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());

            //Step A-Start Error Trapping
            try
            {
                //Step 2-Open connection
                objConn.Open();

                //Step 3-Create SQL string
                string strSQL;

                strSQL = "INSERT INTO CreditCard (CreditCardNumber, CreditCardOwnerName, " +
                "CreditCardProcessingMerchantServiceCompanyCode, CreditCardNetworkCompanyCode, " +
                "CreditCardIssuingBankCode, CreditCardCorporateMerchantBankCode, ExpDate, " +
                "AddressLine1, AddressLine2, City, StateCode, ZipCode, Country, " +
                "CreditCardLimit, CreditCardAvailableCredit, ActivationStatus) " +
                "VALUES(@CreditCardNumber, @CreditCardOwnerName, " +
                "@CreditCardProcessingMerchantServiceCompanyCode, @CreditCardNetworkCompanyCode, " +
                "@CreditCardIssuingBankCode, @CreditCardCorporateMerchantBankCode, " +
                "@ExpDate, @AddressLine1, @AddressLine2, @City, @StateCode, @ZipCode, @Country, " +
                "@CreditCardLimit, @CreditCardAvailableCredit, @ActivationStatus);";

                //Step 4-Create Command object, pass query and connection object
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                //Step 5-SET CommandType Property to text since we have a query string & NOT a Stored-Procedure
                //For stored procedures syntax is objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandType = CommandType.Text;

                //Step 6-Add Parameter to. NOTE WE ARE ASSIGNING METHOD PARAMETER
                //IMPORTANT! Parameter TOKENS @XXXXX name must match same name Used in the INSERT QUERY 
                //AND IN LISTED IN THE ORDER LISTED IN INSERT QUERY! NOTE WE ARE ASSIGNING ALL OBJECT'S DATA
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = objDTO.CreditCardNumber;
                objCmd.Parameters.Add("@CreditCardOwnerName", SqlDbType.VarChar).Value = objDTO.CreditCardOwnerName;
                objCmd.Parameters.Add("@CreditCardProcessingMerchantServiceCompanyCode", SqlDbType.TinyInt).Value = objDTO.CreditCardProcessingMerchantServiceCompanyCode;
                objCmd.Parameters.Add("@CreditCardNetworkCompanyCode", SqlDbType.TinyInt).Value = objDTO.CreditCardNetworkCompanyCode;
                objCmd.Parameters.Add("@CreditCardIssuingBankCode", SqlDbType.TinyInt).Value = objDTO.CreditCardIssuingBankCode;
                objCmd.Parameters.Add("@CreditCardCorporateMerchantBankCode", SqlDbType.TinyInt).Value = objDTO.CreditCardCorporateMerchantBankCode;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.DateTime).Value = objDTO.ExpDate;
                objCmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = objDTO.AddressLine1;
                objCmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = objDTO.AddressLine2;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@StateCode", SqlDbType.Char).Value = objDTO.StateCode.ToCharArray();
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@CreditCardLimit", SqlDbType.Decimal).Value = objDTO.CreditCardLimit;
                objCmd.Parameters.Add("@CreditCardAvailableCredit", SqlDbType.Decimal).Value = objDTO.CreditCardAvailableCredit;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDTO.CreditCardActivationStatus;


                //Step 7-Execute ACTION-Query, Test result and throw exception if failed
                int intRecordsAffected = objCmd.ExecuteNonQuery();

                //Step 8-validate if INSERT QUERY was successful
                if (intRecordsAffected == 1)
                {
                    //Step 8a-Return true
                    return true;
                }

                //Step 9 - Terminate ADO Objects
                objCmd.Dispose();
                objCmd = null;

                //Step10-return false
                return false;

            }//End of try
             //Step B-Trap for BO, App & General Exceptions
            catch (Exception objE)
            {
                //Step C- throw system exception since run time error has occurred.
                throw new Exception("Unexpected Error in CreditCardADO Insert(CreditCardDTO objDTO) Method: {0} " + objE.Message);
            }
            finally
            {
                //Step 11-Terminate connection
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }//End of Insert


        //====================== END of CREDITCARDDAO Class DATA ACCESS METHOD GetRecordByID(key)S =======================================================





















    }
}
