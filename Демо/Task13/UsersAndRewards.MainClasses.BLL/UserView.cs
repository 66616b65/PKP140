using System;
using Entities;
using UsersAndRewards.MainMethods.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndRewards.MainClasses.BLL
{
    public class UserView
    {
        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime Birthdate { get; }
        public int Age { get; }
        public string UserRewards { get; }

        public UserView(User user)
        {
            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;
            Age = user.Age;
            if (user.UserRewards != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in user.UserRewards)
                {
                    sb.Append(item.Title + ", ");
                }
                if (sb.Length > 2)
                {
                    UserRewards = sb.ToString(0, sb.Length - 3);
                }
            }
        }

        public static List<UserView> ShowUsers(UsersBL users)
        {
            var myList = new List<UserView>();
            foreach(User item in users.GetList())
            {
                var newUser = new UserView(item);
                myList.Add(newUser);
            }
            return myList;
        }
        public static List<UserView> ShowUsers(IEnumerable<User> users)
        {
            var myList = new List<UserView>();
            foreach (User item in users)
            {
                var newUser = new UserView(item);
                myList.Add(newUser);
            }
            return myList;
        }

        public static string RewardsToString(User user)
        {
            string userRewards = string.Empty;
            if (user.UserRewards != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in user.UserRewards)
                {
                    sb.Append(item.Title + ", ");
                }
                if (sb.Length > 2)
                {
                    userRewards = sb.ToString(0, sb.Length - 3);
                }
            }
            return userRewards;
        }
    }
}
