using System;
using System.Collections.Generic;
using System.Text;

namespace TestClient.Models
{
    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string thumbnailUrl { get; set; }

        public List<Comments> Comments { get; set; }
    }
}
