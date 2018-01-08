using UnityEngine;
using System.Collections;

public class SpriteSaveLaod : MonoBehaviour {
	private string namee;
	private Mix_ChangeItems MCI;

	void Start () 
	{
		MCI = gameObject.GetComponent<Mix_ChangeItems>();
		MCI.SetPrevI (PlayerPrefs.GetInt ("PrevI"));
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("ItemIcons/" + PlayerPrefs.GetString ("SpriteNameBoxBomb"));
	}


	void Update () {

		PlayerPrefs.SetInt ("PrevI", MCI.GetPrevI ());
	

		if (gameObject.GetComponent<SpriteRenderer> ().sprite != null) {
			namee = gameObject.GetComponent<SpriteRenderer> ().sprite.name;
			PlayerPrefs.SetString ("SpriteNameBoxBomb", namee);
				}

	}
}
