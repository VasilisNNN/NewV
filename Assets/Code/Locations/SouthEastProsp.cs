using UnityEngine;
using System.Collections;

public class SouthEastProsp : MonoBehaviour {

	public int[] Days;

	private Rect pos = new Rect(300,200,100,70);
	private DoorCol DC;
	public GUIStyle skin;
	private string T;
	// Use this for initialization
	void Start () {
		DC = GameObject.Find ("DoorWrite").GetComponent<DoorCol> ();
	}
	
	// Update is called once per frame
	void OnGUI () {
		//if(DC.DoorColl)GUI.Box(pos,T,skin);

		if (PlayerPrefs.GetInt ("Day") == 3 || PlayerPrefs.GetInt ("Day") == 4) {
						DC.DoorEnter = true;
			T = "Открыто";		
		}
		else {T = "Закрыто";

						DC.DoorEnter = false;
		
				//if(PlayerPrefs.GetInt ("Day") <3 &&DC.DoorColl)	T = "Дверь заперта";	
				//else if(PlayerPrefs.GetInt ("Day") >4&&DC.DoorColl )T = "Дверь запечатана. Вы опоздали";		


			}
	
	}
}
