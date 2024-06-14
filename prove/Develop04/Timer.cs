using System.Timers;

// timer is only used once and that is in the reflect
// activity since i had to have a timer running in the 
// background

// I also used gemini to help generate this code
// since i had no clue how to do this

public class BackgroundCountdown
{
    private int _targetTimeInSeconds;
    private bool _isRunning;
    private System.Timers.Timer _timer;

    public BackgroundCountdown(int targetTimeInSeconds)
    {
        _targetTimeInSeconds = targetTimeInSeconds;
        _isRunning = false;
        _timer = new System.Timers.Timer(1000); // Set interval to 1 second
        _timer.Elapsed += OnTimerElapsed;
    }

    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _timer.Start();
        }
    }

    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (_targetTimeInSeconds > 0)
        {
            _targetTimeInSeconds--;
        }
        else
        {
            _timer.Stop();
            _isRunning = false;

            
        }
    }

    public bool Running()
    {
        return _isRunning;
    }
}
