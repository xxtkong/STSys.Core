
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.HotlinkingPreventionMiddleware
{
    public class PreventionMiddleware
    {
        private readonly string _wwwrootFolder;
        private readonly RequestDelegate _next;
        public PreventionMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            _wwwrootFolder = env.WebRootPath;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var applicationUrl = $"{context.Request.Scheme}://{context.Request.Host.Value}";
            var headersDictionary = context.Request.Headers;
            var urlReferrer = headersDictionary[HeaderNames.Referer].ToString();

            if (!string.IsNullOrEmpty(urlReferrer) && !urlReferrer.StartsWith(applicationUrl))
            {
                var unauthorizedImagePath = Path.Combine(_wwwrootFolder, "Images/Unauthorized.png");
               // await context.Response.WriteAsync(unauthorizedImagePath);
                await context.Response.SendFileAsync(unauthorizedImagePath);
            }
            await _next(context);
        }
    }
}
