using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Helprs;

public static class Functions
{
    public static async Task<string> UpLoadImageAsync(IFormFile file)
    {
        try
        {
            if (file.Length <= 0) return "";

            string[] imgName = file.FileName.Split(".");
            string imgPath = Guid.NewGuid() + $".{imgName[1]}";

            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot/UpLoad", imgPath);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }
            return imgPath;
        }
        catch
        {
            return "";
        }
        
    }
    public static async Task<bool> DeleteImageAsync(string imgName)
    {
        try
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot/UpLoad", imgName);
            
            if(!File.Exists(path))return false;

             await Task.Run(() => File.Delete(path));

            return true;
        }
        catch
        {
            return false;
        }
    }
}
