using System;
using log4net;
using RiverFlowCalculator.Interfaces;

namespace RiverFlowCalculator.Calculators
{
	public class MethodFactory : IMethodFactory
	{
		private readonly ILog _logger;

		public MethodFactory(ILog logger)
		{
			_logger = logger;
		}

		public IDischargeCalculator SelectCalculator(string flowType, ISettings settings)
		{
			switch (flowType)
			{
				case "River" : return new DividedCrossSectionMethod(settings.RiverBankFlowFactor, settings.AllowErrors);
				case "SquareCanal" : return new SquareCanalMethod();
				case "RoundCanal": return new RoundCanalMethod();
				case "TrapezoidCanal": return new TrapezoidCanalMethod();
				default:
				{
					string msg = $"Unsupported method {flowType}";
					_logger.Error(msg);
					throw new Exception(msg);
				}
			}
		}
	}
}
