using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Helpers
{
    public static class ImageUtilities
    {
        public static void DeleteImage(this Controller controller, string fileName, string folderName = "")
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var absPhotoPath = Path.Combine(controller.Server.MapPath("~/Upload/" + folderName), fileName);

                if (System.IO.File.Exists(absPhotoPath))
                {
                    System.IO.File.Delete(absPhotoPath);
                }
            }
        }

        public static string SaveImage(this Controller controller, HttpPostedFileBase image, string folderName = "")
        {
            if (image == null)
                return "";

            string directory = controller.Server.MapPath("~/Upload/" + folderName);
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string savePath = Path.Combine(directory, fileName);

            image.SaveAs(savePath);

            return fileName;
        }

        public static string FeaturedImage(this UrlHelper urlHelper, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return urlHelper.Content("~/Images/no-image.png");
            }

            return urlHelper.Content("~/Upload/" + fileName);
        }

        public static string SaveCroppedFeaturedImage(this Controller controller, string imgBase64)
        {
            if (string.IsNullOrEmpty(imgBase64))
                return null;

            byte[] data = Convert.FromBase64String(imgBase64.Substring(22));
            string fileName = Guid.NewGuid() + ".png";
            string savePath = Path.Combine(
                controller.Server.MapPath("~/Upload/"), fileName
            );
            System.IO.File.WriteAllBytes(savePath, data);

            return fileName;
        }
    }
}