// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var jobs = new List<(string, int)>
{
    ("A", 3),
    ("B", 1),
    ("C", 2),
    ("D", 4)
};
Console.WriteLine(Solution.Schedule(jobs).Aggregate(((res, current) => res + "," + current)));

public static class Solution
{
    public static List<string> Schedule(List<(string, int)> jobs)
    {
        jobs.Sort(((lhs, rhs) => lhs.Item2 - rhs.Item2));
        return jobs.Select(x => x.Item1).ToList();
    }
}