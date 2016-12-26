using System;
using System.IO;
using System.Web;

namespace IC.LMS.Business.FileCabinetCS
{
    public class LoadFiles
    {
        public bool UploadFiles()
        {
            int iUploadedCnt = 0;

            var path = HttpContext.Current.Server.MapPath("Uploadfiles/");
            CreateFolderIfNeeded(path);
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    var filePath = HttpContext.Current.Server.MapPath(path + hpf.FileName);
                    if (!File.Exists(filePath))
                    {
                        hpf.SaveAs(filePath);
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
            }

            if (iUploadedCnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
    }
}
