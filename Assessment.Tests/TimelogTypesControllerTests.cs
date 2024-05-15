using Xunit;
using Assessment.Controllers;
using Assessment.Models;
using Microsoft.AspNetCore.Mvc;


namespace Assessment.Tests
{
    public class TimelogTypesControllerTests
    {
        [Fact]
        public void GetTimelogTypes_ReturnsAllItems()
        {
            // Arrange: Controller-Instanz wird erstellt.
            var controller = new TimelogTypesController();

            // Act: Die GetTimelogTypes-Methode wird aufgerufen.
            var result = controller.GetTimelogTypes();

            // Assert: Überprüfe, ob das Ergebnis vom korrekten Typ ist und die erwartete Anzahl an Elementen enthält.// Assert
            var viewResult = Assert.IsType<ActionResult<List<TimelogTypeResponse>>>(result);
            var model = Assert.IsAssignableFrom<List<TimelogTypeResponse>>(viewResult.Value);
            Assert.Equal(5, model.Count()); // Es werden 5 Elemente erwartet.
        }
        [Fact]
        public void GetTimelogType_WithInvalidId_ReturnsNotFound()
        {
            // Arrange: Controller-Instanz wird erstellt.
            var controller = new TimelogTypesController();

            // Act: Die GetTimelogType-Methode wird mit einer ungültigen ID aufgerufen.
            var result = controller.GetTimelogType(9999); // 999 annehmen, dass diese ID nicht existiert

            // Assert: Überprüfe, ob das Ergebnis ein NotFoundResult ist.
            Assert.IsType<NotFoundResult>(result.Result);
        }

        
    }
}
