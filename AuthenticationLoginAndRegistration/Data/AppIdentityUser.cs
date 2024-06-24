using AuthenticationLoginAndRegistration.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationLoginAndRegistration.Data
{
    public class AppIdentityUser : IdentityUser
    {
        [Required, StringLength(100)]
        public string Firstname { get; set; }

        [Required, StringLength(100)]
        public string Lastname { get; set; }

        [StringLength(100)]
        public string Companyname { get; set; }

        public virtual ICollection<Todo> Todo { get; set; }
    }
}
