using UnityEngine;
using System.Collections;

public class Add_Prefabs_InSceenStart : MonoBehaviour {
	public int iint;

	public string namee;
	public int day = -1;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("Day")==day&&PlayerPrefs.GetInt("Day")>=0)
		PlayerPrefs.SetInt (namee,iint);
		else if(PlayerPrefs.GetInt("Day")<0)PlayerPrefs.SetInt (namee,iint);
	}
	

}
