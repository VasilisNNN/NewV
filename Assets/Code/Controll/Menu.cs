using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public UnityEngine.Audio.AudioMixer mg;

   // private Rect[] controller_rect = new Rect[4];

	private bool Sound,Visuals,Languages,Costumes;
	private int controllernum;
    private Rect[] rect_options = new Rect[10];
//	private string[] OptionNamesInLine;
	private GUISkin skin;

	private int  ChoiseXMax;
    private int ChoisePosition, ChoisePositionY, ChoisePositionScreen, ChoisePositionFullScreen, language;
    private float timer_e;


    private bool/* _vertical_button_Up, _vertical_button_Down,*/ _horizontalScroll_button, _verticalScroll_button;
    private float _horizontalScroll_axis, _verticalScroll_axis;

    public bool exit_b { get; set; }
    public bool enter_b { get; set; }
    public bool Options { get; set; }
   // private bool Extras;
   
    private int[] Sc_width, Sc_height;

	private float MasterV, BGV, MusicV, InDoorV;

    private bool MoveCh,FullScreen = true;

    private string[] ScreenResStrings,FullScreenString, LanguageString;

  
    private float starttimer;

	private Texture2D ArrowLeft,ArrowRight,ChoiseTexture;
	private float ControllTV,ControllTH;
