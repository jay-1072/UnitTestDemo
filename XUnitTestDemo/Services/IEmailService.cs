namespace XUnitDemo.Services
{
    public interface IEmailService
    {
        bool IsEmailAvailable();
        void SendEmail();
    }
}