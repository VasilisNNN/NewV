using UnityEngine;
using System.Collections;

public class Kitchen : MonoBehaviour {
	private Movement Vas;
	public GUIStyle skin;
	private Rect rect;
	private Inventory Inv;
	// Use this for initialization
	void Start ()
	{
	rect = new Rect(100f,80f,400f,100f);
	Vas = GameObject.Find ("Vasilis").GetComponent<Movement>();
	Inv = GameObject.Find ("Vasilis").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i =0; i<Vas.Getcollob().Count; i++) {
			if (Vas.Getcollob()[i].name == "BombCraft" && Input.GetKeyDown (KeyCode.E)) {
				if (PlayerPrefs.GetInt ("Resepy") == 1) {
					Inv.SaveInv ();
					Application.LoadLevel ("BombCraft");
				}
			}
		}
	}


	void OnGUI()
	{
		for (int i = 0; i<Vas.Getcollob().Count; i++) {
			if (Vas.Getcollob () [i].name == "BombCraft" && Input.GetKey (KeyCode.E)) {
				if (PlayerPrefs.GetInt ("Resepy") == 0)
					GUI.Label (rect, "Чтобы что-то создать, нужен рецепт", skin);
			}
		}
	}


}
