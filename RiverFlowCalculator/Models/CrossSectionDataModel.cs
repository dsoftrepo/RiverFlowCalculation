using System;

namespace RiverFlowCalculator
{
	public class CrossSectionDataModel
	{ 
		public string StationName { get; set; }
		public string FlowType { get; set; }
		public DateTime MeasureTime { get; set; }
		public MeasurePoint[] MeasurePoints { get; set; }
		public float ReadAccuracy { get; set; }
	}
}
