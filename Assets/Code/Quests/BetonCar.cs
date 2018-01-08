using UnityEngine;
using System.Collections;

public class BetonCar : MonoBehaviour {
	private ChoiseInterface CI;
	private Movement move;
	private Camera mainCam;
	private bool go;
	private Transform Wheel0;
	private Transform Wheel1;
	private Transform Wheel2;

	// Use this for initialization
	void Start () {

		Wheel0 = GameObject.Find("Wheel0").GetComponent<Transform> ();
		Wheel1 = GameObject.Find("Wheel1").GetComponent<Transform> ();
		Wheel2 = GameObject.Find("Wheel2").GetComponent<Transform> ();
		mainCam = Camera.main;

		CI = gameObject.GetComponent<ChoiseInterface>();
		CI.SetAll (false);

		move = GameObject.Find("Vasilis").GetComponent<Movement>();
		/*if (PlayerPrefs.GetInt ("BetonCar") == 1)
			Draw (false);*/
	}
	
	// Update is called once per frame
	void Update () {

		float r = 1;

		if (move.Getcollob().Contains(gameObject)&&Input.GetButtonDown("Enter")) 
		{
			if(CI.ReturnCorrentItem () == 0){
			CI.SetAll(!CI.GetOnChoise());
			
			
			}
		}


		if (CI.GetOnChoise () && CI.ReturnCorrentItem () == 1 && Input.GetButtonDown ("Enter"))
		{
			move.SetDraw(false);
			CI.SetAll(false);
			go = true;
			GameObject.Find("Vasilis").GetComponent<SpriteRenderer>().enabled = false;

			GameObject.Find("MainCam").GetComponent<CameraBor>().enabled = false;
		}

		if (transform.position.x < -30f) {
			PlayerPrefs.SetInt("BetonCar",2);
			PlayerPrefs.SetString ("PrevName", "Facric0");
			PlayerPrefs.SetString ("CorrLevel", "Pereulock0");
			PlayerPrefs.SetString ("CorrLoadingLevel", "Pereulock0");
			Application.LoadLevel("Pereulock0");

		}
		if (go) {
			if (transform.position.x > -30f){
				r+=20;
				Wheel0.Rotate (new Vector3(0f,0f,r));
				Wheel1.Rotate (new Vector3(0f,0f,r));
				Wheel2.Rotate (new Vector3(0f,0f,r));
				transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, 1f);
			}
			if (transform.position.x > -12f) {
				mainCam.transform.position = new Vector3 (gameObject.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
			}
		}


	}
	private void Draw(bool c)
	{
		GetComponent<SpriteRenderer> ().enabled = c;
		GetComponent<BoxCollider2D> ().enabled = c;
	}
}
