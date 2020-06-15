using System.Diagnostics;

namespace MovieWeb.Services
{
    public class MailService : IMessageService
    {
        public void Send(string message)
        {
            // Code voor mail te sturen
            Debug.WriteLine("Mail verstuurd!");
        }
    }
}
