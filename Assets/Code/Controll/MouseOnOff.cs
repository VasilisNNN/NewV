using UnityEngine;
using System.Collections;

public class MouseOnOff : MonoBehaviour {
	private SpriteRenderer SP;
	private MousePush MP;
	private bool draw;
	// Use this for initialization
	void Start () {
		SP = gameObject.GetComponent<SpriteRenderer> ();
		MP = gameObject.GetComponent<MousePush>();

		if (PlayerPrefs.GetInt (gameObject.name) == 1)
		{SP.enabled = true;
		draw = true;
		}
		else if(PlayerPrefs.GetInt (gameObject.name) == 0) 
		{SP.enabled = false;
			draw = false;}
	}



	void Update () {

		if (MP.MouseP) {
			draw = !draw;
			SP.enabled = draw;

		
			if(draw)PlayerPrefs.SetInt (gameObject.name,1);
			else if(!draw)PlayerPrefs.SetInt (gameObject.name,0);
		}






	}



}
