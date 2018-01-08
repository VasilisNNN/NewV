using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DrawLocation : MonoBehaviour {

	private List<GameObject> childs = new List<GameObject>();
	private SpriteRenderer sprt;
	private BoxCollider2D box;
	private PolygonCollider2D pol;
	private AudioSource au;
	private Days_INT_Draw days;
	public string CorLocation;

	void Start () {
		for (int i = 0; i <gameObject.transform.childCount; i++)
			childs.Add (gameObject.transform.GetChild(i).gameObject);
	}

	void FixedUpdate () {

		if (PlayerPrefs.GetString ("CorrLevel") == CorLocation) {
			foreach (GameObject c in childs) {
				if (c != null)
					OnOff (c, true);
			}
		} else
			foreach (GameObject c in childs) {
				if (c != null)
					OnOff (c, false);
			}

	}

	void OnOff(GameObject g, bool onoff)
	{
		sprt =  g.GetComponent<SpriteRenderer> ();
		box = g.GetComponent<BoxCollider2D> ();
		pol = g.GetComponent<PolygonCollider2D> ();
		au = g.GetComponent<AudioSource> ();
		days = g.GetComponent<Days_INT_Draw> ();

		if (sprt != null && sprt.enabled != onoff)
			sprt.enabled = onoff;
		if (box != null && box.enabled != onoff)
			box.enabled = onoff;
		if (pol != null && pol.enabled != onoff)
			pol.enabled = onoff;
		if (days != null && days.enabled != onoff)
			days.enabled = onoff;

		if (au != null){ 
			if(!au.isPlaying)au.Play();
			if(au.isPlaying)au.Stop();
		}
	}
}
