﻿using AStoudtPhotographyAPI.DTO;
using AStoudtPhotographyAPI.Utilities;

namespace AStoudtPhotographyAPI.Validation
{
    public class PhotoValidation
    {
        public async Task<ValidatedResult> ValidatePhoto(AddPhotoRequest photoToValidate)
        {
            ValidatedResult result = new ValidatedResult();
            result.Success = true;
            //call repo to make sure int value exists in db
            //async await Client exists
            //Photographer exists
            //Photo exists
            //Gallery exists
            //Image DOES NOT exist

            return result;
        }


    }
}
