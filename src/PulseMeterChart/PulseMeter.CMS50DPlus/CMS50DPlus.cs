using SerialPortListener.Serial;
using System;
using System.IO.Ports;

namespace PulseMeterChart.PulseMeter.CMS50DPlus
{
    // References:
    //  - Protocol reference: https://www.tranzoa.net/~alex/blog/images/Communication%20protocol.pdf
    //  - Python tutorial: http://www.atbrask.dk/?p=244
    //  - Python code: https://github.com/atbrask/CMS50Dplus/blob/master/cms50dplus/cms50dplus.py

    /// <summary>
    /// Implemetation for pulsemeter CMS50D+
    /// </summary>
    public class CMS50DPlus : IPulseMeter
    {
        public static bool IsFirstByteOfPacket(byte b)
        {
            return GetIntFromByte(b, 7, 7) == 1;
        }

        public static int GetIntFromByte(byte b, int from, int to)
        {
            string binary = Convert.ToString(b, 2).PadLeft(8, '0');
            binary = Reverse(binary);
            string pulseBinary = binary.Substring(from, to - from + 1);
            pulseBinary = Reverse(pulseBinary);
            return Convert.ToInt32(pulseBinary, 2);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public event EventHandler<IPulseInfo> OnInfoReceived;

        SerialPortManager portManager;
        int currentIndex = 0;
        byte[] currentPackage = new byte[5];

        public CMS50DPlus()
        {
            portManager = new SerialPortManager();
            SerialSettings settings = portManager.CurrentSerialSettings;

            settings.BaudRate = 19200;
            settings.PortName = settings.PortNameCollection[1];
            settings.Parity = Parity.Odd;
            settings.DataBits = 8;
            settings.StopBits = StopBits.One;

            portManager.NewSerialDataRecieved += PortManager_NewSerialDataRecieved;
            portManager.StartListening();
        }
        
        void PortManager_NewSerialDataRecieved(object sender, SerialDataEventArgs received)
        {
            var data = received.Data;

            for (int i = 0; i < data.Length; i++)
            {
                var currentByte = data[i];

                if (currentIndex == 0 && IsFirstByteOfPacket(currentByte))
                {
                    // First package
                    currentPackage[currentIndex] = currentByte;
                    currentIndex++;
                }
                else if (currentIndex > 0 && !IsFirstByteOfPacket(currentByte))
                {
                    // Next package
                    currentPackage[currentIndex] = currentByte;
                    currentIndex++;
                }
                else if (currentIndex > 0 && IsFirstByteOfPacket(currentByte))
                {
                    // Bad package
                    currentIndex = 0;
                    //Console.WriteLine("Bad Packet");
                }
                
                if (currentIndex == 5)
                {
                    currentIndex = 0;

                    // Submit package
                    var info = new PulseNotification(currentPackage);
                    OnInfoReceived?.Invoke(this, info);
                }
            }
        }

    }
}
