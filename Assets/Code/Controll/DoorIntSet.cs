using UnityEngine;
using System.Collections;

public class DoorIntSet : MonoBehaviour {

	private Mix_ChangeItems MI;
	public int DoorOut;
	public string namee;

	private void Start()
	{
		MI = gameObject.GetComponent<Mix_ChangeItems>();
	}
	private void Update()
	{
		if (MI.GetCollisinWithItem ()) {
			PlayerPrefs.SetInt(namee,DoorOut);
		}
	}
}
