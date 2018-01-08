using UnityEngine;
using System.Collections;

public class MapQuest : MonoBehaviour {

	private Inventory Inv;
	private TriggerMouse MouseTrig;
	public int iitem;

	// Use this for initialization
	void Start () {
		Inv = GameObject.FindGameObjectWithTag("Inv").GetComponent<Inventory>();
		MouseTrig = gameObject.GetComponent<TriggerMouse>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Inv.GetCorrentItemMouse()==iitem&&Input.GetKeyDown (KeyCode.Mouse0) && MouseTrig.GetClicked ()) {
			PlayerPrefs.SetInt("Map",1);
			PlayerPrefs.SetInt("PlayDay",1);
		}


	}
}
