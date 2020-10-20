using UnityEngine;

public class MoveScript : MonoBehaviour {
	public Sprite b;
	public Sprite w;

	void Update()
	{
		if (MyMessageListener.potentiometer >= 50)
		{
			this.GetComponent<SpriteRenderer>().sprite = w;
		}
		if (MyMessageListener.potentiometer < 50)
		{
			this.GetComponent<SpriteRenderer>().sprite = b;
		}
		transform.Translate(Vector3.down * Time.deltaTime * NoteControlScript.scrollSpeed);
	}
}
