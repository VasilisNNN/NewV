using UnityEngine;
using System.Collections;

public class InventItemAnimation : MonoBehaviour {

	private ChoiseInterface CI;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		CI = GameObject.Find ("ChInt").GetComponent<ChoiseInterface> ();
	}
	
	// Update is called once per frame
	void Update () {
		print (CI.ReturnCorrentItem());
		anim.SetInteger("AnimSw",CI.ReturnCorrentItem());
	}
}
