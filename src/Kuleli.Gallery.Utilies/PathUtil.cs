using Microsoft.AspNetCore.Http;

namespace Kuleli.Gallery.Utilies
{
    public class PathUtil
    {
        public static string GenerateFileName(IFormFile file)
        {
            var date = DateTime.Now;
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{date.Day}_{date.Month}_{date.Year}_{date.Hour}_{date.Minute}_{date.Second}_{date.Millisecond}{extension}";
            return fileName;
        }
    }
}
