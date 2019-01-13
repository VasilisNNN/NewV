using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        /*if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "Destroy") == 1&& DestroyIfEquel)
            Destroy(gameObject);*/
    }
	void Update () {
		
		if (Targets.Length > 0) 
	    {

			for (int i = 0; i < Targets.Length; i++) {
				if (PlayerPrefs.GetInt (PrefName [i]) == PrefNum [i]) {
                    {
                       // Draw(true, Targets[i]);
                        if (DestroyIfEquel)
                        {
                            Destroy(gameObject);
                           // PlayerPrefs.SetInt(name+SceneManager.GetActiveScene().name+"Destroy",1);
                        }
                    }
				} else {
					//Draw(false,Targets[i]);
                    if (DestroyIfNotEquel)
                    {
                        Destroy(gameObject);
                       // PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "Destroy", 1);
                    }
                }
			}
	
		}
	}

	void Draw(bool tf, GameObject i )
	{
		if (i.GetComponent<SpriteRenderer> () != null)
		    i.GetComponent<SpriteRenderer> ().enabled = tf;
		if (i.GetComponent<BoxCollider> () != null)
			i.GetComponent<BoxCollider> ().enabled = tf;
		if (i.GetComponent<PolygonCollider2D> () != null)
			i.GetComponent<PolygonCollider2D> ().enabled = tf;
		if (i.GetComponent<AudioSource> () != null) {
			if(tf){
				if(!i.GetComponent<AudioSource> ().isPlaying)
				i.GetComponent<AudioSource> ().Play ();
			}
			else i.GetComponent<AudioSource> ().Stop ();
		}
	}
}
