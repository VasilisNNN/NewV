using UnityEngine;
using System.Collections;

public class AnimationTriger : MonoBehaviour {
	
	  //private Animator anim;
	  private bool AnimSw;

	public bool DialogTrgr = false;
	private Movement move;
	void Start () {
		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
		if(GameObject.Find("Dialog")!=null)
	

		 //anim = GetComponent<Animator>();
	     AnimSw = false;
	}

	// Update is called once per frame
	void Update () {
		if (move.Getcollob().Contains(gameObject))
			AnimSw = true;
		else
			AnimSw = false;


		/*if (DialogTrgr && GameObject.Find("Dialog")!=null) {
			if (dialog.GetPlayIn ()&&AnimSw)
				anim.SetInteger ("AnimSw", 1);
			else if(!dialog.GetPlayIn ())
				anim.SetInteger ("AnimSw", 0);
		}else 
			anim.SetBool ("AnimSw", AnimSw);*/
	}
}
