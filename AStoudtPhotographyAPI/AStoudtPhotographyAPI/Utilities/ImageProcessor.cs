using AStoudtPhotographyAPI.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace AStoudtPhotographyAPI.Utilities
{
    public class ImageProcessor
    {
        private List<IFormFile> _images;

        public ImageProcessor(List<IFormFile> images) 
        {
            _images = images;
        }

        public OperationResult<List<string>> ProcessImages()
        {
            List<string> resultErrors = [];
            List<string> resultSuccessFiles = new List<string>();

            foreach (IFormFile image in _images)
            {
                var result = ProcessOriginalImage(image);

                if (!result.Success)
                {
                    resultErrors.Add(image.FileName);
                } 
                else if (result.Message != null) 
                { 
                    resultSuccessFiles.Add(result.Message);
                }
                
            }

            if (resultErrors.Count > 0)
            {
                return OperationResult<List<string>>.FailureResult("There was an issue saving the photos.", resultErrors);
            }
            else
            {
                return OperationResult<List<string>>.SuccessResult(resultSuccessFiles, "Photos Successfully Uploaded.");
            }

        }
        private OperationResult<Photo> ProcessOriginalImage(IFormFile image) 
        {
            var savedImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images/");

            using Image imageToProcess = Image.Load(image.OpenReadStream());
            {
                //1.4 MP 3:2
                //Low Resolution Image Encoder for Web Images
                int maxWidthLowRes = 1440;
                int newHeight = 0;
                if (imageToProcess.Width > maxWidthLowRes)
                {
                    try
                    {
                    //saves image with width of 1440, height is determined by imagesharp to keep aspect ratio (set height to 0)
                    using Image lowResCopy = imageToProcess.Clone(x => x.Resize(maxWidthLowRes, newHeight));
                    string webFileName = "web_" + image.FileName;
                    lowResCopy.Save(savedImagePath + webFileName);
                    }
                    catch
                    {
                        return OperationResult<Photo>.FailureResult($"{image.FileName} did not save properly. Please try uploading images again.");
                    }
                }

                //save original image
                string FileName = "original_" + image.FileName;
                imageToProcess.Save(savedImagePath + FileName);

                return OperationResult<Photo>.SuccessResult(null, FileName);
            }
        }

    }
}
