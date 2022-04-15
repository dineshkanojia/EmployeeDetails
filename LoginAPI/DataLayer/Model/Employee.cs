using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required]
        [Display(Name = "Desgination")]
        public string Desgination { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }


        [Required]
        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }

        public virtual List<RoleMapping> RoleMapping { get; set; }
    }


    [Table("Roles", Schema = "dbo")]
    public class Roles
    {
       
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual List<RoleMapping> RoleMapping { get; set; }
    }

    [Table("RoleMapping", Schema = "dbo")]
    public class RoleMapping
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public Employee Employee { get; set; }

        public Roles Roles { get; set; }
    }
}
