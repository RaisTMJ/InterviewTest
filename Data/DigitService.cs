

using DefaultNamespace;

public class DigitService: IDigitService
{
    readonly DigitModule _digitModule = new DigitModule();


    public async Task<DigitChartModel> GetRangeOfOccurrence(string lowest, string highest)
    {
        var result =  await _digitModule.GetOccurenceNumberRange(Int32.Parse(lowest), int.Parse(highest));
        return result;
    
    }

    public async Task<int> GetReferenceNumber(string sequenceNumber)
    {
       var result =  await _digitModule.GetOccurenceNumberSingleNumber(sequenceNumber);
       return result;

    }
}