//	private float MaxInMenuOptions;
	private int[] SoundVolume;
	private string[] InnerOptions;
	private float EnterDeley;
	private string[] PrefsAccess,PrefsAccessDog;
	private bool CustumeLocked,DogCustumeLocked;
	private AudioSource AU;
	private AudioClip EnterClip,ChoiseClip;
	private List<Rect> MenuRects = new List<Rect>();
    void Start () {
		for(int i = 0 ; i<7;i++)
			MenuRects.Add(new Rect (Screen.width / 2 - 150, Screen.height / 8 + 80 * i, 300, 80));
		
		if(SceneManager.GetActiveScene().name == "StartMenu")Options = true;
		EnterClip = Resources.Load<AudioClip> ("Sound/UI/Enter0");
		ChoiseClip = Resources.Load<AudioClip> ("Sound/UI/Choise");
	

		InnerOptions = new string[2]{"1","1"};
		SoundVolume = new int[3]{8,7,7};
		FullScreenString = new string[2];
		//OptionNamesInLine = new string[5];
	

		Cursor.visible = true;

		//ArrowUp = Resources.Load<Texture>("Sprites/UI/Arrow_Up");
		//ArrowDown  = Resources.Load<Texture>("Sprites/UI/Arrow_Down");
		ArrowLeft = Resources.Load<Texture2D>("Invent/LeftArrow");
		ArrowRight  = Resources.Load<Texture2D>("Invent/RightArrow");
        ChoiseTexture = Resources.Load<Texture2D>("Invent/Choise");


        ScreenResStrings = new string[3] {"1366 * 768","1280 * 720","1024 * 768"};
	

        LanguageString = new string[2] { "RU", "EN" };
        //AuC = new string[3] { "Master", "Background","Objects"};

        Sc_width = new int[3] { 1366, 1280, 1024};
        Sc_height = new int[3] { 768, 720, 768};

        /*En = Resources.Load<Texture>("Sprites/UI/English");
        Ru = Resources.Load<Texture>("Sprites/UI/Russian");*/
        
		skin = Resources.Load<GUISkin>("Invent/Slot");
        //names = new string[4] { "Start", "Options", "Exit","Special" +"\n"+"act"};
        if (GetComponent<AudioSource>() == null) gameObject.AddComponent<AudioSource>();
	    AU = GetComponent<AudioSource> ();
     
       
	
		
	
        if (PlayerPrefs.GetInt("Language") == 0) PlayerPrefs.SetInt("Language", 1);

        // Screen.SetResolution(Sc_width[(int)PlayerPrefs.GetFloat("RND_SpriteScreenSize")], Sc_height[(int)PlayerPrefs.GetFloat("RND_SpriteScreenSize")], true, 1);




        /*  for (int i = 0; i < controller_rect.Length; i++)
          {
              controller_rect[i] = new Rect(Screen.width / 2 - 150f, i * Screen.height / 6 + 50f, 300f, 60f);
          }*/

        for (int i = 0; i < 10; i++)
            rect_options[i] = new Rect(200f, 80f + 40f * i, 400f, 60f);

       
        Load();
        
    
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("Language") == 0 && language != 0) PlayerPrefs.SetInt("Language", language);
        InputSets();
       
        if (Input.GetKeyDown (KeyCode.Escape))
			Options = !Options;
		if (Options) {
			ControllerGeneral ();
		}
           
    }





    void ControllerGeneral()
	{

        /*
        if (PlayerPrefs.GetInt ("Language") == 1 )
			OptionNamesInLine = new string[5] { "Screen Resolution", "Language", "Full Screen", "Back", "To Main Menu" };
		if (PlayerPrefs.GetInt("Language") == -1)
			OptionNamesInLine = new string[5] { "Разреш. экрана", "Язык", "Полный экран", "Назад", "В главное меню" };

        */


        /*if (PlayerPrefs.GetFloat ("Language") == 1 && names [2] != "Exit")
			names = new string[4] { "Start", "Options", "Exit", "Special" + "\n" + "act" };
		if (PlayerPrefs.GetFloat ("Language") == -1 && names [2] != "Выход")
			names = new string[4] { "Старт", "Опции", "Выход", "Особое" + "\n" + "действие" };*/

        /*	if (Options&&joystick&&Application.loadedLevelName =="StartMenu")
		PlayerPrefs.SetFloat ("JoyStickType", ControllerCh);*/


        if (ChoisePositionY > InnerOptions.Length - 1)
			ChoisePositionY = InnerOptions.Length - 1;
		if (ChoisePosition > ChoiseXMax)
			ChoisePosition = ChoiseXMax;



		if (_horizontalScroll_button) {
			if (ChoisePosition < ChoiseXMax && _horizontalScroll_axis > 0)
				ChoisePosition++;
			else if (ChoisePosition > 0 && _horizontalScroll_axis < 0)
				ChoisePosition--;
		}

        /*
            for (int i = 0; i < MenuRects.Count; i++) {
                if (MenuRects [i].Contains (Input.mousePosition))
                    ChoisePositionY = i;

            }*/

        if (_horizontalScroll_button)
        {
            if (ChoisePosition < ChoiseXMax && _horizontalScroll_axis > 0)
                ChoisePosition++;
            else if (ChoisePosition > 0 && _horizontalScroll_axis < 0)
                ChoisePosition--;
        }
        if (_verticalScroll_button)
        {
            if (ChoisePositionY < InnerOptions.Length - 1 && _verticalScroll_axis < 0)
            {
                ChoisePositionY++;
                AU.clip = ChoiseClip;
                AU.Play();
            }
            else if (ChoisePositionY > 0 && _verticalScroll_axis > 0)
            {
                ChoisePositionY--;
                AU.clip = ChoiseClip;
                AU.Play();
            }

        }



        SetOptions ();
	}
	
	
    void SetOptions()
    {
        if (Options)
        {
			if (enter_b&& EnterDeley < Time.fixedTime)
            {
				if (ChoisePositionY == 0&&!Visuals&&!Sound&&!Languages)
                {
					if (SceneManager.GetActiveScene ().name != "StartMenu") {
						Options = false;
                        GetComponent<Movement>().menubackdeley = Time.fixedTime +0.2f;

                        if (!AU.isPlaying) {
							AU.clip = EnterClip;
							AU.Play ();
						}
					} else {
                        if (PlayerPrefs.GetInt("FirstRun") == 0)
                        {
                            SceneManager.LoadScene("StartRoom");
                            PlayerPrefs.SetString("CorrLoadingLevel", "StartRoom");
                        }
                        else
                            SceneManager.LoadScene(PlayerPrefs.GetString("CorrLoadingLevel"));
						
					}

					if (!AU.isPlaying) {
						AU.clip = EnterClip;
						AU.Play ();
					}
					
                }
				if (ChoisePositionY == 4&&!Visuals&&!Sound&&!Languages)
				{
					
					if (SceneManager.GetActiveScene ().name == "StartMenu")
						Application.Quit ();
					else SceneManager.LoadScene ("StartMenu");

					if (!AU.isPlaying) {
						AU.clip = EnterClip;
						AU.Play ();
					}
					
				}
				if (ChoisePositionY == 5&&!Visuals&&!Sound&&!Languages)
				{
					Forget ();
                    EnterDeley = Time.fixedTime + 0.05f;

                    if (!AU.isPlaying) {
						AU.clip = EnterClip;
						AU.Play ();
					}

				}
				if (ChoisePositionY == InnerOptions.Length-1){

                    if (Sound)
                    {
                        Sound = false;
                        EnterDeley = Time.fixedTime + 0.05f;
                        AU.clip = EnterClip;
                        AU.Play();
                    }
				}
				
					if (ChoisePositionY == 1&&!Visuals) {
						Visuals = true;
                        EnterDeley = Time.fixedTime + 0.05f;
                    AU.clip = EnterClip;
						AU.Play ();
					}
					if (ChoisePositionY == 2&&!Sound) {
						Sound = true;
                        EnterDeley = Time.fixedTime + 0.05f;
                    AU.clip = EnterClip;
						AU.Play ();
					}
					if (ChoisePositionY == 3&&!Languages)
                {
						Languages = true;
                        EnterDeley = Time.fixedTime + 0.05f;
                    AU.clip = EnterClip;
						AU.Play ();
					}
				
            }
			if(Languages)SetLanguages();
			if(Visuals) SetVisuals();
			if(Sound) SetSounds();
		
		}
	}



    

        void DrawOP()
	{
       

        if (SceneManager.GetActiveScene ().name == "StartMenu") {
            
            if (PlayerPrefs.GetInt("Language") == 1)
				InnerOptions = new string[6]
			{"Back","Visual","Sound","Language","Exit","Forget everything."};
			else
				InnerOptions = new string[6]
			{"Назад","Экран","Звук","Язык","Выход","Забыть все."};


			if (PlayerPrefs.GetInt("Language") == -1) {
				if (PlayerPrefs.GetInt ("FirstRun") == 1)
					InnerOptions [0] = "Продолжить";
				else
					InnerOptions [0] = "Новая игра";

				InnerOptions [InnerOptions.Length - 1] = "Забыть все";

			} else {
				if (PlayerPrefs.GetInt ("FirstRun") == 1)
					InnerOptions [0] = "Continue";
				else
					InnerOptions [0] = "Start";

				InnerOptions [InnerOptions.Length - 1] = "Forget all this";
			}
		} else {
            if (PlayerPrefs.GetInt("Language") == 1)
                InnerOptions = new string[5]
            {"Back","Visual","Sound","Language","To main menu"};
            else
                InnerOptions = new string[5]
            {"Назад","Экран","Звук","Язык","В меню"};

        }






		DrawBoxInnerOptions (InnerOptions.Length-1,false);
	}
    

    void OnGUI()
    {
	

        
		if(Options)
		{
			GUI.Box(new Rect(Screen.width - 200,Screen.height -180,200,80), "Produced by: Marginal act", skin.customStyles[2]);

			if(PlayerPrefs.GetInt("Language")==1)
				GUI.Box(new Rect(Screen.width - 200,Screen.height - 90,200,80), "Language: English", skin.customStyles[2]);
			else
				GUI.Box(new Rect(Screen.width - 200,Screen.height - 90,200,80), "Язык: Русский", skin.customStyles[2]);

			//if(new Rect(Screen.width - 200,Screen.height - 90,200,80).Contains(Input.mousePosition)&&Input.GetMouseButtonDown(2))
				
			if(Sound)DrawSound();
			else if(Languages)DrawLanguage();
			else if(Visuals)DrawVisuals();
			else DrawOP();
		}
  
    }

