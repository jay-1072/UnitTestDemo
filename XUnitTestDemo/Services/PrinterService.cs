namespace XUnitDemo.Services
{
    public class PrinterService : IPrinterService
    {
        public bool IsPrinterAvailable()
        {
            return true;
        }

        public void Print(string content)
        {
            // some logic to print.
        }
    }
}