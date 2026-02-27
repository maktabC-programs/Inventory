namespace CW10B.Logger;
public class FileLogger : ILogger
{
    public static readonly string LogPath = "Logs.txt";
    public void LogWarning(string message)
    {
        Log(" Warning: " + message+"\n");
    }

    public void Log(string message)
    {
        if (File.Exists(LogPath))
        {
            File.AppendAllText(LogPath, message);
            return;
        }
        File.WriteAllText(LogPath, message);
        
    }

    public void LogError(string message)
    {
        Log("Error: " +message+ "\n");
    }
}