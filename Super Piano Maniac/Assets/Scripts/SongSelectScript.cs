using UnityEngine;

public class SongSelectScript : MonoBehaviour
{
	public void Load (int value) {
		if (value == 1)
		{ GameManager.Instance.LoadSong(value); }
		if (value == 2)
		{ GameManager.Instance.LoadSong(value); }
	}
}
