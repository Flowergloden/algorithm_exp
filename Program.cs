// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
new PQueue<int>(((x, y) => x - y), new List<int>() { 6, 4, 8, 7, 9 });

class PQueue<T>
{
    private readonly Func<T, T, int> _comparison;
    private List<T> _list;

    public PQueue(Func<T, T, int> comparison, List<T> list)
    {
        this._comparison = comparison;
        this._list = list;
        _list.Sort(Compare);
    }

    private int Compare(T a, T b)
    {
        return _comparison(a, b);
    }
}