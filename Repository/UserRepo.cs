using Domain.Enums;
using System.Collections.Generic;
using Domain.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Domain.Interfaces;
using Domain.StringLiterals;
using Repository.Factory;

namespace Repository
{
    public class UserRepo:IUserRepo
    {
        public UserRepo()
        {
        }
        /// <summary>
        /// Getting the user details as per the choice of the user.
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<Model> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            SqlDataAdapter adapter=null;
            DataRow[] result=null;
            DataSet dataSet=null;
            DataTable userTable=null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeeportal"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string selectQuery = string.Empty;
                    switch ((int)userRoleChoice)
                    {
                        case 1:
                            selectQuery = StringLiterals._getUserQuery; 
                            break;
                        case 2:
                            selectQuery = StringLiterals._getOthersQuery;
                            break;
                        case 3:
                            selectQuery = StringLiterals._getAllQuery;
                            break;
                    }
                    adapter = new SqlDataAdapter(selectQuery, connection);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet, "User");
                    userTable = dataSet.Tables["User"];
                    result = userTable.Select();
                    ConvertToList(result);
                }
            }
            return DataSource._userList;
        }
        /// <summary>
        /// this is used to insert data into list. 
        /// </summary>
        /// <param name="result"></param>
        public  void ConvertToList(DataRow[] result)
        {
            foreach (DataRow row in result)
            {
                DataSource._userList.Add(new UserModel
                               {
                                   EmailAddress = row["EmailAddress"].ToString(),
                                   FirstName = row["FirstName"].ToString(),
                                   LastName = row["LastName"].ToString()
                               });
            }
        }
    }
}