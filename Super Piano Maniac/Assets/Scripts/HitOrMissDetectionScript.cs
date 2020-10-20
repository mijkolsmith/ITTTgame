using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOrMissDetectionScript : MonoBehaviour
{
	public static KeyCode lPress;
	public static KeyCode dPress;
	public static KeyCode uPress;
	public static KeyCode rPress;
	public bool lPressable = false;
	public bool dPressable = false;
	public bool uPressable = false;
	public bool rPressable = false;

	private void Start()
	{
		lPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "D"));
		dPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "F"));
		uPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "J"));
		rPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "K"));
	}

	private void Update()
	{
		if (Input.GetKeyDown(lPress) && lPressable == true || MyMessageListener.left == 1 && lPressable == true)
		{
			NoteControlScript.hit += 1;
			NoteControlScript.combo += 1;
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(dPress) && dPressable == true || MyMessageListener.down == 1 && dPressable == true)
		{
			NoteControlScript.hit += 1;
			NoteControlScript.combo += 1;
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(uPress) && uPressable == true || MyMessageListener.up == 1 && uPressable == true)
		{
			NoteControlScript.hit += 1;
			NoteControlScript.combo += 1;
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(rPress) && rPressable == true || MyMessageListener.right == 1 && rPressable == true)
		{
			NoteControlScript.hit += 1;
			NoteControlScript.combo += 1;
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "MissCollider")
		{
			//destroy the object if it hits the misscollider
			Destroy(gameObject);

			//everytime we miss, add a miss and reset the combo
			NoteControlScript.miss += 1;
			NoteControlScript.combo = 0;

			//the note is now missed, so you can't be able to press the button to hit the next one before that one is in the detection range
			if (other.gameObject.name == "Left")
			{
				lPressable = false;
			}
			if (other.gameObject.name == "Down")
			{
				dPressable = false;
			}
			if (other.gameObject.name == "Up")
			{
				uPressable = false;
			}
			if (other.gameObject.name == "Right")
			{
				rPressable = false;
			}
		}

		//put the booleans to whether the buttons are now hittable to true
		if (other.gameObject.name == "Left" && gameObject.name == "LeftB(Clone)")
		{
			lPressable = true;
		}
		if (other.gameObject.name == "Down" && gameObject.name == "DownB(Clone)")
		{
			dPressable = true;
		}
		if (other.gameObject.name == "Up" && gameObject.name == "UpB(Clone)")
		{
			uPressable = true;
		}
		if (other.gameObject.name == "Right" && gameObject.name == "RightB(Clone)")
		{
			rPressable = true;
		}
		if (other.gameObject == GameManager.Instance.laser && gameObject.name == "LaserB(Clone)")
		{
			NoteControlScript.hit += 1;
			NoteControlScript.combo += 1;
			Destroy(gameObject);
		}
	}
}
