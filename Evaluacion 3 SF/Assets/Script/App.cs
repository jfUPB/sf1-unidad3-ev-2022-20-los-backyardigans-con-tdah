//Código para Unity AyudaaaMe
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class App : MonoBehaviour
{
    private SerialPort _serialPort;
    private byte[] buffer;

    public string strReceived;
     
    public string[] strData = new string[4];
    public string[] strData_received = new string[4];
    //public float qw, qx, qy, qz; o esta
    public float x, y, z, w;
    
    private float waitTime = 0.050f;
    private float timer = 0.0f;
    void Start()
    {
        _serialPort = new SerialPort();
        _serialPort.PortName = "/dev/ttyACM0";
        _serialPort.BaudRate =115200;
        _serialPort.DtrEnable = true;
        _serialPort.Open();
        Debug.Log("Open Serial Port");
        buffer = new byte[12];
    }
    
    
    void Update()
    {
        _serialPort.Write("s");
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = timer - waitTime;
            //   _serialPort.Write("ask\n");
        //if {}
        strData = strReceived.Split(','); 
        
        if (strData[0] != "" && strData[1] != "" && strData[2] != "")//make sure data are reday
        //if (_serialPort.BytesToRead => 12)
        {

            x = float.Parse(strData[0]);
            y = float.Parse(strData[1]);
            z = float.Parse(strData[2]);

            //transform.rotation = new Quaternion(x, y, z, w);
            //transform.rotation = new Quaternion(x, y, z, w);
            transform.rotation = new Quaternion(-y, -z, x, w);

        }
    }
}