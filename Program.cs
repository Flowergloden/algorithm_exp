// See https://aka.ms/new-console-template for more information

var list = new List<int>() { 7, 10, 66, 65535, -65535, 18 };
var queue = new PQueue<int>(((lhs, rhs) => lhs - rhs), list);
queue.Enqueue(-1);
var tmp = queue.Dequeue();

class PQueue<T>
{
    private readonly Func<T, T, int>? _comparison;
    private readonly List<T> _list;
    private readonly bool _bDefaultComparison;
    public int Count => _list.Count;

    public PQueue(Func<T, T, int> comparison, List<T> list)
    {
        _comparison = comparison;
        _list = list;
        _bDefaultComparison = false;
        _list.Sort(Compare);
    }

    public PQueue(List<T> list)
    {
        _list = list;
        _bDefaultComparison = true;
        _list.Sort();
    }

    public PQueue()
    {
        _list = new();
        _bDefaultComparison = true;
        _list.Sort();
    }

    public void Enqueue(T item)
    {
        _list.Add(item);
        if (_bDefaultComparison)
        {
            _list.Sort();
            return;
        }

        _list.Sort(Compare);
    }

    public T Dequeue()
    {
        var tmp = _list[0];
        _list.RemoveAt(0);
        return tmp;
    }

    private int Compare(T a, T b)
    {
        return _comparison(a, b);
    }
}