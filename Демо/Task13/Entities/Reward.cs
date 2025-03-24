using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reward
    {
        public int ID;
        private string title { get; set; }
        private string description { get; set; }

        public Reward()
        {
            if (ID == default(int))
            {
                ID = IDGenerator.GetID();
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value.Length <= 50 && !string.IsNullOrEmpty(value))
                    title = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length <= 250 && !string.IsNullOrEmpty(value))
                    description = value;
            }
        }
    }
}
