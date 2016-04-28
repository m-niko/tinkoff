namespace Tinkoff.DAL.Models
{
    public interface IShortedUrlGenerator
    {
        string GenerateShortedUrl(string rawUrl);
    }
}