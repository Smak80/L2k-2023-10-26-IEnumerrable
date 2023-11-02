using System.Collections;

var odd = new Odd(1, 10);

foreach(var val in odd)
{
    Console.Write("{0} ", val);
}

public class Odd : IEnumerable
{
    private IEnumerator _oddEnumerator;
    public IEnumerator GetEnumerator() => _oddEnumerator;

    public Odd(int min, int max)
    {
        _oddEnumerator = new OddEnumerator(min, max);
    }
}

public class OddEnumerator : IEnumerator
{
    private int _min;
    private int _max;
    private int _current;
    public object Current => _current;

    public OddEnumerator(int min, int max)
    {
        (_min, _max) = min < max ? (min, max) : (max, min);
        Reset();
    }

    public bool MoveNext()
    {
        _current += 2;
        return _current <= _max;
    }

    public void Reset()
    {
        _current = _min - Math.Abs(_min % 2) - 1;
    }
}
