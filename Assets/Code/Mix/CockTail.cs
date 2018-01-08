using UnityEngine;
using System.Collections;

public class CockTail : MonoBehaviour {

	//private Mix_ChangeItems MCI;
	private ChoiseInterface CI;
	public int[] number ;
	private int FinalCock;
	private int Count = 0;
	private DialogItem DI;

	private Mix_ChangeItems MCI;
	private bool t;
	private float timer;
	private bool drawday = false;
	private Inventory Inv;
	void Start () {
		Inv = GameObject.Find("Inventory").GetComponent<Inventory>();
		CI = GameObject.Find("ChInt").GetComponent<ChoiseInterface>();
		DI = gameObject.GetComponent<DialogItem>();
		MCI = gameObject.GetComponent<Mix_ChangeItems> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	




			if (MCI.GetCollisinWithItem ()) {
				t = true;
			}
			
			if (t && DI.PlayIn == false) {


				CI.SetAll (true);
				t = false;
			}
		


			if (Count == 3 && Input.GetButtonDown ("Enter")) {
				CI.SetAll (false);
				Count = 0;

			}


			for (int i = 0; i<number.Length; i++) {
				//print(i);
				if (CI.ReturnCorrentItem () == i && CI.GetOnChoise ()) {
					//print("add");
					if (Input.GetButtonDown ("Enter")) {
			
						FinalCock += number [i];
						Count++;

					}
				}
			}
		if (Count == 3) {
			if (FinalCock >= 50) {
				PlayerPrefs.SetInt ("BlackPeter", 1);
				CI.SetAll (false);
				timer = Time.fixedTime;
				PlayerPrefs.SetInt ("Day", PlayerPrefs.GetInt ("Day") + 1);
				drawday = true;
				FinalCock = 0;

			} else if (FinalCock < 50&&FinalCock>0) {
				Inv.AddItem (2);
				CI.SetAll (false);
				FinalCock = 0;
			}
		}
	}



	void OnGUI()
	{
		Texture textureDay;
		textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt("Day"));
		if (drawday) {

			if (timer + 4 >= Time.fixedTime) 
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), textureDay);		
		}
	}
}
