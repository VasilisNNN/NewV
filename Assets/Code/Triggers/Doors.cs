using UnityEngine;
using System.Collections;

public class ClosedDoor : MonoBehaviour {

	private bool DoorColl;
	public GUISkin skin;
	private Rect rect;

	private bool draw = false;
	public bool OnOff = true;
	public string text = "Закрыто";
	public string texten = "Closed";
	
void Start()
	{
	
	}

void Update()
	{
		rect = new Rect (Screen.width/2f-150f,70f,300f,200f);

		if (gameObject.GetComponent<BoxCollider2D> ().enabled)
			OnOff = true;
		else
			OnOff = false;

		if (OnOff) {
			if (DoorColl && Input.GetButtonDown("Enter"))
				draw = true;
			else if (!DoorColl)
				draw = false;
		}

	}

void OnGUI()
	{
		if (draw && OnOff) 
		{
			if(PlayerPrefs.GetInt("Language")==0)GUI.Label (rect, text, skin.customStyles[0]);
			else if(PlayerPrefs.GetInt("Language")==1)GUI.Label (rect, texten, skin.customStyles[0]);
		}
	}

	
	void OnTriggerStay2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			DoorColl = true;
		} 
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			DoorColl = false;
		} 
	}

	
public void SetOnOff(bool onoff)
	{
		OnOff = onoff;
	}

}
