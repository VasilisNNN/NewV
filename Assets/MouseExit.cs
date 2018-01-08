using UnityEngine;
using System.Collections;

public class MouseExit : MonoBehaviour {
	private TriggerMouse exit;
	public string levelname;
	// Use this for initialization
	void Start () {
		exit = GetComponent<TriggerMouse> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (exit.GetClicked ()) {
			Application.LoadLevel(levelname);
		}
	}
}
