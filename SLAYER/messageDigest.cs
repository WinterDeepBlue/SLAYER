using System;
using System.Security.Cryptography;
using System.Text;

namespace humanResource.LOGIN.SLAYER
{
    public class Salt
    {
        #region salt
        RIPEMD160Managed rip160;
        string hashp = endpoint((rip160 = new RIPEMD160Managed()), GetRandomBytes(1000 * 1024));

        static byte[] GetRandomBytes(int count)
                    {
                        var bytes = new byte[count];
                        (new Random()).NextBytes(bytes);
                        return bytes;
                    }

        static string endpoint(RIPEMD160Managed ripmd160, byte[] source)
                    {
                        byte[] hash = ripmd160.ComputeHash(source);
                        string hashString = string.Empty;
                        foreach (byte x in hash)
                        {
                            hashString += string.Format("{0:x2}", x);
                        }
                        return hashString;
                    }
        
        #endregion

        /*private string salty = "$#AX&";*/    /// <summary>
                                           /// NEED TO DEVELOP CUSTOM->SALT
                                           /// </summary>
        private string _frame;
        private int _innerC;
        private int _outerC;

        // private int[] t_buffer;
        protected string MixBuffer
        {
            //property-declaration
            get {      return _frame; }
            set
                {      //ob instanciation
                       /*HashBasic hashobj = new HashBasic();         */ //for-?generalUTF8HASH digestion
                       StringBuilder stringBld = new StringBuilder();//append(elementsof,H_STRING)
                       StringBuilder stringCom = new StringBuilder();//append(quad_set,salt)

                       string hString = HashBasic.hash_func(value);
                    char[] dframe = hString.ToCharArray();
                    foreach (char element in dframe)
                                           {    //t_buffer[element] = h_string[element];
                                                stringBld.Append(element);
                                                _innerC+=1;
                                                //I/O builds.append
                                                   if(_innerC.Equals(8))//cond.check(>append{9}+salt)
                                                   {
                                                       if(_outerC<5)/* bug line *///salt-sequence cont.control 3x
                                                       {
                                                           stringCom.Append(string.Concat(stringBld.ToString(), salty));
                                                           //wipe-in out->stringbuilderobj(clear)method
                                                           stringBld.Clear();
                                                           _innerC = 0;
                                                           _outerC += 1;
                                                       }
                                                   }
                                           }
                        //forperforming-?UniqueHashSequence
                        //split(string) >basic at 4 pieces, +salt keep in-consider ie.mixing ->float could be difficult to get opperate on
                       _frame = stringCom.ToString(); //*/
                   }
        }
    }

    #region secureHash>level_2
     //working module tag****************
     public class Securehash : Salt  //secure->hashUTF32(support very bloated keys @4B)
        {
            public string Guid(string buffer)
            {
                MixBuffer = buffer;//properties->decl
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(MixBuffer));//returns hash create from mix-buffer property
                    Guid result = new Guid(hash);
                    return result.ToString();
                }
            }
        }
    #endregion

    #region basicHash
    //working module tag****************
    public static class HashBasic//basic->hash
        {
             public static string hash_func(string buffer)
                     {
                         using (MD5 mHash = MD5.Create())
                         {
                             string hash = GetM_hash(mHash, buffer);
                             return hash;
                         }
                     }
              //creating->hash(bundle)
              private static string GetM_hash(MD5 mHash, string buffer)
                    {
                        byte[] hash = mHash.ComputeHash(Encoding.UTF8.GetBytes(buffer));
                        //initiating string-?bundler>
                        StringBuilder stBuild = new StringBuilder();
                        //bundler
                        for (int i = 0; i < hash.Length; i++)
                            stBuild.Append(hash[i].ToString("x2"));
                        //return->bundlestringcase->hashfunc
                        return stBuild.ToString();
                    }
        }
    #endregion
}
