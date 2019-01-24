using humanResource.APPCODE.BLL.department;
using humanResource.LOGIN.CORE;
using System.Data;
using humanResource.LOGIN.SLAYER;
namespace humanResource.LOGIN.SLAYER.SESSION
{
    public class Register
    {
        CoreX obj = new CoreX();
        #region insesrtUpdate
            public int KeyManagerInsertQ(string username, string hrFname, string hrLname, string password)
            {
                
                string InsertQuery = "Insert into keyManager(guid,username,hrFname,hrLname,password) Values(@guid,@username,@hrFname,@hrLname,@password)";
                GUID buffer = new GUID();
                Securehash bufferx = new Securehash();
                NameValuePairList nameValuePairObject = new NameValuePairList();
                nameValuePairObject.Add(new NameValuePair("@guid", bufferx.Guid(username)));
                nameValuePairObject.Add(new NameValuePair("@username", username));
                nameValuePairObject.Add(new NameValuePair("@hrFname", hrFname));
                nameValuePairObject.Add(new NameValuePair("@hrLname", hrLname));
                nameValuePairObject.Add(new NameValuePair("@password", password));

                int status = obj.InsertUpdateOrDelete(InsertQuery, nameValuePairObject);
                return status;
            }
        //need to re->write
            public int KeyManagerUpdate(string username, string hrFname, string hrLname, string password)
            {
                
                string updateQuery = "UPDATE keyManager SET into keyManager(guid,username,hrFname,hrLname,password) Values(@guid,@username,@hrFname,@hrLname,@password)";
                GUID buffer = new GUID();
                NameValuePairList nameValuePairObject = new NameValuePairList();
                nameValuePairObject.Add(new NameValuePair("@guid", buffer.hashFunc(username)));
                nameValuePairObject.Add(new NameValuePair("@username", username));
                nameValuePairObject.Add(new NameValuePair("@hrFname", hrFname));
                nameValuePairObject.Add(new NameValuePair("@hrLname", hrLname));
                nameValuePairObject.Add(new NameValuePair("@password", password));

                int status = obj.InsertUpdateOrDelete(updateQuery, nameValuePairObject);
                return status;
            }

            //login-session
            public int LoginInfoInsert(string username, string hrFname, string hrLname, string password)
            {
               
                string InsertQuery = "Insert into loginInfo(sessionId,guid,sessionTime) Values(@sessionId,@guid,@sessionTime)";
                GUID buffer = new GUID();
                NameValuePairList nameValuePairObject = new NameValuePairList();
                nameValuePairObject.Add(new NameValuePair("@sessionId", buffer.hashFunc(username)));
                nameValuePairObject.Add(new NameValuePair("@guid", username));
                nameValuePairObject.Add(new NameValuePair("@sessionTime", hrFname));

                int status = obj.InsertUpdateOrDelete(InsertQuery, nameValuePairObject);
                return status;
            }
        #endregion
        

        #region selectQuery
            public DataSet KeyFsequenceAll(string username)
            {
                string selectQuery = "SELECT * FROM keyManager WHERE username='"+username+"'";

                DataSet data = obj.FillAndReturnDataSet(selectQuery);
                return data;
            }
    
        public DataSet KeyFsequence(string username)
            {
                string selectQuery = "SELECT password FROM keyManager WHERE username='"+username+"'";
               
                DataSet data = obj.FillAndReturnDataSet(selectQuery);
                return data;
            }


        #endregion
        #region selectQuery
            public DataSet AKeyFsequence()
            {
                string selectQuery = "SELECT * FROM admin";

                DataSet data = obj.FillAndReturnDataSet(selectQuery);
                return data;
            }

        #endregion
    }

}