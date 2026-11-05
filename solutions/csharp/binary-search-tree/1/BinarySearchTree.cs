using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private int _val;
    private BinarySearchTree? _left;
    private BinarySearchTree? _right;
    
    public BinarySearchTree(int value)
    {
        _val = value;
        _left = null;
        _right = null;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        _val = values.First();
        _left = null;
        _right = null;
        foreach (int v in values.Skip(1)) {
            Add(v);
        }
    }

    public int Value
    {
        get { return _val; }
    }

    public BinarySearchTree? Left
    {
        get { return _left; }
    }

    public BinarySearchTree? Right
    {
        get { return _right; }
    }

    private List<int> Values(BinarySearchTree tree) {
        if (tree == null) return new List<int>();
        return Values(tree._left).Concat(new List<int>{tree._val}).Concat(Values(tree._right)).ToList();
    }

    public BinarySearchTree Add(int value)
    {
        if (value > _val) {
            if (_right == null) _right = new BinarySearchTree(value);
            else _right = _right.Add(value);
        } else {
            if (_left == null) _left = new BinarySearchTree(value);
            else _left = _left.Add(value);
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator() {
        return Values(this).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}