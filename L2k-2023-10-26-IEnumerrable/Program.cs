using System.Collections;

var odd = new Odd(1, 10);

foreach(var val in odd)
{
    Console.Write("{0} ", val);
    if ((int)val >= 5) break;
}
Console.WriteLine("Дубль 2");
foreach (var val in odd)
{
    Console.Write("{0} ", val);
}
Console.WriteLine("А теперь чётные");
var even = new Even(1, 10);
foreach (var val in even)
{
    Console.Write("{0} ", val);
    if (val >= 5) break;
}
Console.WriteLine("Чётный дубль два");
foreach (var val in even)
{
    Console.Write("{0} ", val);
}

Console.WriteLine("простые числа от 10 до 100:");
var pn = new PrimeNumbers(10, 100);
Console.WriteLine(pn.Count);
foreach (var val in pn)
{
    Console.Write("{0} ", val);
}

public class PrimeNumbers : IReadOnlyCollection<int>
{
    int _min, _max;
    List<int> _list = new List<int>();
    public PrimeNumbers(int min, int max) {
        (_min, _max) = min < max ? (min, max) : (max, min);
        FillPrimeList();
    }

    private void FillPrimeList()
    {
        for (int i = Math.Max(2, _min); i <= _max; i++)
        {
            if (IsPrime(i)) _list.Add(i);
        }
    }

    private bool IsPrime(int i)
    {
        var maxVal = Math.Sqrt(i);
        for (int d = 2; d <= maxVal; d++)
        {
            if (i % d == 0) return false;
        }
        return true;
    }

    public int Count => _list.Count;

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var i in _list)
        {
            yield return i;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Even : IEnumerable<int>
{
    int min, max;
    public Even(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<int> GetEnumerator()
    {
        var first = min + Math.Abs(min % 2);
        for (int i = first; i <= max; i += 2)
        {
            yield return i;
        }
    }
}

public class Odd : IEnumerable
{
    //private IEnumerator _oddEnumerator;
    int min;
    int max;
    public IEnumerator GetEnumerator() => new OddEnumerator(min, max);

    public Odd(int min, int max)
    {
        this.min = min; 
        this.max = max;
        //_oddEnumerator = new OddEnumerator(min, max);
    }
}

public class OddEnumerator : IEnumerator//, IDisposable
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

    //public void Dispose()
    //{
    //    Reset();
    //}
}
