using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework
{
    public class ResultMessage
    {
        public static string Duplicateed { get; set; } = "موجود است";
        public static string NullCommand{get;set;}="ورودی خالی است";
        public static string NotFound{get;set;}="این رکورد موجود نیست";
        public static string Faild{get;set;}="عملیات ناموفق بود";
    }
}
