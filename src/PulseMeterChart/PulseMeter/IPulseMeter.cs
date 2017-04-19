using System;

namespace PulseMeterChart.PulseMeter
{
    public interface IPulseMeter
    {
        event EventHandler<IPulseInfo> OnInfoReceived;
    }
}
