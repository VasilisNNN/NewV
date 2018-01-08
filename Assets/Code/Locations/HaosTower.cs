using UnityEngine;
using System.Collections;

public class HaosTower : MonoBehaviour {
	public Sprite[] sprite;
	private int i;
	private float time;
	public bool DrawFirstDays = false;
	private BoxCollider2D BC;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		BC = gameObject.GetComponent<BoxCollider2D>();
		if(BC!=null)BC.enabled = false;
		time = Time.fixedTime;
		if (PlayerPrefs.GetInt ("Day") >= 10)
			i = 1;
		else
			i = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (DrawFirstDays && PlayerPrefs.GetInt ("Day") < 6)
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		else if (!DrawFirstDays && PlayerPrefs.GetInt ("Day") < 6) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			if(BC!=null)BC.enabled = false;
		
		}

		if (PlayerPrefs.GetInt ("Day") >= 6&&PlayerPrefs.GetInt ("Day") < 10) 
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			if(BC!=null)BC.enabled = true;
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
		}


		if (PlayerPrefs.GetInt ("Day") >= 10) 
		{gameObject.GetComponent<SpriteRenderer>().enabled = true;
		if(BC!=null)BC.enabled = true;
			if(time+1.5<=Time.fixedTime)
			{
			
			i =  Random.Range(1,sprite.Length-1);
			time = Time.fixedTime;

			}


			gameObject.GetComponent<SpriteRenderer>().sprite = sprite[i];
		}



	}


}
