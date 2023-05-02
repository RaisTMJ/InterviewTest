using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class SortingAlgorithmModule: ISortingAlgorithmProcedure
{



    public static char[] OrderByAlgorithmTest(char[] input, int ordering)
    {
       
        List<int>  indexSelected  = new List<int>();
        ordering -= 1;
        int currentIndex = 0;
        var indexNewChar = new List<int>();
        var itemAvailable = Enumerable.Range(0, input.Length).ToList();

        while (indexNewChar.Count< input.Length)
        {
                itemAvailable = itemAvailable.Where(val => !indexNewChar.Contains(val)).ToList();
                if (itemAvailable.Count > (currentIndex + ordering))
                {
                    currentIndex += ordering;
                    indexNewChar.Add(itemAvailable.ElementAt(currentIndex));
                    continue;
                }
                if (currentIndex >= itemAvailable.Count)
                {
                    currentIndex -= itemAvailable.Count;
                    continue;
                }
                var coeficient = 0;
                while (ordering  >= ((itemAvailable.Count- currentIndex)+ (coeficient* itemAvailable.Count)) && ordering>= itemAvailable.Count)
                {
                    coeficient++;
                }
                var cf = coeficient >= 1 ? (coeficient - 1 ) : 0;
                currentIndex = ordering - (itemAvailable.Count - currentIndex) -  cf* itemAvailable.Count;
                    indexNewChar.Add(itemAvailable.ElementAt(currentIndex));
        }
        return indexNewChar.Select(val => input[val]).ToArray();
        
        # region exampple of correct result
        // rotation of 7
        // 0123456789
        // 6 012345789
// 63 01245789
// 631 0245789
// 6310 245789
// 63102 45789
// 631025 4789
// 6310259 478

        
        #endregion
    }


    public string GetSortingAlgorithmSequence(SortingAlgorithmModel model)
    {
        throw new NotImplementedException();
    }

    public string GetSortingAlgorithmSequenceWithDash(SortingAlgorithmModel model)
    {
        throw new NotImplementedException();
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
        var selectedIndex = 0;
        var indexNewChar = new List<int>();
        var charList = model.CharString.ToCharArray().ToList();
        
        var rotatedCharListIndex = new List<int>();

        
        
        for (var i = charList.Count - 1; i >= 0; i--)
        {
            selectedIndex = i;
            
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
        rotatedCharListIndex.AddRange(indexNewChar);
        rotatedCharListIndex.AddRange(indexNewChar);
        var getlast2State = rotatedCharListIndex.GetRange(rotatedCharListIndex.Count- (2* indexNewChar.Count), 2* indexNewChar.Count);
        var aa = getlast2State.Select(x=> charList[x]).ToArray();
        var startIndex =(getlast2State.IndexOf(0)+ ordering- indexNewChar.Count+1)% indexNewChar.Count;
        var sortedValue = getlast2State.GetRange(startIndex ,indexNewChar.Count );
        return sortedValue.Select(val => charList[val]).Reverse().ToArray();
      
    }   

    
    public List<int> AddSpecificElementToList (List<int> list, int element, int positionFromLastIndex)
    {
        list.Insert(list.Count - positionFromLastIndex, element);
        return list;
    }


}

