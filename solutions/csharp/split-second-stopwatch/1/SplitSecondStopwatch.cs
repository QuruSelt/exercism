public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{    
    private TimeProvider _time = time;
    private long _startTimeStamp = time.GetTimestamp();
    private long _stopTimeStamp = time.GetTimestamp();
    
    private long _lapStartTimeStamp = time.GetTimestamp();
    private long _lapStopTimeStamp = time.GetTimestamp();

    private TimeSpan _lapStopTime = new TimeSpan(0, 0, 0);
    private TimeSpan _stopTime = new TimeSpan(0, 0, 0);

    private List<TimeSpan> _previousLaps = new List<TimeSpan>();
    
    public StopwatchState State { get; set; } = StopwatchState.Ready;
    public TimeSpan CurrentLap { get
        {
            if (State != StopwatchState.Stopped) {
                return _time.GetElapsedTime(_lapStartTimeStamp) - _lapStopTime;
            }
            return _time.GetElapsedTime(_lapStartTimeStamp) - _lapStopTime.Add(_time.GetElapsedTime(_lapStopTimeStamp));
        }
                               }
    public TimeSpan Total { get
        {
            if (State != StopwatchState.Stopped) {
                return _time.GetElapsedTime(_startTimeStamp) - _stopTime;
            }
            return _time.GetElapsedTime(_startTimeStamp) - _stopTime.Add(_time.GetElapsedTime(_stopTimeStamp));
        }
                               }
    public IReadOnlyCollection<TimeSpan> PreviousLaps { get
        {
            return _previousLaps;
        }
                                                      }
    
    public void Start()
    { 
        if (State == StopwatchState.Ready) {
            _lapStartTimeStamp = time.GetTimestamp();
            State = StopwatchState.Running;
        }
        else if (State == StopwatchState.Stopped) {
            _stopTime = _stopTime.Add(_time.GetElapsedTime(_stopTimeStamp));
            _lapStopTime = _lapStopTime.Add(_time.GetElapsedTime(_lapStopTimeStamp));
            State = StopwatchState.Running;
        }
        else if (State == StopwatchState.Running) throw new InvalidOperationException();
    }

    public void Stop()
    {
        if (State == StopwatchState.Ready) throw new InvalidOperationException();
        else if (State == StopwatchState.Stopped) throw new InvalidOperationException();
        else if (State == StopwatchState.Running) {
            _stopTimeStamp = time.GetTimestamp();
            _lapStopTimeStamp = time.GetTimestamp();
            State = StopwatchState.Stopped;
        }
    }

    public void Reset()
    {
        if (State == StopwatchState.Ready) throw new InvalidOperationException();
        else if (State == StopwatchState.Stopped) {
            _previousLaps = new List<TimeSpan>();
            
            _startTimeStamp = time.GetTimestamp();
            _stopTimeStamp = time.GetTimestamp();
            _lapStartTimeStamp = time.GetTimestamp();
            _lapStopTimeStamp = time.GetTimestamp();
            _lapStopTime = new TimeSpan(0, 0, 0);
            _stopTime = new TimeSpan(0, 0, 0);
            
            State = StopwatchState.Ready;
        }
        else if (State == StopwatchState.Running) throw new InvalidOperationException();
    }

    public void Lap()
    {
        if (State == StopwatchState.Ready) throw new InvalidOperationException();
        else if (State == StopwatchState.Stopped) throw new InvalidOperationException();
        else if (State == StopwatchState.Running){
            _previousLaps.Add(CurrentLap);
            
            _lapStartTimeStamp = time.GetTimestamp();
            _lapStopTimeStamp = time.GetTimestamp();
            _lapStopTime = new TimeSpan(0, 0, 0);
        }
    }
}
