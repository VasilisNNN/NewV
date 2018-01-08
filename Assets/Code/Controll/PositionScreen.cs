using UnityEngine;
using System.Collections;

public class PositionScreen : MonoBehaviour {

	private Camera cam;
	public bool Rcorner = false;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}



	void Update () {
		if (!Rcorner) {
			transform.position = 
			new Vector3 (cam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 1f)).x * -1,
			            transform.position.y, 1f);
		} else {
			transform.position = 
				new Vector3 (cam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 1f)).x,
				             transform.position.y, 1f);
		}
	}



}
