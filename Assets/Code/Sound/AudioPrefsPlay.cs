using UnityEngine;
using System.Collections;

public class AudioPrefsPlay : MonoBehaviour {
	private AudioSource Au; 

	public string IntName;
	public int PrefsNum;

	// Use this for initialization
	void Start () {
		Au = GetComponent<AudioSource> ();
		Au.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	if (PlayerPrefs.GetInt (IntName) == PrefsNum) 
		{
			Au.enabled = true;
				}
		else Au.enabled = false;


	}
}
