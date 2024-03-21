// See https://aka.ms/new-console-template for more information

using System.Collections;


var sol = new Sol();
var res = sol.QuickSort(new List<int>() { 5, 7, 1, 67, 65535, -1 });

Console.WriteLine("Hello, World!");
public class Sol
{
    public IList<T> QuickSort<T>(IList<T> list)
        where T : IComparable<T>
    {
        if (list.Count is 1 or 0)
        {
            return list;
        }

        var pivotIndex = new Random().Next(list.Count);
        var pivot = list[pivotIndex];


        var left = new List<T>();
        var right = new List<T>();

        foreach (var item in list)
        {
            if (item.CompareTo(pivot) <= 0)
            {
                left.Add(item);
            }
            else
            {
                right.Add(item);
            }
        }

        var ans = QuickSort<T>(left);
        foreach (var item in QuickSort<T>(right))
        {
            ans.Add(item);
        }

        return ans;
    }
}