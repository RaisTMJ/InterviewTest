namespace DefaultNamespace;


public interface  IDigitService
{
    public Task<DigitChartModel> GetRangeOfOccurrence(string lowest, string highest);
    public Task<int> GetReferenceNumber(string sequenceNumber );
}

