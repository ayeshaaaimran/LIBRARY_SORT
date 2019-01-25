using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySort
{
    class LibrarySort
    {
        int[] arr1;
        int[] arr2;
        int index;
        int key;
        static void Main(string[] args)
        {
            Console.WriteLine("Library Sort:-");
            LibrarySort sort1 = new LibrarySort();
            sort1.index = sort1.BinarySearch();
            sort1.sort();
            sort1.print();

        }
        public LibrarySort() //initializes the array sizes & takes input from the user into array
        {
            int numberOfelements;
            Console.WriteLine("Enter the number of elements in array:");
            numberOfelements = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            arr1 = new int[numberOfelements];
            arr2 = new int[(numberOfelements * 2) + 1];
            Console.WriteLine("Enter sorted data:(Ascending Order)");
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public int BinarySearch() //Performs binary search on given input array
        {
            int min = 0;
            int max = arr1.Length - 1;
            Console.WriteLine("Enter the element to be inserted:");
            key = Convert.ToInt32(Console.ReadLine());
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == arr1[mid])
                {
                    return ++mid;
                }
                else if (key < arr1[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }

            }
            return 0;


        }

        public void sort() //adds the element and rebalances the array (Main algorithm)
        {
            int track = 0;
            int flag = 0;
            if (arr1.Contains(key)) //if the element to be inserted already exists in the array
            {
                Array.Resize(ref arr1, arr1.Length + 1); //resizes the array(adds one index)
                for (int i = arr1.Length - 1; i > index; i--)
                {
                    arr1[i] = arr1[i - 1]; //performs shifting to make the correct position vacant
                }
                arr1[index] = key; //adds the element to the correct position 
            }
            else //if the element to be inserted doesnot exists in the array
            {
                for (int i = 0; i < arr1.Length; i++)  //helps to find the correct position to insert the element
                {
                    if (key >= arr1[i])
                    {
                        track++;
                    }
                }
                Array.Resize(ref arr1, arr1.Length + 1); //resizes the array(adds one index)
                for (int j = arr1.Length - 1; j > track; j--)
                {
                    arr1[j] = arr1[j - 1];  //performs shifting to make the correct position vacant
                }
                arr1[track] = key; //adds the element to the correct position
            }
            for (int x = 0; x < arr1.Length; x++) //creates a gapped sorted array
            {
                arr2[flag] = arr1[x];
                flag = flag + 2;
            }


        }

        public void print() //prints the sorted array
        {
            Console.WriteLine();
            Console.WriteLine("Gapped sorted array:");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write("{0} ", arr2[i]);           //prints gapped sorted array
            }
            Console.WriteLine();
            Console.WriteLine("Sorted array without gaps:");
            for (int j = 0; j < arr1.Length; j++)
            {
                Console.Write("{0} ", arr1[j]);          //prints sorted array without gaps
            }
            Console.WriteLine();
        }
    }
}
