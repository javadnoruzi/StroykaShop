using Microsoft.AspNetCore.Mvc.Filters;
using StroykaShop.Framework.Application;
using StroykaShop.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
           
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var permission = (NeedPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttributes(typeof(NeedPermissionAttribute));

            var Accountpersmissions = _authHelper.GetPermissions();
            if (Accountpersmissions.All(x => x != permission.Permission))
            {
                context.HttpContext.Response.Redirect("/Account");
            }


        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
          
        }
    }
}
