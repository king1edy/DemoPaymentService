namespace DemoPaymentService.Util
{
    public class Misc
    {
        private static Random random = new Random();

        public static string Payment_URL()
        {
            if (string.IsNullOrEmpty(ENV.DemoPaymentService))
                throw new Exception("Environment Variable is not configured");

            var arrayInfo = ENV.DemoPaymentService.Split("|");
            return arrayInfo[0];
        }

        public static string Paystack_SECRET_KEY()
        {
            if (string.IsNullOrEmpty(ENV.DemoPaymentService))
                throw new Exception("Environment Variable is not configured");

            var arrayInfo = ENV.DemoPaymentService.Split("|");
            return arrayInfo[1];
        }

        public static string Mono_SECRET_KEY()
        {
            if (string.IsNullOrEmpty(ENV.DemoPaymentService))
                throw new Exception("Environment Variable is not configured");

            var arrayInfo = ENV.DemoPaymentService.Split("|");
            return arrayInfo[2];
        }              

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}