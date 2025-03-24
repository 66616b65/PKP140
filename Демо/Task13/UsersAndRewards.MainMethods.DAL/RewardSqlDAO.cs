using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace UsersAndRewards.MainMethods.DAL
{
    public class RewardSqlDAO : IRewardDAO, IDisposable
    {
        private SqlConnection _connection;

        private void InitConnection()
        {
            _connection = new SqlConnection(DatabaseConfig.GetConnectionString());
            _connection.Open();
            _connection.StateChange += ConnectionStateChange;
        }
        void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Broken)
            {
                InitConnection();
            }
        }
        public RewardSqlDAO()
        {
            
        }
        public Reward this[int i]
        {
            get
            {
                Reward reward = new Reward();
                InitConnection();
                using (SqlCommand command = new SqlCommand("SELECT ID, Title, Description FROM REWARDS", _connection))
                { 
                    int index = -1;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            index++;
                            if (index == i)
                            {
                                reward.ID = (int)reader["ID"];
                                reward.Title = (string)reader["Title"];
                                reward.Description = reader["Description"].ToString();
                                break;
                            }
                        }
                    }
                }
                Dispose();
                return reward;
            }

            set
            {
                InitConnection();
                int rewID = 0;
                using (SqlCommand command = new SqlCommand("SELECT ID FROM REWARDS", _connection))
                {
                    int index = -1;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            index++;
                            if (index == i)
                            {
                                rewID = (int)reader["ID"];
                                break;
                            }
                        }
                    }
                }
                Dispose();
                Edit(rewID, value.Title, value.Description);
                //Dispose();
            }
        }

        public void Add(Reward reward)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("AddReward");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", reward.ID);
                command.Parameters.AddWithValue("@Title", reward.Title);
                //  object description = string.IsNullOrEmpty(reward.Description)
                //  ? DBNull.Value
                //  : reward.Description;
                object description = new object();
                if (string.IsNullOrEmpty(reward.Description))
                {
                    description = DBNull.Value;
                }
                else
                {
                    description = reward.Description;
                }
                command.Parameters.AddWithValue("@Description", description);

                command.ExecuteNonQuery();
            }
            Dispose();
        }

        public void Delete(Reward reward)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("DeleteReward");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", reward.ID);

                var result = command.ExecuteNonQuery();
            }
            Dispose();
        }

        public void Edit(int id, string title, string description)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("EditReward");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);

                var result = command.ExecuteNonQuery();
            }
            Dispose();
        }

        public Reward Get(int rewardID)
        {
            InitConnection();
            Reward reward = new Reward();
            using (SqlCommand command = new SqlCommand("SELECT ID, Title, Description FROM REWARDS", _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader["ID"] == rewardID)
                        {
                            reward.ID = (int)reader["ID"];
                            reward.Title = reader["Title"].ToString();
                            reward.Description = reader["Description"].ToString();
                            break;
                        }
                    }
                }
            }
            Dispose();
            return reward;
        }

        public IEnumerable<Reward> GetList()
        {
            InitConnection();
            using (SqlCommand command = new SqlCommand("SELECT ID, Title, Description FROM REWARDS", _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string title = reader["Title"].ToString();
                        string description = reader["Description"].ToString();

                        yield return new Reward()
                        {
                            ID = id,
                            Title = title,
                            Description = description
                        };
                    }
                }
            }
            Dispose();
        }

        public int IndexOf(Reward reward)
        {
            int index = -1;
            InitConnection();
            using (SqlCommand command = new SqlCommand("SELECT ID FROM REWARDS", _connection))
            {
                int i = -1;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                        if ((int)reader["ID"] == reward.ID)
                        {
                            index = i;
                        }
                    }
                }   
            }
            Dispose();
            return index;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
