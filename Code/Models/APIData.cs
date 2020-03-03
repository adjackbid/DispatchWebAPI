using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DispatchWebAPI.Models
{
    public class APIData
    {
        //固定格式
        public string FunctionName { get; set; }
        public string FunctionUID { get; set; } //uni id
        public string FunctionType { get; set; } //S：Send / R：Return

        //先定義成object
        public object Content { get; set; } //內容

        public string returncode { get; set; } //00

        public string returnmessage { get; set; } //OK
    }
}
