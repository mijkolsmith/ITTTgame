using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour {

	public static Slider Volume;
	GameObject Source;
	public AudioSource Music;

	GameObject Option;
	Transform Options;
	public Text buttonText;
	public Event keyEvent;
	public KeyCode newKey;
	public bool waitingForKey = false;

	private void Start()
	{
		Volume = GameObject.Find("Slider").GetComponent<Slider>();
		Source = GameObject.Find("MenuMusic");
		Music = Source.GetComponent<AudioSource>();

		Option = GameObject.Find("OptionsMenu");
		Options = Option.transform;

		for (int i=0; i<4; i++)
		{
			if(Options.GetChild(i).name == "LeftButton")
			{
				Options.GetChild(i).GetComponentInChildren<Text>().text = HitOrMissDetectionScript.lPress.ToString();
			}
			if (Options.GetChild(i).name == "DownButton")
			{
				Options.GetChild(i).GetComponentInChildren<Text>().text = HitOrMissDetectionScript.dPress.ToString();
			}
			if (Options.GetChild(i).name == "UpButton")
			{
				Options.GetChild(i).GetComponentInChildren<Text>().text = HitOrMissDetectionScript.uPress.ToString();
			}
			if (Options.GetChild(i).name == "RightButton")
			{
				Options.GetChild(i).GetComponentInChildren<Text>().text = HitOrMissDetectionScript.rPress.ToString();
			}
		}
	}

	private void Update()
	{
		Music.volume = Volume.value;
	}

	private void OnGUI()
	{
		keyEvent = Event.current;

		if (keyEvent.isKey && waitingForKey == true)
		{
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
		{
			StartCoroutine(AssignKey(keyName));
		}
	}

	public void SendText (Text text)
	{
		buttonText = text;
	}

	IEnumerator WaitForKey()
	{
		while (!keyEvent.isKey)
		{
			yield return null;
		}
	}

	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;
		yield return WaitForKey();

		switch (keyName)
		{
			case "left":
				HitOrMissDetectionScript.lPress = newKey;
				buttonText.text = HitOrMissDetectionScript.lPress.ToString();
				PlayerPrefs.SetString("leftKey", HitOrMissDetectionScript.lPress.ToString());
				break;
			case "down":
				HitOrMissDetectionScript.dPress = newKey;
				buttonText.text = HitOrMissDetectionScript.dPress.ToString();
				PlayerPrefs.SetString("downKey", HitOrMissDetectionScript.dPress.ToString());
				break;
			case "up":
				HitOrMissDetectionScript.uPress = newKey;
				buttonText.text = HitOrMissDetectionScript.uPress.ToString();
				PlayerPrefs.SetString("upKey", HitOrMissDetectionScript.uPress.ToString());
				break;
			case "right":
				HitOrMissDetectionScript.rPress = newKey;
				buttonText.text = HitOrMissDetectionScript.rPress.ToString();
				PlayerPrefs.SetString("rightKey", HitOrMissDetectionScript.rPress.ToString());
				break;
		}
	}
}
