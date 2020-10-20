using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour {
	
	public Song1Script song1Script;
	public Song2Script song2Script;

	public void Back()
	{
		GameManager.Instance.sm.LoadScene(0);
	}

	public void Unload()
	{
		if (GameManager.Instance.s1 != null)
		{
			GameManager.Instance.s1.Unload();
		}
		if (GameManager.Instance.s2 != null)
		{
			GameManager.Instance.s2.Unload();
		}
	}
}
