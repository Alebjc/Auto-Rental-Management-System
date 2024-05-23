using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public interface ICreditCardDAO
    {
        //*************************************** ICreditCardDAO INTERFACE CODE *******************************************************************

        //######################################################## IMPORTANT WARNING! #######################################################
        //NOTE THAT IS PROVIDED HERE IN THIS DOCUMENT IS THE CODE INSIDE THE INTERFACE. 
        //THE INTERFACE HEADER AND STRUCTURE SHOULD HAVE ALREADY BEEN CREATED VIA VISUAL STUDIO VIA REQUIREMENTS AS INTRUCTED IN THE REQUIREMENT DOCUMENTATION.

        //###########################################################################################################################################



        //====================== START of ICreditCardDAO INTERFACE Declarations =======================================================



        CreditCardDTO GetRecordByID(string key);


        bool Insert(CreditCardDTO objDTO);
        

        


        //====================== END of ICreditCardDAO INTERFACE Declarations =======================================================



    }
}
