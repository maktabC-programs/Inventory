namespace CW10B.Logger;

public interface ILogger
{
   public void LogWarning(string message);
   public void Log(string message);
   public void LogError(string message);

}