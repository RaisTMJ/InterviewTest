using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class SortingAlgorithmModel
{
    [Required] public string CharString { get; set; }
    [Required] public int SequenceOrder { get; set; }

    [Required] public bool IncludeDash { get; set; } 
    public int DashSequence { get; set; } 
    [Required] public bool IsInverse { get; set; }
    
}

public class Test
{
    [Required] public string CharString { get; set; }
    [Required] public int SequenceOrder { get; set; }
    
    [Required] public bool IncludeDash { get; set; } 
    [Required] public bool IsInverse { get; set; }
        
}