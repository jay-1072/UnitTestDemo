using XUnitDemo.Services;

namespace XUnitDemoTests.ServicesMock
{
    internal class MockPrinterService : IPrinterService
    {
        public bool IsPrinterAvailable()
        {
            return true;
        }

        public void Print(string content)
        {
            //
        }
    }
}
