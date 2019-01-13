using UnityEngine;
using System.Collections;

public class Days_Draw : MonoBehaviour {

	public bool equel = true;
	public bool less = false;
	public bool grater = false;

    
	private AudioSource AU;
	
	public int day;
	

	public bool Box = false;
	public bool Sprite = false;
    public bool AUDIO = false;

    public bool[] Delete;
	void Awake()
	{
		AU = GetComponent<AudioSource>();

	}
	
	void Update()
	{
        for (int i = 0; i < Delete.Length; i++)
        {
            if (Delete[i]&&PlayerPrefs.GetInt("Day")==i)
                Destroy(gameObject);
                }

		if (less) {
			if (PlayerPrefs.GetInt ("Day") < day)
				Draw ();
			
		} else if (equel) {
			if (PlayerPrefs.GetInt ("Day") == day)
				Draw ();
			

		} else if (grater) {
			if (PlayerPrefs.GetInt ("Day") > day)
				Draw ();
			
		} 
		
	}
	
	
	
	
	void Draw()
	{
		if (AU != null) {

            if (!AU.isPlaying && AUDIO)
            {
                AU.Play();
                AUDIO = false;
            }
			
		}


    }
}
