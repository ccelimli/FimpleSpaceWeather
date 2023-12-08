using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        private T _Data;
        public DataResult(bool success, T data) : base(success) => this.Data = data;

        public DataResult(bool success, string Message, T data) : base(success, Message) => this.Data = data;

        public T Data { get => _Data; set => _Data = value; }
    }
}
