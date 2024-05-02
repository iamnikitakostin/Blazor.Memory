namespace Kmakai.MemoryGame.Client.Models;

public class Timer : ITimer
{
    private System.Threading.Timer? GameTimer;
    public int Interval = 1000;
    public DateTime StartTime;
    public DateTime StopTime;
    public TimeSpan ElapsedTime;
    public TimerCallback Callback;

    public Timer(TimerCallback callback)
    {
        Callback = callback;
    }

    public void start()
    {
        StartTime = DateTime.Now;
        GameTimer = new System.Threading.Timer(Callback, null, 0, Interval);
    }

    public void stop()
    {
        StopTime = DateTime.Now;
        GameTimer!.Dispose();
        ElapsedTime = StopTime - StartTime;
    }

}
