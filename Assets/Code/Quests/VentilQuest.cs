using UnityEngine;
using System.Collections;

public class VentilQuest : MonoBehaviour {

	private bool DoorColl;
	private bool i;
	private int power,death,live,haos,fire,empty;
	// Update is called once per frame
	void Awake()
	{
		power = PlayerPrefs.GetInt("PowerWay");
		death = PlayerPrefs.GetInt("DeathWay");
		live = PlayerPrefs.GetInt("LiveWay");
		haos = PlayerPrefs.GetInt("HaosWay");
		empty = PlayerPrefs.GetInt("EmptyWay");
		fire = PlayerPrefs.GetInt("FireWay");
	}
	void Start()
	{
		if (PlayerPrefs.GetInt (gameObject.name) == 1)
			i = true;
		else
			i = false;
	}

	void Update () {
	

		if (PlayerPrefs.GetInt ("FirstVent") <2) {

			if (DoorColl && Input.GetButtonDown ("Enter")) {


				i = !i;
				PlayerPrefs.SetInt (gameObject.name, i.GetHashCode ());

			}
			if (DoorColl && Input.GetButtonUp ("Enter")) {
				if (!i) {
					PlayerPrefs.SetInt ("DeathWay", death);
					PlayerPrefs.SetInt ("PowerWay", power);
					PlayerPrefs.SetInt ("HaosWay", haos);
				
					PlayerPrefs.SetInt ("FireWay", fire + 1);
					PlayerPrefs.SetInt ("EmptyWay", empty + 1);
					PlayerPrefs.SetInt ("LiveWay", live + 1);
				} else if (i) {
					PlayerPrefs.SetInt ("DeathWay", death + 1);
					PlayerPrefs.SetInt ("PowerWay", power + 1);
					PlayerPrefs.SetInt ("HaosWay", haos + 1);
				
					PlayerPrefs.SetInt ("FireWay", fire);
					PlayerPrefs.SetInt ("EmptyWay", empty);
					PlayerPrefs.SetInt ("LiveWay", live);
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			DoorColl = true;
		} 
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			DoorColl = false;
		} 
	}
}
