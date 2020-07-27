namespace RiverFlowCalculator.Interfaces
{
	public interface IRepository
	{
		void SaveReading(CrossSectionDataModel data, float result);
	}
}
