namespace AStoudtPhotographyAPI.Repositories
{
    public class PhotoRepository : BaseRepository
    {
        public PhotoRepository(IConfiguration config) : base(config) { }

        //GET All Photos By Gallery

        //GET Single/All Photos
        //return images requested

        //POST byteArray? (single photos only? the data could be VERY LARGE, or is there a reason not to?) 
        //Validations
        //validate incoming data properties exists on object, where required
        //validate photographerId exists in db
        //verify clientId exists in db
        //validate galleryId exists in db

        //If file size is larger the ?X? then
        //--create original / print size (10112204C3Original)
        //--create web/socialMedia sized version (10112204C3Web)
        //ELSE
        //--create original... then in the controller, handle the logic so that it pulls the correct fileName
        //place into structured folder

        //SET SQL properties
        //SET Created DateTime
        //SET PhotoPath
        //Is marked Public?

        //Create SQL record

        //Return Success Message
        //End Function
    }
}
