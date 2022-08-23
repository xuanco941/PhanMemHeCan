
namespace PhanMemHeCan.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RemoveSessionDeadMiddleware
    {
        private readonly RequestDelegate _next;

        public RemoveSessionDeadMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // neu ma session login ton tai va session login la id user da bi delete
            if (httpContext.Session.GetInt32(Common.SESSION_USERID) != null && Common.listIdUserHasDeleted.Contains((int)httpContext.Session.GetInt32(Common.SESSION_USERID)) == true)
            {
                //remove session when id has be deleted
                Common.listIdUserHasDeleted.Remove((int)httpContext.Session.GetInt32(Common.SESSION_USERID));


                System.Diagnostics.Debug.WriteLine("RemoveSessionDeadMiddleware RemoveSessionDeadMiddleware RemoveSessionDeadMiddleware");
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyAppExtentions
    {
        public static IApplicationBuilder UseRemoveSessionDeadMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RemoveSessionDeadMiddleware>();
        }
    }
}
