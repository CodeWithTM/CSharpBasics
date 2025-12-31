using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAlgos
{
    internal class Algo
    {

        // Binary Search Algorithm

        public class BinSearch
        {
            public int Search(int[] arr, int target)
            {
                int left = 0;
                int right = arr.Length - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    // Check if target is present at mid
                    if (arr[mid] == target)
                        return mid;

                    // If target is greater, ignore left half
                    if (arr[mid] < target)
                        left = mid + 1;
                    // If target is smaller, ignore right half
                    else
                        right = mid - 1;
                }

                // Target was not found in the array
                return -1;
            }
        }

        // List down any other algorithms
        // Sorting Algorithms
        // Searching Algorithms

    }
}
