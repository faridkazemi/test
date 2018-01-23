using BanjoTwitterExercise.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BanjoTwitterExercise.Controllers
{
    public class HomeController : Controller
    {
        ITweetRepository repository { get; set; }

       public HomeController(ITweetRepository tweetRepository)
        {
            repository = tweetRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("RecentFinetech/{hashtag}")]
        public async Task<JsonResult>  GetRecents(string hashtag)
        {
            var result = await  repository.GetRecentTweetsByHashtagAsync(hashtag);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}