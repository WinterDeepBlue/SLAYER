using System;

namespace humanResource.LOGIN.SLAYER
{
        /*     instanciating class hashcheck allows us to use basic & secure hash check.
         *     hash_func_ordinalcasesensitive method check case sensitive combination of given string
         *     secure hash has both case in-sensitive & CASE sensitive checks
         */
        public class HashCheck
        {    //genralhash->scheme
            public bool hash_func_ordinaCaseSensitive(string value,string hString/*fetch hash from dataset database*/)
            {
                HashBasic hsaob = new HashBasic();
            
                if (hsaob.hash_func(value).Equals(hString,StringComparison.Ordinal))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //forsecurehash->scheme
            public bool sHash_func_oridinalCaseInSensitive(string value,string hString/*fetch hash from dataset database*/,bool _case)
            {
                Securehash hsaob = new Securehash();
                StringComparer sComp = StringComparer.OrdinalIgnoreCase;

                if (_case)//case-sensitive
                {
                    if (hsaob.Guid(value).Equals(hString,StringComparison.Ordinal))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else//case in-sensitive
                {
                    if (0 == sComp.Compare(hsaob.Guid(value), hString))//returns zero at true case check
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
             
            }
        }
    

}