using UnityEngine;
using System.Collections;

public class MorgOutDoor: MonoBehaviour {

	private Mix_ChangeItems MI;
	private DoorCol DC;
	public int DoorOut;

	private void Start()
	{
		MI = gameObject.GetComponent<Mix_ChangeItems>();
		DC = gameObject.GetComponent<DoorCol>();
	}
	private void Update()
	{
		if (MI.GetCollisinWithItem ()) {
			DC.SetDoorEnter (true);
			PlayerPrefs.SetInt("MorgOutDoor",DoorOut);
			PlayerPrefs.SetInt("DayPlus",1);
		}
	}

}
