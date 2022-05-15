using Microsoft.AspNetCore.Razor.TagHelpers;
using StroykaShop.Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
{
    [HtmlTargetElement(Attributes ="permission")]
    public class PermissionTagHelper:TagHelper
    {
        private readonly IAuthHelper _authHleper;

        public PermissionTagHelper(IAuthHelper authHleper)
        {
            _authHleper = authHleper;
        }

        public int Permission { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_authHleper.ISVeriFired())
            {
                output.SuppressOutput();
                return;
            }
            var permission = _authHleper.GetPermissions();
            if(!permission.All(x=> x != Permission))
            {
                output.SuppressOutput();
                return;
            }
            base.Process(context, output);
        }
    }
}
