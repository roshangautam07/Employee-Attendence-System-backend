using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.Models
{
    public class Attendance
    {
        [Key]  // Mark field as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Employee Attendance date is required")]
        public string attendanceDate { get; set; }
        [Required(ErrorMessage = "Employee Attendance time is required")]
        public string attendanceTime { get; set; }
        [Required(ErrorMessage = "Attendance status required")]
        public string status { get; set; }
        [Required(ErrorMessage = "Please Select the employee")]
        public  int employeeId { get; set; }
    }
}