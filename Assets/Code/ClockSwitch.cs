using UnityEngine;
using System.Collections;

public class ClockSwitch : MonoBehaviour {
	private Movement move;
	void Awake()
	{
		if (PlayerPrefs.GetInt ("PlayDay") == 1||PlayerPrefs.GetInt ("Day")>1) 
		{
			gameObject.GetComponent<AudioSource>().enabled = false;
			gameObject.GetComponent<AudioSource>().playOnAwake = false;
			
			gameObject.GetComponent<SpriteRenderer>().enabled = false;	
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			
		}else gameObject.GetComponent<AudioSource>().playOnAwake = true;
	}


	void Start()
	{
		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
		if (PlayerPrefs.GetInt ("PlayDay") == 0||PlayerPrefs.GetInt ("Day")==1) 
		{
			/*gameObject.GetComponent<AudioSource>().enabled = false;
			gameObject.GetComponent<AudioSource>().playOnAwake = false;*/

			gameObject.GetComponent<SpriteRenderer>().enabled = true;	
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			
		}
	}



	// Update is called once per frame
	void Update () 
	{
		for(int i = 0 ; i<move.Getcollob().Count;i++)
		    {
			if(move.Getcollob()[i].tag == "Clock")
			PlayerPrefs.SetInt ("PlayDay",1);	
		
		}

		if (PlayerPrefs.GetInt ("PlayDay") == 1) 
		{
			gameObject.GetComponent<AudioSource>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;	
			gameObject.GetComponent<BoxCollider2D>().enabled = false;

		}
	}


}
