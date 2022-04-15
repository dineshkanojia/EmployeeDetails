using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class CustomError
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public bool ResponseStatus { get; set; } = true;
    }
}
