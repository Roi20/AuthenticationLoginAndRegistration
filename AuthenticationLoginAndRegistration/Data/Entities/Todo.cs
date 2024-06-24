using AuthenticationLoginAndRegistration.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationLoginAndRegistration.Data.Entities
{
    public class Todo : IBaseModel
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required, MaxLength(100), Display(Name = "Todo")]
        public string Name { get; set; }

        [MaxLength(200), Required]
        public string? Description { get; set; }

        [Required]
        public TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        [Required, Display(Name = "Date")]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [ForeignKey("AppIdentityUser")]
        public string aspUser_Id { get; set; }

        public virtual AppIdentityUser User { get; set; }
    }
}
