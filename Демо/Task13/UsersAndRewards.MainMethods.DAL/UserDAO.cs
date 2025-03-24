using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UsersAndRewards.MainMethods.DAL
{
    public class UserDAO : IUserDAO, IEnumerable
    {
        private List<User> users = new List<User>();

        public User this[int i]
        {
            get
            {
                return users[i];
            }

            set
            {
                users[i] = value;
            }
        }

        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentException("Нет пользователя!");
            users.Add(user);
        }

        public void Delete(User user)
        {
            if (user == null)
                throw new ArgumentException("Нет пользователя!");
            users.Remove(user);
        }

        public User Find(Predicate<User> match)
        {
            return users.Find(match);
        }

        public int IndexOf(User user)
        {
            return users.IndexOf(user);
        }
        public IEnumerator GetEnumerator()
        {
            return users.GetEnumerator();
        }
        public IEnumerable<User> GetList()
        {
            return users;
        }

        public User Get(int userID)
        {
            return users.Find(x => x.ID == userID);
        }

        public void Edit(int id, string fname, string lname, DateTime bdate, List<Reward> userRewards)
        {
            int userIndex = IndexOf(Get(id));
            this[userIndex].FirstName = fname;
            this[userIndex].LastName = lname;
            this[userIndex].Birthdate = bdate;
            this[userIndex].UserRewards = userRewards;
        }
    }
}

