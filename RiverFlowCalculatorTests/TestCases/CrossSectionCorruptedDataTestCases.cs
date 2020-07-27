using System.Collections;
using RiverFlowCalculator;

namespace RiverFlowCalculatorTests.TestCases
{
	internal class CrossSectionCorruptedDataTestCases : IEnumerable
	{
		public IEnumerator GetEnumerator()
		{
			yield return CrossSectionDataTestCases.GetBase(null);
			yield return CrossSectionDataTestCases.GetBase(
				new []
				{
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0.5f, 0.25f}, OrderId = 1},
					null,
					null,
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 2, Velocity = new [] {0.5f, 0.25f}, OrderId = 4}
				});
			yield return CrossSectionDataTestCases.GetBase(
				new []
				{
					null,
					null,
					null,
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0.5f, 0.25f}, OrderId = 4}
				});
			yield return CrossSectionDataTestCases.GetBase(
				new []
				{
					null,
					null,
					null,
					(MeasurePoint)null
				});
			yield return CrossSectionDataTestCases.GetBase(new MeasurePoint[] {});
		}
	}
}