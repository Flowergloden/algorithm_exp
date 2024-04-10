// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public static class Solution
{
    public static List<string> BellmanFord(List<List<(int, int)>> graph, int source) // (to, weight) && index from 0
    {
        var res = new List<int>();
        for (int i = 0; i < graph.Count; i++)
        {
            res.Add(i == source ? 0 : int.MaxValue);
        }



        return res.Select(x =>
                x switch
                {
                    int.MaxValue => "Single point",
                    int.MaxValue - 1 => "negative weight cycle",
                    _ => x.ToString()
                })
            .ToList();
    }

}