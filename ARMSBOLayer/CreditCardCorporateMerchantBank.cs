using ARMSDALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class CreditCardCorporateMerchantBank 
    {


        public byte CreditCardCorporateMerchantBankCode { get; set; }
        public string CreditCardCorporateMerchantBankName { get; set; }

        public CreditCardCorporateMerchantBank()
        {
            this.CreditCardCorporateMerchantBankCode = 0;
            this.CreditCardCorporateMerchantBankName = "";
        }

        public CreditCardCorporateMerchantBank(byte CCMBC, string CCMBN)
        {
            this.CreditCardCorporateMerchantBankCode = CCMBC;
            this.CreditCardCorporateMerchantBankName = CCMBN;
        }

        ~CreditCardCorporateMerchantBank()
        {

        }


        public static List<CreditCardCorporateMerchantBank> GetAllCreditCardMerchantBanks()
        {
            try
            {
                // Call the DALayer method to get all credit card processing merchant service companies
                List<CreditCardCorporateMerchantBank> merchantBanks = DALayer_GetAllMerchantBank();

                // Return the list of companies if the method call was successful
                return merchantBanks ?? new List<CreditCardCorporateMerchantBank>();
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                // Return null in case of an exception
                return null;
            }
        }

        protected static List<CreditCardCorporateMerchantBank> DALayer_GetAllMerchantBank() {
            
                try
                {
                    //Step 1-Use DAL object Factory Base Class POINTER to get the SQL Server FACTORY 
                    //Data Access Object using POLYMORPHISM.
                    DALObjectFactoryBase objDAOFactory =
                    DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                    //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work
                    CreditCardCorporateMerchantBankDAO objCreditCardMerchantBankDAO = objDAOFactory.GetCreditCardCorporateMerchantBankDAO();

                    //Step 3-call DAO object to do the work & return COLLECTION of Data Transfer Objects
                    List<CreditCardCorporateMerchantBankDTO> objCreditCardMerchantDTOList = objCreditCardMerchantBankDAO.GetAllRecords();


                    if (objCreditCardMerchantDTOList != null)
                    {

                        //Step 5-Create a LIST Collection of CreditCardNetworkCompany objects to populate with 
                        //the data from each DTO Object in of DTO collection
                        List<CreditCardCorporateMerchantBank> objCreditCardMerchantBankList = new List<CreditCardCorporateMerchantBank>();

                        //Step 6-Loop through the objCreditCardNetworkCompanyDTOList
                        //collection
                        foreach (CreditCardCorporateMerchantBankDTO objDTO in objCreditCardMerchantDTOList)
                        {
                            //Step 6a-Create new CreditCardNetworkCompany object
                            CreditCardCorporateMerchantBank objCreditCardMerchantBank = new CreditCardCorporateMerchantBank();

                            //Step 6b-get the data from DTO object and SET CreditCardNetworkCompany object
                            objCreditCardMerchantBank.CreditCardCorporateMerchantBankCode = objDTO.CreditCardCorporateMerchantBankCode;
                            objCreditCardMerchantBank.CreditCardCorporateMerchantBankName = objDTO.CreditCardCorporateMerchantBankName;

                            //Step 6c-Add CreditCardNetworkCompany Object to the objCreditCardNetworkCompanyList COLLECTION  
                            objCreditCardMerchantBankList.Add(objCreditCardMerchantBank);

                        }//End of foreach

                        //Step 6d-once copy process ends, Return objCreditCardMerchantList COLLECTION
                        return objCreditCardMerchantBankList;

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
                    throw new Exception("Unexpected Error in DALayer_GetAllMerchantBank Method: {0} " + objE.Message);

                }
            }
        }
    }
            
        
    


