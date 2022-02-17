using Etv.DA;
using Etv.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etv.BL
{
    public class UserBL
    {
        private readonly UserDA userDa;
        public UserBL()
        { 
            userDa = new UserDA();
        }
        public bool Add(User user)
        {
            //Regla de negoios
            user.UserId = Guid.NewGuid();
            return userDa.Add(user);
        }

        //public User Autentication(string email, string password)
        //{
        //    return userDa.Autencation(email, password);
        //}
    }
}
