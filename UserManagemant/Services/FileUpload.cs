namespace UserManagemant.Services
{
    public static class FileUpload
    {
        public static string SaveFile(this IFormFile file, string path)
        {
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string fullPath = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            };

            return fileName;
        }
    }
}
