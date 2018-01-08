using UnityEngine;
using System.Collections;

public class ExitFromQuestSceen : MonoBehaviour {

	public string LevelName;
	private Inventory Inv;
	private Scales scales;
private void Start()
	{
		Inv = GameObject.FindGameObjectWithTag("Inv").GetComponent<Inventory>();
	}
	
	public void FixedUpdate () {
	
	if (Input.GetKeyDown (KeyCode.Escape)) {
			PlayerPrefs.SetString("PrevName",Application.loadedLevelName);
			Inv.SaveInv();
			Application.LoadLevel (LevelName);
				}
	}
	
}
