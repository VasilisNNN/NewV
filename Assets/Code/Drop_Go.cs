using UnityEngine;
using System.Collections;

public class Drop_Go : MonoBehaviour {

	private Animator anim;
	private Mix_ChangeItems MCI;
	private bool go = false;
	public bool flip = false;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		MCI = GetComponent<Mix_ChangeItems>();
		anim = GetComponent<Animator>();

		if(PlayerPrefs.GetInt (gameObject.name) == 1){
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			go = false;
		}
	

	}
	
	// Update is called once per frame
	void Update () {

		print (gameObject.name + PlayerPrefs.GetInt (gameObject.name));
		if (flip && go&&PlayerPrefs.GetInt (gameObject.name) != 1) {
				transform.localScale = new Vector3 (transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
				flip = false;
			}

			if (MCI.GetCollisinWithItem ()) {

			if(Application.loadedLevelName == "Line")
				PlayerPrefs.SetInt("Line",PlayerPrefs.GetInt("Line")+1);

				anim.SetInteger ("AnimSw", 1);
				PlayerPrefs.SetInt (gameObject.name,1);
			if(Application.loadedLevelName == "Line")
			PlayerPrefs.SetInt ("Line",PlayerPrefs.GetInt ("Line")+1);
				go = true;

			}
		
			if (go) {
				transform.position = new Vector3 (transform.position.x - speed / 100f, transform.position.y, transform.position.z);			
	
				if (transform.position.x < -23f) 
			{	GetComponent<SpriteRenderer> ().enabled = false;
				if(PlayerPrefs.GetInt (gameObject.name) == 1){
					GetComponent<SpriteRenderer> ().enabled = false;
					GetComponent<BoxCollider2D> ().enabled = false;
					go = false;
				}
			}
			
			}


			
		
	}

}
