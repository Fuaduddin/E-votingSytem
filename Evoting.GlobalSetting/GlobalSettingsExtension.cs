using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices;
using System.Collections.Specialized;
using System.Configuration;

namespace Evoting.GlobalSetting
{
    public class GlobalSettingsExtension
    {
        public string PasswordDencrypt(string Password)
        {
            string encryptedpassword;
            if (!string.IsNullOrEmpty(Password))
            {
                // parse base64 string
                byte[] encryptpassword = Convert.FromBase64String(Password);
                //decrypt data
                encryptedpassword = Encoding.Unicode.GetString(encryptpassword);
            }
            else
            {
                encryptedpassword = "";
            }
            return encryptedpassword;
        }
        public string PasswordEncrypt(string Password)
        {
            string encryptedpassword;
            if (!string.IsNullOrEmpty(Password))
            {
                byte[] convertpasswordbyte = ASCIIEncoding.Unicode.GetBytes(Password);
                encryptedpassword = Convert.ToBase64String(convertpasswordbyte);
            }
            else
            {
                encryptedpassword = "";
            }
            return encryptedpassword;
        }
    }
}