//VISUALS
	void SetVisuals()
	{
		if (ChoisePositionY == 0) {

			ChoiseXMax = 2;
			ChoisePositionScreen =	SetInHorPlusMinus(ChoisePositionScreen);
		}
		if (ChoisePositionY == 1) {
			
			ChoiseXMax = 1;
			ChoisePositionFullScreen =SetInHorPlusMinus(ChoisePositionFullScreen);
			
            if (ChoisePositionFullScreen == 0) FullScreen = true;
            else if (ChoisePositionFullScreen == 1) FullScreen = false;
        }

		if(ChoisePositionY == InnerOptions.Length-1&&enter_b)
		{ 
			if (!AU.isPlaying) {
				AU.clip = EnterClip;
				AU.Play ();
			}
			PlayerPrefs.SetFloat("FullScreen", ChoisePositionFullScreen);
			PlayerPrefs.SetFloat("ScreenSize", ChoisePositionScreen);
			Screen.SetResolution(Sc_width[ChoisePositionScreen], Sc_height[ChoisePositionScreen], FullScreen, 1);
		    Visuals = false;

           
		}
	
	}
   void DrawVisuals()
	{
		if(PlayerPrefs.GetInt("Language")==1&&FullScreenString[1]!="Fullscreen Off")
		FullScreenString = new string[2] { "Fullscreen On", "Fullscreen Off"};
		if(PlayerPrefs.GetInt("Language")!=1&&FullScreenString[1]!="Полный экран Выкл")
		FullScreenString = new string[2] { "Полный экран Вкл", "Полный экран Выкл"};

		if(PlayerPrefs.GetInt("Language")==1)InnerOptions = new string[3]{"Resolution: ",FullScreenString[ChoisePositionFullScreen],"Accept"};
		else InnerOptions = new string[3]{"Разрешение: ",FullScreenString[ChoisePositionFullScreen],"Подтвердить"};

		InnerOptions [0] = ScreenResStrings[ChoisePositionScreen];
		DrawBoxInnerOptions (InnerOptions.Length-1,true);
	}

