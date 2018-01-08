using UnityEngine;
using System.Collections;

public class BodyQuest : MonoBehaviour {

	public GameObject[] Objectss;
	private float timer;
	private bool Startt = false;
	Texture textureDay;

	void Update () {
		if(PlayerPrefs.GetInt("Eye0")==1&&PlayerPrefs.GetInt("Eye1")==1&&
		   PlayerPrefs.GetInt("Hand0")==1&&PlayerPrefs.GetInt("Hand1")==1&&
		   PlayerPrefs.GetInt("FullPeter")<1)
		{



			if(!Startt){
				PlayerPrefs.SetInt("Day",PlayerPrefs.GetInt("Day")+1);
				timer = Time.fixedTime+4f;
				Startt = true; 
			}
			PlayerPrefs.SetInt("FullPeter",1);

		}

	}

	void OnGUI()
	{
		if (Startt) {
			if (timer > Time.fixedTime) {

				if(PlayerPrefs.GetInt ("Day")>=11||PlayerPrefs.GetInt ("Language")==0)
					textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt ("Day"));
				else if(PlayerPrefs.GetInt ("Day")<11&&PlayerPrefs.GetInt ("Language")==1)
					textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt ("Day")+"En");

				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), textureDay);
			}

			if (timer < Time.fixedTime) 
			{
				Startt = false;
			}
		}
	}
}
