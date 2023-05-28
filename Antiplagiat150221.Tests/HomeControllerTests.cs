using System;
using Microsoft.AspNetCore.Mvc;
using Antiplagiat150221.Controllers;
using Xunit;
using System.IO;
using System.Text.Json;

namespace Antiplagiat150221.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("ru")]
        [InlineData("en")]
        public void ChangeLanguageTest(string value)
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            JsonResult result = controller.ChangeLanguage(value);

            // Assert
            Assert.NotEqual("", JsonSerializer.Serialize(result));
            Assert.True(File.Exists("langs.json"));
        }
    }
}
