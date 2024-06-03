using OptiHeatPro;
using System;
using System.Collections.Generic;
using Xunit;

namespace OptiHeatPro.Tests
{
    public class OptimizerTests
    {
        // Existing test method
        [Fact]
        public void Optimize_ShouldReturnResultsList()
        {
            // Arrange
            Optimizer optimizer = new Optimizer();
            List<DataEntry> heatingData = new List<DataEntry>
            {
                new DataEntry
                {
                    HeatDemand = 5,
                    ElectricityPrice = 1000
                }
            };
            double co2ReductionPercentage = 0.1; // Example CO2 reduction percentage

            // Act
            List<Result> results = optimizer.Optimize(heatingData, co2ReductionPercentage);

            // Assert
            Assert.NotNull(results);
            // Add more assertions as needed
        }

        [Fact]
        public void Optimize_WithNoHeatingData_ShouldReturnEmptyResultsList()
        {
            // Arrange
            Optimizer optimizer = new Optimizer();
            List<DataEntry> heatingData = new List<DataEntry>();
            double co2ReductionPercentage = 0.1; // Example CO2 reduction percentage

            // Act
            List<Result> results = optimizer.Optimize(heatingData, co2ReductionPercentage);

            // Assert
            Assert.Empty(results);
        }

        [Fact]
        public void Optimize_WithHighCO2ReductionPercentage_ShouldReturnResultsWithReducedCO2Emissions()
        {
            // Arrange
            Optimizer optimizer = new Optimizer();
            List<DataEntry> heatingData = new List<DataEntry>
            {
                new DataEntry
                {
                    HeatDemand = 5,
                    ElectricityPrice = 1000
                }
            };
            double originalCO2ReductionPercentage = 0.1; // Original CO2 reduction percentage
            double highCO2ReductionPercentage = 0.5; // High CO2 reduction percentage

            // Act
            List<Result> originalResults = optimizer.Optimize(heatingData, originalCO2ReductionPercentage);
            List<Result> highCO2ReductionResults = optimizer.Optimize(heatingData, highCO2ReductionPercentage);

            // Assert
            // Calculate the total CO2 emissions before and after optimization
            double originalTotalCO2Emissions = originalResults.Sum(r => r.TotalCO2Emissions);
            double highCO2ReductionTotalCO2Emissions = highCO2ReductionResults.Sum(r => r.TotalCO2Emissions);
            
            // Assert that the total CO2 emissions are reduced with high CO2 reduction percentage
            Assert.True(highCO2ReductionTotalCO2Emissions < originalTotalCO2Emissions);
        }

        [Fact]
        public void Optimize_WithHighHeatDemand_ShouldAllocateHeatFromAllBoilers()
        {
            // Arrange
            Optimizer optimizer = new Optimizer();
            List<DataEntry> heatingData = new List<DataEntry>
            {
                // Add sample data entries here
                new DataEntry
                {
                    HeatDemand = 10,
                    ElectricityPrice = 1000
                }

            };
            double co2ReductionPercentage = 0.1; // Example CO2 reduction percentage

            // Act
            List<Result> results = optimizer.Optimize(heatingData, co2ReductionPercentage);

            // Assert
            // Calculate the total heat demand from the data
            double totalHeatDemand = heatingData[0].HeatDemand;

            // Calculate the total heat output from all boilers in the results
            double totalBoilerOutput = 0;
            foreach (var result in results)
            {
                totalBoilerOutput += result.GasBoilerOutput + result.OilBoilerOutput + result.GasMotorOutput + result.ElectricBoilerOutput;
            }

            // Assert that the total boiler output matches the total heat demand
            Assert.Equal(totalHeatDemand, totalBoilerOutput);
        }
    }
}

