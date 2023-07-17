using ImageUpload.Models;
using ImageUpload.view;
using Microsoft.AspNetCore.Mvc;

namespace ImageUpload.Repository
{
    public class Upload : IUpload
    {
        public static IWebHostEnvironment _environment;
        public Upload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public ImageReader UploadData(FileUploadAPI objFile)
        {
            ImageReader imageReader = new ImageReader();
            ImageDatabase2 obj = new ImageDatabase2();
            sdirectdbContext _db = new sdirectdbContext();

            if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
            }
            string val = DateTime.Now.ToString();
            val = val.Replace("-", string.Empty);
            val = val.Replace(":", string.Empty);
            val = val.Replace(" ", string.Empty);
            val = val.Replace("/", string.Empty);
            using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + val+objFile.files.FileName))
            {



                objFile.files.CopyTo(filestream);
                filestream.Flush();
                obj.ImageName = "\\Upload\\" + objFile.files.FileName + DateTime.Now;
                _db.ImageDatabase2s.Add(obj);
                _db.SaveChanges();
            }
            imageReader.response = "image uploaded";
            imageReader.statuscode = 200;
            return imageReader;



        }
    }
}
