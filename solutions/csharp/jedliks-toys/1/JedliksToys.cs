class RemoteControlCar
{
    private int _battery = 100;
    private int _meters = 0;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_meters} meters";

    public string BatteryDisplay() => _battery == 0 ? $"Battery empty" : $"Battery at {_battery}%";

    public void Drive()
    {
        if (_battery == 0) return;
        _meters += 20;
        _battery -= 1;
    }
}
