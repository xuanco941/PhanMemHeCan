
using PhanMemHeCan.Models.Group.ViewModels;
using System.Data.SqlClient;
using System.Linq;

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


        public static Group? GetGroupFromID(GroupIDViewModel groupIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            Group? group = (from gr in phanMemHeCanContext.Group where gr.GroupID == groupIDViewModel.GroupID select gr).FirstOrDefault();
            return group;
        }
        //Tìm kiếm group bằng tên
        public static List<Group> FindGroupByName(GroupNameViewModel groupNameViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var list = (from gr in phanMemHeCanContext.Group where (gr.GroupName != null && gr.GroupName.Contains(groupNameViewModel.GroupName) == true) select gr).ToList();
            return list;
        }

        // Them nhóm quyền
        public static int AddGroup(AddGroupViewModel group)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Group.Add(new Group ( group.GroupName, group.IsManagementUser, group.IsManagementGroup));
            return phanMemHeCanContext.SaveChanges();
        }

        // Sua group
        public static int UpdateGroup(Group gr)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var groupUpdate = phanMemHeCanContext.Group.FirstOrDefault(group => group.GroupID == gr.GroupID);
            if(groupUpdate != null)
            {
                groupUpdate.GroupName = gr.GroupName;
                groupUpdate.IsManagementUser = gr.IsManagementUser;
                groupUpdate.IsManagementGroup = gr.IsManagementGroup;
            }
            return phanMemHeCanContext.SaveChanges();

        }

        public static int DeleteGroup(GroupIDViewModel groupIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var groupDelete = phanMemHeCanContext.Group.FirstOrDefault(group => group.GroupID == groupIDViewModel.GroupID);
            if(groupDelete != null)
            {
                phanMemHeCanContext.Group.Remove(groupDelete);
            }
            return phanMemHeCanContext.SaveChanges();
        }
    }
}
