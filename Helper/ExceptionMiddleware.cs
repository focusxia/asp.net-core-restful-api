using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Helper
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context,StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";
                switch (statusCode)
                {
                    case 400:
                        msg = "请求参数错误";
                        break;
                    case 401:
                        msg = "需要授权";
                        break;
                    case 403:
                        msg = "未授权";
                        break;
                    case 404:
                        msg = "未找到请求路径";
                        break;
                    case 422:
                        msg = "请求参数错误";
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpContext,int statusCode, string msg)
        {
            httpContext.Response.ContentType = "application/json;charset=utf-8";
            return httpContext.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = statusCode,
                Massage = msg
            }.ToString());
        }
    }
}
