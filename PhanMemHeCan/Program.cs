using PhanMemHeCan.Middlewares;
using PhanMemHeCan.Models;
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
app.UseRemoveSessionDeadMiddleware();
app.UseAuthMiddleware();

await PhanMemHeCanContext.ResetDatabase();
GroupBusiness.AddGroup(new PhanMemHeCan.Models.Group.GroupViewModel.AddGroupViewModel { GroupName = "QUyen Admin", IsManagementGroup = true, IsManagementUser = true });
await UserBusiness.AddUser(new PhanMemHeCan.Models.User.UserViewModel.AddUserViewModel { FullName = "DO VAN XUAN", Username = "username", Password = "password" , GroupID = 1});

app.Run();






