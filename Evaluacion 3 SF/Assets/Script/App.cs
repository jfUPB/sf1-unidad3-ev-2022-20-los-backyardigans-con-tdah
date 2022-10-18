using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class App : MonoBehaviour
{
    private SerialPort _serialPort;
    private byte[] buffer; // aquí también podemos inicializar el buffer = new byte[12];

    public string strReceived;
     
    public string[] strData = new string[4];
    public string[] strData_received = new string[4];
    public float qw, qx, qy, qz; //Usemos la composición para utilizar los ejes
    //public float x, y, z, w; o esta
    
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
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = timer - waitTime;
             _serialPort.Write("s");
            // que pasa si le digo que pregunte con ask y cuando se le pase el comando ask mande el dato
        }
        
        if (_serialPort.BytesToRead >= 12)
        {
           
            _serialPort.Read(buffer, 0, 12);
            qx = System.BitConverter.ToSingle(buffer, 0);
            qy = System.BitConverter.ToSingle(buffer, 4);
            qz = System.BitConverter.ToSingle(buffer, 8);
           transform.rotation = new Quaternion(-qy, -qz, qx, qw);

        }

        //if (strData[0] != "" && strData[1] != "" && strData[2] != "")//make sure data are reday
       // {

           // x = float.Parse(strData[0]);
           // y = float.Parse(strData[1]);
           // z = float.Parse(strData[2]);

            //transform.rotation = new Quaternion(-qy, -qz, qx, qw);
            //transform.rotation = new Quaternion(x, y, z, w);

      //  }
    }

}
