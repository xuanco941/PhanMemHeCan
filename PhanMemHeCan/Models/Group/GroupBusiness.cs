
using PhanMemHeCan.Models.Group.GroupViewModel;
using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Group
{
    internal class GroupBusiness
    {
        public static List<Group>? GetAllGroups()
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            List<Group>? list = (from gr in phanMemHeCanContext.Group select gr).ToList();
            return list;
        }


        public static Group? GetGroupFromID(int GroupID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            Group? group = (from gr in phanMemHeCanContext.Group where gr.GroupID == GroupID select gr).FirstOrDefault();
            return group;
        }
        //Tìm kiếm group bằng tên
        public static List<Group> FindGroupByName(string name)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var list = (from gr in phanMemHeCanContext.Group where (gr.GroupName != null && gr.GroupName.Contains(name) == true) select gr).ToList();
            return list;
        }

        // Them nhóm quyền
        public static bool AddGroup(AddGroupViewModel group)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Group.Add(new Group { GroupName = group.GroupName, IsManagementGroup = group.IsManagementGroup, IsManagementUser = group.IsManagementUser });
            return phanMemHeCanContext.SaveChanges() > 0 ? true : false;
        }

        // Sua group
        public static bool UpdateGroup(Group gr)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var groupUpdate = (from g in phanMemHeCanContext.Group where g.GroupID == gr.GroupID select g).First();

            groupUpdate = gr;
            if (phanMemHeCanContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool DeleteGroup(int GroupID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var groupDelete = (from g in phanMemHeCanContext.Group where g.GroupID == GroupID select g).First();
            phanMemHeCanContext.Remove(groupDelete);
            if (phanMemHeCanContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
