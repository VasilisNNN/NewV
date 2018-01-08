using UnityEngine;
using System.Collections;

public class MousePush : MonoBehaviour {

	public bool MouseP{get;set;}
	public bool MouseColl{get; set; }

	// Update is called once per frame
	void Update () {
		if (MouseColl && Input.GetKeyDown (KeyCode.Mouse0)) {
			MouseP = true;
		}else MouseP = false;
	}

	void OnMouseEnter()
	{
		MouseColl = true;
	}
	void OnMouseExit()
	{
		MouseColl = false;
	}
}
