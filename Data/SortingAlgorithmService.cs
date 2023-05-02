using DefaultNamespace;

namespace InterviewTest.Data;

public class SortingAlgorithmService: ISortingAlgorithm
{
    private SortingAlgorithmModule _sortingModule = new SortingAlgorithmModule();
    public Task<char[]> GetRotationAlgorithmSequence(SortingAlgorithmModel model)
    {
        if(!model.IsInverse)
        {
            var result = SortingAlgorithmModule.OrderByAlgorithmTest(model.CharString.ToCharArray(), model.SequenceOrder);
            if (model.IncludeDash && model.DashSequence> 0 )
            {
                result = _sortingModule.GetSortingAlgorithmSequenceWithDash(result, model.DashSequence);
            }
            return Task.FromResult(result);
        }
     
        if(model.IsInverse && !model.IncludeDash)
        {
            
          return  Task.FromResult(_sortingModule.GetSortingAlgorithmSequenceWithInverse(model));
        }
        throw new Exception("Inverse Algorithm with Dash is not implemented");
    }
    
}