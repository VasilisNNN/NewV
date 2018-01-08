using UnityEngine;
using System.Collections;

public class Titles : MonoBehaviour {

	public GUIStyle skin;
	private Rect rect;
	private float time;
	private TextB texB;
	private TextEn texEn;
	private int day = 0;
	// Use this for initialization
	void Start () {

		time = Time.fixedTime;
		texB = GetComponent<TextB>();
		texEn = GetComponent<TextEn>();
	}
	void Update()
	{
		PlayerPrefs.SetInt ("Day", day);
		if (time+5f < Time.fixedTime) {
			time = Time.fixedTime;
			day++;}
		if (day == 5) {
			PlayerPrefs.SetInt ("StartBedRoom",0);
			Application.LoadLevel ("StartMenu");
			day = 1;
		}
		
	}
	void OnGUI()
	{
		for (int i = 0; i<texB.GetLines().Length; i++) {
			rect = new Rect (Screen.width/2 - 200f,i*80f,400f,400f);

			if(PlayerPrefs.GetInt ("Language") == 0)
			GUI.Label (rect, texB.GetLines () [i], skin);

			if(PlayerPrefs.GetInt ("Language") == 1)
			GUI.Label (rect, texEn.GetLines () [i], skin);
		}
	}
}
