using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace UsersAndRewards.MainMethods.DAL
{
    public class RewardDAO : IRewardDAO, IEnumerable
    {
        private List<Reward> rewards = new List<Reward>();

        public Reward this[int i]
        {
            get
            {
                return rewards[i];
            }

            set
            {
                rewards[i] = value;
            }
        }
        public void Edit(int id, string title, string description)
        {
            int rewIndex = IndexOf(Get(id));
            this[rewIndex].Title = title;
            this[rewIndex].Description = description;
        }
        public void Add(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Нет награды!");
            rewards.Add(reward);
        }
        public void Delete(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Нет награды!");
            rewards.Remove(reward);
        }

        public Reward Get(int rewardID)
        {
            return rewards.Find(x => x.ID == rewardID);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)rewards).GetEnumerator();
        }

        public int IndexOf(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Нет награды!");
            return rewards.IndexOf(reward);
        }
        public IEnumerable<Reward> GetList()
        {
            return rewards;
        }
    }
}
