using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MVCInstagramFatih.Entity;

namespace MVCInstagramFatih.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            User u = Session["Kullanici"] as User;
            return View(u.photoposts.ToList());
        }
        public ActionResult Update()
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            User u = Session["Kullanici"] as User;
            return View(u);
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            UserManagement UM = new UserManagement();

            return View(UM.UpdateUser(user));
        }
        public ActionResult Create()
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(string posthashtag,string PhotoDescription, HttpPostedFileBase ImageUpload)
        {
            if (!SessionManagement.ExistSession(Session["Kullanici"]))
            {
                return RedirectToAction("Login", "Home");
            }
            string[] Hastaglar = posthashtag.Split(',');
            List<PostHashtag> Taglar = new List<PostHashtag>();

            foreach (string item in Hastaglar)
            {
                Taglar.Add(new PostHashtag()
                {
                    HastagName=item
                });
            }

            if (ImageUpload.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/img/images/post"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImageUpload.FileName));
                string SqlFilePath = "~/img/images/post/" + Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImageUpload.FileName);
                ImageUpload.SaveAs(filePath);
                PhotoPostManagement PpM = new PhotoPostManagement();
                PhotoPost PP = new PhotoPost();
                PP.AktifMi = true;
                PP.InsertDate = DateTime.Now;
                PP.PhotoDescription = PhotoDescription;
                PP.PhotoPath = SqlFilePath;
                PP.posthashtag=Taglar;
                PP.IsPhoto = true;
                PP.user = Session["Kullanici"] as User;
                PpM.InsertPost(PP);
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index", "Profil");
        }
        
    }
}