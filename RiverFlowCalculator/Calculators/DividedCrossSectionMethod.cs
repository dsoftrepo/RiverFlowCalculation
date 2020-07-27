using System;
using System.Collections.Generic;
using System.Linq;
using RiverFlowCalculator.Interfaces;

namespace RiverFlowCalculator.Calculators
{
    public class DividedCrossSectionMethod : IDischargeCalculator
    {
	    private readonly float _riverBankFlowFactor;
	    private readonly int _allowedErrors;

	    public DividedCrossSectionMethod(float riverBankFlowFactor = 1f, int allowedErrors = 0)
	    {
		    _riverBankFlowFactor = riverBankFlowFactor;
		    _allowedErrors = allowedErrors;
	    }

	    public void ValidateData(CrossSectionDataModel data)
	    {
			if(data?.MeasurePoints == null) 
				throw new ArgumentException("Missing data", nameof(MeasurePoint));

		    data.MeasurePoints = data.MeasurePoints
			    .Where(x => x != null)
			    .OrderBy(x => x.OrderId).ToArray();

		    if(data.MeasurePoints.Length < 3) 
			    throw new ArgumentException("Missing data", nameof(MeasurePoint));

		    MeasurePoint last = data.MeasurePoints.Last();
			MeasurePoint first = data.MeasurePoints.First();
		    IEnumerable<MeasurePoint> failedMeasures = data.MeasurePoints
			    .Where(x=>x.OrderId > first.OrderId && x.OrderId < last.OrderId && (Math.Abs(x.Velocity.Average()) < 0.0001 || Math.Abs(x.DistanceFromInitialPoint) < 0.0001)).ToArray();

		    data.MeasurePoints = data.MeasurePoints.Except(failedMeasures).ToArray();

		    if (first.Depth > 0 || last.Depth > 0) 
			    throw new FloodingException("Flooding alarm");

		    if(failedMeasures.Count() > _allowedErrors) 
			    throw new ArgumentException("Incomplete data", nameof(MeasurePoint));

		    float lastDistance = -1;
		    foreach (MeasurePoint measurePoint in data.MeasurePoints)
		    {
			    if (measurePoint.DistanceFromInitialPoint <= lastDistance)
					throw new Exception("Measurements order disruption");
			    lastDistance = measurePoint.DistanceFromInitialPoint;
		    }

		    data.ReadAccuracy = failedMeasures.Any() 
			    ? 100 - failedMeasures.Count() / (float) data.MeasurePoints.Length * 100
			    : 100;
	    }

	    public float Calculate(CrossSectionDataModel data)
	    {
			ValidateData(data);
			
			MeasurePoint second  = data.MeasurePoints[1];
			float startSection = second.Depth * second.DistanceFromInitialPoint / 8 * (second.Velocity.Average() * _riverBankFlowFactor);

			MeasurePoint beforeLast = data.MeasurePoints[data.MeasurePoints.Length-1];
			float endSection = beforeLast.Depth * (data.MeasurePoints.Last().DistanceFromInitialPoint - beforeLast.DistanceFromInitialPoint) / 8 * (beforeLast.Velocity.Average() * _riverBankFlowFactor);

			float discharge = startSection + endSection;
		    
		    for (var i = 1; i < data.MeasurePoints.Length-1; i++)
		    {
				MeasurePoint previous = data.MeasurePoints[i - 1];
				MeasurePoint next = data.MeasurePoints[i + 1];
			    
				float sectionWidth = next.DistanceFromInitialPoint - previous.DistanceFromInitialPoint;
			    float sectionArea = sectionWidth / 2 * data.MeasurePoints[i].Depth;
			    float sectionDischarge = data.MeasurePoints[i].Velocity.Average() * sectionArea;
			    discharge += sectionDischarge;
		    }

		    return discharge;
	    }
    }
}
