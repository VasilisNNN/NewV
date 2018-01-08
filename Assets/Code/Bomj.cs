using UnityEngine;
using System.Collections;

public class Bomj : MonoBehaviour {
	private Mix_ChangeItems MCI;
	private Animator anim;
	void Awake()
	{MCI = GetComponent<Mix_ChangeItems>();
		anim = GetComponent<Animator>();

	}
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Bomj") == 1) {
			MCI.enabled = false;
			anim.SetBool ("Sw", true);
		} else {
			MCI.enabled = true;
			anim.SetBool ("Sw", false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	if (MCI.GetCollisinWithItem ()) {
			PlayerPrefs.SetInt("Bomj",1);
			anim.SetBool("Sw", true);
			MCI.enabled = false;
		}
	}
}
