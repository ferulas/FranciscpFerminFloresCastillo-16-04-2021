using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestClient.Models;

namespace TestClient.Services
{
    public interface IAlbumService
    {
        List<Album> GetAlbums();
        Album GetAlbum(int albumId);
    }
}
