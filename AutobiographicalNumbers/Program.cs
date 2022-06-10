namespace AutobiographicalNumbers;

public class NumberGenerator {
    private bool CheckAutobiographical (int num) {
        var numAsCharArray = num
            .ToString()
            .ToCharArray();
        
        //digit, number of occurences
        var theoryMap = CreateTheoryMap(numAsCharArray);
        var actualMap = CreateActualMap(numAsCharArray);

        return false;
    }

    private Dictionary<int, int> CreateTheoryMap(char[] numAsCharArray) {
        var theoryMap = new Dictionary<int, int>();
        var digit = 0;
        
        foreach (var ch in numAsCharArray) {
            var occurrences = int.Parse(ch.ToString());
            theoryMap.Add(digit, occurrences);
            digit++;
        }

        return theoryMap;
    }

    private Dictionary<int, int> CreateActualMap(char[] numAsCharArray) {
        var actualMap = new Dictionary<int, int>();

        foreach (var ch in numAsCharArray) {
            var digit = int.Parse(ch.ToString());
            if (!actualMap.ContainsKey(digit)) {
                actualMap.Add(digit, 1);
                continue;
            }

            actualMap[digit] += 1;
        }
        
        return actualMap;
    }

}