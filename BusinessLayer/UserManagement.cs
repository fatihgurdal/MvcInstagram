using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInstagramFatih.Entity;
using DataAccessLayer;

namespace BusinessLayer
{
    public class UserManagement
    {
        private Repository<User> Rep { get; set; }
        public UserManagement()
        {
            Rep = new Repository<User>();
        }
        public bool AddUser(User user)
        {
            if (!ExistUser(user))
            {
                Rep.Add(user);
                return true;
            }
            else
            {
                return false;
            }                
        }
        public void DeleteUser(User user)
        {
            User u = Rep.First(x => x == user);
            u.AktifMi = false;
            Rep.UpdateSaveChanges();
        }
        public void DeleteUser(int userid)
        {
            User u = Rep.First(x => x.UserId == userid);
            u.AktifMi = false;
            Rep.UpdateSaveChanges();
        }
        public bool ExistUser(User user)
        {
            return (Rep.Find(x => x.UserId == user.UserId).Count() > 0) ? true : false;
        }
        public bool ExistUser(string Name,string Pass)
        {
            if (Rep.Find(x => x.UserName == Name && x.UserPass==Pass).Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistUser(int userid)
        {        
            return (Rep.SorguyaGoreListele(x => x.UserId == userid).Count() > 0) ? true : false;
        }
        public User UpdateUser(User user)
        {
            User u = Rep.First(x => x.UserId == user.UserId);

            u.Description = user.Description;
            u.FirstName = user.FirstName;
            //u.ProfilImagePath = u.ProfilImagePath;
            u.UserName = user.UserName;
            u.UserPass = user.UserPass;
            Rep.UpdateSaveChanges();

            return u;
        }
        public User GetUser(int userid)
        {
            if (ExistUser(userid))
            {
                return Rep.SorguyaGoreListele(x => x.UserId == userid).Single();
            }
            else
            {
                return null;
            }
            
        }
        public User GetUser(string Name,string Pass)
        {
            return Rep.First(x => x.UserPass == Pass && x.UserName == Name);
        }
        public ICollection<User> GetUser()
        {
            return Rep.Listele();
        }
        public int GetHastagCount(int userId)        {
            int hastagcount = 0;
            User u = Rep.First(x => x.UserId == userId);
            foreach (PhotoPost item in u.photoposts)
            {
                hastagcount += item.posthashtag.Count();
            }
            return hastagcount;
        }
    }
}
