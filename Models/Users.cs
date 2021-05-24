using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}