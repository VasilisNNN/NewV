using UnityEngine;
using System.Collections;

public class LocationExit: MonoBehaviour {
	
	public string LevelName;
	public string CorrLevel;
	
	void Update () {
		if(Input.GetButtonDown("Enter"))
		{
			PlayerPrefs.SetString("PrevName",Application.loadedLevelName);
			PlayerPrefs.SetString("CorrLevel",CorrLevel);
		Application.LoadLevel(LevelName);
		}
		
	}
}
