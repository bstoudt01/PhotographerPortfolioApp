using AStoudtPhotographyAPI.Utilities;

namespace AStoudtPhotographyAPI.Validation
{
    public class FileValidation
    {
        public ValidatedResult ValidateFile(List<IFormFile> files)
        {
            ValidatedResult result = new ValidatedResult();
            var maxSize = 1024 * 1024 * 5;
            if (files.Count == 0) 
            {
                result.Errors.Add("There were no files included in the upload.");
                return result;
            }

            foreach (var file in files)
            {
                if (file is null || file.Length == 0)
                {
                    result.Errors.Add("The file is null");
                }
                else if (!IsFileExtensionAllowed(file, [".jpeg", ".jpg"]))
                {
                    result.Errors.Add("Invalid file type. Please upload a jpeg or jpg file.");
                }
                else if (!IsFileSizeWithinLimit(file, maxSize))
                {
                    var mbSize = (double)maxSize / 1024 / 1024;
                    result.Errors.Add($"{file.FileName} - File size exceeds the maximum allowed size ({mbSize} MB).");
                }
                else if (FileWithSameNameExists(file))
                {
                    result.Errors.Add("Duplicate file name detected. " +
                        "Please upload a file with a different name.");
                }
            }

            result.Success = !result.Errors.Any();
            return result;
        }

        public bool IsFileSizeWithinLimit(IFormFile file, long maxSizeInBytes)
        {
            return file.Length <= maxSizeInBytes;
        }
        public bool IsFileExtensionAllowed(IFormFile file, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(file.FileName);
            return allowedExtensions.Contains(extension);
        }
        public bool FileWithSameNameExists(IFormFile fileName)
        {
            // Implement logic to check if a file with the same name exists in the system
            return false;
        }
    }
}
