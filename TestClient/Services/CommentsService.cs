using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestClient.Http;
using TestClient.Models;

namespace TestClient.Services
{
    public class CommentsService : ServiceClientHttpServiceBase, ICommentsService
    {      

        public List<Comments> GetCommentsAsync(int photoId)
        {
            var comments = GetAsyncComments(GetServiceUrl());
            return comments.FindAll(item => item.Id == photoId);
        }

        protected override string GetServiceUrl()
        {
            return "https://jsonplaceholder.typicode.com/comments";
        }
    }
}
