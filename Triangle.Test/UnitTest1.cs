using Microsoft.AspNetCore.Mvc;
using Moq;
using Triangle.Domain.Dto;
using Triangle.Domain.Services.Interfaces;
using Triangle.Api.Controllers;

namespace Triangle.Api.Tests
{
    public class TriangleControllerTests
    {
        [Fact]
        public void GetStyle_ReturnsOk_WhenValidTriangle()
        {
            // Arrange
            var triangleServiceMock = new Mock<ITriangleService>();
            triangleServiceMock.Setup(x => x.GetStyle(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns("OK");

            var controller = new TriangleController(triangleServiceMock.Object);

            var validTriangle = new TriangleDto
            {
                FirstSide = 3.0,
                SecondSide = 3.0,
                ThirdSide = 3.0
            };

            // Act
            var result = controller.GetStyle(validTriangle);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetStyle_ReturnsBadRequest_WhenInvalidTriangle()
        {
            // Arrange
            var triangleServiceMock = new Mock<ITriangleService>();
            triangleServiceMock.Setup(x => x.GetStyle(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Throws<ArgumentException>();

            var controller = new TriangleController(triangleServiceMock.Object);

            var invalidTriangle = new TriangleDto
            {
                FirstSide = 1.0,
                SecondSide = 2.0,
                ThirdSide = 3.0
            };

            // Act
            var result = controller.GetStyle(invalidTriangle);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Validate_Equilateral_Style()
        {
            // Arrange
            var triangleServiceMock = new Mock<ITriangleService>();
            triangleServiceMock.Setup(x => x.GetStyle(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns("Equilateral");

            var controller = new TriangleController(triangleServiceMock.Object);

            var validTriangle = new TriangleDto
            {
                FirstSide = 5.0,
                SecondSide = 5.0,
                ThirdSide = 5.0
            };

            // Act
            var result = controller.GetStyle(validTriangle);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Validate_Isosceles_Style()
        {
            // Arrange
            var triangleServiceMock = new Mock<ITriangleService>();
            triangleServiceMock.Setup(x => x.GetStyle(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns("Isosceles");

            var controller = new TriangleController(triangleServiceMock.Object);

            var validTriangle = new TriangleDto
            {
                FirstSide = 3.0,
                SecondSide = 4.0,
                ThirdSide = 4.0
            };

            // Act
            var result = controller.GetStyle(validTriangle);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Validate_RightAngled_Style()
        {
            // Arrange
            var triangleServiceMock = new Mock<ITriangleService>();
            triangleServiceMock.Setup(x => x.GetStyle(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns("Right-angled");

            var controller = new TriangleController(triangleServiceMock.Object);

            var validTriangle = new TriangleDto
            {
                FirstSide = 3.0,
                SecondSide = 4.0,
                ThirdSide = 5.0
            };

            // Act
            var result = controller.GetStyle(validTriangle);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
