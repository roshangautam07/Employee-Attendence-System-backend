using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.Models
{
    public class Employee
    {
        [Key]  // Mark field as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Employee FirstName is required")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Employee MiddleName is required")]
        public string middleName { get; set; }
        [Required(ErrorMessage = "Employee LastName is required")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Employee Gender is required")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Employee Date of birth is required")]
        public string dob { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public List<Attendance> attendences { get; set; }

        public Employee()
        {
            attendences = new List<Attendance>();
        }
        
    }
}