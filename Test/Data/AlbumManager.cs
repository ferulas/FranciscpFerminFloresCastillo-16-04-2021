using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestClient.Models;
using TestClient.Services;

namespace Test.Data
{
    public class AlbumManager
    {
        AlbumService service = new AlbumService();
        public List<Album> GetAlbums()
        {
            return service.GetAlbums();
        }

        public  Album GetAlbum(int id =0)
        {
            return service.GetAlbum(id);
        }
        
    }
}
