using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment_3
{
    public class CustomExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(KeyNotFoundException e)
            {
                context.Response.StatusCode = 404;
                context.Response.ContentType= "text/plain";
                await context.Response.WriteAsync(e.Message);
            }
            catch (ArgumentException e)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.Message);
            }
            catch (System.Exception e) 
            { 
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(e.Message);
            }
            
        }
    }
}
