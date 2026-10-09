class RemoteControlCar
{
    public int speed;
    public int distanceDriven;
    public int batteryDrain;
    public int battery;
    
    public RemoteControlCar(int speed, int batteryDrain) {
        this.speed = speed;
        this.distanceDriven = 0;
        this.batteryDrain = batteryDrain;
        this.battery = 100;
    }
    
    public bool BatteryDrained() => battery < batteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {
        if (BatteryDrained()) return;
        distanceDriven += speed;
        battery -= batteryDrain;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    public int distance;
    public RaceTrack(int distance) {
        this.distance = distance;
    }
    

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < distance && !car.BatteryDrained()) {
            car.Drive();
        }

        return car.DistanceDriven() >= distance;
    }
}
