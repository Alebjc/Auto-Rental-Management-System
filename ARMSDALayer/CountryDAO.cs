﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public class CountryDAO : IUserInterfaceSupportDAO<CountryDTO>
    {

        public List<CountryDTO> GetAllRecords()
        {

            //Step 1-GET the Connection from SQLServerDAOFactory Object & Create ADO SqlConnection Object  
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());

            //Step A-Start Error Trapping
            try
            {
                //Step 2-Open connection
                objConn.Open();

                //Step 3-Create SQL string
                string strSQL = "SELECT * FROM Country;";

                //Step 4-Create Command object, pass query and connection object
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                //Step 5-SET CommandType Property to text since we have a query string & NOT a Stored-Procedure
                //For stored procedures syntax is objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandType = CommandType.Text;


                //Step 7-Create DATAREADER POINTER & Execute Query via
                //COMMAND OBJECT ExecuteReader Method which returns a populated
                //DATAREADER OBJECT with the results of the query
                SqlDataReader objDR = objCmd.ExecuteReader();

                //Step 8-Test to make sure there is data in the DataReader Object
                if (objDR.HasRows)
                {
                    //Step 9-Test Create a Generic List Collection Object of Data Transfer Objects
                    List<CountryDTO> colRecordList = new List<CountryDTO>();

                    //Step 10-Loop through the Collection to Add Data Transfer Object
                    while (objDR.Read())
                    {
                        //10a-Create Data Transfer Object
                        CountryDTO objDTO = new CountryDTO();

                        //10b-Populate Data Transfer Object with DataReader records. IMPORTANT! Note that data
                        // must be extracted in the ORDER in which the QUERY RETURNS THE DATA.
                        objDTO.CountryID = objDR.GetByte(0);
                        objDTO.CountryCode2Char = objDR.GetString(1);
                        objDTO.CountryCode3Char = objDR.GetString(2);
                        objDTO.CountryName = objDR.GetString(3);

                        //Step 10c-Add Data Transfer Object to the collection
                        colRecordList.Add(objDTO);

                    }//End of loop

                    //Step 11-Return the collection
                    return colRecordList;
                }
                else
                {
                    //Step 12 - Terminate ADO Objects
                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;

                    //Step13-return null since no records found
                    return null;

                }//End of if/else
            }//End of try
             //Step B-Trap for BO, App & General Exceptions
            catch (Exception objE)
            {
                //Step C- throw system exception since run time error has occurred.
                throw new Exception("Unexpected Error in CreditCardNetworkCompanyDAO " +
                    "GetAllRecords() Method: {0} " + objE.Message);
            }
            finally
            {
                //Step 11-Terminate connection
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }//End of GetAllRecords





        public List<CountryDTO> getAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
