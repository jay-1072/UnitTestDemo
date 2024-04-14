using XUnitDemo.Services;

namespace XUnitDemoTests.ServicesMock
{
    internal class MockEmailService : IEmailService
    {
        public bool IsEmailAvailable()
        {
            return true;
        }

        public void SendEmail()
        {
            //
        }
    }
}