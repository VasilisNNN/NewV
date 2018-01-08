using UnityEngine;
using System.Collections;

public class DayPrefs_Start : MonoBehaviour {
	public int day;
	public string Iname;
	public int Inum;

	void Start () {
		if(PlayerPrefs.GetInt("Day")==day)
			PlayerPrefs.SetInt(Iname,Inum);
	}

}
