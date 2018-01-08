using UnityEngine;
using System.Collections;

public class Empty2 : MonoBehaviour {

	
	void Update () {
		if(PlayerPrefs.GetInt("ChernIn")==1)SpriteCntrl ("Code", false);
        
		if (PlayerPrefs.GetInt ("Day") >=5&&PlayerPrefs.GetInt ("Day") <=9) {
			if(PlayerPrefs.GetInt("ChernIn")!=1)SpriteCntrl ("Code", true);
		} else {
			SpriteCntrl("Code",false);
		}
	}
	
	private void SpriteCntrl(string ob,bool on)
	{
		GameObject.Find(ob).GetComponent<SpriteRenderer>().enabled = on;
		GameObject.Find(ob).GetComponent<BoxCollider2D>().enabled = on;
		if(GameObject.Find(ob).GetComponent<Animator>()!=null)GameObject.Find(ob).GetComponent<Animator>().enabled = on;
	}
}
