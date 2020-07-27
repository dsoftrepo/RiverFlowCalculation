namespace RiverFlowCalculator.Interfaces
{
	public interface IDischargeCalculator
	{
		void ValidateData(CrossSectionDataModel data);
		float Calculate(CrossSectionDataModel data);
	}
}
