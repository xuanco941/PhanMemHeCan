using Microsoft.AspNetCore.Mvc;

using PhanMemHeCan.Models.User;

namespace PhanMemHeCan.Controllers;

public class AuthenticationController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32(Common.SESSION_USERID) != null)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }

    //Dang nhap, luu session vao bien session class common
    [HttpPost]
    public IActionResult Login(IFormCollection form)
    {
        string username = form["username"].ToString().Trim();
        string password = form["password"].ToString().Trim();

        try
        {
            User? user = UserBusiness.AuthLogin(username, password);

            if (user != null)
            {
                //set session
                HttpContext.Session.SetInt32(Common.SESSION_USERID, user.UserID);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["messageLogin"] = "Tài khoản hoặc mật khẩu không chính xác.";
                TempData["usernameRecent"] = username;
                TempData["passwordRecent"] = password;
                return RedirectToAction("Index");
            }
        }
        catch
        {
            TempData["messageLogin"] = "Lỗi hệ thống, không thể đăng nhập.";
            TempData["usernameRecent"] = username;
            TempData["passwordRecent"] = password;
            return RedirectToAction("Index");
        }
 
    }

    //dang xuat
    public IActionResult Logout()
    {
        HttpContext.Session.Remove(Common.SESSION_USERID);
        return RedirectToAction("Index");
    }

}
