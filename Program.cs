// See https://aka.ms/new-console-template for more information

const int inf = int.MaxValue;

Console.WriteLine("Hello, World!");
var graph = new int[][]
{
    new[] { 0, 1, inf },
    new[] { inf, 0, 1 },
    new[] { -1, -1, 0 },
};
Console.WriteLine(Solution.BellmanFord(graph, 0).Aggregate(((n, current) => n + "," + current)));

public static class Solution
{
    public static List<string>
        BellmanFord(int[][] graph, int source) // [from][to] && index from 0 && int.MaxValue is infinity
    {
        var res = new List<int>();
        for (int i = 0; i < graph.Length; i++)
        {
            res.Add(i == source ? 0 : int.MaxValue);
        }

        for (int i = 0; i < graph.Length - 1; i++)
        {
            InnerRelax(graph, source, res);
        }

        FinalRelax(graph, source, res);

        return res.Select(x =>
                x switch
                {
                    int.MaxValue => "Single point",
                    int.MaxValue - 1 => "negative weight cycle",
                    _ => x.ToString()
                })
            .ToList();

        void InnerRelax(int[][] ints, int source1, List<int> list)
        {
            for (int j = 0; j < ints.Length; j++)
            {
                if (j == source1) continue;
                var cache = list[j];
                list[j] = ints.Select((from, index) =>
                {
                    if (from[j] == int.MaxValue)
                    {
                        return int.MaxValue;
                    }

                    return from[j] + list[index];
                }).Min();
            }
        }

        void FinalRelax(int[][] ints, int source1, List<int> list)
        {
            var cycles = new List<int>();
            for (int j = 0; j < ints.Length; j++)
            {
                if (j == source1) continue;
                var cache = list[j];
                list[j] = ints.Select((from, index) =>
                {
                    if (from[j] == int.MaxValue)
                    {
                        return int.MaxValue;
                    }

                    return from[j] + list[index];
                }).Min();
                if (list[j] != cache)
                {
                    cycles.Add(j);
                }
            }

            foreach (var index in cycles)
            {
                list[index] = int.MaxValue - 1;
            }
        }
    }
}