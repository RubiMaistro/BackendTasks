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
    }
}