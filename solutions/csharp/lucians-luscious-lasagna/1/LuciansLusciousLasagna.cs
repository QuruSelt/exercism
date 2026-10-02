class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40;

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int ElapsedOvenTime) => ExpectedMinutesInOven() - ElapsedOvenTime;

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int Layers) => 2 * Layers;

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int Layers, int ElapsedOvenTime) => PreparationTimeInMinutes(Layers) + ElapsedOvenTime;
}
