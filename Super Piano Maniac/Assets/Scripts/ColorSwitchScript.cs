using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorSwitchScript : MonoBehaviour {
	/*
	public Image 
	public Sprite 
	public Sprite
	*/

	//main menu
	public Image background;
	public Sprite black;
	public Sprite white;

	public Image select;
	public Sprite bselect;
	public Sprite wselect;

	public Image options;
	public Sprite boptions;
	public Sprite woptions;

	public Image quit;
	public Sprite bquit;
	public Sprite wquit;

	//song select menu
	//public Image background;
	//public Image select;

	public Image back;
	public Sprite bback;
	public Sprite wback;

	public Image song1;
	public Sprite bsong1;
	public Sprite wsong1;

	public Image song2;
	public Sprite bsong2;
	public Sprite wsong2;

	//options menu
	//public Image background;
	//public Image options;
	//public Image back;

	public Image volume;
	public Sprite bvolume;
	public Sprite wvolume;

	public Image keybinds;
	public Sprite bkeybinds;
	public Sprite wkeybinds;

	//gamescene
	//public Image background;
	//public Image back;
	public Image left;
	public Sprite bleft;
	public Sprite wleft;

	public Image down;
	public Sprite bdown;
	public Sprite wdown;

	public Image up;
	public Sprite bup;
	public Sprite wup;

	public Image right;
	public Sprite bright;
	public Sprite wright;
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(MyMessageListener.color);
		LoadGameObjects();
		if (SceneManager.GetActiveScene().name == "Main Menu")
		{
			if (MyMessageListener.potentiometer <= 50)
			{
				if (GameObject.Find("MainMenu") == isActiveAndEnabled)
				{
					background.sprite = black;
					select.sprite = bselect;
					options.sprite = boptions;
					quit.sprite = bquit;
				}

				if (GameObject.Find("SongSelectMenu") == isActiveAndEnabled)
				{
					background.sprite = black;
					select.sprite = bselect;
					back.sprite = bback;
					song1.sprite = bsong1;
					song2.sprite = bsong2;
				}

				if (GameObject.Find("OptionsMenu") == isActiveAndEnabled)
				{
					background.sprite = black;
					options.sprite = boptions;
					back.sprite = bback;
					volume.sprite = bvolume;
					keybinds.sprite = bkeybinds;
				}
			}
			if (MyMessageListener.potentiometer > 50)
			{
				if (GameObject.Find("MainMenu") == isActiveAndEnabled)
				{
					background.sprite = white;
					select.sprite = wselect;
					options.sprite = woptions;
					quit.sprite = wquit;
				}

				if (GameObject.Find("SongSelectMenu") == isActiveAndEnabled)
				{
					background.sprite = white;
					select.sprite = wselect;
					back.sprite = wback;
					song1.sprite = wsong1;
					song2.sprite = wsong2;
				}

				if (GameObject.Find("OptionsMenu") == isActiveAndEnabled)
				{
					background.sprite = white;
					options.sprite = woptions;
					back.sprite = wback;
					volume.sprite = wvolume;
					keybinds.sprite = wkeybinds;
				}
			}
		}
		if (SceneManager.GetActiveScene().name == "GameScene")
		{
			if (MyMessageListener.potentiometer <= 50)
			{
				background.sprite = black;
				back.sprite = bback;
				left.sprite = wleft;
				down.sprite = wdown;
				up.sprite = wup;
				right.sprite = wright;
			}
			if (MyMessageListener.potentiometer > 50)
			{
				background.sprite = white;
				back.sprite = wback;
				left.sprite = bleft;
				down.sprite = bdown;
				up.sprite = bup;
				right.sprite = bright;
			}
		}
	}

	void LoadGameObjects () {
		//main menu
		if (GameObject.Find("MainMenu") == isActiveAndEnabled && SceneManager.GetActiveScene().name == "Main Menu")
		{
			background = GameObject.Find("Panel").GetComponent<Image>();
			select = GameObject.Find("SongSelectButton").GetComponent<Image>();
			options = GameObject.Find("OptionsButton").GetComponent<Image>();
			quit = GameObject.Find("QuitButton").GetComponent<Image>();
		}
			
		//song select menu
		if (GameObject.Find("SongSelectMenu") == isActiveAndEnabled && SceneManager.GetActiveScene().name == "Main Menu")
		{
			background = GameObject.Find("Panel").GetComponent<Image>();
			select = GameObject.Find("SongSelect").GetComponent<Image>();
			back = GameObject.Find("BackButton").GetComponent<Image>();
			song1 = GameObject.Find("Song 1").GetComponent<Image>();
			song2 = GameObject.Find("Song 2").GetComponent<Image>();
		}

		//options menu
		if (GameObject.Find("OptionsMenu") == isActiveAndEnabled && SceneManager.GetActiveScene().name == "Main Menu")
		{
			background = GameObject.Find("Panel").GetComponent<Image>();
			options = GameObject.Find("OptionsImage").GetComponent<Image>();
			back = GameObject.Find("BackButton").GetComponent<Image>();
			volume = GameObject.Find("VolumeImage").GetComponent<Image>();
			keybinds = GameObject.Find("KeybindsImage").GetComponent<Image>();
		}

		//game scene
		if (back == null && SceneManager.GetActiveScene().name == "GameScene")
		{
			background = GameObject.Find("Panel").GetComponent<Image>();
			back = GameObject.Find("BackButton").GetComponent<Image>();
			left = GameObject.Find("Left").GetComponent<Image>();
			down = GameObject.Find("Down").GetComponent<Image>();
			up = GameObject.Find("Up").GetComponent<Image>();
			right = GameObject.Find("Right").GetComponent<Image>();
		}
	}
}
