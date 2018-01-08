using UnityEngine;
using System.Collections;

public class FinaleSceen : MonoBehaviour {
	private Animator anim;
	private float time;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		time = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "KillPeter") 
		{
			KillingPeter KP = GameObject.Find ("Vasilis").GetComponent<KillingPeter> ();
			ChoiseInterface CI = GameObject.Find ("ChInt").GetComponent<ChoiseInterface>();

			GameObject FS = GameObject.Find ("FS_BG");

			if(KP.FinalSceenShoot)
			{
				GetComponent< SpriteRenderer>().enabled = true;
				PlayerPrefs.SetInt("Burning5D",0);
				PlayerPrefs.SetInt("Day",4);
			 anim.SetInteger("Start",0);
			 FS.GetComponent<SpriteRenderer>().enabled = true;
			 CI.SetDrawChoise(false);
			 CI.SetOnChoise(false);
				GameObject.Find ("Player").GetComponent<Movement>().DrawDialog = false;
				if(time+5f<Time.fixedTime){
					SetPrefabsWays("DeathWay","PowerWay","HaosWay");
					PlayerPrefs.SetString("CorrLevel","Pitky");
					Application.LoadLevel("Pitky");
				}
			}

			if(KP.FinalSceenColl)
			{

				GetComponent< SpriteRenderer>().enabled = true;
				anim.SetInteger("Start",1);
			 PlayerPrefs.SetInt("Burning5D",1);
			PlayerPrefs.SetInt("Day",4);
			FS.GetComponent<SpriteRenderer>().enabled = true;
			CI.SetDrawChoise(false);
			CI.SetOnChoise(false);
				GameObject.Find ("Player").GetComponent<Movement>().DrawDialog = false;
				if(time+5f<Time.fixedTime){
					SetPrefabsWays("LiveWay","EmptyWay","FireWay");
					PlayerPrefs.SetString("CorrLevel","MorgKPodv");
					Application.LoadLevel("MorgKPodv");
				}
			}

			if(!KP.FinalSceenColl&&!KP.FinalSceenShoot)
			{
				FS.GetComponent<SpriteRenderer>().enabled = false;
				time = Time.fixedTime;

			}
		}
	}


	private void SetPrefabsWays(string a,string b,string c)
	{
		bool p = true;
		if (p) 
		{
			PlayerPrefs.SetInt(a,PlayerPrefs.GetInt(a)+4);
			PlayerPrefs.SetInt(b,PlayerPrefs.GetInt(b)+4);
			PlayerPrefs.SetInt(c,PlayerPrefs.GetInt(c)+4);
		/*	print (PlayerPrefs.GetInt(a));
			print (PlayerPrefs.GetInt(b));
			print (PlayerPrefs.GetInt(c));*/
			p = false;
		}

	}


}
