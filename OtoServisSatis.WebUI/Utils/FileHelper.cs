namespace OtoServisSatis.WebUI.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";
            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName; //yükleme yapacağımız dizin Directory uygulamanın çalıştığı konumu getiriyor.

                using var stream = new FileStream(directory, FileMode.Create); //dizinde yeni bir dosya oluşturduk
                await formFile.CopyToAsync(stream); //stream içindeki verileri kullanarak uygulamanın çalıştığı sunucuya kopyalama işlemini gerçekleştirdik
            }
            return fileName;
        }
    }
}
