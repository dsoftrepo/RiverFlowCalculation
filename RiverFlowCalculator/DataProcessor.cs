using System;
using log4net;
using RiverFlowCalculator.Interfaces;

namespace RiverFlowCalculator
{
	public class DataProcessor : IFlowDataProcessor
	{
		private readonly IMethodFactory _methodFactory;
		private readonly IRepository _repository;
		private readonly ISettings _settings;
		private readonly ILog _logger;

		public DataProcessor(
			IMethodFactory methodFactory,
			IRepository repository,
			ISettings settings,
			ILog logger)
		{
			_methodFactory = methodFactory;
			_repository = repository;
			_settings = settings;
			_logger = logger;
		}

		public void ProcessIncomingData(CrossSectionDataModel data)
		{
			if(data == null) return;

			var result = 0f;
			try
			{
				IDischargeCalculator method = _methodFactory.SelectCalculator(data.FlowType, _settings);
				result = method.Calculate(data);
			}
			catch (FloodingException ex)
			{
				if (_settings.AlarmFlooding)
				{
					_logger.Error(ex);
					throw;
				}
				_logger.Warn(ex);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
			}
			finally
			{
				_repository.SaveReading(data, result);
			}
		}
	}
}
