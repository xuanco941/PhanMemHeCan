using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models.Group;
using PhanMemHeCan.Models.Group.GroupViewModel;

namespace PhanMemHeCan.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ViewBag.Groups = GroupBusiness.GetAllGroups();
            }
            catch
            {
                //Lỗi
            }
            return View();
        }

        //Thêm
        [HttpPost]
        public IActionResult AddGroup([FromBody] AddGroupViewModel addGroupViewModel)
        {
            try
            {
                GroupBusiness.AddGroup(addGroupViewModel);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }
        [HttpPost]
        public IActionResult UpdateGroup([FromBody] Group group)
        {
            try
            {
                GroupBusiness.UpdateGroup(group);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }
        [HttpPost]
        public IActionResult DeleteGroup([FromBody] GroupIDViewModel groupIDViewModel)
        {
            try
            {
                GroupBusiness.DeleteGroup(groupIDViewModel.GroupID);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }
        [HttpPost]
        public IActionResult GetGroupFromID([FromBody] GroupIDViewModel groupIDViewModel)
        {
            try
            {
                Group group = GroupBusiness.GetGroupFromID(groupIDViewModel.GroupID);
                return Json(group);
            }
            catch
            {
                return Json("error");
            }

        }


        [HttpPost]
        public IActionResult FindGroupByName([FromBody] GroupNameViewModel groupNameViewModel)
        {
            try
            {
                List<Group> groups = GroupBusiness.FindGroupByName(groupNameViewModel.GroupName);
                return Json(groups);
            }
            catch
            {
                return Json("error");
            }

        }




    }
}
