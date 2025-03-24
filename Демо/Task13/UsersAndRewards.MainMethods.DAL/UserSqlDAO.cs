using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace UsersAndRewards.MainMethods.DAL
{
    public class UserSqlDAO : IUserDAO, IDisposable
    {
        private SqlConnection _connection;

        public User this[int i]
        {
            get
            {
                InitConnection();
                User user = new User();
                using (SqlCommand command = new SqlCommand("SELECT ID, FirstName, LastName, Birthdate FROM USERS", _connection))
                {
                    int index = -1;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        index++;
                        if (index == i)
                        {
                            user.ID = (int)reader["ID"];
                            user.FirstName = (string)reader["FirstName"];
                            user.LastName = (string)reader["LastName"];
                            user.Birthdate = (DateTime)reader["Birthdate"];
                            
                            break;
                        }
                    }
                }
                user.UserRewards = GetRewards(user.ID).ToList();
                Dispose();
                return user;
            }

            set
            {
                int usID = 0;
                InitConnection();
                using (SqlCommand command = new SqlCommand("SELECT ID FROM USERS", _connection))
                {
                    int index = -1;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        index++;
                        if (index == i)
                        {
                            usID = (int)reader["ID"];
                            break;
                        }
                    }
                }
                Dispose();
                Edit(usID, value.FirstName, value.LastName, value.Birthdate, value.UserRewards);
            }
        }

        public UserSqlDAO()
        {
            
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
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

        public DataTable AddRewards(List<Reward> rewards)
        {
            DataTable uRewards = new DataTable();
            
            uRewards.Columns.Add("URewardID");
            //if (rewards != null)
            //{
                foreach (Reward reward in rewards)
                {
                    uRewards.Rows.Add(reward.ID);
                }
            
            return uRewards;
        }
        public void Add(User user)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("AddUser");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", user.ID);
                command.Parameters.AddWithValue("@Firstname", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                if (user.UserRewards != null)
                {
                    var p = command.Parameters.AddWithValue("@UsersRewards", AddRewards(user.UserRewards));
                    p.SqlDbType = SqlDbType.Structured;
                }
                var result = command.ExecuteNonQuery();
            }
            Dispose();
        }

        public void Delete(User user)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("DeleteUser");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", user.ID);

                var result = command.ExecuteNonQuery();
            }
            Dispose();
        }
        

        public int IndexOf(User user)
        {
            int index = -1;
            InitConnection();
            using (SqlCommand command = new SqlCommand("SELECT ID FROM USERS", _connection))
            {
                int i = -1;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                        if ((int)reader["ID"] == user.ID)
                        {
                            index = i;
                        }
                    }
                    reader.Close();
                }
            }
            Dispose();
            return index;
        }

        public IEnumerable<User> GetList()
        {
            InitConnection();
            List<User> result = new List<User>();
            using (SqlCommand command = new SqlCommand("SELECT ID, FirstName, LastName, Birthdate FROM USERS", _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string fname = reader["FirstName"].ToString();
                        string lname = reader["LastName"].ToString();
                        DateTime bdate = (DateTime)reader["Birthdate"];
                        //yield return new User()
                        //{
                        //    ID = id,
                        //    FirstName = fname,
                        //    LastName = lname,
                        //    Birthdate = bdate,
                        //    UserRewards = GetRewards(id).ToList()
                        //};
                        result.Add(new User(id, fname, lname, bdate));
                    }
                    reader.Close();
                }
            }
            foreach (var item in result)
            {
                item.UserRewards = GetRewards(item.ID).ToList();
            }
            Dispose();
            return result;
        }
        public IEnumerable<Reward> GetRewards(int id)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("GetUsersRewards");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rID = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string description = reader["Description"].ToString();
                        //string description = reader.GetString(2);

                        yield return new Reward()
                        {
                            ID = id,
                            Title = title,
                            Description = description
                        };
                    }
                    reader.Close();
                }
            }
            Dispose();
        }
        public User Get(int userID)
        {
            InitConnection();
                User user = new User();
                using (SqlCommand command = new SqlCommand("SELECT ID, FirstName, LastName, Birthdate FROM USERS WHERE ID = @id", _connection))
                {
                command.Parameters.AddWithValue("@id", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                user.ID = userID;
                                user.FirstName = (string)reader["FirstName"];
                                user.LastName = (string)reader["LastName"];
                                user.Birthdate = (DateTime)reader["Birthdate"];
                                break;
                        }
                        reader.Close();
                    }
                }
                user.UserRewards = GetRewards(userID).ToList();
            Dispose();
                return user;
        }

        public void Edit(int id, string fname, string lname, DateTime bdate, List<Reward> userRewards)
        {
            InitConnection();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = String.Format("EditUser");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FirstName", fname);
                command.Parameters.AddWithValue("@LastName", lname);
                command.Parameters.AddWithValue("@Birthdate", bdate);
                if (userRewards != null)
                {
                    var p = command.Parameters.AddWithValue("@UsersRewards", AddRewards(userRewards));
                    p.SqlDbType = SqlDbType.Structured;
                }

                var result = command.ExecuteNonQuery();
            }
            Dispose();
        }

    }
}
