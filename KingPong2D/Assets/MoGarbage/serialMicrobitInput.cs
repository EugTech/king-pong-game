using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class serialMicrobitInput : MonoBehaviour {

	public static string com = "COM6";
	public static int BaudRate = 115200;

	public string COM;
	public int BAUD;

	char[] strm = new char[15];

	string outputS = "";
	string outputS2 = "";

	int outputI = 0;
	int outputI2 = 0;

	public float outputF = 0;
	public int max = 1072;

	string s = null;

	private Thread _t1;

	SerialPort port;
	void Start () {
		//port = new SerialPort("COM6", 115200,Parity.None,8,StopBits.One);
		//port = new SerialPort("COM5", 115200);
		port = new SerialPort(COM, BAUD);
		port.Open();

		port.ReadTimeout = 1000;

		//port.Write("2");

		//port.DataReceived += Port_DataReceived;

		//StartCoroutine(NumberTwo());

		_t1 = new Thread(_Func);

		_t1.Start();
	}

	private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		//string s = port.ReadLine();
		//Debug.Log(s);

		SerialPort sp = (SerialPort)sender;
		string indata = sp.ReadExisting();
		string s = sp.ReadLine();

		Debug.Log("Data Received:");
		Debug.Log(sp.ReadLine());
	}

	private void _Func()
	{
		while (true)
		{
			s = port.ReadLine();

			//yield return s = ;
			calculate();
		}
		
	}

	// Update is called once per frame
	void Update()
	{
		//string s = null;
		//s = port.ReadLine();
		//try
		//{
		//	s = port.ReadLine();
		//}
		//catch
		//{
		//	Debug.LogError("CantReadLine");
		//}

		//port.Write("*");
		//port.Read(strm, 0, 15);



		//calculate();
	}

	void calculate()
	{
		if (s != null)
		{
			if (s.Contains("-"))
			{

				s = s.Remove(s.IndexOf("-"), 1);

				if (s.Contains("-"))
				{
					s = s.Remove(s.IndexOf("-"), 1);
				}

				int.TryParse(s, out outputI);
				outputS = outputI.ToString();
				int HLen = outputS.Length / 2;
				outputS2 = outputS.Substring(0, HLen);
				int.TryParse(outputS2, out outputI2);

				outputI2 *= -1;


				Debug.Log(HLen.ToString() + "   " + s + " " + outputS + " " + outputS2 + " " + outputI.ToString() + " " + outputI2.ToString());
			}
			else
			{
				//Debug.Log(s);
				//int HLen = s.Length / 2;
				//outputS = s.Substring(HLen - 1, HLen);
				int.TryParse(s, out outputI);
				outputS = outputI.ToString();
				int HLen = outputS.Length / 2;
				outputS2 = outputS.Substring(0, HLen);
				int.TryParse(outputS2, out outputI2);


				Debug.Log(HLen.ToString() + "   " + s + " " + outputS + " " + outputS2 + " " + outputI.ToString() + " " + outputI2.ToString());
			}

			outputF = (float)outputI2 / (float)max;

		}
	}
}
