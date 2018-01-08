using UnityEngine;
using System.Collections;

public class Pereulock1_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Day") == 7) {
			CollCntrl("DoorPeter",true);	
		}else CollCntrl("DoorPeter",false);	
	}
	private void SpriteCntrl(string ob,bool on)
	{
		GameObject.Find(ob).GetComponent<SpriteRenderer>().enabled = on;
	}
	private void CollCntrl(string ob,bool on)
	{
		GameObject.Find(ob).GetComponent<BoxCollider2D>().enabled = on;
	}
}
