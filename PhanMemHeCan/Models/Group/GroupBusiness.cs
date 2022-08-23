
using PhanMemHeCan.Models.Group.GroupViewModel;
using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Group
{
    internal class GroupBusiness
    {
        public static List<Group> GetAllGroups()
        {
            List<Group> list = new List<Group>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from [Group]";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Group group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3));
                list.Add(group);
            }
            sqlConnection.Close();
            return list;
        }


        public static Group GetGroupFromID(int GroupID)
        {
            Group group = new Group();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec GetGroupFromID @GroupID";
            command.Parameters.AddWithValue("GroupID", GroupID);
            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3));

            }
            sqlConnection.Close();
            return group;
        }
        //Tìm kiếm group bằng tên
        public static List<Group> FindGroupByName(string name)
        {
            List<Group> list = new List<Group>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();

            command.CommandText = "exec FindGroupByName @name'";
            command.Parameters.AddWithValue("name", name);
            command.Connection = sqlConnection;


            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Group group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3));
                list.Add(group);
            }
            sqlConnection.Close();
            return list;
        }

        // Them nhóm quyền
        public static void AddGroup(AddGroupViewModel group)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Group.Add(new Group { GroupName = group.GroupName, IsManagementGroup = group.IsManagementGroup, IsManagementUser = group.IsManagementUser });
            phanMemHeCanContext.SaveChanges();
        }

        // Sua group
        public static void UpdateGroup(Group group)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateGroup @GroupID, @GroupName, @IsManagementUser, @IsManagementGroup";

            command.Parameters.AddWithValue("GroupID", group.GroupID);
            command.Parameters.AddWithValue("GroupName", group.GroupName);
            command.Parameters.AddWithValue("IsManagementUser", group.IsManagementUser);
            command.Parameters.AddWithValue("IsManagementGroup", group.IsManagementGroup);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteGroup(int GroupID)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteGroup @GroupID";
            command.Parameters.AddWithValue("GroupID", GroupID);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
