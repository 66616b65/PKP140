using System;
using Entities;
using UsersAndRewards.MainMethods.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UsersAndRewards.MainClasses.BLL
{
    public class UsersBL
    {
        private readonly IUserDAO usersDAO;
        public UsersBL()
        {
            if (DatabaseConfig.GetContext().ToString() == "adonet")
            {
                usersDAO = new UserSqlDAO();
            }
            else
            {
                usersDAO = new UserDAO();
            }
        }
        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentException("Пользователя нет!");
            usersDAO.Add(user);
        }
        public void Add(string firstName, string lastName, DateTime birthdate, RewardsBL rewards)
        {
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate
            };
            foreach(Reward item in rewards.GetList())
            {
                user.UserRewards.Add(item);
            }
            Add(user);
        }

        public User this[int i]
        {
            get
            {
                return usersDAO[i];
            }

            set
            {
                usersDAO[i] = value;
            }
        }
        public void Delete(User user)
        {
            if (user == null)
                throw new ArgumentException("Нет пользователя!");
            usersDAO.Delete(user);
        }

      /*  public User Find(Predicate<User> match)
        {
            return usersDAO.Find(match);
        }*/

        public int IndexOf(User user)
        {
            return usersDAO.IndexOf(user);
        }
        public IEnumerable<User> GetList()
        {
            return usersDAO.GetList();
        }
        public IEnumerable<User> SortByFirstNameAsc()
        {
            return (from s in GetList()
                    orderby s.FirstName ascending
                    select s);
        }

        public IEnumerable<User> SortByFirstNameDesc()
        {
            return (from s in GetList()
                    orderby s.FirstName descending
                    select s).ToList();
        }
        public IEnumerable<User> SortByLastNameAsc()
        {
            return (from s in GetList()
                    orderby s.LastName ascending
                    select s);
        }

        public IEnumerable<User> SortByLastNameDesc()
        {
            return (from s in GetList()
                    orderby s.LastName descending
                    select s).ToList();
        }

        public User Get(int userID)
        {
            return usersDAO.Get(userID);
        }

        public void Edit(int id, string fname, string lname, DateTime bdate, List<Reward> userRewards)
        {
            //var user = new User();
            //user.ID = id;
            //user.FirstName = fname;
            //user.LastName = lname;
            //user.Birthdate = bdate;
            //user.UserRewards = userRewards;
            //this[IndexOf(Get(id))] = user;
            usersDAO.Edit(id, fname, lname, bdate, userRewards);
        }
    }
}