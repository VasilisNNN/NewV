using UnityEngine;
using System.Collections;

public class Cam_Prefs_Controll : MonoBehaviour {

	private Color col;
	private float fcol = 0.08f;

	public string Iname;
	public int Ivalue;
	public bool greater = false;

	void Update () {
		if (greater) {
			if (PlayerPrefs.GetInt (Iname) >= Ivalue) {
				fcol = 0.06f;
			} else
				fcol = 1;
		} else {
			if (PlayerPrefs.GetInt (Iname) == Ivalue) {
				fcol = 0.06f;
			} else
				fcol = 1;
		}



		col.b = fcol;
		col.r = fcol;
		col.g = fcol;

		Camera.main.backgroundColor = col;
	}
}
