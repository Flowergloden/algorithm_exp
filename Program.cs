// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
var sol = new Sol();
var lhs = new List<int> { 1, 3, 5, 7, 9 };
var rhs = new List<int> { 2, 4, 6, 8, 10 };
var nth = 5;
var result = sol.Solve(lhs, rhs, 5);

public class Sol
{
    public T Solve<T>(IList<T> lhs, IList<T> rhs, int nth, int leftIndex = 0, int rightIndex = 0)
        where T : IComparable<T>
    {
        if (leftIndex == 0 && rightIndex == 0)
        {
            leftIndex = lhs.Count;
            rightIndex = rhs.Count;
        }

        if (leftIndex + rightIndex + 2 == nth)
            return lhs[leftIndex].CompareTo(rhs[rightIndex]) >= 0 ? lhs[leftIndex] : rhs[rightIndex];

        if (leftIndex + rightIndex + 2 > nth)
        {
            leftIndex /= 2;
            rightIndex /= 2;
            return Solve(lhs, rhs, leftIndex, rightIndex, nth);
        }

        if (leftIndex + rightIndex < nth)
        {
            leftIndex += leftIndex / 2;
            rightIndex += rightIndex / 2;
            return Solve(lhs, rhs, leftIndex, rightIndex, nth);
        }
        // TODO: find proper way to divide

        throw new Exception("error");
    }
}