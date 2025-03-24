using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndRewards.MainMethods.DAL
{
    public interface IUserDAO
    {
        void Add(User user);
        void Delete(User user);
     //   Entities.User Find(Predicate<Entities.User> match);
        int IndexOf(Entities.User user);
        Entities.User this[int i] { set; get; }
        IEnumerable<Entities.User> GetList();
        Entities.User Get(int userID);
        void Edit(
            int id, 
            string fname, 
            string lname,
            DateTime bdate,
            List<Reward> userRewards);
    }
}

