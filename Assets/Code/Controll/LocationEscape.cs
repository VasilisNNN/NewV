using UnityEngine;
using System.Collections;

public class LocationEscape: MonoBehaviour {
	
	public string LevelName;
	public string CorrLevel;
	private Inventory Inv;
	void Start()
	{
		if(GameObject.Find ("Inventory")!=null)Inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
	}
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{if(GameObject.Find ("Inventory")!=null)Inv.SaveInv();
			PlayerPrefs.SetString("PrevName",Application.loadedLevelName);
			PlayerPrefs.SetString("CorrLevel",CorrLevel);
		Application.LoadLevel(LevelName);
		}
		
	}
}
