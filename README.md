# Pulse Meter Chart
A simple project that reads data from pulse meter CMS50D+ in real time and displays it in a chart using Windows Forms.

Binary data received from serial port are parsed into meaningful information. Every time a packet arrives an event fires with the information received:
 - Heart Rate in BPM
 - Heart Waveform
 - Beat
 - If finger is in or out

![alt tag](https://github.com/ceichin/PulseMeterChart/blob/master/screenshot.png)

**NOTE:** You may have to change the serial port number from code to make it work depending on your computer and where the pulsemeter is connected.



