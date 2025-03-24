using System;
using Entities;
using UsersAndRewards.MainMethods.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndRewards.MainClasses.BLL
{
    public class RewardView
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }

        public RewardView(Reward reward)
        {
            ID = reward.ID;
            Title = reward.Title;
            Description = reward.Description;
        }

        public static List<RewardView> ShowRewards(RewardsBL rewards)
        {
            var myList = new List<RewardView>();
            foreach (Reward item in rewards.GetList())
            {
                var newReward = new RewardView(item);
                myList.Add(newReward);
            }
            return myList;
        }
        public static List<RewardView> ShowRewards(IEnumerable<Reward> rewards)
        {
            var myList = new List<RewardView>();
            foreach (Reward item in rewards)
            {
                var newReward = new RewardView(item);
                myList.Add(newReward);
            }
            return myList;
        }
    }
}
