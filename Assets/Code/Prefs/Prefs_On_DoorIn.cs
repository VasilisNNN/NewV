using UnityEngine;
using System.Collections;

public class Prefs_On_DoorIn : MonoBehaviour {


	private Movement move;
	public bool SetTrue_PlusFalse;

	public string namee;
	public int i;
	
	void Start () {

		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
	}
	
	void FixedUpdate () {
		
		if(move.Getcollob().Contains(gameObject)&&Input.GetButton("Enter"))
		{
		if (SetTrue_PlusFalse) 
		PlayerPrefs.SetInt (namee, i);
		
		else 
			PlayerPrefs.SetInt (namee, PlayerPrefs.GetInt (namee)+i);
		
		}
	}

}
