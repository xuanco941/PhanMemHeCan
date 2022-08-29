using PhanMemHeCan.Middlewares;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Car;
using PhanMemHeCan.Models.Group;
using PhanMemHeCan.Models.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //session co thoi gian song la 365 ngay
    options.IdleTimeout = TimeSpan.FromDays(365);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// dung session trong page razor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Index}/{id?}");

// dung middleware xac nhan da dang nhap chua
//app.UseRemoveSessionDeadMiddleware();
//app.UseAuthMiddleware();

await PhanMemHeCanContext.ResetDatabase();
GroupBusiness.AddGroup(new PhanMemHeCan.Models.Group.ViewModels.AddGroupViewModel { GroupName = "Quyền Admin", IsManagementGroup = true, IsManagementUser = true });
UserBusiness.AddUser(new PhanMemHeCan.Models.User.ViewModels.AddUserViewModel { FullName = "Đỗ Văn Xuân", Username = "admin", Password = "123", GroupID = 1 });
CarBusiness.AddCar(new PhanMemHeCan.Models.Car.ViewModels.AddCarViewModel { DriverName = "Nguyễn Hồng Sơn", CarWeight = 999, NumberPlates = "29H1-99999" });

app.Run();






