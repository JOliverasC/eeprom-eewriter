In order to EEPROM program yo need

1).-ArduinoMEGA or clone

2).-Hardware as described here: http://danceswithferrets.org/geekblog/?page_id=903

3).-Program Sketch https://github.com/JOliverasC/eeprom-writer

4).-Windows PC (perhaps Mono may handle it in Linux) with https://github.com/JOliverasC/-eewriter program

    Executable: https://github.com/JOliverasC/-eewriter/tree/master/EEWriter/EEWriter/bin/Debug/EEWriter.exe
    
or

    Build solution https://github.com/JOliverasC/-eewriter/tree/master/EEWriter/EEWriter.sln with SharpDevelop (Or M$ Visual Studio)
    

![ScreenShot capture](https://github.com/JOliverasC/-eewriter/blob/master/Docs/EEWriterSreenShot.png)

Steps:

Connect ArduinoATMEGA and select Serial Port from Combobox (You have File/Re-scan com ports command)

Test Button Identify if the port is the correct one (Check "EEPROM Version" answer to '?' command)

Select EEPROM Size

a).-For Read EEPROM press Read button

    You may Data/view the buffer 

   You may Verify with Verify button
   
   You may store with File/Save ROM Image
   
b).-For Write EEPROM
   You may fill the buffer with Data/Set to zeros|Ones|Random data
   
   You may fill the buffer reading data with File/Load ROM Image
   
   You may select "write byte" or the "write page" with the checkBox
   
   You may start the writting process with Write button


Obviously there are mixed posibilities (verify buffer - EEPROM)  

With Tools menu you may protect/unprotect an EEPROM who support SPD feature

I hope you find as usefull as I find the original works of https://github.com/oddblk 
