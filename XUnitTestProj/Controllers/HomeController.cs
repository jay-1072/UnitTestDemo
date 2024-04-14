using Moq;
using Xunit;
using XUnitDemo.Controllers;
using XUnitDemo.Services;

namespace XUnitDemoTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeContoller_Index_ValidLargeNumber()
        {
            // Arrange
            //IPrinterService printerService = new MockPrinterService();
            //IEmailService emailService = new MockEmailService();

            Mock<IEmailService> emailMockService = new Mock<IEmailService>();
            emailMockService.Setup(x => x.IsEmailAvailable()).Returns(false);
            emailMockService.Setup(x => x.SendEmail()).Verifiable();

            Mock<IPrinterService> printerMockService = new Mock<IPrinterService>();
            printerMockService.Setup(x => x.IsPrinterAvailable()).Returns(true);
            printerMockService.Setup(x => x.Print(It.IsAny<string>())).Verifiable();

            HomeController controller = new HomeController(emailMockService.Object, printerMockService.Object);
            int guessedNumber = 110;
            string expectedResult = "Wrong! Try a smaller number";

            // Act
            var result = controller.Index(guessedNumber);

            // Assert
            Assert.Equal(expectedResult, result);

            emailMockService.Verify(x => x.SendEmail(), Times.Never);
            printerMockService.Verify(x => x.Print("print this message"), Times.Once);
        }

        //[Fact]
        //public void HomeContoller_Index_ValidSmallNumber()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //    int guessedNumber = 90;
        //    string expectedResult = "Wrong! Try a bigger number";

        //    // Act
        //    var result = controller.Index(guessedNumber);

        //    // Assert
        //    Assert.Equal(expectedResult, result);
        //}

        //[Fact]
        //public void HomeContoller_Index_ValidNumber()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //    int guessedNumber = 100;
        //    string expectedResult = "You guessed correct number";

        //    // Act
        //    var result = controller.Index(guessedNumber);

        //    // Assert
        //    Assert.Equal(expectedResult, result);
        //}
    }
}