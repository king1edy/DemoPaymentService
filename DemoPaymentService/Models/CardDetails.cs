namespace DemoPaymentService.Models
{
    public class CardDetails
    {
        public string CardNumber { get; set; }

        public string ValidUntil { get; set; }
        public string CvvCode { get; set; }
        public string CardPin { get; set; }
        public CardType CardType { get; set; }
        public string CardHolderName { get; set; }
    }
}