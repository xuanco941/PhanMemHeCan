using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Group;
using PhanMemHeCan.Models.Group.ViewModels;

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
            int rowChanged = 0;
            try
            {
                //trả về số dòng thay đổi trên database
                rowChanged = GroupBusiness.AddGroup(addGroupViewModel);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Group> { status = true, message = "Thêm thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Group> { status = false, message = "Thêm không thành công.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            catch
            {
                return Json(new ResponseViewModel<Group> { status = false, message = "Lỗi hệ thống, không thể thêm nhóm quyền.", rowsNumberChanged = rowChanged, data = null });
            }
        }
        [HttpPost]
        public IActionResult UpdateGroup([FromBody] Group group)
        {
            int rowChanged = 0;
            try
            {
                rowChanged = GroupBusiness.UpdateGroup(group);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Group> { status = true, message = "Cập nhật thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Group> { status = false, message = "Cập nhật không thành công.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            catch
            {
                return Json(new ResponseViewModel<Group> { status = false, message = "Lỗi hệ thống, không thể cập nhật.", rowsNumberChanged = rowChanged, data = null });
            }
        }
        [HttpPost]
        public IActionResult DeleteGroup([FromBody] GroupIDViewModel groupIDViewModel)
        {
            int rowChanged = 0;
            try
            {
                rowChanged = GroupBusiness.DeleteGroup(groupIDViewModel);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Group> { status = true, message = "Xóa thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Group> { status = false, message = "Xóa không thành công.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            catch
            {
                return Json(new ResponseViewModel<Group> { status = false, message = "Lỗi hệ thống, không thể xóa.", rowsNumberChanged = rowChanged, data = null });
            }
        }
        [HttpPost]
        public IActionResult GetGroupFromID([FromBody] GroupIDViewModel groupIDViewModel)
        {
            try
            {
                Group? group = GroupBusiness.GetGroupFromID(groupIDViewModel);
                return Json(new ResponseViewModel<Group> { status = true, message = "success", rowsNumberChanged = 0, data = group });
            }
            catch
            {
                return Json(new ResponseViewModel<Group> { status = false, message = "error", rowsNumberChanged = 0, data = null });
            }

        }


        [HttpPost]
        public IActionResult FindGroupByName([FromBody] GroupNameViewModel groupNameViewModel)
        {
            try
            {
                List<Group> groups = GroupBusiness.FindGroupByName(groupNameViewModel);
                return Json(new ResponseViewModel<List<Group>> { status = true, message = "success", rowsNumberChanged = 0, data = groups });
            }
            catch
            {
                return Json(new ResponseViewModel<List<Group>> { status = true, message = "error", rowsNumberChanged = 0, data = null });
            }
        }




    }
}
