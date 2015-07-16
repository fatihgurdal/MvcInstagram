using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MVCInstagramFatih.Entity;

namespace BusinessLayer
{
    public class PhotoPostManagement
    {
        private Repository<PhotoPost> Rep { get; set; }
        public HastagManagement HM { get; set; }
        public PhotoPostManagement()
        {
            Rep = new Repository<PhotoPost>();
            HM = new HastagManagement();
        }
        public void InsertPost(PhotoPost photopost)
        {
            photopost.InsertDate = DateTime.Now;
            Rep.Add(photopost);
        }
        public void DeletePost(PhotoPost photopost)
        {
            Rep.Delete(photopost);
        }
        public void DeletePost(int photopostid)
        {
            PhotoPost PP = Rep.Find(X => X.PhotoPostId == photopostid).Single();
            DeletePost(PP);
        }
        public bool ExistPost(int photopostid)
        {
            if (Rep.Find(x=>x.PhotoPostId==photopostid).Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistPost(PhotoPost photopost)
        {
            return ExistPost(photopost.PhotoPostId);
        }
        public ICollection<PhotoPost> ListPost()
        {
            return Rep.Listele();
        }
        public ICollection<PhotoPost> ListPost(int UserId)
        {
            return ListPost(new UserManagement().GetUser(UserId));
        }
        public ICollection<PhotoPost> ListPost(User user)
        {
            return Rep.SorguyaGoreListele(x => x.user == user);
        }
        public List<PhotoPost> ListPost(string hastag)
        {

            IEnumerable<PostHashtag> PH = HM.GetHashtag(hastag);

            List<PhotoPost> list= new List<PhotoPost>();

            foreach (PostHashtag item in PH)
	        {
                list.Add(Rep.First(x => x.PhotoPostId == item.PhotoPostId));
	        }

            return list;
        }
    }
}
