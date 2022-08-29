namespace DemoPaymentService.Util
{
    public class ENV
    {
        public static readonly string DemoPaymentService = Environment.GetEnvironmentVariable("DemoPaymentService", EnvironmentVariableTarget.Machine);
    }
}
