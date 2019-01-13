using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
	private Trigger exit;
	private Trigger screensize;

	private int screenNum ;
	private Trigger LT,RT,RU,EN;
	private NumberCount NC;
	private int ScrW;
	public Sprite[] sprts;
	private SpriteRenderer sizeRend;
	void Start()
	{
		ScrW = Screen.width;

		if(ScrW == 1024)
			screenNum = 0;
		if(ScrW == 1280)
			screenNum = 1;
		if( ScrW== 1366)
			screenNum = 2;
	
	
		exit = GameObject.Find ("Exitset").GetComponent<Trigger> ();
		screensize = GameObject.Find ("Size").GetComponent<Trigger> ();
		sizeRend = GameObject.Find ("Size").GetComponent<SpriteRenderer> ();

		LT = GameObject.Find ("LeftTrigger").GetComponent<Trigger> ();
		RT = GameObject.Find ("RightTrigger").GetComponent<Trigger> ();
		NC = GameObject.Find ("Sound").GetComponent<NumberCount> ();
		RU = GameObject.Find ("RU").GetComponent<Trigger> ();
		EN = GameObject.Find ("EN").GetComponent<Trigger> ();
	}

	void Update () {


		sizeRend.sprite = sprts[screenNum];


		if (screenNum == 0) 
			ScrW = 1024;
		if (screenNum == 1)
			ScrW = 1280;
		if (screenNum == 2)
			ScrW = 1366;


	//	print (ScrW);

		if (RU.GetClicked ())
			PlayerPrefs.SetInt ("Language", 0);
		if(EN.GetClicked())
			PlayerPrefs.SetInt("Language",1);


		if(RT.GetClicked())
			AudioListener.volume = NC.GetNumber()/30f;
		if(LT.GetClicked())
			AudioListener.volume = NC.GetNumber()/30f;


			if (Input.GetMouseButtonDown (0)) {

		

			if (exit.GetClicked ()) {
                SceneManager.LoadScene("StartMenu");
					Screen.SetResolution (ScrW, 768, Screen.fullScreen);
			}

			if (screensize.GetClicked ()) {

				if (screenNum < 2)
					screenNum++;
				else
					screenNum = 0;


			
				//PlayerPrefs.SetString("CorrLevel", "StartMenu");
			}

		}

			

	}

}
