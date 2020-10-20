using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDelete : MonoBehaviour
{
	private void Start()
	{
		//for debug purposes
		Destroy(transform.gameObject);

		//so the intro doesn't play every time when you go the main menu (it's not that hard FromSoftware)
		if (GameManager.Instance.intro == false)
		{
			Destroy(transform.gameObject);
		}

		var videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
		videoPlayer.loopPointReached += EndReached;
	}

	void EndReached(UnityEngine.Video.VideoPlayer vp)
	{
		Destroy(GameObject.Find("IntroVideo"));
	}
}
