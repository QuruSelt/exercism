public class Robot
{
    private string _name = null;

    private static ReadOnlySpan<char> Letters => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static ReadOnlySpan<char> Digits => "0123456789";
    private static HashSet<string> _uniqueNames = new HashSet<string>();
    
    private string GenerateRandomName => $"{new Random().GetString(Letters, 2)}{new Random().GetString(Digits, 3)}";
    
    public string Name
    {
        get
        {
            if (_name == null) {
                _name = GenerateRandomName;
                while (!_uniqueNames.Add(_name)) _name = GenerateRandomName;
            }
            return _name;
        }
    }

    public void Reset() {
        _uniqueNames.Remove(_name);
        _name = null;
    }
}