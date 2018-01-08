using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
	private TriggerMouse exit;
	private TriggerMouse screensize;

	private int screenNum ;
	private TriggerMouse LT,RT,RU,EN;
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
	
	
		exit = GameObject.Find ("Exitset").GetComponent<TriggerMouse> ();
		screensize = GameObject.Find ("Size").GetComponent<TriggerMouse> ();
		sizeRend = GameObject.Find ("Size").GetComponent<SpriteRenderer> ();

		LT = GameObject.Find ("LeftTrigger").GetComponent<TriggerMouse> ();
		RT = GameObject.Find ("RightTrigger").GetComponent<TriggerMouse> ();
		NC = GameObject.Find ("Sound").GetComponent<NumberCount> ();
		RU = GameObject.Find ("RU").GetComponent<TriggerMouse> ();
		EN = GameObject.Find ("EN").GetComponent<TriggerMouse> ();
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
				Application.LoadLevel ("StartMenu");
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
