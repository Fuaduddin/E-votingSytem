using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Evoting.GlobalSetting
{
    public class GlobalSettingsExtension
    {
        public string UploadImage(HttpPostedFileBase CategoryImage)
        {
            string savepath = "";
            string imageurl, imagepath, filepath;
            if (CategoryImage.ContentLength > 0)
            {
                var filename = Path.GetFileName(Guid.NewGuid() + CategoryImage.FileName);
                imagepath = HttpContext.Current.Server.MapPath("~/Image/");
                filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/");
                if (imagepath == null)
                {
                    Directory.CreateDirectory(imagepath);
                }
                imageurl = Path.Combine(imagepath, filename);
                savepath = "/Image/" + filename;
                CategoryImage.SaveAs(imageurl);
            }
            return savepath;
        }
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
