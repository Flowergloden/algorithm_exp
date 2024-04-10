// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
var items = new List<(int, int)> { (20, 10), (30, 20), (65, 30), (40, 40), (60, 50) };
var maxWeight = 100;
Console.WriteLine(Solution.Greedy(items, maxWeight));

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
}