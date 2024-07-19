namespace GuideMeApp.Utils
{
    public static class ImageHelper
    {
        public static async Task<FileResult?> ImageFilePicker()
        {
            return await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images
            });
        }

        public static async Task<byte[]> StreamToByteArrayAsync(Stream inputStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await inputStream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
