namespace DefaultNamespace;

public class DigitModule
{
    private readonly List<int> _sequenceCoeficient = new List<int> {10, 8, 6, 4, 2};
    private readonly List<string> _alphabet = new List<string> {"A","B","C", "D", "E"};

    public Task<int> GetOccurenceNumberSingleNumber(string sequenceNumber)
    {
        Dictionary<string, List<int>> summarize = InitializeDictionary();
       var seq =  sequenceNumber.ToCharArray().Select(x => Int32.Parse(x.ToString())).ToList();

       for (int i = 0; i < seq.Count; i++)
       {
             var result = seq[i] * _sequenceCoeficient[i%5];
              summarize[_alphabet[i%5]].Add(result);             
       }

       var sum =  summarize.Sum(x => x.Value.Sum());
       return Task.FromResult(ReduceToSingleDigit(sum.ToString()));
    }

    public async Task<DigitChartModel> GetOccurenceNumberRange(int lowestSeq, int higherSeq)
    {
        var result = new List<int>();

        for (int i = lowestSeq ; i <higherSeq +1; i++)
        {
          result.Add(await GetOccurenceNumberSingleNumber(i.ToString())); 
        }

        return ConvertResultOccurenceToTableFormat(result) ;
    }

    private DigitChartModel ConvertResultOccurenceToTableFormat(List<int> result)
    {
        var label = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        var process = new DigitChartModel
        {
            Label = label.Select(x=> x.ToString()).ToList(),
            Data = new List<int>()
        };

            foreach (var item in label)
        {
            var count = result.Count(x => x == item); 
            process.Data.Add(count);
        }
        
        
        return process;
    }

    private int ReduceToSingleDigit(string seq)
    {
         var newValue = seq.Select(x=> Int32.Parse(x.ToString())).Sum();
         if (newValue > 9)
         {
            return ReduceToSingleDigit(newValue.ToString());
         }

         return newValue;
    }

    private Dictionary<string, List<int>> InitializeDictionary()
    {
        Dictionary<string, List<int>> summarize = new Dictionary<string, List<int>>();
        foreach (var item in _alphabet)
        {
            summarize.Add(item, new List<int>());
        }
        return summarize;
    }
}