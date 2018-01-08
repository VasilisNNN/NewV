using UnityEngine;
using System.Collections;

public class Tube_Move_Boiler : MonoBehaviour {

	private Movement move;
	public BoxCollider2D[] V;
	private Animator anim;
	private int a ;

	private float timer;
	private SpriteRenderer sprite;
	private AudioSource Au;
	void Awake () {
	
		anim = GetComponent<Animator>();
		/*if (PlayerPrefs.GetInt (gameObject.name) == null) {
			anim.SetInteger ("AnimSw", tr);
			PlayerPrefs.SetInt (gameObject.name,tr);

		}*/
		Au = GetComponent<AudioSource> ();


		move = GameObject.Find("Vasilis").GetComponent<Movement>();
		timer = Time.fixedTime;
		sprite = GetComponent<SpriteRenderer> ();
		//anim.SetInteger("AnimSw",PlayerPrefs.GetInt(gameObject.name));
		if (PlayerPrefs.GetInt(gameObject.name) == 0 || PlayerPrefs.GetInt(gameObject.name) == -2|| PlayerPrefs.GetInt(gameObject.name) == 2)
			PlayerPrefs.SetFloat(gameObject.name+"tr",-1);
		else
			PlayerPrefs.SetFloat(gameObject.name+"tr",1);


		if(PlayerPrefs.GetInt(gameObject.name) == 1|| PlayerPrefs.GetInt(gameObject.name) == -2)
			
			PlayerPrefs.SetInt(gameObject.name + "l",2);	
		else
			
			PlayerPrefs.SetInt(gameObject.name + "l",-1);	

	}

	void Start()
	{
		//anim.SetInteger("AnimSw",PlayerPrefs.GetInt(gameObject.name));
		transform.localScale = new Vector3 (transform.localScale.x * PlayerPrefs.GetFloat(gameObject.name+"tr"), transform.localScale.y, transform.localScale.z);

	}
	void Update () {

		sprite.sortingOrder = PlayerPrefs.GetInt(gameObject.name + "l");


			anim.SetInteger ("AnimSw", PlayerPrefs.GetInt (gameObject.name));


		a = PlayerPrefs.GetInt (gameObject.name);
		if (timer + 0.7f < Time.fixedTime) {
			for(int i = 0; i<V.Length; i++){
			if (move.Getcollob().Contains(V[i].gameObject)&& Input.GetButtonDown ("Enter")) {



				
					anim.SetInteger("AnimSw",PlayerPrefs.GetInt(gameObject.name));
					Au.Play();
				timer = Time.fixedTime;
					transform.localScale = new Vector3 (transform.localScale.x * PlayerPrefs.GetFloat(gameObject.name+"tr"), transform.localScale.y, transform.localScale.z);




					if (PlayerPrefs.GetInt(gameObject.name) > -2)
						PlayerPrefs.SetInt(gameObject.name,PlayerPrefs.GetInt(gameObject.name)-1);
				else
				
						PlayerPrefs.SetInt(gameObject.name,1);
					


				if(PlayerPrefs.GetInt(gameObject.name) == 1|| PlayerPrefs.GetInt(gameObject.name) == -2)
			
					PlayerPrefs.SetInt(gameObject.name + "l",2);	
			    else
				
					PlayerPrefs.SetInt(gameObject.name + "l",-1);	



					if (PlayerPrefs.GetInt(gameObject.name) == 0 || PlayerPrefs.GetInt(gameObject.name) == -2)
						PlayerPrefs.SetFloat(gameObject.name+"tr",-1);
					else if(PlayerPrefs.GetInt(gameObject.name) == 1 || PlayerPrefs.GetInt(gameObject.name) == -1)
						PlayerPrefs.SetFloat(gameObject.name+"tr",1);
					
				

				}
			}
		}

	

	}
	public int GetA()
	{

		return a;
	}
}
