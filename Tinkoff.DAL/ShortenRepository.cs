using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Tinkoff.DAL.Models;

namespace Tinkoff.DAL
{
    public class ShortenRepository : IShortenRepository
    {
        public async Task<Shorten> GetShortenByRawUrlAsync(string rawUrl)
        {
            using (var context = new ShortenDbContext())
            {
                return await context.Shortens.FirstOrDefaultAsync(s => s.RawUrl.Equals(rawUrl));
            }
        }

        public async Task<Shorten> GetShortenByShortedUrlAsync(string shortedUrl)
        {
            using (var context = new ShortenDbContext())
            {
                return await context.Shortens.FirstOrDefaultAsync(s => s.ShortedUrl.Equals(shortedUrl));
            }
        }

        public async Task<List<Shorten>> GetShortenUrlsAsync(string[] rawUrls)
        {
            using (var context = new ShortenDbContext())
            {
                return await context.Shortens.Where(s => rawUrls.Contains(s.RawUrl)).OrderByDescending(o => o.CreateDate).ToListAsync();
            }
        }

        public async Task SaveAsync(Shorten shorten)
        {
            using (var context = new ShortenDbContext())
            {
                context.Shortens.Add(shorten);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Shorten shorten)
        {
            using (var context = new ShortenDbContext())
            {
                context.Entry(shorten).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
