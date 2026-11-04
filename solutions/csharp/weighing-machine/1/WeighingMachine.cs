class WeighingMachine
{
    private int _precision;
    private double _weight;
    private double _tareAdjustment;
    
    public int Precision {
        get { return _precision; }
    }
    public double TareAdjustment{ 
        get { return _tareAdjustment; }
        set { _tareAdjustment = value; }
    }
    public double Weight { 
        get { return _weight; }
        set {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }
    public string DisplayWeight {
        get {
            double dw = _weight - _tareAdjustment;
            return $"{$"{dw.ToString($"F{_precision}")}"} kg";
        }
    }

    public WeighingMachine(int precision) {
        _precision = precision;
        _tareAdjustment = 5.0;
    }
}
