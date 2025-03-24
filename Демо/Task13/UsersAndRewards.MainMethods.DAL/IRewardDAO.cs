using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndRewards.MainMethods.DAL
{
 public interface IRewardDAO
    {
        void Add(Entities.Reward reward);
        void Delete(Entities.Reward reward);
        Entities.Reward Get(int rewardID);
        int IndexOf(Entities.Reward reward);
        Entities.Reward this[int i] { set;  get; }
        IEnumerable<Entities.Reward> GetList();
        void Edit(int id, string title, string description);
    }
}
