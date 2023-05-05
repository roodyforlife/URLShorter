using Data;
using Data.Models;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    class UrlService : IUrlService
    {
        private readonly DataBaseContext _db;
        private readonly IUserService _userService;
        public UrlService(DataBaseContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        public async Task<UrlResponse> CreateAsync(Url url)
        {
            var errorResponse = new UrlResponse(false);
            if (await _db.Urls.FirstOrDefaultAsync(x => x.Link == url.Link) is not null)
            {
                errorResponse.AddError("Url already has in database");
                return errorResponse;
            }

            if (!ValidateUrl.IsValidUri(url.Link))
            {
                errorResponse.AddError("It isn't an URL");
                return errorResponse;
            }

            url.NewLink = CryptUrl(url.Link);
            await _db.AddAsync(url);
            await _db.SaveChangesAsync();

            return new UrlResponse(true, await _db.Urls.Include(x => x.User).FirstOrDefaultAsync(x => x.Link == url.Link));
        }

        private string CryptUrl(string url)
        {
            string newUrl = String.Empty;
            using(MD5 md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(url ?? ""));
                newUrl = string.Join("", Enumerable.Range(0, hash.Length).Select(i => hash[i].ToString("x2")));
            }
            
            return newUrl;
        }

        public Url Get(string link)
        {
            var test = _db.Urls.Include(x => x.User).FirstOrDefault(x => x.NewLink == link);
            return test;
        }

        public List<Url> Get() => _db.Urls.Include(x => x.User).ToList();

        public async Task Delete(int id)
        {
            Url url = await _db.Urls.FirstOrDefaultAsync(x => x.Id == id);
            _db.Remove(url);
            await _db.SaveChangesAsync();
        }
    }
}
