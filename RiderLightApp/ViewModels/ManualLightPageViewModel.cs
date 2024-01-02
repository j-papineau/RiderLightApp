using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using Avalonia.Media;

namespace RiderLightApp.ViewModels;

public partial class ManualLightPageViewModel: ViewModelBase
{
    [ObservableProperty] private string _circleColor = "Gray";
    [ObservableProperty] private bool _isConnecting = false;
    [ObservableProperty] private Color? _colorPicker;
    [ObservableProperty] private string _colorDisplay = "";
    

    private static SerialPort? _serialPort;

    [RelayCommand]
    private void SendStripOne()
    {
        Debug.WriteLine(ColorPicker);
        ColorDisplay = ColorPicker.ToString()!;
        
    }
    
    [RelayCommand]
    private static void SendStripTwo()
    {
        
    }
    
    
    [RelayCommand]
    private void ConnectToEsp()
    {
        Debug.WriteLine("Attempting ESP connection through serial port...");
        IsConnecting = true;
        
        //default for ESP32 is COM4 UART
        try
        {
            _serialPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            _serialPort.Open();
            FlashWhite();
            //success
            CircleColor = "Green";
            IsConnecting = false;
            _serialPort.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("SERIAL CONNECTION FAILURE");
            throw;
        }
    }
    
    private static void FlashWhite()
    {
        _serialPort!.Write("LED1 |\n");
        Thread.Sleep(500);
        _serialPort!.Write("LED2 |\n");
        Thread.Sleep(500);
        _serialPort.Write("OFF |\n");

    }
}