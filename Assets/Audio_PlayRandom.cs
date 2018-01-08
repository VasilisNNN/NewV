using UnityEngine;
using System.Collections;

public class Audio_PlayRandom : MonoBehaviour {
	private AudioSource Au;
	public bool play = false;
	// Use this for initialization
	void Awake () {
		Au = GetComponent<AudioSource>();
		//Au.SetScheduledStartTime(1);
		Au.time = Random.Range(0,Au.clip.length-1);
		if (!Au.isPlaying&&play)
			Au.Play ();
	}
}
