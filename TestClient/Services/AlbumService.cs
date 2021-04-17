using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestClient.Http;
using TestClient.Models;


namespace TestClient.Services
{
    public class AlbumService : ServiceClientHttpServiceBase, IAlbumService 
    {
        /// <summary>
        /// Get a list of albums
        /// </summary>
        /// <returns></returns>
        public List<Album> GetAlbums()
        {
            return GetAsyncAlbums(GetServiceUrl());
            //return GetAsync<List<Album>>(GetServiceUrl());
        }

        /// <summary>
        /// Get an Album
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public Album GetAlbum(int albumId)
        {

            var albums = GetAsyncAlbums(GetServiceUrl());

            var album = albums.Find(item => item.Id == albumId);
            album.Photos = new PhotoService().GetPhoto(albumId);
            return album;
        }

        protected override string GetServiceUrl()
        {
            return "https://jsonplaceholder.typicode.com/albums";
        }
    }
}
