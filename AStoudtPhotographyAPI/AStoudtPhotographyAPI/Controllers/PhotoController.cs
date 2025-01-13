using AStoudtPhotographyAPI.DTO;
using AStoudtPhotographyAPI.Models;
using AStoudtPhotographyAPI.Repositories;
using AStoudtPhotographyAPI.Utilities;
using AStoudtPhotographyAPI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace AStoudtPhotographyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private IConfiguration _configuration;
        private PhotoValidation _photoValidation = new PhotoValidation();
        private FileValidation _fileValidation = new FileValidation();
        private IPhotoRepository _photoRepository;

        public PhotoController(IConfiguration configuration, IPhotoRepository photoRepository)
        {
            _configuration = configuration;
            _photoRepository = photoRepository;
        }

        //TODO: GET Photos
        //[HttpGet]
        //[Route("GetPhoto")]
        //public IActionResult GetPhoto() 
        //{
        //    var builder = new SqlConnectionStringBuilder
        //    {
        //    };
        //}

        [HttpPost]
        [Route("AddPhoto")]
        //[RequestSizeLimit(1_000_000)]
        public async Task<IActionResult> PostPhotoAsync(AddPhotoRequest photoMetadata)
        {
            try
            {
                //Validations
                var validatePhotoMetadata = await _photoValidation.ValidatePhoto(photoMetadata);
                if (!validatePhotoMetadata.Success)
                {
                    return BadRequest(validatePhotoMetadata.Errors.ToString());
                }

                var validateFiles = _fileValidation.ValidateFile(photoMetadata.Photos);
                if (!validateFiles.Success)
                {
                    return BadRequest(validateFiles.Errors.ToString());
                }

                //Process Files
                var result = new ImageProcessor(photoMetadata.Photos).ProcessImages();
                if (!result.Success)
                {
                    return BadRequest(result.Errors.ToString());
                }


                //Create General Photo model
                var tempPhotoModel = new Photo 
                { 
                    ClientId = photoMetadata.ClientId,
                    SessionId = photoMetadata.SessionId,
                    IsPrivate = photoMetadata.IsPrivate,
                    GalleryId = photoMetadata.GalleryId
                };

                if (result.Data != null) { 
                    foreach (var sucessfulResult in result.Data)
                    {
                        //append each files name 
                        tempPhotoModel.FileLocation = sucessfulResult;
                        await _photoRepository.Add(tempPhotoModel);
                    }
                }
            }
            catch
            {
                return Conflict();
            }

            long size = photoMetadata.Photos.Sum(f => f.Length);
            //TODO: pull in client name and session location
            return Ok($"Successfully uploaded {photoMetadata.Photos.Count} images for Client {photoMetadata.ClientId} at the {photoMetadata.SessionId} session.");
        }
    }
}
