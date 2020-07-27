namespace RiverFlowCalculator.Interfaces
{
	public interface IMethodFactory
	{
		IDischargeCalculator SelectCalculator(string flowType, ISettings settings);
	}
}