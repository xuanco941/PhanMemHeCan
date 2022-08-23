using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models.User;
using PhanMemHeCan.Models.User.UserViewModel;

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
            try
            {
                UserBusiness.AddUser(addUserViewModel);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                UserBusiness.UpdateUser(user);
                return Json("success");
            }
            catch
            {
                //Lỗi
                return Json("error");
            }
        }


        [HttpPost]
        public IActionResult GetUserFromID([FromBody] UserIDViewModel userIDViewModel)
        {
            try
            {
                User user = UserBusiness.GetUserFromID(userIDViewModel.UserID);
                return Json(user);
            }
            catch
            {
                return Json("error");
            }

        }


        [HttpPost]
        public IActionResult FindUserByFullNameOrUsername([FromBody] NameViewModel nameViewModel)
        {
            try
            {
                List<User> users = UserBusiness.FindUserByFullNameOrUsername(nameViewModel.Name);
                return Json(users);
            }
            catch
            {
                return Json("error");
            }

        }



        //Xóa
        [HttpPost]
        public IActionResult DeleteUser([FromBody] UserIDViewModel userIDViewModel)
        {
            try
            {
                UserBusiness.DeleteUser(userIDViewModel.UserID);
                //them vao list user has deleted
                Common.listIdUserHasDeleted.Add(userIDViewModel.UserID);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }

    }
}

