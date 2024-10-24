namespace CMCSProjectPART1.Models
{
    public class MonthlyClaimModel
    {
        public int Id { get; set; }
        public DateTime ClaimDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string DocumentPath { get; set; } // Store the path of the document
    }
}
