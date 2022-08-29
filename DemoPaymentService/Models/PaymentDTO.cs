namespace DemoPaymentService.Models
{
    public class PaymentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Amount { get; set; }

        public CardDetails CardDetails { get; set; }
    }
}