using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        private bool _Success;
        private string _Message;

        public Result(bool success)
        {
            this.Success = success;
        }

        public Result(string message)
        {
            this.Message = message;
        }

        public Result(bool success, string message)
        {
            this.Message= message;
            this.Success = success;
        }

        public bool Success { get => _Success; set => _Success = value; }
        public string Message { get => _Message; set => _Message = value; }
    }
}
