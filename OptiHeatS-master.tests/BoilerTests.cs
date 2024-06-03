using OptiHeatPro;
using Xunit;

namespace OptiHeatPro.Tests
{
    public class BoilerTests
    {

        [Fact]
        public void Boiler_Constructor1_ShouldInitializeProperties()
        {
            // Arrange
            string name = "TestBoiler";
            double maxHeat = 5.0;
            decimal productionCosts = 500m;
            double co2Emissions = 215.0;
            double gasConsumption = 1.1;

            // Act
            Boiler boiler = new Boiler(name, maxHeat, productionCosts, co2Emissions, gasConsumption);

            // Assert
            Assert.Equal(name, boiler.Name);
            Assert.Equal(maxHeat, boiler.MaxHeat);
            Assert.Null(boiler.MaxElectricity);
            Assert.Equal(productionCosts, boiler.ProductionCosts);
            Assert.Equal(co2Emissions, boiler.CO2Emissions);
            Assert.Equal(gasConsumption, boiler.GasConsumption);
        }

        [Fact]
        public void Boiler_Constructor2_ShouldInitializeProperties()
        {
            // Arrange
            string name = "TestBoiler";
            double maxHeat = 5.0;
            double maxElectricity = 2.0;
            decimal productionCosts = 500m;
            double co2Emissions = 215.0;
            double gasConsumption = 1.1;

            // Act
            Boiler boiler = new Boiler(name, maxHeat, maxElectricity, productionCosts, co2Emissions, gasConsumption);

            // Assert
            Assert.Equal(name, boiler.Name);
            Assert.Equal(maxHeat, boiler.MaxHeat);
            Assert.Equal(maxElectricity, boiler.MaxElectricity);
            Assert.Equal(productionCosts, boiler.ProductionCosts);
            Assert.Equal(co2Emissions, boiler.CO2Emissions);
            Assert.Equal(gasConsumption, boiler.GasConsumption);
        }

        [Fact]
        public void Boiler_Constructor3_ShouldInitializeProperties()
        {
            // Arrange
            string name = "TestBoiler";
            double maxHeat = 5.0;
            double maxElectricity = 2.0;
            decimal productionCosts = 500m;

            // Act
            Boiler boiler = new Boiler(name, maxHeat, maxElectricity, productionCosts);

            // Assert
            Assert.Equal(name, boiler.Name);
            Assert.Equal(maxHeat, boiler.MaxHeat);
            Assert.Equal(maxElectricity, boiler.MaxElectricity);
            Assert.Equal(productionCosts, boiler.ProductionCosts);
            Assert.Equal(0, boiler.CO2Emissions);
            Assert.Equal(0, boiler.GasConsumption);
        }
    }
}