//LANGUAGE
	void SetLanguages()
	{
		ChoiseXMax = 1;

		if(ChoisePositionY==0)language = SetInHorPlusMinus(language);

		if (ChoisePositionY == InnerOptions.Length - 1&&enter_b) {
			
				AU.clip = EnterClip;
				AU.Play ();

            if (language <= 0)
            {
                PlayerPrefs.SetInt("Language", -1);
            }
            if (language >= 1)
            {
                PlayerPrefs.SetInt("Language", 1);
            }
            
            Languages = false;
			}

	}
	void DrawLanguage()
	{
		if(PlayerPrefs.GetInt("Language")==1)InnerOptions = new string[2]{LanguageString[language],"Back"};
		else InnerOptions = new string[2]{LanguageString[language],"Назад"};
		DrawBoxInnerOptions (InnerOptions.Length-1,true);
	}

//SOUND

	void SetSounds()
	{	
		SetMixer ();

		if (ChoisePositionY == 0) {
		//	print (SoundVolume [ChoisePositionY]);
			ChoiseXMax = 9;
			SoundVolume [ChoisePositionY] = 
		SetInHorPlusMinus (SoundVolume [ChoisePositionY]);
		}
		if (ChoisePositionY == 1) {
			ChoiseXMax = 9;
			SoundVolume [ChoisePositionY] = 
				SetInHorPlusMinus (SoundVolume [ChoisePositionY]);
		}
		if (ChoisePositionY == 2) {
			ChoiseXMax = 9;
			SoundVolume [ChoisePositionY] = 
				SetInHorPlusMinus (SoundVolume [ChoisePositionY]);
		}

	}

	void DrawSound()
	{
		if(PlayerPrefs.GetInt("Language")==1)InnerOptions = new string[4]{"Master"+" "+SoundVolume[0]*10,"BG"+" "+SoundVolume[1]*10,"Objects"+" "+SoundVolume[2]*10,"Accept"};
		else InnerOptions = new string[4]{"Master" +" "+SoundVolume[0]*10,"Фон"+" "+SoundVolume[1]*10,"Объекты"+" "+SoundVolume[2]*10,"Подтвердить"};

		DrawBoxInnerOptions (InnerOptions.Length-1,true);
	}



	void DrawBoxInnerOptions(int MaxArrows,bool DrawArrows)
	{
		float SH = Screen.height / 4;

        GUI.DrawTexture(new Rect(MenuRects[0].x - 10, MenuRects[ChoisePositionY].y - 5, MenuRects[0].width + 20, MenuRects[0].height + 10), ChoiseTexture);

        for (int i = 0; i < InnerOptions.Length; i++)
			GUI.Box (MenuRects[i], InnerOptions [i], skin.customStyles [6]);
		
		if (DrawArrows) {
			if (ChoisePositionY < MaxArrows) {
				GUI.DrawTexture (new Rect (MenuRects[0].x - 70, MenuRects[ChoisePositionY].y +20, 70, 50), ArrowLeft);
				GUI.DrawTexture (new Rect (MenuRects[0].x + MenuRects[0].width, MenuRects[ChoisePositionY].y + 20, 70, 50), ArrowRight);
			}

           
        }
       
    }


    void Load()
	{
		int j = 0;
		for (int i = 0; i<Input.GetJoystickNames ().Length; i++) {
			
			if (Input.GetJoystickNames () [i] == "") {
				j++;
			}
		}
		if (j == Input.GetJoystickNames ().Length) 
		{
			PlayerPrefs.SetFloat ("JoyStickOn", 0);
		}

		if(PlayerPrefs.GetFloat("FullScreen")==0)
		FullScreen = true;
		else 
			FullScreen = false;

		Screen.SetResolution(Sc_width[(int)PlayerPrefs.GetFloat("ScreenSize")], Sc_height[(int)PlayerPrefs.GetFloat("ScreenSize")], FullScreen, 1);


		if(PlayerPrefs.GetFloat("Master_V")!=0)
		SoundVolume [0] = (int)PlayerPrefs.GetFloat ("Master_V")/10+8;
		if(PlayerPrefs.GetFloat("BG_V")!=0)
			SoundVolume [1] = (int)PlayerPrefs.GetFloat ("BG_V")/10+8;
		if(PlayerPrefs.GetFloat("Objects_V")!=0)
			SoundVolume [2] = (int)PlayerPrefs.GetFloat ("Objects_V")/10+8;

        mg = Resources.Load<UnityEngine.Audio.AudioMixer>("PrefabObjects/NewAudioMixer");

        mg.SetFloat ("Master", PlayerPrefs.GetFloat("Master_V"));
		mg.SetFloat ("BG", PlayerPrefs.GetFloat("BG_V"));
		mg.SetFloat ("Objects", PlayerPrefs.GetFloat("Objects_V"));

	
        if (PlayerPrefs.GetInt("Language") < 1)
            language = 0;
        else
            language = 1;

        ChoisePositionFullScreen = (int)PlayerPrefs.GetFloat("FullScreen");
		
		if (ChoisePositionFullScreen == 0) FullScreen = true;
		else if (ChoisePositionFullScreen == 1) FullScreen = false;

        ChoisePositionScreen =  (int)PlayerPrefs.GetFloat("ScreenSize");

    }

	void SetMixer()
	{
		mg.SetFloat ("Master", -80+SoundVolume [0]*10);
		PlayerPrefs.SetFloat("Master_V",-80+SoundVolume [0]*10);
		
		mg.SetFloat ("BG",-80+SoundVolume [1]*10);
		PlayerPrefs.SetFloat("BG_V",-80+SoundVolume [1]*10);

		mg.SetFloat ("Objects", -80+SoundVolume [2]*10);
		PlayerPrefs.SetFloat("Objects_V",-80+ SoundVolume [2]*10);
	}


	int SetInHorPlusMinus(int t)
	{
		if (t > ChoiseXMax)
			t = ChoiseXMax;
		if (_horizontalScroll_button)
		{
			if (t < ChoiseXMax && _horizontalScroll_axis > 0)
				t++;
			else if (t > 0 && _horizontalScroll_axis < 0)
				t--;
			
		}
		return t;
	}

	/*void SetCostumes()
	{
		if (Camera.main.transform.position.x >= 18)PlayerPrefs.SetInt("NewCostume",0);

		if (ChoisePosition <= PrefsAccessDog.Length - 1) {
			if (PlayerPrefs.GetInt (PrefsAccessDog [ChoisePosition]) == 0 && DogCustumeLocked) {
				PlayerPrefs.SetInt ("FinCostume", 0);
				DogCustumeLocked = false;
			}
		}
		if (ChoisePosition <= PrefsAccess.Length - 1) {
			if (PlayerPrefs.GetInt (PrefsAccess [ChoisePosition]) == 0 && CustumeLocked) {
				PlayerPrefs.SetInt ("Costume", 0);
				CustumeLocked = false;
			}
		}
		//Transform cost = GameObject.Find ("Cost").transform;
		if (Costumes) {
		

			InnerOptions = new string[3]{"Fin","Angelina","Exit"};
			if (ChoisePositionY == 1) {
			
				if(Camera.main.transform.position.x >= 18){
					ChoiseXMax = PrefsAccessDog.Length-1;
					PlayerPrefs.SetInt ("FinCostume", ChoisePosition);
					if(ChoisePosition<=PrefsAccessDog.Length-1){
				if(PlayerPrefs.GetInt(PrefsAccessDog[ChoisePosition])==1){


					DogCustumeLocked = false;
				}
				else DogCustumeLocked = true;
				}
				}
			
			}
			if (ChoisePositionY == 0) {

				//print (PlayerPrefs.GetInt ("Costume"));
				if(Camera.main.transform.position.x >= 18){
					ChoiseXMax = PrefsAccess.Length-1;
					PlayerPrefs.SetInt ("Costume", ChoisePosition);
					if(ChoisePosition<=PrefsAccess.Length-1){
				if(PlayerPrefs.GetInt(PrefsAccess[ChoisePosition])==1){

					CustumeLocked = false;
				}
				else CustumeLocked = true;
				}
					}

			}
			if (ChoisePositionY == InnerOptions.Length - 1 && enter_b&&timer_e<Time.fixedTime) {
				Costumes = false;
				ChoiseXMax = 4;
				timer_e = Time.fixedTime+1;
			}


			GameObject.Find ("AppleCostumes").transform.position = new Vector3 (12.41f, 2-1 * ChoisePositionY, 0);
		}
		}
		*/

	public void Forget()
	{
		PlayerPrefs.DeleteAll ();
		if(language <=0 )PlayerPrefs.SetInt("Language", -1);
		if(language ==1 )PlayerPrefs.SetInt("Language", 1);
        

        PlayerPrefs.SetFloat("FullScreen", ChoisePositionFullScreen);
		PlayerPrefs.SetFloat("ScreenSize", ChoisePositionScreen);

		SetMixer ();
	}
    void InputSets()
    {

        _horizontalScroll_button = Input.GetButtonDown("Horizontal");
        _horizontalScroll_axis = Input.GetAxis("Horizontal");
        _verticalScroll_button = Input.GetButtonDown("Vertical");
        _verticalScroll_axis = Input.GetAxis("Vertical");


        enter_b = Input.GetButtonDown("Enter");

        exit_b = Input.GetButtonDown("Exit");



    }
}


