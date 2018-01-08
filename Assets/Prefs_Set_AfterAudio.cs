using UnityEngine;
using System.Collections;

public class Prefs_Set_AfterAudio : MonoBehaviour {
	public AudioSource AU;
	public string ConditionName,Name;
	public int ConditionValue,Value;

	void Awake()
	{
		if (PlayerPrefs.GetInt (ConditionName) == ConditionValue) {
			//AU.playOnAwake = true;
			AU.Play ();
		}
	}

	void Update () {


		if (!AU.isPlaying&&PlayerPrefs.GetInt(ConditionName)== ConditionValue)
			PlayerPrefs.SetInt (Name, Value);
	}
}
