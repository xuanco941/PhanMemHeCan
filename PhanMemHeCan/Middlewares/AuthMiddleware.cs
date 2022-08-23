﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PhanMemHeCan.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            string host = httpContext.Request.Host.ToString();
            string path = httpContext.Request.Path.ToString().ToLower();

            // Neu path = / , login , logout thi cho pheo di tiep 
            // neu khong thi phai co session xac nhan dang nhap moi cho tiep tuc
            // neu khong co session xac nhan thi chuyen ve trang dang nhap
            if (path == "/" || path.Contains("/authentication/login") || path.Contains("/authentication/logout"))
            {
                await _next(httpContext);
            }
            else
            {
                if (httpContext.Session.GetInt32(Common.SESSION_USERID) != null)
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.Redirect("/");
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
