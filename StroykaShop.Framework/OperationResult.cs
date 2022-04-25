using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool Result { get; set; }
        public OperationResult()
        {
            Message = "موفق";
            Result = true;
        }
        public OperationResult Success(string message = "با موفقیت انجام شد")
        {
            Message = message;
            Result = true;
            return this;
        }
        public OperationResult Failed(string message = "عملیات با شکست مواجه شد")
        {
            Message = message;
            Result = false;
            return this;
        }

    }
}
