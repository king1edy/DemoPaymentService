namespace DemoPaymentService.Models
{
    public class PaymentResponse
    {
        public bool HasError { get; set; }
        public string Status { get; set; }

        public string Message { get; set; }
    }
}
