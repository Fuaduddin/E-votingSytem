using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace E_Voting.SuperAdmin.Admin.Extension
{
    public class ExtensionMethods
    {
        public string UploadImage(HttpPostedFileBase Image)
        {
            string savepath = "";
            string imageurl, imagepath, filepath;
            if (Image.ContentLength > 0)
            {
                var filename = Path.GetFileName(Guid.NewGuid() + Image.FileName);
                imagepath = HttpContext.Current.Server.MapPath("~/Content/Image/");
                filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/");
                if (imagepath == null)
                {
                    Directory.CreateDirectory(imagepath);
                }
                imageurl = Path.Combine(imagepath, filename);
                savepath = "~/Content/Image/" + filename;
                Image.SaveAs(imageurl);
            }
            return savepath;
        }
    }
}