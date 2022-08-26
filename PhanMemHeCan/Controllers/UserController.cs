using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models.User;
using PhanMemHeCan.Models.User.ViewModels;
using PhanMemHeCan.Models;

namespace PhanMemHeCan.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
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


        //Thêm
        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserViewModel addUserViewModel)
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

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UserViewModel user)
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


        //Xóa
        [HttpPost]
        public IActionResult DeleteUser([FromBody] UserIDViewModel userIDViewModel)
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


        [HttpPost]
        public IActionResult GetUserFromID([FromBody] UserIDViewModel userIDViewModel)
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

        [HttpPost]
        public IActionResult FindUserByFullNameOrUsername([FromBody] NameViewModel nameViewModel)
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

        [HttpGet]
        public IActionResult GetAllUsers()
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


    }
}

