# -eewriter
Clone (with C# source code) of eewriter from http://danceswithferrets.org/geekblog/?page_id=903

Needs one ArduinoMega programmed w/ https://github.com/JOliverasC/eeprom-writer

Hardware is the same of original development http://danceswithferrets.org/geekblog/?page_id=903

Software is developed with SharpDevelop, avalaible from http://www.icsharpcode.net/opensource/sd/Default.aspx

The main reason for writing this program is to add a new functionality. I used the original code with an EEPROM SST29EE010 and it failed because it uses the 'Page Write mode', resulting in only 16 bytes written for each page (of 127 bytes)

I only used the code with SST29EE010 EEPROM, but it should work for other EEPROMS implementing this mode

I apologize because this is a Quick and Dirty project, but comments are welcome
