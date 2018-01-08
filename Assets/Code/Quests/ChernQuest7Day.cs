using UnityEngine;
using System.Collections;

public class ChernQuest7Day : MonoBehaviour {
	private ChoiseInterface CI;
	private Movement move;

	private Camera mainCam;
	private Transform CamPos;
	private bool go;
	private Transform[] Wheel = new Transform[3];
	//private Transform CamSHPos;

	private float speed = 0.01f;
	private float rotation = 20;
	private float timer;
	private float CamShakeBor;
	private BoxCollider2D CamSH;

	private AudioSource AU;
	public AudioClip[] Clip;
	private void Awake()
	{
		AU = GetComponent<AudioSource> ();


		if (PlayerPrefs.GetInt ("ChinCar") == 2&&Application.loadedLevelName == "Plocha")
		transform.position = new Vector3 (PlayerPrefs.GetFloat ("ChinCar_X"), PlayerPrefs.GetFloat ("ChinCar_Y"), transform.position.z);

		if (PlayerPrefs.GetInt ("ChinCar") == 3&&Application.loadedLevelName == "Fabric0")
			transform.position = new Vector3 (PlayerPrefs.GetFloat ("ChinCar_X"), PlayerPrefs.GetFloat ("ChinCar_Y"), transform.position.z);

	}

	// Use this for initialization
	void Start () {

		GameObject CSH = GameObject.Find ("CamSH");
		if (CSH != null) {
			CamSH = CSH.GetComponent<BoxCollider2D> ();
			//CamSHPos = CSH.GetComponent<Transform> ();
		}


		for (int i = 0; i<Wheel.Length; i++) {

			if (GameObject.Find ("Wheell"+i) != null)
				Wheel[i] = GameObject.Find ("Wheell"+i).GetComponent<Transform> ();
		}


		mainCam = Camera.main;
		CamPos = mainCam.GetComponent<Transform>();
		CI = gameObject.GetComponent<ChoiseInterface>();

		if(CI!=null)CI.SetAll (false);
		
		move = GameObject.Find("Vasilis").GetComponent<Movement>();

		CamShakeBor = 0.2f;
		/*if (PlayerPrefs.GetInt ("BetonCar") == 1)
			Draw (false);*/
	}

	// Update is called once per frame
	void Update () {



		if (Application.loadedLevelName == "Pereulock1") {

			if (move.Getcollob().Contains(gameObject)&&Input.GetButtonDown("Enter")) 
			{
				if(CI.ReturnCorrentItem () == 0)CI.SetAll(!CI.GetOnChoise());
			}

		

			if (CI.GetOnChoise () && CI.ReturnCorrentItem () == 1 && Input.GetButtonDown ("Enter")) {

				CI.SetAll (false);
				PlayerPrefs.SetInt ("ChinCar", 0);
				Application.LoadLevel ("Fabric0");
			}
			if (CI.GetOnChoise () && CI.ReturnCorrentItem () == 2 && Input.GetButtonDown ("Enter")) {
				
				CI.SetAll (false);
				PlayerPrefs.SetInt ("ChinCar", 0);
				Application.LoadLevel ("Plocha");
			}


		} 

		if(Application.loadedLevelName == "Fabric0"){



			if (PlayerPrefs.GetInt ("ChinCar")>=2) 
			{
			
				if(AU.isPlaying)AU.Stop();
			}

				if (transform.position.x < 11f)
				{   
				Less();
				}
				else if(transform.position.x >= 10f){



				if(timer>Time.fixedTime){CameraShakeM();
					PlayerPrefs.SetInt ("ChinCar", 1);
					AU.clip = Clip[1];
					if(!AU.isPlaying)AU.Play();
					PlayerPrefs.SetInt("PowerWay",PlayerPrefs.GetInt("PowerWay")+3);
				}
					if(timer<Time.fixedTime)
					{
						
					if(PlayerPrefs.GetInt ("ChinCar")==1)

					{   Application.LoadLevel("FabricInHall");
						Draw (true,"Vasilis");
						PlayerPrefs.SetFloat("ChinCar_X",transform.position.x);
						PlayerPrefs.SetFloat("ChinCar_Y",transform.position.y);
						PlayerPrefs.SetInt ("ChinCar", 3);

					}
					}

				}

			
		}

		if(Application.loadedLevelName == "Plocha"){
			

			if (PlayerPrefs.GetInt ("ChinCar")>=2) 
			{
				
				if(AU.isPlaying)AU.Stop();
			}


			if (transform.position.x < 10f)
			{   
				Less();
			}
			else if(transform.position.x >= 9f){
				

				
				if(timer>Time.fixedTime){CameraShakeM();
					PlayerPrefs.SetInt ("ChinCar", 1);
					AU.clip = Clip[1];
					if(!AU.isPlaying)AU.Play();
					PlayerPrefs.SetInt("FireWay",PlayerPrefs.GetInt("FireWay")+3);
				}
				if(timer<Time.fixedTime)
				{
					
					if(PlayerPrefs.GetInt ("ChinCar")==1)
					{   
						Draw (true,"Vasilis");
						PlayerPrefs.SetFloat("ChinCar_X",transform.position.x);
						PlayerPrefs.SetFloat("ChinCar_Y",transform.position.y);
						PlayerPrefs.SetInt ("ChinCar", 2);
						PlayerPrefs.SetInt ("MonumentFall", 1);
						mainCam.GetComponent<CameraBor>().enabled =true;
					}
				}
				
			}
			
			
		}
	}



	private void Draw(bool c,string b)
	{
		GameObject.Find(b).GetComponent<SpriteRenderer> ().enabled = c;
		GameObject.Find(b).GetComponent<BoxCollider2D> ().enabled = c;
	}
	private void CameraShakeM()
	{
		if(CamShakeBor>=0.02)CamShakeBor -= 0.02f;

		if (CamPos.position.y < CamSH.bounds.min.y) {
			CamShakeBor *= -1f;

		}
		if (CamPos.position.y > CamSH.bounds.max.y) {

			CamShakeBor *= -1f;

		}
		
		CamPos.position = new Vector3 (CamPos.position.x, CamPos.position.y + CamShakeBor, CamPos.position.z);


	}
	private void Less()
	{
		if(PlayerPrefs.GetInt ("ChinCar")==0){
		float r = 1;

		Draw (false,"Vasilis");
		speed += 0.01f;
		rotation += 0.3f;
		if(!AU.isPlaying)AU.Play();
		mainCam.GetComponent<CameraBor>().enabled =false;
		move.SetDraw(false);
		timer = Time.fixedTime+1f;
		r -= rotation;
		//CamSHPos = CamPos;
		
		for(int i = 0;i<Wheel.Length;i++)
		{Wheel[i].Rotate (new Vector3 (0f, 0f, r));}
		
		AU.clip = Clip[0];
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, 1f);
		CamPos.position = new Vector3 (transform.position.x, CamPos.position.y, CamPos.position.z);
		}

	}

}
