using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult getData()
        {
            Database1Entities db = new Database1Entities();
            var query = from x in db.Scores
                        orderby x.Score1 descending
                        select x;
            List<string> scores = new List<string>();
            int i = 0;
            foreach (var v in query)
            {
                if (i == 5)
                    break;
                scores.Add(v.Score1.ToString());
                i++;
            }
            return Json(scores, JsonRequestBehavior.AllowGet);
        }


    }
}
