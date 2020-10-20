using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance{get{return instance;}}

	public ScenesManager sm;
	public Song1Script s1;
	public Song2Script s2;
	public int song = 0;
	public bool intro = true;
	public bool connected;

	public GameObject canvas2;
	public GameObject camera2;

	public GameObject laser;
	public Image laserSR;

	public Image lSR;
	public Sprite lUnpressed;
	public Sprite lPressed;
	public Image dSR;
	public Sprite dUnpressed;
	public Sprite dPressed;
	public Image uSR;
	public Sprite uUnpressed;
	public Sprite uPressed;
	public Image rSR;
	public Sprite rUnpressed;
	public Sprite rPressed;

	bool Loaded = false;

	public static KeyCode lPress;
	public static KeyCode dPress;
	public static KeyCode uPress;
	public static KeyCode rPress;

	private void Awake()
	{
		DontDestroyOnLoad(this);
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}

		sm = new ScenesManager();
		
		lPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "D"));
		dPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "F"));
		uPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "J"));
		rPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "K"));
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex == 1 && !Loaded)
		{
			canvas2 = Instantiate(canvas2);
			camera2 = Instantiate(camera2);
			canvas2.GetComponent<Canvas>().worldCamera = camera2.GetComponent<Camera>();
			
			lSR = canvas2.transform.GetChild(2).GetChild(6).GetComponent<Image>();
			dSR = canvas2.transform.GetChild(2).GetChild(7).GetComponent<Image>();
			uSR = canvas2.transform.GetChild(2).GetChild(8).GetComponent<Image>();
			rSR = canvas2.transform.GetChild(2).GetChild(9).GetComponent<Image>();
			
			laser = canvas2.transform.GetChild(2).GetChild(10).gameObject;
			laserSR = laser.GetComponent<Image>();

			Loaded = true;
		}

		if (connected && SceneManager.GetActiveScene().buildIndex == 1)
		{
			laser.SetActive(true);
			if (MyMessageListener.potentiometer <= 40)
			{
				laser.transform.localPosition = new Vector3(-136.25f, laser.transform.localPosition.y, laser.transform.localPosition.z);
			}
			if (MyMessageListener.potentiometer <= 60 && MyMessageListener.potentiometer > 33)
			{
				laser.transform.localPosition = new Vector3(0f, laser.transform.localPosition.y, laser.transform.localPosition.z);
			}
			if (MyMessageListener.potentiometer <= 99 && MyMessageListener.potentiometer > 66)
			{
				laser.transform.localPosition = new Vector3(136.25f, laser.transform.localPosition.y, laser.transform.localPosition.z);
			}
		}
		else if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			laser.SetActive(false);
		}

		if (Input.GetKeyDown(lPress))
		{
			lSR.sprite = lPressed;
		}
		if (Input.GetKeyDown(dPress))
		{
			dSR.sprite = dPressed;
		}
		if (Input.GetKeyDown(uPress))
		{
			uSR.sprite = uPressed;
		}
		if (Input.GetKeyDown(rPress))
		{
			rSR.sprite = rPressed;
		}

		if (Input.GetKeyUp(lPress))
		{
			lSR.sprite = lUnpressed;
		}
		if (Input.GetKeyUp(dPress))
		{
			dSR.sprite = dUnpressed;
		}
		if (Input.GetKeyUp(uPress))
		{
			uSR.sprite = uUnpressed;
		}
		if (Input.GetKeyUp(rPress))
		{
			rSR.sprite = rUnpressed;
		}
	}

	public void LoadSong(int i)
	{
		if (i == 1)
		{
			sm.LoadScene(1);
			s1 = new Song1Script();
		}
		if (i == 2)
		{
			sm.LoadScene(1);
			s2 = new Song2Script();
		}
	}
}