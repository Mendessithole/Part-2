using System.ComponentModel.DataAnnotations;

namespace CMCSProjectPART1.Models
{
    public class Claim
    {
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }
        public string EmployeeNo { get; set; }
        public string ContactDetails { get; set; }
        public string Module { get; set; }
        public string Programme { get; set; } // Ensure this exists
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
