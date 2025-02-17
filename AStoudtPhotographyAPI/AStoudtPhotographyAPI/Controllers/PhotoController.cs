﻿using AStoudtPhotographyAPI.DTO;
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

        /// <summary>
        /// Upload Photos
        /// </summary>
        /// <returns>Session ID, Client ID, and Photo Count of photos uploaded</returns>
        /// <response code="200">Returns the newly created Session ID, Client ID, and Photo Count</response>
        /// <response code="400">Returns the list of errors</response>
        /// <response code="409">Returns response if there was a conflic with saving.</response>
        [HttpPost("AddPhoto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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
                    return BadRequest(validateFiles.Errors);
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

        //TODO: GET Photos
        //[HttpGet]
        //[Route("GetPhoto")]
        //public IActionResult GetPhoto() 
        //{
        //    var builder = new SqlConnectionStringBuilder
        //    {
        //    };
        //}
    }
}
