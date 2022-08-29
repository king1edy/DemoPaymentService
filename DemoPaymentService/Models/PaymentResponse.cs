namespace DemoPaymentService.Models
{
    public class PaymentResponse
    {
        public bool HasError { get; set; }
        public bool Status { get; set; }

        public string Message { get; set; }
    }
}
