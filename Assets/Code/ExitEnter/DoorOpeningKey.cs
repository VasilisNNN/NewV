using UnityEngine;
using System.Collections;

public class DoorOpeningKey : MonoBehaviour {
	
	private Mix_ChangeItems MI;
	private DoorCol DC;
	private ClosedDoor CD;
private void Start()
	{
		MI = gameObject.GetComponent<Mix_ChangeItems>();
		DC = gameObject.GetComponent<DoorCol>();
		CD = gameObject.GetComponent<ClosedDoor> ();





	}
private void Update()
	{
		if (PlayerPrefs.GetInt (gameObject.name + "Open") == 1) {
			if(CD!=null)CD.enabled = false;
			MI.enabled = false;
			DC.SetDoorEnter (true);
		} else if (PlayerPrefs.GetInt (gameObject.name + "Open") == 0) {
			if(CD!=null)CD.enabled = true;
			DC.SetDoorEnter (false);
		}

		if (MI.GetCollisinWithItem ()) {
			if(CD!=null)CD.enabled = false;
			DC.SetDoorEnter (true);
			PlayerPrefs.SetInt(gameObject.name + "Open", 1);
		}
	}

}
