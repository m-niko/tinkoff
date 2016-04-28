using System;

namespace Tinkoff.DAL.Models
{
    public class DefaultShortedUrlGenerator : IShortedUrlGenerator
    {
        public string GenerateShortedUrl(string rawUrl)
        {
            return new UriBuilder(rawUrl).Uri.ToString();
        }
    }
}