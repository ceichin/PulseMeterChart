namespace PulseMeterChart.PulseMeter
{
    /// <summary>
    /// Represents the info of the pulsemeter in a certain moment
    /// </summary>
    public interface IPulseInfo
    {
        bool IsFingerIn { get; set; }
        bool IsBeating { get; set; }
        int PulseRate { get; set; }
        int PulseWaveForm { get; set; }
    }
}
