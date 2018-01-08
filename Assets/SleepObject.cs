using UnityEngine;
using System.Collections;

public class SleepObject : MonoBehaviour {

	private Mix_ChangeItems MCI;
	private ChoiseInterface CI;
	private ClosedDoor CD;
	private Movement Move; 
	private bool DrawNewDay = false;
	private float timer;
	private Texture textureDay;
	private Inventory Inv;
	// Use this for initialization
	void Start () {
		Inv = GameObject.Find ("Vasilis").GetComponent<Inventory> ();
		MCI = GetComponent<Mix_ChangeItems> ();
		CI = GetComponent<ChoiseInterface> ();
		CD = GetComponent<ClosedDoor>();
		Move = GameObject.Find("Vasilis").GetComponent<Movement> ();
		CI.SetAll (false);

	}
	
	// Update is called once per frame
	void Update () {
		/*if(!Inv.CheckItem(45))Inv.AddItem (45);
		if(!Inv.CheckItem(46))Inv.AddItem (46);
		if(!Inv.CheckItem(50))Inv.AddItem (50);
		if(!Inv.CheckItem(51))Inv.AddItem (51);*/
	if (MCI.GetCollisinWithItem())
	CI.SetAll (true);
		if (CI.GetOnChoise ()) {
			CD.enabled = false;
			if (Input.GetButtonDown ("Enter")) {
				if (CI.ReturnCorrentItem () == 1) {
					timer = Time.fixedTime;
					PlayerPrefs.SetInt ("EmptyWay", PlayerPrefs.GetInt ("EmptyWay") + 6);
					PlayerPrefs.SetInt ("Day", PlayerPrefs.GetInt ("Day") + 1);
					DrawNewDay = true;

					if(PlayerPrefs.GetInt ("Day")>=11||PlayerPrefs.GetInt ("Language")==0)
						textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt ("Day"));
					else if(PlayerPrefs.GetInt ("Day")<11&&PlayerPrefs.GetInt ("Language")==1)
						textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt ("Day")+"En");

					CI.SetAll (false);
				}
				if (CI.ReturnCorrentItem () == 0 && CI.GetOnChoise ()) {
					Inv.AddItem (MCI.GetCorrentNumItemList ());

					CI.SetAll (!CI.GetOnChoise ());
					//Move.SetMove (true);

				}

			}
		}
	}

	
	void OnGUI () {
		
		
		if(DrawNewDay)
		{
			CI.SetAll(false);
			if (timer + 0.3f < Time.fixedTime && timer + 4 >= Time.fixedTime) 
			{
				//Move.SetMove (false);
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), textureDay);
			}
			else if(timer+4<Time.fixedTime)
			{
				//Move.SetMove (true);
				DrawNewDay = false;
				CD.enabled = true;
			}
			
		}
		
		
	}
}
