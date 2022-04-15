using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class EmployeeViewModel : CustomError
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Postcode { get; set; }

        public string Desgination { get; set; }

        public DateTime DOB { get; set; }

        public bool IsDelete { get; set; }

        public int Status { get; set; }

        public string RoleName { get; set; }
    }
}
