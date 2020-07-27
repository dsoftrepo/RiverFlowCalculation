using System;
using NUnit.Framework;
using RiverFlowCalculator;
using RiverFlowCalculator.Calculators;
using RiverFlowCalculatorTests.TestCases;

namespace RiverFlowCalculatorTests
{
    [TestFixture]
    public class DischargeCalculatorTests
    {
		[TestCaseSource(typeof(CrossSectionCorruptedDataTestCases))]
	    public void CalculatorValidateDataShouldThrowExceptionIfMissingData(CrossSectionDataModel data)
	    {
		    var calculator = new DividedCrossSectionMethod();
		    Assert.Throws<ArgumentException>(() =>
		    {
			    calculator.ValidateData(data);
		    });
	    }

	    [TestCaseSource(typeof(CrossSectionDataTestCases), nameof(CrossSectionDataTestCases.FloodData))]
	    public void CalculatorValidateDataShouldThrowFloodingException(CrossSectionDataModel data)
	    {
		    var calculator = new DividedCrossSectionMethod();
		    Assert.Throws<FloodingException>(() =>
		    {
			    calculator.ValidateData(data);
		    });
	    }

	    [TestCaseSource(typeof(CrossSectionDataTestCases), nameof(CrossSectionDataTestCases.MeasurementDisorder))]
	    public void CalculatorValidateDataShouldThrowExceptionIfWrongMeasurement(CrossSectionDataModel data)
	    {
		    var calculator = new DividedCrossSectionMethod();
		    var ex = Assert.Throws<Exception>(() =>
		    {
			    calculator.ValidateData(data);
		    });

		    Assert.AreEqual(ex.Message, "Measurements order disruption");
	    }

	    [TestCaseSource(typeof(CrossSectionDataTestCases), nameof(CrossSectionDataTestCases.Data))]
	    public void CalculatorShouldReturnCorrectResult(CrossSectionDataModel data, int allowedErrors, float expectedResult, float expectedAccuracy)
	    {
            var calculator = new DividedCrossSectionMethod(1, allowedErrors);

            float result = calculator.Calculate(data);

            Assert.AreEqual(expectedResult, result);
			Assert.AreEqual(expectedAccuracy, data.ReadAccuracy);
	    }
    }
}
