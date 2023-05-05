using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class UrlResponse
    {
        public bool Success { get; set; }
        public Url Url { get; set; }
        public List<string> Errors { get; set; } = new();

        public UrlResponse(bool success, Url url)
        {
            Success = success;
            Url = url;
        }

        public UrlResponse(bool success)
        {
            Success = success;
        }

        public void AddError( string error)
        {
            Errors.Add(error);
        }
    }
}
