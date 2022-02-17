using Etv.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etv.DA
{
    public class UserDA
    {
        private static List<User> Lst = new List<User>
        {
            new User { UserId=Guid.NewGuid(),Email="andre@gmail.com",Password="123",Rol=1 }
        };

        public bool Add(User user)
        {
            try
            {
                Lst.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public User Autencation(string email, string password)
        //{
        //    var oUser = Lst.FirstOrDefault(o => o.Email = email && o.Password == password);
        //    if (oUser != null)
        //    {
        //        return oUser;
        //        return null;
        //    }
        //}
    }
}
