using UnityEngine;
using System.Collections;

public class SetColisionInt : MonoBehaviour {
	private bool Coll;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Coll && Input.GetButtonDown ("Enter")) 
		{
		PlayerPrefs.SetInt(gameObject.name,1);
		}
	}

	
	void OnTriggerStay2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			Coll = true;
		} 
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			Coll = false;
		} 
	}
}
