using System;
using log4net;
using Moq;
using NUnit.Framework;
using RiverFlowCalculator.Calculators;
using RiverFlowCalculator.Interfaces;

namespace RiverFlowCalculatorTests
{
	[TestFixture]
	public class MethodFactoryTests
	{
		private readonly ILog _loggerMock = Mock.Of<ILog>();
		private readonly ISettings _settingsMock = Mock.Of<ISettings>();

		[SetUp]
		public void Setup()
		{
			Mock.Get(_settingsMock).SetupGet(x => x.AllowErrors).Returns(1);
			Mock.Get(_settingsMock).SetupGet(x => x.AlarmFlooding).Returns(true);
		}

		[TestCase("River", typeof(DividedCrossSectionMethod))]
		[TestCase("SquareCanal", typeof(SquareCanalMethod))]
		[TestCase("RoundCanal", typeof(RoundCanalMethod))]
		[TestCase("TrapezoidCanal", typeof(TrapezoidCanalMethod))]
		public void MethodFactoryShouldReturnCorrectMethodInstance(string flowType, Type methodType)
		{
			var factory = new MethodFactory(_loggerMock);
			IDischargeCalculator method = factory.SelectCalculator(flowType, _settingsMock);

			Assert.AreEqual(methodType, method.GetType());
		}

		[TestCase("Pipe")]
		[TestCase("")]
		[TestCase(null)]
		public void MethodFactoryShouldThrowExceptionIfUnsupportedFlowType(string flowType)
		{
			var factory = new MethodFactory(_loggerMock);
			Assert.Throws<Exception>(() =>
			{
				factory.SelectCalculator(flowType, _settingsMock);
			});

			Mock.Get(_loggerMock).Verify(x => x.Error(It.IsAny<string>()), Times.Once);
			Mock.Get(_loggerMock).Invocations.Clear();
		}
	}
}
