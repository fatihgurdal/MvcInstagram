using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MVCInstagramFatih.Entity;
using MVCInstagramFatih.Models;

namespace MVCInstagramFatih.Controllers
{
    public class HomeController : Controller
    {
        public PhotoPostManagement PpM { get; set; }
        public UserManagement UM { get; set; }
        public HomeController()
        {
            PpM = new PhotoPostManagement();
            UM = new UserManagement();
        }
        // GET: Home
        public ActionResult Index(string Hastag = "")
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            if (Hastag == "")
            {
                return View(PpM.ListPost());
            }
            else
            {
                return View(PpM.ListPost(Hastag));
            }
        }
        public ActionResult Profil(int id)
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            User u = UM.GetUser(id);
            return View(u);
        }
        public ActionResult Login()
        {
            UM = new UserManagement();
            if (Session["Kullanici"] != null)
            {
                User u = Session["Kullanici"] as User;
                if (UM.ExistUser(u))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string UserPass)
        {
            UM = new UserManagement();
            if (UM.ExistUser(UserName, UserPass))
            {
                Session["Kullanici"] = UM.GetUser(UserName, UserPass);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Kullanici"] = null;
            return RedirectToAction("Login", "Home");
        }

        public JsonResult SetLike(LikeModeModel LikeModel)
        {
            LikeManagement LM = new LikeManagement();

            if (LM.ExistLike(LikeModel.PhotoId, LikeModel.KisiId))
            {
                LM.SetLike(LikeModel.PhotoId, LikeModel.KisiId, false);
                return Json(false);
            }
            else
            {
                LM.SetLike(LikeModel.PhotoId, LikeModel.KisiId, true);
                return Json(true);
            }
        }

        public PartialViewResult AddComment(CommentModeModel CommentModel)
        {
            CommentManagement CM = new CommentManagement();
            PhotoComment SPM = CM.InsertComment(CommentModel.PhotoId, CommentModel.UserId, CommentModel.CommentStr);
            PhotoComment SPM2 = new CommentManagement().GetComment(SPM.PhotoCommentId);
            return PartialView("_SingleComment", SPM2);
        }

        public JsonResult DeleteComment(DeleteCommentModel ComentModel)
        {
            CommentManagement CM = new CommentManagement();
            CM.DeleteComment(ComentModel.CommentId);

            return Json(true);
        }

    }
}