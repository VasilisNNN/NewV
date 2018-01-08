using UnityEngine;
using System.Collections;

public class Prefs_Add_After_Use : MonoBehaviour {

	private Movement move;
	public  string namee;
	public int ii;
	public bool SetTrue_PlusFalse = true;

	// Use this for initialization
	void Start () {
		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (move.Getcollob().Contains(gameObject)&& Input.GetButtonDown ("Enter")) {
		if (SetTrue_PlusFalse) 
		PlayerPrefs.SetInt (namee, ii);
		else 
		PlayerPrefs.SetInt (namee, PlayerPrefs.GetInt (namee)+ii);

		}
	}
}
