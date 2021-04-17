using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using TestClient.Models;

namespace Test.Controllers
{
    public class AlbumController : Controller
    {

        AlbumManager manager = new AlbumManager();
        public IActionResult Index()
        {
            List<Album> albums = manager.GetAlbums();
            return View(albums);
        }

        public IActionResult GetAlbum(int id = 0)
        {
            var album = manager.GetAlbum(id);
            return View(album);
        }

        public IActionResult GetComments(int id = 0)
        {
            var photo = manager.GetAlbum(id).Photos.Find(item => item.Id == id);            
            return View(photo.Comments);
        }
    }
}
