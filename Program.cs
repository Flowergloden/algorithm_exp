// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
const int inf = 0x3f3f3f;

var graph = new[]
{
    new[] { 0, 4, inf, 5, inf },
    new[] { inf, 0, 1, inf, 6 },
    new[] { 2, inf, 0, 3, inf },
    new[] { inf, inf, 1, 0, 2 },
    new[] { 1, inf, inf, 4, 0 },
};

Console.WriteLine(Solution.Floyd(graph)
    .Aggregate("", (sumLine, curLine) => sumLine + "\n" + curLine
        .Aggregate("", (sum, cur) => sum + "|" + (cur == inf ? "INF" : cur + "  ")) + "|"
    ));

public static class Solution
{
    public static int[][] Floyd(int[][] graph)
    {
        var distance = graph;
        graph.CopyTo(distance, 0);

        for (int k = 0; k < graph.Length; k++)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    distance[i][j] = int.Min(distance[i][j], distance[i][k] + distance[k][j]);
                }
            }
        }

        return distance;
    }
}