using SchoolApp.Models.DataModels.StaticModel;

namespace SchoolApiService.Services
{
    public class ImageUploadService
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public ImageUploadService(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }


        public async Task<string?> Upload(ImageUpload upload)
        {
            try
            {
                string base64Data = upload.ImageData.Replace('_', '/').Replace('-', '+');

                //			upload.ImageData = upload.ImageData.Substring(1, upload.ImageData.Length - 2)
                //.Replace(@"\/", "/");

                //			Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                //			base64Data = regex.Replace(upload.ImageData, string.Empty);

                //string base64Data = upload.ImageData.Split(";base64,")[1];

                byte[] bits = Convert.FromBase64String(upload.ImageData);

                if (string.IsNullOrEmpty(upload.ImageName))
                {
                    upload.ImageName = Guid.NewGuid().ToString() + ".png";
                }

                upload.ImageName = "/images/" + upload.ImageName;
                string path = this.hostEnvironment + "/" + upload.ImageName;
                using (FileStream ms = new FileStream(path, FileMode.Create))
                {
                    await ms.WriteAsync(bits);
                    await ms.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return upload.ImageName;
        }


    }
}
