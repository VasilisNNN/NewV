using UnityEngine;
using System.Collections;

public class StayInRoom : MonoBehaviour {

	private float timer;
	public float interval;
	public string names;
	public int Iset;

	// Use this for initialization
	void Start () {
		timer = Time.fixedTime+interval;
	}
	
	// Update is called once per frame
	void Update () {

		if (timer <= Time.fixedTime-interval) {
			//print ("TimerPlus");
			PlayerPrefs.SetInt (names,PlayerPrefs.GetInt (names)+Iset);
			timer = Time.fixedTime;
		}
	}
}
