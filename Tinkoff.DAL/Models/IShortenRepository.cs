using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tinkoff.DAL.Models
{
    public interface IShortenRepository
    {
        Task<Shorten> GetShortenByRawUrlAsync(string rawUrl);
        Task<Shorten> GetShortenByShortedUrlAsync(string shorten);
        Task<List<Shorten>> GetShortenUrlsAsync(string[] rawUrls);
        Task SaveAsync(Shorten shorten);
        Task UpdateAsync(Shorten shorten);
    }
}