using System;

namespace Program
{
    //Class created for holding random number generator methods
    static class GenNum
    {
        public static Random rand = new Random();

        public static int[] NumArr()
        {
            int[] arr = new int[1000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(750);
            }

            return arr;
        }

        //Print array
        public static void PrintArr(int[] arr)
        {
            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }

    }

    class Program
    {
        //Partition array
        static int Part(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = (low - 1);
            for (int x = low; x < high; x++)
            {
                if (arr[x] < pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[x];
                    arr[x] = temp;
                }

            }

            int temper = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temper;

            return i + 1;

        }

        //Quick sort algorithm method
        static int[] Quick(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int Partin = Part(arr, low, high);
                Quick(arr, low, Partin - 1);
                Quick(arr, Partin + 1, high);
            }

            return arr;
        }

        //Recursive Binary Search algorithm
        static int BinarySearch(int[] arr, int i, int y, int x)
        {
            if (y >= i)
            {
                int mid = i + (y - i) / 2;

                if (arr[mid] == x)return mid;
                    
                if (arr[mid] > x) return BinarySearch(arr, i, mid - 1, x);

                return BinarySearch(arr, mid + 1, y, x);
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int SearchedValue = GenNum.rand.Next(750);

            int[] array = GenNum.NumArr();
            array = Quick(array, 0, array.Length - 1);

            //Print sorted array
            GenNum.PrintArr(array);
            Console.WriteLine("Searching for: " + SearchedValue);

            //Run BinarySearch method to find the random Value we are searching for
            if (BinarySearch(array, 0, array.Length, SearchedValue) == -1) {  Console.WriteLine("Not Found"); }

            else { Console.WriteLine("Element Found!"); }
        }
    }
}
