using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class App : MonoBehaviour
{
    
    SerialPort serialport = new SerialPort("/dev/ttyACM0", 115200);
    public string strReceived;
     
    public string[] strData = new string[3];
    //public string[] strData_received = new string[3];
    //public float qw, qx, qy, qz;
    public float x, y, z, w;
    
    private float waitTime = 0.050f;
    private float timer = 0.0f;
    void Start()
    {
        serialport.Open(); //Open the Serial Stream.
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = timer - waitTime;
        }
        
        strReceived = serialport.ReadLine(); //Read the information  

        strData = strReceived.Split(','); 
        if (strData[0] != "" && strData[1] != "" && strData[2] != "")//make sure data are reday
        {

            x = float.Parse(strData[0]);
            y = float.Parse(strData[1]);
            z = float.Parse(strData[2]);

            //transform.rotation = new Quaternion(-qy, -qz, qx, qw);
            //transform.rotation = new Quaternion(x, y, z, w);

        }
    }
}