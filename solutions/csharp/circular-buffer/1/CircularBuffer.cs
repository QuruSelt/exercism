public class CircularBuffer<T>
{
    private static int _oldest;
    public static int _next;
    private static int _capacity;
    private static bool _full;
    private T[] _buffer;
    
    public CircularBuffer(int capacity)
    {
        if (capacity < 1) throw new ArgumentOutOfRangeException();
        _oldest = 0;
        _next = 0;
        _full = false;
        _capacity = capacity;
        _buffer = new T[_capacity];
    }

    public T Read()
    {
        if (!_full && _oldest == _next) throw new InvalidOperationException();
        T res = _buffer[_oldest++];
        _oldest %= _capacity;
        _full = false;
        return res;
    }

    public void Write(T value)
    {
        if (_full) throw new InvalidOperationException();
        _buffer[_next++] = value;
        _next %= _capacity;
        _full = _oldest == _next;
    }

    public void Overwrite(T value)
    {
        _buffer[_next] = value;
        if (_next == _oldest) _oldest = (_oldest + 1) % _capacity;
        _next = (_next + 1) % _capacity;
        _full = _oldest == _next;
    }

    public void Clear()
    {
        _oldest = 0;
        _next = 0;
        _full = false;
        _buffer = new T[_capacity];
    }
}