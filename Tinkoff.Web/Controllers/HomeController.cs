using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tinkoff.DAL;
using Tinkoff.DAL.Models;

namespace Tinkoff.Web.Controllers
{
    public class HomeController : Controller
    {
        private IShortenRepository shortenRepository;

        public HomeController()
        {
            shortenRepository = new ShortenRepository();
        }
        public HomeController(IShortenRepository shortenRepository)
        {
            this.shortenRepository = shortenRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ClickShortedUrl(string shortedUrl)
        {
            var shorten = await shortenRepository.GetShortenByShortedUrlAsync(shortedUrl);

            if (shorten != null)
            {
                shorten.IncreaseClickCount();

                try
                {
                    await shortenRepository.UpdateAsync(shorten);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError(ex.Message);
                }

                return Redirect(shorten.Url);
            }

            return RedirectToAction("Index");
        }
    }
}