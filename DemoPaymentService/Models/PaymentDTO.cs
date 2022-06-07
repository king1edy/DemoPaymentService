namespace DemoPaymentService.Models
{
    public class PaymentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DestinationBankId { get; set; }
        public string DestinationBank { get; set; }
        public string DestinationBankAccountNum { get; set; }

        public int SourceBankId { get; set; }
        public string SourceBank { get; set; }
        public string SourceBankAccountNum { get; set; }
        public double Amount { get; set; }

        public CardDetails CardDetails { get; set; }
    }
}