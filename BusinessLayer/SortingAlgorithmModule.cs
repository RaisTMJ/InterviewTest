using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class SortingAlgorithmModule
{
    public static char[] OrderByAlgorithm(char[] input, int ordering)
    {
        ordering -= 1;
        int currentIndex = 0;
        var indexNewChar = new List<int>();
        var itemAvailable = Enumerable.Range(0, input.Length).ToList();

        while (indexNewChar.Count< input.Length)
        {
         var available = itemAvailable.Except(indexNewChar).ToList();
         
         if(currentIndex ==  available.Count)
         {
             currentIndex = 0;
         }
         if(currentIndex + ordering < available.Count+1)
         {
             currentIndex = (currentIndex + ordering) % available.Count();
             indexNewChar.Add(available[currentIndex]);
             continue;
         }

         if (currentIndex + ordering >= available.Count+1)
         {
             currentIndex = (ordering - (available.Count-currentIndex))%available.Count;
             indexNewChar.Add(available[currentIndex]);
             continue;
         }
         
        }
        return indexNewChar.Select(val => input[val]).ToArray();
    }
    public char[] GetSortingAlgorithmSequenceWithDash(char [] sortedInput, int dashPosition)
    {
        var newList = new List<char>();
        var dash = '-';
        for (var i = 1; i <= sortedInput.Length; i++)
        {
            newList.Add(sortedInput[i-1]); 
            if (i%dashPosition == 0)
            {
                newList.Add(dash);
            }
        }
        return newList.ToArray();

    }

    public Char[] GetSortingAlgorithmSequenceWithInverse(SortingAlgorithmModel model)
    {
        var currentIndex = 0;
        var ordering = model.SequenceOrder - 1;
        var indexNewChar = new List<int>();
        var charList = model.CharString.ToCharArray().ToList();
        var rotatedCharListIndex = new List<int>();
        for (var i = charList.Count - 1; i >= 0; i--)
        {
            if (charList.Count - 1  ==i)
            {
                currentIndex += ordering;
                indexNewChar.Add(i);
                rotatedCharListIndex.Add(currentIndex);
                continue;
            }
            while ((currentIndex+ordering+ 1) >= rotatedCharListIndex.Count)
            {
                rotatedCharListIndex.AddRange(indexNewChar);
            }
            currentIndex += ordering;
          indexNewChar =   AddSpecificElementToList(indexNewChar, i, rotatedCharListIndex.Count - currentIndex-1);
        }
        var arrayStripe = indexNewChar.Concat(indexNewChar).Concat(indexNewChar).ToList();
        arrayStripe.Reverse();
        var index = arrayStripe.IndexOf(0);
        var adjustmentIndex = indexNewChar.Count - (ordering%indexNewChar.Count);
        var result = arrayStripe.GetRange(index + adjustmentIndex%indexNewChar.Count, indexNewChar.Count);
        return result.Select(x=> charList[x]).ToArray();

    }   
    
    private List<int> AddSpecificElementToList (List<int> list, int element, int positionFromLastIndex)
    {
        list.Insert(list.Count - positionFromLastIndex, element);
        return list;
    }


}

