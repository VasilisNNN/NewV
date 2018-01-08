using UnityEngine;
using System.Collections;

public class DoorCol : MonoBehaviour {
	//public bool EnterToTheDoor{ get; set; }
	public string LevelName;
	public bool DoorEnter = true;	
	private bool DoorColl;
	public bool LoadLocation = true;
	private Inventory Inv;

	public bool NoButtonEnter = false;

	private bool SW;
	private Texture2D EnterDoor,ExitDoor;
	private Movement pl;
private void Start()
	{
		if (GameObject.Find ("Vasilis") != null) {
			Inv = GameObject.Find ("Vasilis").GetComponent<Inventory> ();
			pl = GameObject.Find("Vasilis").GetComponent<Movement> ();
		}
		EnterDoor = Resources.Load<Texture2D> ("Interface/CursorFoot");
		ExitDoor = Resources.Load<Texture2D> ("Interface/Cursor");
		//Inv.AddItem (45);
		//vas = GameObject.Find("Vasilis").GetComponent<Transform>();

		/*if (!NoButtonEnter&&LevelName==PlayerPrefs.GetString ("PrevName")) 
		{
			vas.position = new Vector3(PlayerPrefs.GetFloat("PrevX"),PlayerPrefs.GetFloat("PrevY"));
		}*/

	}
	
private void Update()
	{	
	
	//	print ("s "  + PlayerPrefs.GetString ("CorrLevel"));
		if (DoorEnter) {
				
						if (NoButtonEnter && DoorColl) {
			
				//EnterToTheDoor = true;
				Inv.SaveInv ();

				               

				PlayerPrefs.SetString ("PrevName", Application.loadedLevelName);
				           PlayerPrefs.SetString ("CorrLevel", LevelName);
				if(LoadLocation){Application.LoadLevel (LevelName);
					PlayerPrefs.SetString ("CorrLoadingLevel", LevelName);
				}
								
			}
			
			if (Input.GetMouseButtonDown(0) && DoorColl)
			{

				/*PlayerPrefs.SetFloat("PrevX",vas.position.x);
				PlayerPrefs.SetFloat("PrevY",vas.position.y);
*/
				if(Application.loadedLevelName == "StartRoom")
					PlayerPrefs.SetInt ("StartBedRoom", 1);

				//Inv.SaveInv ();
				             	PlayerPrefs.SetString ("PrevName", Application.loadedLevelName);
				              PlayerPrefs.SetString ("CorrLevel", LevelName);

				if(!LoadLocation)
				{

					if(Camera.main.GetComponent<CameraBor>()!=null)Camera.main.GetComponent<CameraBor>().Set_UpdateBounds();


				}
				if(LoadLocation)
				{

					if(Camera.main.GetComponent<CameraBor>()!=null)Camera.main.GetComponent<CameraBor>().Set_UpdateBounds();
					Application.LoadLevel (LevelName);
					//Cursor.SetCursor (ExitDoor, Vector2.zero, CursorMode.Auto);
					PlayerPrefs.SetString ("CorrLoadingLevel", LevelName);
				}

						}
				}


	}

	void OnMouseOver()
	{
		
			pl.CursorT = EnterDoor;
			//Cursor.SetCursor (EnterDoor, Vector2.zero, CursorMode.Auto);
			DoorColl = true;
	}
	void OnMouseExit()
	{
		pl.CursorT = ExitDoor;
	   //Cursor.SetCursor (ExitDoor, Vector2.zero, CursorMode.Auto);
       DoorColl = false;

	}
	public void SetDoorEnter(bool DE)
	{
		DoorEnter = DE;
	}
	public bool GetDoorEnter()
	{
		return DoorEnter;
	}




}
