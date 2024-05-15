using Xunit;
using Moq;
using Assessment.Controllers;
using Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
    }
}
