namespace DefaultNamespace;

public interface ISortingAlgorithm
{
   public Task<Char []> GetRotationAlgorithmSequence(SortingAlgorithmModel model);
}

public interface ISortingAlgorithmProcedure
{
   public string GetSortingAlgorithmSequence(SortingAlgorithmModel model);
   public string GetSortingAlgorithmSequenceWithDash(SortingAlgorithmModel model);
   public string GetSortingAlgorithmSequenceWithInverse(SortingAlgorithmModel model);
   
 
 // checklist to done  

    protected char[] ExtendArray(char[] input, char[] addArray);
    
}