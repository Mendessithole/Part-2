namespace CMCSProjectPART1.Models
{
    public class ClaimModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        // Add this Status property to track the approval status of the claim
        public string Status { get; set; } = "Pending"; // Default status is Pending
    }
}
