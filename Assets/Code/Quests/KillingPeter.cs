using UnityEngine;
using System.Collections;

public class KillingPeter : MonoBehaviour {
	private bool Shoot = false;
	public bool Charge{ get; set;}
	public bool Talk{ get; set;}
	private ChoiseInterface CI;

	private Animator anim;
	public GUIStyle skin;

	private Transform Peter;


	private Movement pl;
	private int shoot;
	private float AnimationTimer = 0;
	private Transform BulletPos;

	public bool FinalSceenShoot{ get; set;}
	public bool FinalSceenColl{ get; set; }
	private Camera cam;
	void Start () {
		cam = Camera.main;
		shoot = 0;
		Charge = true;
		FinalSceenShoot = false;
		FinalSceenColl = false;

		Talk = false;
		BulletPos = GameObject.Find ("Bullet").GetComponent<Transform> ();
		BulletPos.position = new Vector3 (cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,1f)).x*-1+0.7f,BulletPos.position.y,BulletPos.position.z);


		pl = GameObject.Find("Vasilis").GetComponent<Movement>();
		pl.DrawDialog = true;


		anim = gameObject.GetComponent<Animator>();
		CI = GameObject.Find("ChInt").GetComponent<ChoiseInterface>();
		Peter = GameObject.Find("Peter").GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

		AnimationPause ();

	if (BulletPos.position.x < 10&&Shoot)
		BulletPos.position = new Vector3 (BulletPos.position.x+0.5f,BulletPos.position.y,BulletPos.position.z);





		if (pl.DrawDialog == true) {
			CI.SetOnChoise(false);
		}
		//print (shoot);

		if(shoot==4)
		{
		FinalSceenShoot = true;
		//Shoot = false;
		}


			if (Input.GetKeyDown (KeyCode.E)) 
		{

				if (CI.ReturnCorrentItem () == 0) {	
				Shoot = false;
				pl.DrawDialog = true; 
			

				AnimationTimer = Time.fixedTime;
				anim.SetInteger ("Choise", 0);


				Peter.position = new Vector3 (Peter.position.x - 0.5f, Peter.position.y, Peter.position.z);
								}

				


			if (CI.ReturnCorrentItem () == 1) {
				pl.DrawDialog = false; 
			
				if(!Charge)
				{
				AnimationTimer = Time.fixedTime;
					BulletPos.position = new Vector3 (cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,1f)).x*-1+0.7f,BulletPos.position.y,BulletPos.position.z);

				anim.SetInteger ("Choise", 1);

										Charge = true;
				                        Shoot = false;
				Peter.position = new Vector3 (Peter.position.x -  0.5f, Peter.position.y, Peter.position.z);
				}
				}





			if (CI.ReturnCorrentItem () == 2) {

				pl.DrawDialog = false; 

										if (Charge) {
					Shoot = true;
				    shoot = Random.Range(1,7);
					anim.SetInteger ("Choise", 2);
					AnimationTimer = Time.fixedTime;
					Charge = false;
				    }

				}

						}
				
	}

	private void OnGUI()
	{

			if (Shoot&&AnimationTimer+2>Time.fixedTime&&shoot!=4) {
				        
			if(PlayerPrefs.GetInt("Language") == 0)GUI.Box(new Rect(Screen.width/2f-100f,10f,200f,100f),"Промах",skin);
			if(PlayerPrefs.GetInt("Language") == 1)GUI.Box(new Rect(Screen.width/2f-100f,10f,200f,100f),"Miss",skin);				
		}
				
	
	}


	private void OnTriggerStay2D(Collider2D c)
	{
		
		if (c.gameObject.name == "Peter") {
			FinalSceenColl = true;	
		}
	}




	private void AnimationPause()
	{


		if(anim.GetInteger("Choise")!=0 )CI.SetOnChoise (false);
		else CI.SetOnChoise (true);

		if (AnimationTimer + 1.1f>= Time.fixedTime) {
				} else {
			anim.SetInteger ("Choise", 0);	
		}



	}





}

