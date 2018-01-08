using UnityEngine;
using System.Collections;

public class Prefs_SetAfter_GiveItem : MonoBehaviour {
	private Mix_ChangeItems MCI;
	public string namee;
	public int i;
	public bool pluss = false;

	private int tt = 0;
	void Start () {
		MCI = GetComponent<Mix_ChangeItems> ();
	}

	void Update () {


			if (MCI.GetCollisinWithItem ()) {

			if (!pluss && tt == 0) {
	
				PlayerPrefs.SetInt (namee, i);
				tt = 1;
			} else if (tt == 0) {

				PlayerPrefs.SetInt (namee, PlayerPrefs.GetInt (namee) + i);
				tt = 1;
			}
		} else
			tt = 0;
		
	}

}
