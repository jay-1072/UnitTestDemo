namespace XUnitDemo.Services
{
    public class EmailService : IEmailService
    {
        public bool IsEmailAvailable()
        {
            return true;
        }

        public void SendEmail()
        {
            // some logic to send email.
        }
    }
}