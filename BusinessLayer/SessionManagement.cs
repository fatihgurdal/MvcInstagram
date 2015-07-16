using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInstagramFatih.Entity;

namespace BusinessLayer
{
    public static class SessionManagement
    {
        public static bool ExistSession(object Users)
        {
            if (Users==null)
            {
                return false;
            }
            User u = Users as User;
            UserManagement UM = new UserManagement();
            if (UM.ExistUser(u))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
