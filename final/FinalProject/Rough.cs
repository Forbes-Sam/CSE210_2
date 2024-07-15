
public class Rough : Job
{
    private bool _roughDone;
    private bool _trimDone;

    public Rough()
    {
        _roughDone = false;
        _trimDone = false;
    }

    public void RoughMes()
    {}
    public void TrimMes()
    {}

    public override void DisplayJob()
    {
        base.DisplayJob();
    }
}