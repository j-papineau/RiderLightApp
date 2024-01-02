using System.IO.Ports;
namespace RiderLightApp.Lib;

public class SerialConnection
{
    //ESP32 is normally on COM4
     static SerialPort serialPort;

     public SerialConnection()
     {
         serialPort = new SerialPort("COM4", 9600);
         
         //run test function
     }
     
     
    
}