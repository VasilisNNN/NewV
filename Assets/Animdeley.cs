using UnityEngine;
using System.Collections;

public class Animdeley : MonoBehaviour {
	private float timer;
	public float deley = 10;
	private Animator Anim; 
	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator> ();
		timer = Time.fixedTime+deley;
	}
	
	// Update is called once per frame
	void Update () {
	

		if (timer < Time.fixedTime) {
			Anim.SetBool("AnimSw",true);
			timer = Time.fixedTime+deley;
		}
		else Anim.SetBool("AnimSw",false);
	}
}
