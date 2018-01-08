using UnityEngine;
using System.Collections;

public class MorgStreet : MonoBehaviour {
	
	public Sprite[] sprite;
	//private Movement move;
	
	private void Start()
	{
		//move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		
		
		if(PlayerPrefs.GetInt ("Day") == 5){
			SpriteCntrl("P1",true);
			SpriteCntrl("P2",true);
			SpriteCntrl("P3",true);
			SpriteCntrl("P4",true);
			CollCntrl("P1",true);
			CollCntrl("P2",true);
			CollCntrl("P3",true);
			CollCntrl("P4",true);
			SpriteCntrl("Fireman3",true);
			SpriteCntrl("Fireman2",true);


		}else
		{
			SpriteCntrl("P1",false);
			SpriteCntrl("P2",false);
			SpriteCntrl("P3",false);
			SpriteCntrl("P4",false);
			CollCntrl("P1",false);
			CollCntrl("P2",false);
			CollCntrl("P3",false);
			CollCntrl("P4",false);
			SpriteCntrl("Fireman3",false);
			SpriteCntrl("Fireman2",false);

			
		}
		if (PlayerPrefs.GetInt ("Day") < 5) {
		}
		
		
	}
	private void SpriteCntrl(string ob,bool on)
	{
		GameObject.Find(ob).GetComponent<SpriteRenderer>().enabled = on;
	}
	private void CollCntrl(string ob,bool on)
	{
		GameObject.Find(ob).GetComponent<BoxCollider2D>().enabled = on;
	}
}
