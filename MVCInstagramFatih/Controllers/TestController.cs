using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MVCInstagramFatih.Entity;

namespace MVCInstagramFatih.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            CommentManagement cm = new CommentManagement();
            PhotoComment pc = cm.GetComment(1);

            return View(pc);
        }
    }
}