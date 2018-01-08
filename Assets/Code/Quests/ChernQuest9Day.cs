using UnityEngine;
using System.Collections;

public class ChernQuest9Day : MonoBehaviour {
	private ChoiseInterface CI;
	private Movement move;


	// Use this for initialization
	void Start () {

		CI = gameObject.GetComponent<ChoiseInterface>();
		CI.SetAll (false);
		
		move = GameObject.Find("Vasilis").GetComponent<Movement>();
		/*if (PlayerPrefs.GetInt ("BetonCar") == 1)
			Draw (false);*/
	}
	
	// Update is called once per frame
	void Update () {
	

		if (move.Getcollob().Contains(gameObject)&& Input.GetButtonDown ("Enter")) {
			CI.SetAll (true);
		} 



		if (CI.GetOnChoise () && CI.ReturnCorrentItem () == 2 && Input.GetButtonDown ("Enter"))
		{
			CI.SetAll(false);
		}
	
		
		
	}
	private void Draw(bool c)
	{
		GetComponent<SpriteRenderer> ().enabled = c;
		GetComponent<BoxCollider2D> ().enabled = c;
	}
}
