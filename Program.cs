// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
var sol = new Sol();
var lhs = new List<int> { 1, 3, 5, 7, 9 };
var rhs = new List<int> { 2, 4, 6, 8, 10 };
var nth = 5;
var result = sol.Solve(lhs, rhs, nth);
Console.WriteLine(result);

public class Sol
{
    public T Solve<T>(IList<T> lhs, IList<T> rhs, int nth) // nth is the ACTUAL index
        where T : IComparable<T>
    {
        if (lhs.Count == 0)
        {
            return rhs[nth];
        }

        if (rhs.Count == 0)
        {
            return lhs[nth];
        }

        var lhsMid = lhs.Count / 2;
        var rhsMid = rhs.Count / 2;

        if (lhsMid + rhsMid < nth)
        {
            if (lhs[lhsMid].CompareTo(rhs[rhsMid]) < 0)
            {
                return Solve(lhs.Skip(lhsMid + 1).ToList(), rhs, nth - lhsMid - 1);
            }
            else
            {
                return Solve(lhs, rhs.Skip(rhsMid + 1).ToList(), nth - rhsMid - 1);
            }
        }
        else
        {
            if (lhs[lhsMid].CompareTo(rhs[rhsMid]) < 0)
            {
                return Solve(lhs, rhs.Take(rhsMid).ToList(), nth);
            }
            else
            {
                return Solve(lhs.Take(lhsMid).ToList(), rhs, nth);
            }
        }
    }
}