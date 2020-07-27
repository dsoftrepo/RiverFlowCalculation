using System;
using RiverFlowCalculator;

namespace RiverFlowCalculatorTests.TestCases
{
	internal class CrossSectionDataTestCases
	{
		public static object[] MeasurementDisorder =
		{
			new object[]
			{
				GetBase(new []
				{
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0.5f, 0.25f}, OrderId = 1},
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 1, Velocity = new [] {1.12f, 0.75f}, OrderId = 2},
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 1, Velocity = new [] {0.8f, 0.55f}, OrderId = 3},
					new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 1, Velocity = new [] {0.7f, 0.45f}, OrderId = 4},
				})
			}
		};

		public static object[] FloodData =
		{
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 0, Velocity = new [] {0.5f, 0.25f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {1.12f, 0.75f}, OrderId = 2},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 2, Velocity = new [] {0.8f, 0.55f}, OrderId = 3},
					})
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {1.12f, 0.75f}, OrderId = 2},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 4, Velocity = new [] {0.8f, 0.55f}, OrderId = 3},
					})
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 0, Velocity = new [] {0.5f, 0.25f}, OrderId = 1},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {1.12f, 0.75f}, OrderId = 2},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 4, Velocity = new [] {0.8f, 0.55f}, OrderId = 3},
					})
			}
		};

		public static object[] Data =
		{
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {1.5f, 1.25f}, OrderId = 2},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {2.5f, 2.0f}, OrderId = 3},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 3, Velocity = new [] {1.5f, 1.0f}, OrderId = 4},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 4, Velocity = new [] {0f}, OrderId = 5}
					}),
				0,
				7.296875f,
				100
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {0.5f, 0.25f}, OrderId = 2},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {0.8f, 0.45f, 0.12f}, OrderId = 3},
						new MeasurePoint{Depth = 3.2f, DistanceFromInitialPoint = 3, Velocity = new [] {0.9f, 0.55f, 0.22f}, OrderId = 4},
						new MeasurePoint{Depth = 2.6f, DistanceFromInitialPoint = 5, Velocity = new [] {1.1f, 0.85f, 0.45f}, OrderId = 5},
						new MeasurePoint{Depth = 1.5f, DistanceFromInitialPoint = 6, Velocity = new [] {0.9f, 0.45f, 0.12f}, OrderId = 6},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 7, Velocity = new [] {0f}, OrderId = 7}
					}),
				0,
				7.86220884f,
				100
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {0.9f, 0.55f, 0.22f}, OrderId = 2},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 3},
						new MeasurePoint{Depth = 3.2f, DistanceFromInitialPoint = 3, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 4},
						new MeasurePoint{Depth = 2.6f, DistanceFromInitialPoint = 5, Velocity = new [] {1.6f, 1.25f, 0.82f}, OrderId = 5},
						new MeasurePoint{Depth = 1.5f, DistanceFromInitialPoint = 6, Velocity = new [] {1.9f, 1.75f, 1.42f}, OrderId = 6},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 7, Velocity = new [] {2.3f, 2.05f, 1.42f}, OrderId = 7},
						new MeasurePoint{Depth = 0.9f, DistanceFromInitialPoint = 8, Velocity = new [] {1.7f, 1.05f, 0.42f}, OrderId = 8},
						new MeasurePoint{Depth = 0.9f, DistanceFromInitialPoint = 9, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 9},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 10, Velocity = new [] {0f}, OrderId = 10},
					}),
				0,
				16.8895836f,
				100
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {0.9f, 0.55f, 0.22f}, OrderId = 2},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 3},
						new MeasurePoint{Depth = 3.2f, DistanceFromInitialPoint = 3, Velocity = new [] {0f, 0f, 0f}, OrderId = 4},
						null,
						new MeasurePoint{Depth = 1.5f, DistanceFromInitialPoint = 6, Velocity = new [] {1.9f, 1.75f, 1.42f}, OrderId = 6},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 7, Velocity = new [] {2.3f, 2.05f, 1.42f}, OrderId = 7},
						new MeasurePoint{Depth = 0.9f, DistanceFromInitialPoint = 8, Velocity = new [] {1.7f, 1.05f, 0.42f}, OrderId = 8},
						new MeasurePoint{Depth = 0.9f, DistanceFromInitialPoint = 9, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 9},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 10, Velocity = new [] {0f}, OrderId = 10}
					}),
				1,
				14.4990835f,
				87.5f
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {0.9f, 0.55f, 0.22f}, OrderId = 2},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 3},
						new MeasurePoint{Depth = 3.2f, DistanceFromInitialPoint = 3, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 4},
						new MeasurePoint{Depth = 2.6f, DistanceFromInitialPoint = 5, Velocity = new [] {1.6f, 1.25f, 0.82f}, OrderId = 5},
						new MeasurePoint{Depth = 1.5f, DistanceFromInitialPoint = 6, Velocity = new [] {0f, 0f, 0f}, OrderId = 6},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 7, Velocity = new [] {2.3f, 2.05f, 1.42f}, OrderId = 7},
						new MeasurePoint{Depth = 0.9f, DistanceFromInitialPoint = 8, Velocity = new [] {1.7f, 1.05f, 0.42f}, OrderId = 8},
						new MeasurePoint{Depth = 0.9f, DistanceFromInitialPoint = 9, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 9},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 10, Velocity = new [] {0f}, OrderId = 10}
					}),
				1,
				16.9065838f,
				88.8888855f
			},
			new object[]
			{
				GetBase(
					new []
					{
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 4, Velocity = new [] {0f}, OrderId = 5},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 1, Velocity = new [] {0.8f, 0.5f, 0.2f}, OrderId = 2},
						new MeasurePoint{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new [] {1.2f, 0.75f, 0.42f}, OrderId = 3},
						new MeasurePoint{Depth = 0, DistanceFromInitialPoint = 0, Velocity = new [] {0f}, OrderId = 1},
						new MeasurePoint{Depth = 1, DistanceFromInitialPoint = 3, Velocity = new [] {0.9f, 0.55f, 0.32f}, OrderId = 4}
					}),
				0,
				2.73249984f,
				100
			}
		};

		internal static CrossSectionDataModel GetBase(MeasurePoint[] measurePoints)
		{
			return new CrossSectionDataModel
			{
				StationName = "TestStation",
				FlowType = "Type1",
				MeasureTime = new DateTime(2020, 7, 1, 6, 0, 0),
				MeasurePoints = measurePoints
			};
		}
	}
}


