using UnityEngine;
using System.Collections;

public class Belka : MonoBehaviour {
	
	private ChoiseInterface ChInt;
	private Movement pl;


	void Start()
	{



		ChInt = GameObject.Find ("ChInt").GetComponent<ChoiseInterface> ();
		pl = GameObject.Find ("Vasilis").GetComponent<Movement> ();

		ChInt.SetAll(false);



	}


	void Update () {
				if (PlayerPrefs.GetInt ("Day") == 1 && pl.DrawDialog) {
						PlayerPrefs.SetInt ("DayPlus", 1);
				}


		}
	private void Draww(string s,bool t)
	{
		GameObject.Find (s).GetComponent<SpriteRenderer> ().enabled = t;
		GameObject.Find (s).GetComponent<BoxCollider2D> ().enabled = t;
	}
}
