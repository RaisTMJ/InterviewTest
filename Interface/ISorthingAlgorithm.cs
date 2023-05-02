namespace DefaultNamespace;

public interface ISortingAlgorithm
{
   public Task<Char []> GetRotationAlgorithmSequence(SortingAlgorithmModel model);
}

public interface ISortingAlgorithmProcedure
{
   public string GetSortingAlgorithmSequence(SortingAlgorithmModel model);
   public string GetSortingAlgorithmSequenceWithDash(SortingAlgorithmModel model);
   public char[] GetSortingAlgorithmSequenceWithInverse(SortingAlgorithmModel model);
   
 
 // checklist to done  
    
}