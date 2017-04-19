# PulseMeterChart
A simple project that reads data from pulse meter CMS50D+ in real time and displays it in a chart using Windows Forms.

Binary data received from serial port are parsed into packets with meaningful information to be used as you like. Every time a packet arrives an event fires with the information received.

Information that has been parsed:
 - Heart Rate in BPM
 - Heart Waveform
 - Beat
 - If finger is in or out

![alt tag](https://github.com/ceichin/PulseMeterChart/master/screenshot.png)
