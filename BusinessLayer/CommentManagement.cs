using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MVCInstagramFatih.Entity;

namespace BusinessLayer
{
    public class CommentManagement
    {
        private Repository<PhotoComment> Rep { get; set; }
        public CommentManagement()
        {
            Rep = new Repository<PhotoComment>();
        }
        public PhotoComment InsertComment(int photopostid, int userid, string CommentStr)
        {
            return Rep.Add(new PhotoComment()
            {
                CommentStr=CommentStr,
                InsertDate=DateTime.Now,
                PhotoPostId=photopostid,
                UserId=userid
            });

              
        }
        public void DeleteComment(int photocommentid)
        {
            if (ExistComment(photocommentid))
            {
                Rep.Delete(GetComment(photocommentid));
            }
        }
        public PhotoComment GetComment(int photocommentid)
        {
            return Rep.Find(x => x.PhotoCommentId == photocommentid).FirstOrDefault();
        }
        public bool ExistComment(int photopostid,int userId)
        {
            if (Rep.SorguyaGoreListele(x => x.PhotoPostId == photopostid && x.UserId == userId).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistComment(int photocommentid)
        {
            if (Rep.SorguyaGoreListele(x => x.PhotoCommentId == photocommentid).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ICollection<PhotoComment> ListComment(int photopostid)
        {
            return Rep.SorguyaGoreListele(x => x.PhotoPostId == photopostid);
        }
        public int CommentCount(int photopost)
        {
            return ListComment(photopost).Count();
        }
    }
}
