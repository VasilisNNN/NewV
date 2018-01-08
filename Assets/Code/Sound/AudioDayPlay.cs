using UnityEngine;
using System.Collections;

public class AudioDayPlay : MonoBehaviour {
	private AudioSource Au;
	private int i;
	public AudioClip[] DaysClips;


	void Start () {

//////Basics
	 	Au = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("Day") - 1 < DaysClips.Length) {
						if (DaysClips [PlayerPrefs.GetInt ("Day") - 1] != null)
								Au.clip = DaysClips [PlayerPrefs.GetInt ("Day") - 1];
			            else Au.clip = null;
				} 
		if(Au.enabled)Au.Play();

	}



	void Update () {

		if (Input.GetKeyDown (KeyCode.Equals)) {
			if(i<2)i++;

			if(i>=DaysClips.Length)Au.clip = null;
			else Au.clip = DaysClips[i];

				if (Au.enabled)
				Au.Play ();
				}

		if (Input.GetKeyDown (KeyCode.Minus)) {
			if(i>=1)i--;

			if(i>=DaysClips.Length)Au.clip = null;
			else Au.clip = DaysClips[i];

			if (Au.enabled)
				Au.Play ();


				}
	}

}
