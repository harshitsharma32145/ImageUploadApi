namespace ImageUpload.view
{
    public class FileUploadAPI
    {
        public IFormFile? files { get; set; }
        public string ImgName { get; set; }
    }

    public class ImageReader
    {
        public string response { get; set; }
        public int statuscode { get; set; }
    }
}
