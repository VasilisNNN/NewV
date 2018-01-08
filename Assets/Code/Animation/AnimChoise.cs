using UnityEngine;
using System.Collections;

public class AnimChoise : MonoBehaviour {
	private Animator anim;
	private ChoiseInterface CI;
	public bool ChoiseToZero = false;
	void Start () {
		anim = GetComponent<Animator>();
		CI = GameObject.Find("ChInt").GetComponent<ChoiseInterface>();
	}

	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
		anim.SetInteger("Choise",CI.CorrentItem);

		if (ChoiseToZero)
		{
			if(Input.GetKeyUp(KeyCode.E))
				anim.SetInteger("Choise",-1);
		
		}

	}
}
