

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemHeCan.Models.Group
{
    [Table("Group")]
    public class Group
    {

        [Key]
        public int GroupID { get; set; }
        [StringLength(100)]
        public string? GroupName { get; set; }
        public bool? IsManagementUser { get; set; }
        public bool? IsManagementGroup { get; set; }

        public Group(string? groupName, bool? isManagementUser, bool? isManagementGroup)
        {
            GroupName = groupName;
            IsManagementUser = isManagementUser;
            IsManagementGroup = isManagementGroup;
        }

        public Group(int groupID, string? groupName, bool? isManagementUser, bool? isManagementGroup)
        {
            GroupID = groupID;
            GroupName = groupName;
            IsManagementUser = isManagementUser;
            IsManagementGroup = isManagementGroup;
        }
        public Group()
        {
        }
    }
}
