namespace PulseMeterChart.PulseMeter.CMS50DPlus
{
    public class PulseNotification : IPulseInfo
    {
        public bool IsFingerIn { get; set; }
        public bool IsBeating { get; set; }
        public int PulseRate { get; set; }
        public int PulseWaveForm { get; set; }

        public PulseNotification(byte[] packet)
        {
            IsFingerIn = CMS50DPlus.GetIntFromByte(packet[2], 4, 4) == 0;
            IsBeating = CMS50DPlus.GetIntFromByte(packet[0], 6, 6) == 1;
            PulseRate = CMS50DPlus.GetIntFromByte(packet[3], 0, 6);
            PulseWaveForm = CMS50DPlus.GetIntFromByte(packet[1], 0, 6);
        }

        public override string ToString()
        {
            return $"IsFingerIn: {IsFingerIn}\tBeat: {IsBeating}\tPulse: {PulseRate}\tPulseWaveForm: {PulseWaveForm}";
        }
    }
}
