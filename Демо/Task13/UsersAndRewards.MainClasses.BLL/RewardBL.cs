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
    public class RewardsBL
    {
        private readonly IRewardDAO rewardsDAO;

        public RewardsBL()
        {
            if (DatabaseConfig.GetContext().ToString() == "adonet")
            {
                rewardsDAO = new RewardSqlDAO();
            }
            else
            {
                rewardsDAO = new RewardDAO();
            }
        }

        public void Add(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Нет награды!");
            rewardsDAO.Add(reward);
        }

        public void Add(string title, string description)
        {
            Reward reward = new Reward
            {
                Title = title,
                Description = description
            };
            Add(reward);
        }

        public void Delete(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Нет награды!");
            rewardsDAO.Delete(reward);
        }

        public Reward Get(int rewardID)
        {
            return rewardsDAO.Get(rewardID);
        }
        

        public Reward this[int i]
        {
            get
            {
                return rewardsDAO[i];
            }

            set
            {
                rewardsDAO[i] = value;
            }
        }

        //public void Edit(int id, string title, string description)
        //{
        //    var reward = new Reward();
        //    reward.ID = id;
        //    reward.Title = title;
        //    reward.Description = description;
        //    this[IndexOf(Get(id))] = reward;
        //}

        public void Edit(int id, string title, string description)
        {
            rewardsDAO.Edit(id, title, description);
        }
        public int IndexOf(Reward reward)
        {
            return rewardsDAO.IndexOf(reward);
        }
        
        public IEnumerable<Reward> GetList()
        {
            return rewardsDAO.GetList();
        }
        public IEnumerable<Reward> SortByTitleAsc()
        {
            return (from s in GetList()
                    orderby s.Title ascending
                    select s);
        }

        public IEnumerable<Reward> SortByTitleDesc()
        {
            return (from s in GetList()
                    orderby s.Title descending
                    select s).ToList();
        }
        public IEnumerable<Reward> SortByDescriptionAsc()
        {
            return (from s in GetList()
                    orderby s.Description ascending
                    select s);
        }

        public IEnumerable<Reward> SortByDescriptionDesc()
        {
            return (from s in GetList()
                    orderby s.Description descending
                    select s).ToList();
        }
    }
}