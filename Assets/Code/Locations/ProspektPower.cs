using UnityEngine;
using System.Collections;

public class ProspektPower : MonoBehaviour {

	public Sprite[] sprite;
	private Movement move;

	private void Start()
	{
		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();
	}

	// Update is called once per frame
	void Update () {



			if (PlayerPrefs.GetInt ("FirstPowerContact") == 0 && Application.loadedLevelName == "ProspektPower") {  
			for (int i = 0; i <move.Getcollob().Count; i++) {
				PlayerPrefs.SetInt ("DayPlus", 1);
				if (move.Getcollob () [i].name == "Door0") {
					PlayerPrefs.SetInt ("DeathWay", PlayerPrefs.GetInt ("DeathWay") + 1);
					PlayerPrefs.SetInt ("FirstPowerContact", 1);
				} else if (move.Getcollob () [i].name == "Door1") {
					PlayerPrefs.SetInt ("HaosWay", PlayerPrefs.GetInt ("HaosWay") + 1);
					PlayerPrefs.SetInt ("FirstPowerContact", 1);
				} else if (move.Getcollob () [i].name == "Door2") {
					PlayerPrefs.SetInt ("PowerWay", PlayerPrefs.GetInt ("PowerhWay") + 1);
					PlayerPrefs.SetInt ("FirstPowerContact", 1);
				}

				if (PlayerPrefs.GetInt ("Day") >= 2) {
					
					GameObject.Find ("Door0").GetComponent<DoorCol>().DoorEnter = true;		
					GameObject.Find ("Door1").GetComponent<DoorCol>().DoorEnter = true;	
					GameObject.Find ("Door2").GetComponent<DoorCol>().DoorEnter = true;	
					
					if(move.Getcollob () [i].name == "Door0"||move.Getcollob () [i].name== "Door1"||move.Getcollob () [i].name == "Door2")
					{
						PlayerPrefs.SetInt("FirstIncum",1);	
					}
					
					
				} 

			}
		}
			
			







		if (PlayerPrefs.GetInt ("Day") < 2) {
						GameObject.Find ("Door0").GetComponent<DoorCol> ().DoorEnter = false;			
						GameObject.Find ("Door1").GetComponent<DoorCol> ().DoorEnter = false;
						GameObject.Find ("Door2").GetComponent<DoorCol> ().DoorEnter = false;	
				}


			if(PlayerPrefs.GetInt ("Day") == 5){
			    
			GameObject.Find("Vasilis").GetComponent<Movement>().DrawDialog = true;
			SpriteCntrl("P1",true);
			SpriteCntrl("P2",true);
			SpriteCntrl("P3",true);
			SpriteCntrl("P4",true);
			GameObject.Find("ProspMain_5").GetComponent<SpriteRenderer>().sprite = sprite[1];
			SpriteCntrl("Fire_Door",true);
			SpriteCntrl("Fire3",true);
			SpriteCntrl("Fire2",true);
			SpriteCntrl("Fire_Hole_0",true);
			SpriteCntrl("Fire_Hole_1",true);
			SpriteCntrl("FireMan0",true);
	
			if(PlayerPrefs.GetInt ("BoyResque")==1)
			{
				SpriteCntrl("BoyRes",true);
				CollCntrl("BoyRes",true);
			}

			}else
			{
			GameObject.Find("Vasilis").GetComponent<Movement>().DrawDialog = false;
			SpriteCntrl("P1",false);
			SpriteCntrl("P2",false);
			SpriteCntrl("P3",false);
			SpriteCntrl("P4",false);
			SpriteCntrl("Fire_Door",false);
			SpriteCntrl("Fire3",false);
			SpriteCntrl("Fire2",false);
			SpriteCntrl("Fire_Hole_0",false);
			SpriteCntrl("Fire_Hole_1",false);
			SpriteCntrl("FireMan0",false);


				SpriteCntrl("BoyRes",false);
				CollCntrl("BoyRes",false);

		
		}
		if (PlayerPrefs.GetInt ("Day") < 5) {
		GameObject.Find ("ProspMain_5").GetComponent<SpriteRenderer> ().sprite = sprite [0];

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
