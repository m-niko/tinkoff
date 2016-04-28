using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Tinkoff.DAL;
using Tinkoff.DAL.Models;

namespace Tinkoff.Web.Controllers
{
    public class ShortenController : ApiController
    {
        private IShortenRepository shortenRepository;

        public ShortenController(IShortenRepository shortenRepository)
        {
            this.shortenRepository = shortenRepository;
        }
        public ShortenController()
        {
            this.shortenRepository = new ShortenRepository();
        }

        [HttpGet]
        public async Task<List<Shorten>> Get([FromUri]string[] rawUrls)
        {

            var shortenUrls = await shortenRepository.GetShortenUrlsAsync(rawUrls);
            return shortenUrls;
        }

        [HttpPost]
        public async Task<Shorten> Create([FromBody]string rawUrl)
        {
            var newShorten = await shortenRepository.GetShortenByRawUrlAsync(rawUrl);
            if (newShorten == null)
            {
                newShorten = new Shorten(rawUrl);
                await shortenRepository.SaveAsync(newShorten);
            }
            return newShorten;
        }
    }
}
