
/// <summary>
/// Use this interface to implement console actions
/// </summary>
public interface IGenericConsoleHid
{
    /// <summary>
    /// Used when a button is pressed down and released
    /// </summary>
    void ButtonDown();
    /// <summary>
    /// Used when a toggle button is pressed down
    /// </summary>
    void ButtonToggledDown();
    /// <summary>
    /// Used when a toggle button is released
    /// </summary>
    void ButtonToggledUp();
    /// <summary>
    /// Used when a button press is completed and button rises up
    /// </summary>
    void ButtonUp();
    /// <summary>
    /// Used when a jack is plugged into a socket
    /// </summary>
    void JackPluggedIn();
    /// <summary>
    /// Used when a jack is disconnected from a socket
    /// </summary>
    void JackPluggedOut();
    /// <summary>
    /// Used when slider (linear slider potentiometer) value is changed.
    /// </summary>
    void SliderValueChange(float valueDelta);
}
