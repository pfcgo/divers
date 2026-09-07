using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution {
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
    public List<List<int>> optimalUtilization(int deviceCapacity,
                                             List<List<int>> foregroundAppList,
                                             List<List<int>> backgroundAppList) {
        var fDic = new Dictionary<int, List<int>>(); // size/foreground id
        //var bDic = new Dictionary<int, int>(); // size/background id

        foreach(var app in foregroundAppList) {
            int size = app[1];
            if (!fDic.ContainsKey(size)) {
                fDic[size] = new List<int>();
            }
            fDic[size].Add(app[0]);
        }

        int max = -1;
        var res = new List<List<int>>();

        foreach(var app in backgroundAppList) {
            int bSize = app[1];
            for(int wantedFSize = deviceCapacity - bSize; wantedFSize >= 0; wantedFSize--) {
                int totalSize = wantedFSize + bSize;
                if (totalSize < max)
                    break;

                if (fDic.ContainsKey(wantedFSize)) {
                    if(totalSize > max) {
                        max = totalSize;
                        res.Clear();
                    }
                    res.Add()
                }
            }
        }
    }
    // METHOD SIGNATURE ENDS
}






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