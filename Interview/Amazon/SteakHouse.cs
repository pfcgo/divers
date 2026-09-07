using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED

    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable {

        public int Compare(TKey x, TKey y) {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return result;
        }
    }

    public struct Point {
        public readonly int Item1;
        public readonly int Item2;

        public Point(int item1, int item2) {
            Item1 = item1;
            Item2 = item2;
        }

        // Squared Distance
        public int Distance2() {
            return Item1 * Item1 + Item2 * Item2;
        }
    }

    public List<List<int>> nearestXsteakHouses(int totalSteakhouses,
                                               int[,] allLocations,
                                               int numSteakhouses) {

        var sortedList = new SortedList<int, Point>(new DuplicateKeyComparer<int>());
        for (int i = 0; i < totalSteakhouses; ++i) {
            var p = new Point(allLocations[i,0], allLocations[i,1]);
            var d = p.Distance2();
            sortedList.Add(d, p);
        }

        var res = new List<List<int>>();

        for(int i = 0; i < numSteakhouses; ++i) {
            var p = sortedList.Values[i];
            res.Add(new List<int>() { p.Item1, p.Item2});
        }

        return res;
    }
    // METHOD SIGNATURE ENDS
}