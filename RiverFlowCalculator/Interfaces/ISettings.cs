namespace RiverFlowCalculator.Interfaces
{
	public interface ISettings
	{
		float RiverBankFlowFactor { get; }
		int AllowErrors { get; }
		bool AlarmFlooding { get; }
	}
}
