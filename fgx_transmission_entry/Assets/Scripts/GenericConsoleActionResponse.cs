
/// <summary>
/// Generic interface for implementing action responses
/// </summary>
public interface IGenericConsoleActionResponse
{
    /// <summary>
    /// Implement this to execute wanted action.
    /// </summary>
    void DoAction();
    /// <summary>
    /// Implement this to send a signal informing action's failier
    /// </summary>
    void SignalError();
    /// <summary>
    /// Implement this to send a signal informing action's success
    /// </summary>
    void SignalSuccess();
}
