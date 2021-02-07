namespace HassesWebshopCRM.API.Common
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogWarn(string message);
    }
}