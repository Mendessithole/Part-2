using Microsoft.AspNetCore.Http;

namespace CMCSProjectPART1.Models
{
    public class SubmitClaimModel
    {
        public string ClaimDescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime ClaimDate { get; set; }
        public IFormFile ClaimDocument { get; set; } // New property for file upload
    }
}
