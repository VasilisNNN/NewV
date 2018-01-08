using UnityEngine;
using System.Collections;

public class MorgEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Day") == 3 || PlayerPrefs.GetInt ("Day") > 4) {
						GameObject.Find ("M").GetComponent<Renderer> ().enabled = true; 
						GameObject.Find ("M").GetComponent<BoxCollider2D> ().enabled = true; 
		 
				} else {
						GameObject.Find ("M").GetComponent<Renderer> ().enabled = false;
			GameObject.Find("M").GetComponent<BoxCollider2D>().enabled = false;
				}

	}
}
