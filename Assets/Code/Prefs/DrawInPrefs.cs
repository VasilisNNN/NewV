using UnityEngine;
using System.Collections;

public class DrawInPrefs : MonoBehaviour {
    public GameObject[] Targets;
    public string[] PrefName;
    public float[] PrefNum;
	public string[] PrefString;
	public bool DestroyIfNotEquel;
	public bool DestroyIfEquel;
	public bool OnlyOnStart;
	void Awake () {	
		//print ("Death"+PlayerPrefs.GetInt (name+"Death"));
		if (PlayerPrefs.GetInt ("AllDAreAlive") == 1) {
			for (int i = 0; i < Targets.Length; i++) {
				PlayerPrefs.DeleteKey (PrefName [i]); 
			}
		}
	}
	void Start()
	{
		if(OnlyOnStart)Floatonoff ();

	}

	void Update () {
		if(!OnlyOnStart)Floatonoff ();
		if (PrefString.Length > 0) 
	    {

			for (int i = 0; i < Targets.Length; i++) {
				if (PlayerPrefs.GetString (PrefName [i]) == PrefString [i]) {
					Draw(true,i);
				} else {
					Draw(false,i);
				}
			}
	
		}
	}
	void Floatonoff()
	{
		if (PrefNum.Length > 0) {
			for (int i = 0; i < Targets.Length; i++) {
				if (PlayerPrefs.GetFloat (PrefName [i]) == PrefNum [i]) {
					{
						if(DestroyIfEquel)Destroy(Targets[i]);
						else if(!DestroyIfNotEquel)Draw(true,i);
					}
					
				} else {
					
					if(DestroyIfNotEquel)Destroy(Targets[i]);
					else if(!DestroyIfEquel)Draw(false,i);
				}
			}
			
		}
	}
	void Draw(bool tf, int i )
	{
		if (Targets [i].GetComponent<SpriteRenderer> () != null)
		Targets [i].GetComponent<SpriteRenderer> ().enabled = tf;
		if (Targets [i].GetComponent<BoxCollider> () != null)
			Targets [i].GetComponent<BoxCollider> ().enabled = tf;

	}
}
