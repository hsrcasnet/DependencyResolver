using System;
using Xunit;
using CoffeeMaker;
using Moq;
using CoffeeMaker.Abstractions;
using System.Threading.Tasks;
using FluentAssertions;

namespace CoffeeMaker.Tests
{
    public class CoffeeMachineTests
    {
        [Fact]
        public async Task ShouldGetEspresso()
        {
            // Arrange
            var grinderMock = new Mock<IGrinder>();
            var heaterMock = new Mock<IHeater>();
            var tankMock = new Mock<ITank>();

            var pumpMock = new Mock<IPump>();
            pumpMock.Setup(p => p.Pump(It.IsAny<ITank>(), It.IsAny<IHeater>(), It.IsAny<TimeSpan>()))
                .ReturnsAsync(100m);

            var coffeeMachine = new CoffeeMachine(grinderMock.Object, heaterMock.Object, pumpMock.Object, tankMock.Object);

            // Act
            var espresso = await coffeeMachine.GetEspresso();

            // Assert
            espresso.Should().NotBeNull();
            espresso.Volume.Should().Be(100m);
        }
    }
}
