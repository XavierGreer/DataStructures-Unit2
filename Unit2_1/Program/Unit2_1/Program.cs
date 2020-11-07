using System;

namespace Unit2_1
{
    //Method for creating a 1,000 number array
    static class GenNum
    {
        static Random rand = new Random();

        public static int[] NumArr()
        {
            int[] arr = new int[1000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
            }

            return arr;
        }

        public static void PrintArr(int[] arr)
        {
            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }

    }

    class Program
    {
        //Partition algorithm method
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

        static void Main(string[] args)
        {
            int x = GenNum.NumArr().Length;

            //Console.WriteLine(GenNum.NewNum);
            GenNum.PrintArr(Quick(GenNum.NumArr(), 0, x - 1));
        }
    }
}
