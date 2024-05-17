using System.ComponentModel.DataAnnotations;

namespace DepartmentApi.Models
{
    public class DepartmentModel
    {
        [Key] 
        public int Did { get; set; }
        public string? SchoolName { get; set; }
        public string? RegisterNo { get; set; }
        public string? DepartmentName { get; set; }
        public string? Section { get; set; }
        public string? DepartmentCode { get; set; }
        public int NumberOfStudentEnrolled { get; set;}
        public string? Course { get; set;}
        public string? Details { get;set; }
    }
}
