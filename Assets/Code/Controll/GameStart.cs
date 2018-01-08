using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	private string FirstLevel;

	private float timer;
	private bool Startt = false;
	private Inventory Inv;

	private TriggerMouse sstart;
	private TriggerMouse ccontinue;
	private TriggerMouse settings;
	private TriggerMouse contacts;
	private TriggerMouse exit;
	Texture textureDay;
	void Awake()
	{

		FirstLevel = "StartRoom";
		
		Inv = GameObject.Find ("Inv").GetComponent<Inventory> ();
		sstart = GameObject.Find ("Start").GetComponent<TriggerMouse> ();

		if(GameObject.Find ("Continue")!=null)
			ccontinue = GameObject.Find ("Continue").GetComponent<TriggerMouse> ();

		settings = GameObject.Find ("Settingss").GetComponent<TriggerMouse> ();
		contacts= GameObject.Find ("Contacts").GetComponent<TriggerMouse> ();
		exit = GameObject.Find ("Exit").GetComponent<TriggerMouse> ();
	}




	void Update () {
	
			
			if (sstart.GetClicked ()) {
				Game_start ();
			}


			if (ccontinue.GetClicked ()) {
				Game_continue ();
			}

			if (settings.GetClicked ()) {
			Application.LoadLevel("Settings");
			}
		if (contacts.GetClicked ()) {
			Application.LoadLevel("Support");
		}

			if (exit.GetClicked ()) {
				Application.Quit ();
			}




			    /*if(Input.GetMouseButton(0)||Input.GetButtonDown("Enter"))
		{
		
		}*/
	
	}
	void OnGUI()
	{

			if (Startt) {
				if (timer + 4 >= Time.fixedTime) {

				if(PlayerPrefs.GetInt ("Language")==0)textureDay = Resources.Load<Texture2D> ("Days/Day1");
				if(PlayerPrefs.GetInt ("Language")==1)textureDay = Resources.Load<Texture2D> ("Days/Day1En");
					GUI.DrawTexture (new Rect (Screen.width/2  - 1366f/2f, 0, 1366f, 768f), textureDay);
				} 
				if (timer + 3 < Time.fixedTime) {
					Application.LoadLevel (FirstLevel);
				}
			}

	}
	private void Game_start()
	{
		int L = PlayerPrefs.GetInt ("Language");
		PlayerPrefs.DeleteAll ();
		Inv.SaveInvNULL();

		Startt = true;
		timer = Time.fixedTime;

		PlayerPrefs.SetInt ("GasMaskMen",0);
		PlayerPrefs.SetInt ("Line",0);
		PlayerPrefs.SetInt ("FirstVent",0);

		PlayerPrefs.SetInt ("Soldat0", 0);
		PlayerPrefs.SetInt ("Soldat1", 0);

		PlayerPrefs.SetInt ("Tubes_0", 0);
		PlayerPrefs.SetInt ("Tubes_1", 0);
		PlayerPrefs.SetInt ("Tubes_2", 0);
		PlayerPrefs.SetInt ("Tubes_3", 0);
		PlayerPrefs.SetInt ("Tubes_4", 0);
		PlayerPrefs.SetInt ("Tubes_5", 0);
		PlayerPrefs.SetInt ("Tubes_6", 0);
	


		PlayerPrefs.SetInt ("Language", L);


		PlayerPrefs.SetInt("Fen", 0);
		PlayerPrefs.SetInt("DoorFatBodyOpen", 0);
		PlayerPrefs.SetInt("DoorFatBody"+"SpriteNum", 1);

		PlayerPrefs.SetInt("HospCons", 0);

		PlayerPrefs.SetInt("ChinCar_Return", 0);

		PlayerPrefs.SetInt ("PowerProsp_Police",1);
		PlayerPrefs.SetInt ("PowerProsp_Gov",1);
		PlayerPrefs.SetInt ("PowerProsp_Holpital",1);
		PlayerPrefs.SetInt ("Sleep_Light",1);
		PlayerPrefs.SetInt ("Empty_Light",1);

		PlayerPrefs.SetInt ("Breathing_Men",0);

		PlayerPrefs.SetInt ("FireLeft",0);
		PlayerPrefs.SetInt ("FireRight",0);
		PlayerPrefs.SetInt ("FaceVector",1);

		PlayerPrefs.SetInt ("BetonCar", 0);
		PlayerPrefs.SetInt ("Capsule_sp", 0);
		PlayerPrefs.SetInt ("StartBedRoom", 0);

		PlayerPrefs.SetInt("CrowdItemOne",0);
		PlayerPrefs.SetInt("2CrowdItem",0);
		PlayerPrefs.SetInt("3CrowdItem",0);

		PlayerPrefs.SetInt("Hole",0);
		PlayerPrefs.SetInt("Burning5D",-1);
		PlayerPrefs.SetInt("KidA",0);
		PlayerPrefs.SetInt("BlackPeter",0);

		PlayerPrefs.SetInt ("ChinCar", -1);
		PlayerPrefs.SetInt("PowerProsp_Police",1);
		PlayerPrefs.SetInt("PowerProsp_Gov",1);
		PlayerPrefs.SetInt("PowerProsp_Hospital",1);
		PlayerPrefs.SetInt("Son_North",1);
		PlayerPrefs.SetInt("Son_South",1);
		PlayerPrefs.SetInt("Empty",1);


		PlayerPrefs.SetString("CorrLevel","no");
		PlayerPrefs.SetInt("BombDoorOpen",0);
		PlayerPrefs.SetInt("Day",1);
		PlayerPrefs.SetInt("DayPlus",0);
		PlayerPrefs.SetInt("FirstPowerContact",0);	
		
		
		PlayerPrefs.SetFloat("TimerLong",1.5f);	
		
		PlayerPrefs.SetInt("PowerWay",0);
		PlayerPrefs.SetInt("DeathWay",0);
		PlayerPrefs.SetInt("HaosWay",0);
		PlayerPrefs.SetInt("LiveWay",0);
		PlayerPrefs.SetInt("EmptyWay",0);	
		PlayerPrefs.SetInt("FireWay",0);

		PlayerPrefs.SetInt ("BoyResque", 0);
		PlayerPrefs.SetInt ("Ventil", 0);
		PlayerPrefs.SetInt ("ChernIn",0); 

		PlayerPrefs.SetInt ("PeterMeetRiver",0);
		PlayerPrefs.SetInt ("PeterMeetFire",0);
		
		PlayerPrefs.SetInt ("PrevI",0);
		PlayerPrefs.SetString ("SpriteNameBoxBomb","");
		PlayerPrefs.SetInt("Resepy",0);
		PlayerPrefs.SetInt("BathRoomOn",0);

		PlayerPrefs.SetInt("Eye0",0);
		PlayerPrefs.SetInt("Eye1",0);
		PlayerPrefs.SetInt("Hand0",0);
		PlayerPrefs.SetInt("Hand1",0);
		PlayerPrefs.SetInt ("FullPeter",0);

		PlayerPrefs.SetInt("Hole",0);
		PlayerPrefs.SetInt("HoleFabric",0);
		PlayerPrefs.SetInt("HoleSleep",0);
		PlayerPrefs.SetInt("HoleSklep",0);
		PlayerPrefs.SetInt("HoleBiblio",0);
		PlayerPrefs.SetInt("HoleBiblio2",0);

		PlayerPrefs.SetInt("NeighbourDoor",0);
		PlayerPrefs.SetInt ("Mix_Seed", 0);

		

	}
	private void Game_continue()
	{
		if (PlayerPrefs.GetString ("CorrLevel") != null) {

			Application.LoadLevel (PlayerPrefs.GetString ("CorrLoadingLevel"));

		}
	
	}

}
