using ImageUpload.view;

namespace ImageUpload.Repository
{
    public interface IUpload
    {
        public ImageReader UploadData(FileUploadAPI objFile);
    }
}
