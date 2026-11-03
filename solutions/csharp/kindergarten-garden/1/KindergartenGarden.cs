public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{    
    private Plant[][] _childrenPlants = new Plant[12][];

    private Plant GetPlant(char c) => c switch {
            'G' => Plant.Grass,
            'C' => Plant.Clover,
            'R' => Plant.Radishes,
            _ => Plant.Violets,
    };
    
    public KindergartenGarden(string diagram)
    {
        string[] lines = diagram.Split('\n');
        for (int i = 0; i < lines[0].Length; i += 2) {
            _childrenPlants[i/2] = new Plant[4];
            _childrenPlants[i/2][0] = GetPlant(lines[0][i]);
            _childrenPlants[i/2][1] = GetPlant(lines[0][i+1]);
        }
        for (int i = 0; i < lines[1].Length; i += 2) {
            _childrenPlants[i/2][2] = GetPlant(lines[1][i]);
            _childrenPlants[i/2][3] = GetPlant(lines[1][i+1]);
        }
    }

    public IEnumerable<Plant> Plants(string student) => _childrenPlants[student[0] - 'A'];
}