using UnityEngine;
using System.Collections;

public class HospitalHall2 : MonoBehaviour {

	private Mix_ChangeItems MixZaval;
	private GameObject Kid;

	void Start () {

		if(GameObject.Find("BoyBig")!=null)Kid = GameObject.Find("BoyBig");
		MixZaval = GameObject.Find ("BoyResque").GetComponent<Mix_ChangeItems> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Kid != null) {
			if (Kid.activeSelf) {
				if (Kid.transform.position.x < -23f) 
					Kid.GetComponent<SpriteRenderer> ().enabled = false;
			
			}
		}
		if (Kid != null) {
			if (MixZaval.GetCollisinWithItem ()) {
				Kid.GetComponent<SpriteRenderer> ().enabled = true; 
				PlayerPrefs.SetInt ("BoyResque", 1);
			}
			if (Kid.GetComponent<SpriteRenderer> ().enabled == true)
				Kid.transform.position = new Vector3 (Kid.transform.position.x - 0.07f, Kid.transform.position.y, Kid.transform.position.z);			

		}
	}
}
