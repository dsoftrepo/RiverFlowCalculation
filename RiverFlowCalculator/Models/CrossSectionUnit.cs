namespace RiverFlowCalculator
{
	public class MeasurePoint
	{
		public int OrderId { get; set; }
		public float Depth { get; set; }
		public float DistanceFromInitialPoint { get; set; }
		public float[] Velocity { get; set; }
	}
}
