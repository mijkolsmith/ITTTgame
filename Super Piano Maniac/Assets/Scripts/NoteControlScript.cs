using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteControlScript : MonoBehaviour {

	//this list is to indicate on which lanes notes are going to spawn
	public List<float> whichNote1;
	public List<float> whichNote2;
	public List<float> whichNote3;
	public List<float> laser;
	public int notePos = 0;

	public Transform noteLeft;
	public Transform noteDown;
	public Transform noteUp;
	public Transform noteRight;
	public Transform noteLaser;
	public float xPos;

	public float bpm = 0;
	public float speed = 1;
	public static float scrollSpeed = 1;
	public float scrollSpeedModifier = 10;

	public static float hit = 0;
	public static float miss = 0;
	public static float combo = 0;

	public Text counterText;
	public Text comboText;
	public float timePassed;

	private void Start()
	{
		//load the correct bpm and notes
		if (GameManager.Instance.song == 1)
		{
			bpm = 180;
			//the scroll speed (the speed of the falling notes)
			scrollSpeed = (bpm)/scrollSpeedModifier;
			//the old old way to set the speed of how fast the notes should spawn
			//speed = (24.3f / bpm);
			whichNote1 = Song1Script.Note1;
			whichNote2 = Song1Script.Note2;
			whichNote3 = Song1Script.Note3;
			laser = Song1Script.LaserNote;
			Debug.Log("song 1 is loaded");
			//the old way to define times so I could work outside of update
			//Song1Script.startSong = Time.time;
			//timePassed = Time.time;

			StartCoroutine(spawnNote());
		}
		if (GameManager.Instance.song == 2)
		{
			bpm = 180;
			//the scroll speed (the speed of the falling notes)
			scrollSpeed = (bpm)/scrollSpeedModifier;
			//the speed of how fast the notes should spawn
			//speed = (26.6f / bpm);
			whichNote1 = Song2Script.Note1;
			whichNote2 = Song2Script.Note2;
			whichNote3 = Song2Script.Note3;
			Debug.Log("song 2 is loaded");

			StartCoroutine(spawnNote());
		}       
	}

	private void Update()
	{
		//display the counted notes every frame
		counterText.text = " Notes hit: " + hit + "\n Notes missed: " + miss;
		comboText.text = "" + combo;
		
		//the old way to spawn a note:
		//if (Time.time >= (timePassed + .155f))
		//{
		//	Debug.Log(timePassed);
			
		//	StartCoroutine(spawnNote());
		//	timePassed = Time.time;
		//	Debug.Log(timePassed);
		//}
		
		//the old old way to spawn a note:

		//if (timerReset == "y")
		//{	
			//StartCoroutine(spawnNote());
			//timerReset = "n";
		//}
	}

	IEnumerator spawnNote()
	{
		while (true)
		{
			//the bpm of the song is 180, so that means there's 180/60 = 3 notes per second which means 1/3 of a second per note. we divide this by two to be able to place 8th notes. (.166666)
			//There is a problem though, the notes slowly go off beat. The cheap way to solve this is lowering the number. This number isn't the same on each start-up though, is what I discovered.
			//This problem is why I thought of 2 new ways to spawn notes. One to go outside of update but I still had to use update, and now within a permament numerator, but both didn't fix the problem. 
			//I don't know what causes it or how to fix it, so all I can do is give up for now (I've set to value to something close to what works).
			yield return new WaitForSeconds(.16666666666666f);
			//the old way to wait 0 seconds because we neededed a return value
			//yield return new WaitForSeconds(0);
			//the old old way to wait a certain amount for the next note
			//(this is now old old, right now this doesn't do anything)this part has to do with the bpm of the song, if bpm is 60 speed should be 1. this aligns notes on the beat (divide by 2 or 4 to get to 8ths or 16ths)
			//yield return new WaitForSeconds(speed);

			//check on which lane the note needs to spawn
			if (whichNote1[notePos] == 1 || whichNote2[notePos] == 1 || whichNote3[notePos] == 1)
			{
				//define the x position for this note
				xPos = -81.75f;
				//instantiate the prefab noteleft
				Transform Note = Instantiate(noteLeft);
				//make the note a child of GameScene
				Note.transform.SetParent(transform);
				//give the note the correct position
				Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
			}
			if (whichNote1[notePos] == 2 || whichNote2[notePos] == 2 || whichNote3[notePos] == 2)
			{
				xPos = -27.25f;
				Transform Note = Instantiate(noteDown);
				Note.transform.SetParent(transform);
				Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
			}
			if (whichNote1[notePos] == 3 || whichNote2[notePos] == 3 || whichNote3[notePos] == 3)
			{
				xPos = 27.25f;
				Transform Note = Instantiate(noteUp);
				Note.transform.SetParent(transform);
				Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
			}
			if (whichNote1[notePos] == 4 || whichNote2[notePos] == 4 || whichNote3[notePos] == 4)
			{
				xPos = 81.75f;
				Transform Note = Instantiate(noteRight);
				Note.transform.SetParent(transform);
				Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
			}

			if (GameManager.Instance.connected)
			//spawn laser notes
			{
				if (laser[notePos] == 1)
				{
					xPos = -136.25f;
					Transform Note = Instantiate(noteLaser);
					Note.transform.SetParent(transform);
					Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
				}
				if (laser[notePos] == 2)
				{
					xPos = 0;
					Transform Note = Instantiate(noteLaser);
					Note.transform.SetParent(transform);
					Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
				}
				if (laser[notePos] == 3)
				{
					xPos = 136.25f;
					Transform Note = Instantiate(noteLaser);
					Note.transform.SetParent(transform);
					Note.transform.localPosition = new Vector3(xPos, 242f, 0f);
				}
			}

			//next note in the list
			notePos += 1;
			//old old way to reset the timer so another note can spawn
			//timerReset = "y";
		}
	}
}
