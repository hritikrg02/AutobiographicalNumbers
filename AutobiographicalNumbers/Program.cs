namespace AutobiographicalNumbers;

public static class NumberGenerator {
    private static bool IsAutobiographical (this long num) {
        var numAsCharArray = num
            .ToString()
            .ToCharArray();
        
        //digit, number of occurences
        var theoryMap = CreateTheoryMap(numAsCharArray);
        var actualMap = CreateActualMap(numAsCharArray);

        return DictionaryIsEqual(theoryMap, actualMap);
    }

    private static Dictionary<int, int> CreateTheoryMap(char[] numAsCharArray) {
        var theoryMap = new Dictionary<int, int>();
        var digit = 0;
        
        foreach (var ch in numAsCharArray) {
            var occurrences = int.Parse(ch.ToString());
            theoryMap.Add(digit, occurrences);
            digit++;
        }

        return theoryMap;
    }
    
    
    private static Dictionary<int, int> CreateActualMap(char[] numAsCharArray) {
        var actualMap = new Dictionary<int, int>();

        for (var i = 0; i < numAsCharArray.Length; i++) {
            actualMap.Add(i, 0);
        }

        foreach (var ch in numAsCharArray) {
            try {
                var digit = int.Parse(ch.ToString());
                actualMap[digit] += 1;
            } catch (KeyNotFoundException) {
                return actualMap;
            }
        }
        
        return actualMap;
    }

    private static bool DictionaryIsEqual(Dictionary<int, int> d1, Dictionary<int, int> d2) {
        if (d1.Count != d2.Count) {
            return false;
        }

        foreach (var (key1, value1) in d1) {
            if (!d2.TryGetValue(key1, out var value2)) { // key is not present
                return false;
            }

            if (value2 != value1) {
                return false;
            }
        }

        return true;
    }

    public static void Main(string[] args) {
        var upper = long.Parse(args[0]);

        for (long i = 0; i <= upper; i++) {
            if (i.IsAutobiographical()) {
                Console.WriteLine(i);
            }
        }
    }
}