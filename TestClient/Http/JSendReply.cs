using System;
using System.Collections.Generic;
using System.Text;

namespace TestClient.Http
{
    public class JSendReply<T>
    {

        public string Status = "success";

        public string Message = null;

        public T Data = default;

        public JSendReply()
        {

        }

        public JSendReply(string status, string message, T data = default)
        {
            Status = status;
            Message = message;
            Data = data;
        }


    }
}
