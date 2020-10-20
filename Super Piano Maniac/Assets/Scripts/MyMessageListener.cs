using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMessageListener : MonoBehaviour
{
	public static int left;
	public static int down;
	public static int up;
	public static int right;
	public static int potentiometer;

	// Invoked when a line of data is received from the serial device.
	void OnMessageArrived(string msg)
	{
		left = int.Parse(msg[0].ToString());
		down = int.Parse(msg[1].ToString());
		up = int.Parse(msg[2].ToString());
		right = int.Parse(msg[3].ToString());
		if (msg.Length == 6)
		{
			potentiometer = int.Parse(msg[4].ToString()) * 10 + int.Parse(msg[5].ToString());
		}
		else
		{
			potentiometer = int.Parse(msg[4].ToString());
		}
		Debug.Log(potentiometer);
	}
	
	// Invoked when a connect/disconnect event occurs. The parameter 'success'
	// will be 'true' upon connection, and 'false' upon disconnection or
	// failure to connect.
	void OnConnectionEvent(bool success)
	{
		Debug.Log(success ? "Device connected" : "Device disconnected");
		GameManager.Instance.connected = success ? true : false;
	}
}
