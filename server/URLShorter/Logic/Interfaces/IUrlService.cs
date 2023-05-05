using Data.Models;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUrlService
    {
        public Task<UrlResponse> CreateAsync(Url url);
        public Url Get(string link);
        public List<Url> Get();
        public Task Delete(int id);
    }
}
