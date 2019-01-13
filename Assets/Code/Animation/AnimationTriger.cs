using UnityEngine;
using System.Collections;

public class AnimationTriger : MonoBehaviour {
	
	 private Animator anim;
	  private bool AnimSw;

	public bool DialogTrgr = false;
	private Movement move;
	void Start () {
		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
	
		 anim = GetComponent<Animator>();
	     AnimSw = false;
	}

	// Update is called once per frame
	void Update () {
		if (move.Getcollob().Contains(gameObject))
			AnimSw = true;
		else
			AnimSw = false;
        
			anim.SetBool ("Start", AnimSw);
	}
}
