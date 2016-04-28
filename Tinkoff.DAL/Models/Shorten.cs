using System;
using System.ComponentModel.DataAnnotations;
using Tinkoff.DAL.Infrastructure;

namespace Tinkoff.DAL.Models
{
    public class Shorten
    {
        [Key]
        public int ShortenId { get; private set; }
        public string RawUrl { get; private set; }
        public string Url { get; private set; }
        public string ShortedUrl { get; private set; }
        public DateTime CreateDate { get; private set; }
        public int TotalClicks { get; private set; }

        protected Shorten() { }
        public Shorten(string rawUrl)
        {
            Validate.NotNullOrEmpty(rawUrl);
            RawUrl = rawUrl;
            Url = new UriBuilder(rawUrl).Uri.ToString();
            ShortedUrl = string.Format("{0:X}", rawUrl.GetHashCode());
            CreateDate = DateTime.Now;
            TotalClicks = 0;
        }

        public void IncreaseClickCount()
        {
            TotalClicks++;
        }
    }
}