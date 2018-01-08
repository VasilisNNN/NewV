using UnityEngine;
using System.Collections;

public class Animations_Days : MonoBehaviour {
	private Animator anim;
	private AudioSource Asource;
	public AudioClip[] audioP;
	void Start () {
		if(GetComponent<Animator>()!=null)anim = GetComponent<Animator>();
		if (GetComponent<AudioSource> () != null)
			Asource = GetComponent<AudioSource> ();
	}
	
	
	// Update is called once per frame
	void Update () {
	
		if(GetComponent<Animator>()!=null)
		anim.SetInteger("Day",PlayerPrefs.GetInt("Day"));
		if (GetComponent<AudioSource> () != null) {

			if(audioP[PlayerPrefs.GetInt ("Day")-1]!=null)
			Asource.clip = audioP [PlayerPrefs.GetInt ("Day")-1];

		}
	}
}
