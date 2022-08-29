using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models.User;
using PhanMemHeCan.Models.User.ViewModels;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Group;

namespace PhanMemHeCan.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                try
                {
                    ViewBag.Users = UserBusiness.GetAllUsers();
                }
                catch
                {
                    //Loi
                }
                return View();
            }
            else
            {
                return Forbid();
            }
        }


        //Thêm
        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserViewModel addUserViewModel)
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                int rowChanged = 0;

                try
                {
                    //trả về số dòng thay đổi trên database
                    rowChanged = UserBusiness.AddUser(addUserViewModel);
                    if (rowChanged > 0)
                    {
                        return Json(new ResponseViewModel<AddUserViewModel> { status = true, message = "Thêm thành công.", rowsNumberChanged = rowChanged, data = addUserViewModel });
                    }
                    else
                    {
                        return Json(new ResponseViewModel<AddUserViewModel> { status = false, message = "Thêm không thành công.", rowsNumberChanged = rowChanged, data = null });
                    }

                }
                catch
                {
                    return Json(new ResponseViewModel<AddUserViewModel> { status = false, message = "Lỗi hệ thống, không thể thêm tài khoản này.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            else
            {
                return Forbid();
            }
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UserViewModel user)
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                int rowChanged = 0;
                try
                {
                    //trả về số dòng thay đổi trên database
                    rowChanged = UserBusiness.UpdateUser(user);
                    if (rowChanged > 0)
                    {
                        return Json(new ResponseViewModel<UserViewModel> { status = true, message = "Cập nhật thành công.", rowsNumberChanged = rowChanged, data = user });
                    }
                    else
                    {
                        return Json(new ResponseViewModel<UserViewModel> { status = false, message = "Cập nhật không thành công.", rowsNumberChanged = rowChanged, data = null });
                    }
                }
                catch
                {
                    return Json(new ResponseViewModel<UserViewModel> { status = false, message = "Lỗi hệ thống, không thể cập nhật dữ liệu người dùng này.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            else
            {
                return Forbid();
            }
        }


        //Xóa
        [HttpPost]
        public IActionResult DeleteUser([FromBody] UserIDViewModel userIDViewModel)
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                int rowChanged = 0;
                try
                {
                    rowChanged = UserBusiness.DeleteUser(userIDViewModel);
                    if (rowChanged > 0)
                    {
                        //them vao list user has deleted
                        Common.listIdUserHasDeleted.Add(userIDViewModel.UserID);
                        User? user = UserBusiness.GetUserFromID(userIDViewModel);
                        return Json(new ResponseViewModel<User> { status = true, message = "Xóa thành công.", rowsNumberChanged = rowChanged, data = user });
                    }
                    else
                    {
                        return Json(new ResponseViewModel<User> { status = false, message = "Xóa không thành công.", rowsNumberChanged = rowChanged, data = null });
                    }

                }
                catch
                {
                    return Json(new ResponseViewModel<User> { status = false, message = "Lỗi hệ thống, không thể xóa dữ liệu người dùng này.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            else
            {
                return Forbid();
            }
        }


        [HttpPost]
        public IActionResult GetUserFromID([FromBody] UserIDViewModel userIDViewModel)
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                try
                {
                    User? user = UserBusiness.GetUserFromID(userIDViewModel);
                    return Json(new ResponseViewModel<User> { status = true, message = "success", rowsNumberChanged = 0, data = user });
                }
                catch
                {
                    return Json(new ResponseViewModel<User> { status = false, message = "error", rowsNumberChanged = 0, data = null });
                }
            }
            else
            {
                return Forbid();
            }

        }

        [HttpPost]
        public IActionResult FindUserByFullNameOrUsername([FromBody] NameViewModel nameViewModel)
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                try
                {
                    List<User> users = UserBusiness.FindUserByFullNameOrUsername(nameViewModel);
                    return Json(new ResponseViewModel<List<User>> { status = true, message = "success", rowsNumberChanged = 0, data = users });
                }
                catch
                {
                    return Json(new ResponseViewModel<User> { status = false, message = "error", rowsNumberChanged = 0, data = null });
                }
            }
            else
            {
                return Forbid();
            }

        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            Group? group = GroupBusiness.GetRuleUser(HttpContext.Session.GetInt32(Common.SESSION_USERID));
            if (group != null && group.IsManagementUser)
            {
                try
                {
                    List<UserHasNameGroupViewModel> users = UserBusiness.GetAllUsers();
                    return Json(new ResponseViewModel<List<UserHasNameGroupViewModel>> { status = true, message = "success", rowsNumberChanged = 0, data = users });
                }
                catch
                {
                    return Json(new ResponseViewModel<UserHasNameGroupViewModel> { status = false, message = "error", rowsNumberChanged = 0, data = null });
                }
            }
            else
            {
                return Forbid();
            }
        }


    }
}

