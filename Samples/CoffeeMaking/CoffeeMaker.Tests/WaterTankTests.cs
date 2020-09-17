using CoffeeMaker.Components;
using FluentAssertions;
using System;
using Xunit;

namespace CoffeeMaker.Tests
{
    public class WaterTankTests
    {
        [Fact]
        public void ShouldDrainWater_ThrowsExceptionIfVolumeIsNegative()
        {
            // Arrange
            var waterTank = new WaterTank(capacity: 1000m);

            // Act
            Action action = () => waterTank.Drain(-100m);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ShouldDrainWater_ThrowsExceptionIfCurrentVolumeIsTooLow()
        {
            // Arrange
            var waterTank = new WaterTank(capacity: 1000m);

            // Act
            Action action = () => waterTank.Drain(100m);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ShouldFillWater_Success()
        {
            // Arrange
            var waterTank = new WaterTank(capacity: 1000m);

            // Act
            waterTank.Fill(300m);

            // Assert
            waterTank.CurrentVolume.Should().Be(300m);
        }

        [Fact]
        public void ShouldDrainWater_Success()
        {
            // Arrange
            var waterTank = new WaterTank(capacity: 1000m);
            waterTank.Fill(300m);

            // Act
            var drainedVolume = waterTank.Drain(100m);

            // Assert
            drainedVolume.Should().Be(100m);
            waterTank.CurrentVolume.Should().Be(200m);
        }
    }
}
