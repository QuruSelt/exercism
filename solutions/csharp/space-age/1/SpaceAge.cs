public class SpaceAge
{
    private double _earthYearInSeconds = 31557600.0;
    private double _age;

    private double _mercuryOrbitalYear     =  0.2408467;
    private double _venusOrbitalYear       =  0.61519726;
    private double _earthOrbitalYear       =  1.0;
    private double _marsOrbitalYear        =  1.8808158;
    private double _jupiterOrbitalYear     =  11.862615;
    private double _staurnOrbitalYear      =  29.447498;
    private double _uranusOrbitalYear      =  84.016846;
    private double _neptuneOrbitalYear     =  164.79132;
    
    public SpaceAge(int seconds)
    {
        _age = (double) seconds;
    }

    public double OnEarth() => _age / (_earthYearInSeconds * _earthOrbitalYear);

    public double OnMercury() => _age / (_earthYearInSeconds * _mercuryOrbitalYear);

    public double OnVenus() => _age / (_earthYearInSeconds * _venusOrbitalYear);

    public double OnMars() => _age / (_earthYearInSeconds * _marsOrbitalYear);

    public double OnJupiter() => _age / (_earthYearInSeconds * _jupiterOrbitalYear);

    public double OnSaturn() => _age / (_earthYearInSeconds * _staurnOrbitalYear);

    public double OnUranus() => _age / (_earthYearInSeconds * _uranusOrbitalYear);

    public double OnNeptune() => _age / (_earthYearInSeconds * _neptuneOrbitalYear);
}