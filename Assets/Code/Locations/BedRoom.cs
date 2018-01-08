using UnityEngine;
using System.Collections;

public class BedRoom : MonoBehaviour {
	private Movement Vas;
	public GUIStyle skin;

	void Start ()
	{

		Vas = GameObject.Find ("Vasilis").GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i =0; i<Vas.Getcollob().Count; i++) {
			if (Vas.Getcollob()[i].name == "Eye" && Input.GetKeyDown (KeyCode.E))
				PlayerPrefs.SetInt ("Resepy", 1);
		}

	}
}
