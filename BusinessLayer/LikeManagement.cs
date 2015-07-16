using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MVCInstagramFatih.Entity;
namespace BusinessLayer
{
    public class LikeManagement
    {
        private Repository<PhotoLike> Rep { get; set; }
        public LikeManagement()
        {
            Rep = new Repository<PhotoLike>();
        }
        public void SetLike(int photopostid,int userid,bool LikeMode)
        {
            if ((!ExistLike(photopostid,userid)) && (LikeMode==true))
            {
                Rep.Add(new PhotoLike() { 
                    UserId=userid,
                    PhotoPostId=photopostid                    
                });
            }
            else if ((ExistLike(photopostid,userid)) && (LikeMode==false))
            {
                Rep.Delete(GetLike(photopostid, userid));
            }
            
        }
        public bool ExistLike(int photopostid, int userid)
        {
            if (Rep.SorguyaGoreListele(x => x.UserId == userid && x.PhotoPostId == photopostid).Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public PhotoLike GetLike(int photopostid, int userid)
        {
            return Rep.SorguyaGoreListele(x => x.UserId == userid && x.PhotoPostId == photopostid).Single();
        }
        public ICollection<PhotoLike> ListLike(int photopostid)
        {
            return Rep.SorguyaGoreListele(x => x.PhotoPostId == photopostid);
        }
        public int LikeCount(int photopost)
        {
            return ListLike(photopost).Count();
        }
    }
}
