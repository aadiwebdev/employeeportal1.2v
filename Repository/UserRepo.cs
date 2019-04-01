/*
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Domain.StringLiterals;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepo
    {
        /// <summary>
        /// Retrieve User details from the repository
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<Model> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            List<Model> usersList=new List<Model>();
            switch ((int)userRoleChoice)
            {
                case (int)UserRoleChoice.User :
                        usersList = (List<Model>)DataSource._userList.Where(m => m.IsStudent==StringLiterals._yes).ToList<Model>();
                         break;
                case (int)UserRoleChoice.Other :
                        usersList = (List<Model>)DataSource._userList.Where(m => m.IsStudent==StringLiterals._no).ToList<Model>();
                    break;
                case (int)UserRoleChoice.All:
                    usersList = DataSource._userList;
                    break;
            }
            return usersList;
        }
    }
}
*/





using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using System.Data.SqlClient;
using Domain.StringLiterals;
using System.Data;
using System.Configuration;
namespace Repository
{
    public class UserRepo
    {
        private static List<UserModel> _usersList = new List<UserModel>();
        public UserRepo()
        {
            _usersList = DataSource._userList.Select(x => new UserModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmailAddress = x.EmailAddress,
                Password = x.Password,
                IsStudent = x.IsStudent
            }).ToList();
        }
        /// <summary>
        /// Getting the user details as per the choice of the user.
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<UserModel> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            SqlDataAdapter adapter=null;
            DataRow[] result;
            DataSet dataSet;
            DataTable userTable;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeeportal"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    switch ((int)userRoleChoice)
                    {

                        case 1:
                            adapter = new SqlDataAdapter("SELECT * FROM USERINFO WHERE IsStudent='true'", connection);
                            
                            break;
                        case 2:
                            adapter = new SqlDataAdapter("SELECT * FROM USERINFO WHERE IsStudent='false'", connection);
                            break;
                        case 3:
                            adapter = new SqlDataAdapter("SELECT * FROM USERINFO", connection);
                            break;
                    }

                    dataSet = new DataSet();
                    adapter.Fill(dataSet, "User");
                    userTable = dataSet.Tables["User"];
                    result = userTable.Select();
                    ConvertToList(result);
                    _usersList.Clear();
                }
            }
            return _usersList;
        }
        /// <summary>
        /// this is used to insert data into list. 
        /// </summary>
        /// <param name="result"></param>
        private void ConvertToList(DataRow[] result)
        {
            foreach (DataRow row in result)
            {
                _usersList.Add(new UserModel
                               {
                                   EmailAddress = row["EmailAddress"].ToString(),
                                   FirstName = row["FirstName"].ToString(),
                                   LastName = row["LastName"].ToString()
                               });
            }
        }
    }
}