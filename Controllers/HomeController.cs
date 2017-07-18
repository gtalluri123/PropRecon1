using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropRecon.Biz;
using Newtonsoft.Json;
using PropRecon.Biz.entities;
namespace PropRecon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            new ProcessFindPersonRequest().ProcessRequest();
            return View();

        }
        public JsonResult GetData()
        {
            var context = new UnClaimedEntities();
            //var results = context.TexasRecords.SqlQuery("select * from uptexas where AmountRemitted >@p0 order by AmountRemitted desc", 10000);
            //var results = context.TexasRecords.Where(r=>r.AmountRemitted>10000).OrderByDescending(r=>r.AmountRemitted);
            var results = context.Database.SqlQuery <EnrichedPerson>("exec SearchPeople @amount,@lastname ", 10000,"Talluri");
            //var results = context.TexasRecords.Join(context.People,r=>r.FormerOwnerFirst,p=>p.FirstName,
              
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}
