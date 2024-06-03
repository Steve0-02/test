using OptiHeatPro;
using Xunit;

namespace OptiHeatPro.Tests
{
    public class BoilerManagerTests
    {
        [Fact]
        public void BoilerManager_ShouldInitializeBoilersList()
        {
            // Arrange & Act
            BoilerManager manager = new BoilerManager();

            // Assert
            Assert.NotNull(manager.Boilers);
            Assert.Equal(4, manager.Boilers.Count);

            Assert.Equal("GB", manager.Boilers[0].Name);
            Assert.Equal(5, manager.Boilers[0].MaxHeat);
            Assert.Equal(500, manager.Boilers[0].ProductionCosts);
            Assert.Equal(215, manager.Boilers[0].CO2Emissions);
            Assert.Equal(1.1, manager.Boilers[0].GasConsumption);

            Assert.Equal("OB", manager.Boilers[1].Name);
            Assert.Equal(4, manager.Boilers[1].MaxHeat);
            Assert.Equal(700, manager.Boilers[1].ProductionCosts);
            Assert.Equal(265, manager.Boilers[1].CO2Emissions);
            Assert.Equal(1.2, manager.Boilers[1].GasConsumption);

            Assert.Equal("GM", manager.Boilers[2].Name);
            Assert.Equal(3.6, manager.Boilers[2].MaxHeat);
            Assert.Equal(2.7, manager.Boilers[2].MaxElectricity);
            Assert.Equal(1100, manager.Boilers[2].ProductionCosts);
            Assert.Equal(640, manager.Boilers[2].CO2Emissions);
            Assert.Equal(1.9, manager.Boilers[2].GasConsumption);

            Assert.Equal("EK", manager.Boilers[3].Name);
            Assert.Equal(8, manager.Boilers[3].MaxHeat);
            Assert.Equal(-8, manager.Boilers[3].MaxElectricity);
            Assert.Equal(50, manager.Boilers[3].ProductionCosts);
            Assert.Equal(0, manager.Boilers[3].CO2Emissions);
            Assert.Equal(0, manager.Boilers[3].GasConsumption);
        }
    }
}