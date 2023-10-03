public class Task
{
    public string description;
    public string taskDetail;
    public int points;
    // public float timeRemaining;

    public Task(string desc, string detail, int pts)
    {
        description = desc;
        taskDetail = detail;
        points = pts;
        // timeRemaining = taskDuration;
    }
}
