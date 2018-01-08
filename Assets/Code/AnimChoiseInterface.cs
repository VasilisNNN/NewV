using UnityEngine;
using System.Collections;


public class AnimChoiseInterface : MonoBehaviour {
	private Animator anim;
	private ChoiseInterface CI;

	void Start () {
		anim = GetComponent<Animator>();
		CI = GameObject.Find("ChInt").GetComponent<ChoiseInterface>();
	}

	// Update is called once per frame
	void Update () {
		anim.SetInteger("AnimSw",CI.CorrentItem);

	}
}
