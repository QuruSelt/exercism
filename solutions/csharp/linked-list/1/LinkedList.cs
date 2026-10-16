public class Deque<T>
{
    public class Link<T> {
        public T value;
        public Link<T> next;
        public Link<T> prev;

        public Link(T val) {
            value = val;
            next = null;
            prev = null;
        }
    }

    private Link<T> _first = null;
    private Link<T> _last = null;
    
    public void Push(T value)
    {
        Link<T> newLink = new Link<T>(value);
        newLink.prev = _last;
        if (_last != null) _last.next = newLink;
        _last = newLink;
        if (_first == null) _first = newLink;
    }

    public T Pop()
    {
        Link<T> toPop = _last;
        if (toPop == null) return default!;
        _last = toPop.prev;
        toPop.prev = null;
        if (_last != null) _last.next = null;
        else _first = null;
        return toPop.value;
    }

    public void Unshift(T value)
    {
        Link<T> newLink = new Link<T>(value);
        newLink.next = _first;
        if (_first != null) _first.prev = newLink;
        _first = newLink;
        if (_last == null) _last = newLink;
    }

    public T Shift()
    {
        Link<T> toShift = _first;
        if (toShift == null) return default!;
        _first = toShift.next;
        toShift.next = null;
        if (_first != null) _first.prev = null;
        else _last = null;
        return toShift.value;
    }
}