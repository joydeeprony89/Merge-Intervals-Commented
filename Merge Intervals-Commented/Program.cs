using System;
using System.Collections.Generic;

namespace Merge_Intervals_Commented
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }

  public class Solution
  {
    public int[][] Merge(int[][] intervals)
    {
      if (intervals.Length == 1) return intervals;
      // Need to sort because interval with a less start time can appear later in the input Example -[[1,4],[0,0]]
      // So Sort the input on start time
      Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
      List<int[]> result = new List<int[]>();
      // Push the first item to start the iteration
      result.Add(intervals[0]);
      for (int i = 1; i < intervals.Length; i++)
      {
        var next = intervals[i];
        var nextStart = next[0];
        var nextEnd = next[1];

        var previous = result[result.Count - 1];
        int start = previous[0];
        int end = previous[1];

        if (end < nextStart)
        {
          // if no overlapped then add the current interval
          result.Add(intervals[i]);
        }
        else
        {
          // overlapped found,so Merge.
          // remove the last added interval as it is now merged and no more valid
          result.RemoveAt(result.Count - 1);
          start = Math.Min(start, nextStart);
          end = Math.Max(end, nextEnd);
          result.Add(new int[] { start, end });
        }
      }

      return result.ToArray();
    }
  }
}
