// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
var items = new List<(int, int)> { (10, 1), (15, 2), (40, 3) };
var maxWeight = 5;
Console.WriteLine(Solution.Greedy(items, maxWeight));
Console.WriteLine(Solution.DynamicProgramming(items, maxWeight));

public static class Solution
{
    public static double Greedy(List<(int, int)> items, int maxWeight) // (value, weight)
    {
        items.Sort((a, b) => (double)b.Item1 / b.Item2 - (double)a.Item1 / a.Item2 < 0 ? -1 : 1);
        double res = 0;
        double weight = 0;
        foreach (var item in items)
        {
            weight += item.Item2;

            if (weight > maxWeight)
            {
                weight -= item.Item2;
                res += (maxWeight - weight) * item.Item1 / item.Item2;
                break;
            }

            res += item.Item1;
        }

        return res;
    }

    public static int DynamicProgramming(List<(int, int)> items, int maxWeight) // (value, weight)
    {
        var dp = new List<List<int>>();
        for (int i = 0; i <= items.Count; i++)
        {
            var lst = new List<int>();
            for (int j = 0; j <= maxWeight; j++)
            {
                lst.Add(0);
            }

            dp.Add(lst);
        }

        for (int i = 1; i < dp.Count; i++)
        {
            for (int j = dp[i].Count - 1; j > i; j--)
            {
                if (items[i - 1].Item2 > j)
                {
                    dp[i][j] = dp[i - 1][j];
                    continue;
                }

                dp[i][j] = int.Max(dp[i - 1][j], dp[i - 1][j - items[i - 1].Item2] + items[i - 1].Item1);
            }
        }

        var res = dp.Select(x => x.Max()).Max();

        return res;
    }
}