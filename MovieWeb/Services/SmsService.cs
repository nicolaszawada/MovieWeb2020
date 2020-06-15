using System.Diagnostics;

namespace MovieWeb.Services
{
    public class SmsService : IMessageService
    {
        public void Send(string message)
        {
            Debug.WriteLine("Sms verstuurd: " + message);
        }
    }
}
