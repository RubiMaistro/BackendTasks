using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendTasks.Pages
{
    public class IndexModel : PageModel
    {
        public int[] Array { get; set; } = { 3, 2, 1, 2, 2, 2, 3 };
        public int Number { get; set; } 

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var sortedArray = IntArrayQuickSort(Array);
            Number = GetNumber(Array);
            
        }

        public static int GetNumber(int[] array)
        {
            int index = 0;

            while (index < array.Length && array[index] < 1)
                index++;

            int expected = 1;

            while (index < array.Length)
            {
                if (array[index] > expected)
                    return expected;
                while (index < array.Length && array[index] == expected)
                    index++;
                expected++;
            }

            return expected;
        }

        public static int[] IntArrayQuickSort(int[] data, int l, int r)
        {
            int i, j;
            int x;

            i = l;
            j = r;

            x = data[(l + r) / 2]; /* find pivot item */
            while (true)
            {
                if (i < 0)
                    break;
                while (data[i] < x)
                    i++;
                while (x < data[j])
                    j--;
                if (i <= j)
                {
                    exchange(data, i, j);
                    i++;
                    j--;
                }
                if (i > j)
                    break;
            }
            if (l < j)
                IntArrayQuickSort(data, l, j);
            if (i < r)
                IntArrayQuickSort(data, i, r);

            return data;
        }

        public static int[] IntArrayQuickSort(int[] data)
        {
            return IntArrayQuickSort(data, 0, data.Length - 1);
        }

        public static void exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }

        // Week of Days

        private int daysCount = 7;
        private string[] days = new string[]
            { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        public string WeekOfDay(string S, int K)
        {
            int index = getIndex(S, days);

            int indexForSPlusK = (index + K) % daysCount;

            return days[indexForSPlusK];
        }

        private int getIndex(string S, string[] days)
        {
            for (int i = 0, c = days.Length; i < c; ++i)
            {
                if (days[i] == (S))
                {
                    return i;
                }
            }
            return 0;
        }

        // Minimum deletion cost avoid repeating letters
        public int GetTotalCost(string S, int[] C)
        {
            var characters = S.ToCharArray();
            var firstLetter = characters[0];

            int totalCost = 0;
            int maxCost = C[0];
            int currentTotalCost = C[0];

            for (int i = 1; i < S.Length; i++)
            {
                var c = characters[i];
                int currentCost = C[i];
                if (c == firstLetter)
                {
                    maxCost = maxCost > currentCost ? maxCost : currentCost;
                    currentTotalCost += currentCost;
                }
                else
                {
                    totalCost += currentTotalCost - maxCost;
                    firstLetter = c;
                    maxCost = currentCost;
                    currentTotalCost = currentCost;
                }
            }
            totalCost += currentTotalCost - maxCost;
            return totalCost;
        }

        // Resolve the riddle
        public string GetResolveRiddle(string riddle)
        {
            string result = "";

            char prev = '\0';
            for (int i = 0; i < riddle.Length; i++)
            {
                char current = riddle[i];
                if (current == '?')
                {
                    char next = '\0';
                    if (i != riddle.Length - 1)
                    {
                        next = riddle[i + 1];
                    }
                    current = GetCurrectChar(prev, next);
                }
                result += current;
                prev = current;
            }
            return result;
        }

        private char GetCurrectChar(char prev, char next)
        {
            var characters = "abcdefghijklmnopqrstuvz".ToCharArray();
            var rand = new Random();

            while (true)
            {
                var randomIndex = rand.Next(characters.Length);
                if (prev != characters[randomIndex] && next != characters[randomIndex])
                    return characters[randomIndex];
            }
        }
    }
}