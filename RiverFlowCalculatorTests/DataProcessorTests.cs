using System;
using log4net;
using Moq;
using NUnit.Framework;
using RiverFlowCalculator;
using RiverFlowCalculator.Interfaces;

namespace RiverFlowCalculatorTests
{
	[TestFixture]
	public class DataProcessorTests
	{
		private readonly IDischargeCalculator _dischargeCalculator = Mock.Of<IDischargeCalculator>();
		private readonly IMethodFactory _methodFactory = Mock.Of<IMethodFactory>();
		private readonly IRepository _repository = Mock.Of<IRepository>();
		private readonly ISettings _settings = Mock.Of<ISettings>();
		private readonly ILog _logger = Mock.Of<ILog>();
		
		[SetUp]
		public void Setup()
		{
			Mock.Get(_logger).Invocations.Clear();
		}

		[Test]
		public void DataProcessorShouldSaveDataAndLogErrorIfException()
		{
			Mock.Get(_dischargeCalculator)
				.Setup(x => x.Calculate(It.IsAny<CrossSectionDataModel>()))
				.Throws<Exception>();
			Mock.Get(_methodFactory)
				.Setup(x => x.SelectCalculator(It.IsAny<string>(), It.IsAny<ISettings>()))
				.Returns(_dischargeCalculator);
			
			CrossSectionDataModel data = GetDataMock();
			GetProcessor().ProcessIncomingData(data);

			Mock.Get(_repository).Verify(x=>x.SaveReading(data, It.IsAny<float>()), Times.Once);
			Mock.Get(_logger).Verify(x=>x.Error(It.IsAny<Exception>()), Times.Once);
		}

		[Test]
		public void DataProcessorShouldSaveDataIfNoException()
		{
			Mock.Get(_dischargeCalculator)
				.Setup(x => x.Calculate(It.IsAny<CrossSectionDataModel>()))
				.Returns(1);
			Mock.Get(_methodFactory)
				.Setup(x => x.SelectCalculator(It.IsAny<string>(), It.IsAny<ISettings>()))
				.Returns(_dischargeCalculator);

			CrossSectionDataModel data = GetDataMock();
			GetProcessor().ProcessIncomingData(data);

			Mock.Get(_repository).Verify(x=>x.SaveReading(data, It.IsAny<float>()), Times.Once);
			Mock.Get(_logger).Verify(x=>x.Error(It.IsAny<Exception>()), Times.Never);
		}

		[Test]
		public void DataProcessorShouldAlarmIfSettingIsOn()
		{
			Mock.Get(_settings).SetupGet(x => x.AlarmFlooding).Returns(true);
			Mock.Get(_dischargeCalculator)
				.Setup(x => x.Calculate(It.IsAny<CrossSectionDataModel>()))
				.Throws<FloodingException>();
			Mock.Get(_methodFactory)
				.Setup(x => x.SelectCalculator(It.IsAny<string>(), It.IsAny<ISettings>()))
				.Returns(_dischargeCalculator);

			CrossSectionDataModel data = GetDataMock();
			Assert.Throws<FloodingException>(() =>
			{
				GetProcessor().ProcessIncomingData(data);
			});

			Mock.Get(_repository).Verify(x=>x.SaveReading(data, It.IsAny<float>()), Times.Once);
			Mock.Get(_logger).Verify(x=>x.Error(It.IsAny<FloodingException>()), Times.Once);
		}

		[Test]
		public void DataProcessorShouldNotAlarmIfSettingIsOffOnlyLogWarning()
		{
			Mock.Get(_settings).SetupGet(x => x.AlarmFlooding).Returns(false);
			Mock.Get(_dischargeCalculator)
				.Setup(x => x.Calculate(It.IsAny<CrossSectionDataModel>()))
				.Throws<FloodingException>();
			Mock.Get(_methodFactory)
				.Setup(x => x.SelectCalculator(It.IsAny<string>(), It.IsAny<ISettings>()))
				.Returns(_dischargeCalculator);

			CrossSectionDataModel data = GetDataMock();
			GetProcessor().ProcessIncomingData(data);

			Mock.Get(_repository).Verify(x=>x.SaveReading(data, It.IsAny<float>()), Times.Once);
			Mock.Get(_logger).Verify(x=>x.Error(It.IsAny<FloodingException>()), Times.Never);
			Mock.Get(_logger).Verify(x=>x.Warn(It.IsAny<FloodingException>()), Times.Once);
		}

		private CrossSectionDataModel GetDataMock()
		{
			return new CrossSectionDataModel
			{
				StationName = "TestStation",
				FlowType = "Type1",
				MeasureTime = new DateTime(2020, 7, 1, 6, 0, 0),
				MeasurePoints = new[]
				{
					new MeasurePoint
						{Depth = 1, DistanceFromInitialPoint = 0, Velocity = new[] {0.5f, 0.25f}, OrderId = 1},
					new MeasurePoint
						{Depth = 2, DistanceFromInitialPoint = 2, Velocity = new[] {1.12f, 0.75f}, OrderId = 2},
					new MeasurePoint
						{Depth = 1, DistanceFromInitialPoint = 4, Velocity = new[] {0.8f, 0.55f}, OrderId = 3},
				}
			};
		}

		private DataProcessor GetProcessor()
		{
			return new DataProcessor(_methodFactory, _repository, _settings, _logger);
		}
	}
}
