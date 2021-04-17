using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestClient.Http;
using TestClient.Models;

namespace TestClient.Services
{
    public class PhotoService : ServiceClientHttpServiceBase, IPhotoSercive
    {


        /// <summary>
        /// Get an Album
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public List<Photo> GetPhoto(int albumId)
        {

            var photosData = GetAsyncPhotos(GetServiceUrl());
            var photos = photosData.FindAll(item => item.Id == albumId);
            photos.ForEach(item => item.Comments = new CommentsService().GetCommentsAsync(item.Id));
            return photos;
        }

        protected override string GetServiceUrl()
        {
            return "https://jsonplaceholder.typicode.com/photos";
        }
    }
}
