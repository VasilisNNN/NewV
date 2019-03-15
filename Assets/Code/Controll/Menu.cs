using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
public class Menu : MonoBehaviour {
    public UnityEngine.Audio.AudioMixer mg;

    // private Rect[] controller_rect = new Rect[4];

    private bool Sound, Visuals, Languages, SettingsBox, JoystickBool;
    //	private string[] OptionNamesInLine;
    private GUISkin skin;
    public bool XBoxGamepad { get; set; }
    public bool PSGamepad { get; set; }
    public bool joystick { get; set; }

    private int ChoiseXMax;
    private int ChoisePosition, ChoisePositionY, ChoisePositionScreen, ChoisePositionFullScreen, language, JoystickHorNum;
    private float timer_e;

    private float _horizontalScroll_axis, _verticalScroll_axis;

    public bool exit_b { get; set; }
    public bool enter_b { get; set; }
    public bool Options { get; set; }
    // private bool Extras;
   


    private int[] Sc_width, Sc_height;



    private bool MoveCh, FullScreen = true;

    private string[] ScreenResStrings, FullScreenString, LanguageString, JoystickONOFF;


    private float starttimer;

    private Texture2D ArrowLeft, ArrowRight, ChoiseTexture, SliderBG, SliderFG;
   
    //	private float MaxInMenuOptions;
    private int[] SoundVolume;
    private string[] InnerOptions;
    private float EnterDeley;

    private AudioSource AU;
    private AudioClip EnterClip, ChoiseClip;
    private List<Rect> MenuRects = new List<Rect>();
    private int[] JINT;
    void Start() {
        JINT = new int[Input.GetJoystickNames().Length];
        

        if (SceneManager.GetActiveScene().name == "StartMenu") Options = true;
        EnterClip = Resources.Load<AudioClip>("Sound/UI/Accept");
        ChoiseClip = Resources.Load<AudioClip>("Sound/UI/Click");


        InnerOptions = new string[2] { "1", "1" };
        SoundVolume = new int[3] { 8, 7, 7 };
        FullScreenString = new string[2];
        //OptionNamesInLine = new string[5];


        Cursor.visible = true;

        //ArrowUp = Resources.Load<Texture>("Sprites/UI/Arrow_Up");
        //ArrowDown  = Resources.Load<Texture>("Sprites/UI/Arrow_Down");
        ArrowLeft = Resources.Load<Texture2D>("Invent/LeftArrow");
        ArrowRight = Resources.Load<Texture2D>("Invent/RightArrow");
        ChoiseTexture = Resources.Load<Texture2D>("Invent/Choise");

        SliderBG = Resources.Load<Texture2D>("Invent/SliderBG");
        SliderFG = Resources.Load<Texture2D>("Invent/SliderFG");


        ScreenResStrings = new string[4] { "1920 * 1080","1366 * 768", "1280 * 720", "1024 * 768" };
        LanguageString = new string[2] { "RU", "EN" };

        Sc_width = new int[4] { 1920,1366, 1280, 1024 };
        Sc_height = new int[4] { 1080,768, 720, 768 };

        skin = Resources.Load<GUISkin>("Invent/Slot");

        if (PlayerPrefs.GetInt("Language") == 0) PlayerPrefs.SetInt("Language", 1);

        // Screen.SetResolution(Sc_width[(int)PlayerPrefs.GetFloat("RND_SpriteScreenSize")], Sc_height[(int)PlayerPrefs.GetFloat("RND_SpriteScreenSize")], true, 1);




        /*  for (int i = 0; i < controller_rect.Length; i++)
          {
              controller_rect[i] = new Rect(Screen.width / 2 - 150f, i * Screen.height / 6 + 50f, 300f, 60f);
          }*/

        Load();

        for (int i = 0; i < 7; i++)
            MenuRects.Add(new Rect(Screen.width / 2 - (Screen.width / 7)/2, Screen.height / 8 + 80 * i, Screen.width / 7, Screen.width / 12));


        AU = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        for (int i = 0; i < 7; i++)
            MenuRects[i] = new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 8 + (Screen.width / 16) * i, Screen.width / 4, Screen.width / 16);


        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] != "")
                JINT[i] = 1; 
            else JINT[i] = 0;

            if(JINT.Sum()==0)
            joystick = false;
            else joystick = true;

        }
        XBoxGamepad = joystick;

        if (PlayerPrefs.GetInt("Language") == 0 && language != 0) PlayerPrefs.SetInt("Language", language);
        InputSets();

        if (SceneManager.GetActiveScene().name == "SecretLocation")
        {
            if (exit_b)
                Options = !Options;

        }

        if (Options) {
            ControllerGeneral();
        }

    }





    void ControllerGeneral()
    {


        if (ChoisePositionY > InnerOptions.Length - 1)
            ChoisePositionY = InnerOptions.Length - 1;
        if (ChoisePosition > ChoiseXMax)
            ChoisePosition = ChoiseXMax;


        if (EnterDeley < Time.fixedTime)
        {

            if (ChoisePosition < ChoiseXMax && _horizontalScroll_axis > 0)
            {
                ChoisePosition++;
                AU.clip = ChoiseClip;
                AU.Play();
            }
            else if (ChoisePosition > 0 && _horizontalScroll_axis < 0)
            {
                ChoisePosition--;
                AU.clip = ChoiseClip;
                AU.Play();
            }
        }

        /*
            for (int i = 0; i < MenuRects.Count; i++) {
                if (MenuRects [i].Contains (Input.mousePosition))
                    ChoisePositionY = i;

            }*/

        if (EnterDeley <Time.fixedTime) {
            if (ChoisePositionY < InnerOptions.Length - 1 && _verticalScroll_axis < 0)
            {
                ChoisePositionY++;
                AU.clip = ChoiseClip;
                AU.Play();
                EnterDeley = Time.fixedTime + 0.1f;
            }
            else if (ChoisePositionY > 0 && _verticalScroll_axis > 0)
            {
                ChoisePositionY--;
                AU.clip = ChoiseClip;
                AU.Play();
                EnterDeley = Time.fixedTime + 0.1f;
            }

        }




        SetOptions();
    }


    void SetOptions()
    {
        if (Options)
        {
            if (enter_b && EnterDeley < Time.fixedTime)
            {
                if (!SettingsBox && !Visuals && !Sound && !Languages && !JoystickBool)
                {
                    if (ChoisePositionY == 0 )
                {
                    if (SceneManager.GetActiveScene().name != "StartMenu")
                    {
                        Options = false;
                        GetComponent<Movement>().menubackdeley = Time.fixedTime + 0.2f;

                        if (!AU.isPlaying)
                        {
                            AU.clip = EnterClip;
                            AU.Play();
                        }
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("FirstRun") == 0)
                        {
                            SceneManager.LoadScene("StartRoom");
                            PlayerPrefs.SetString("CorrLoadingLevel", "StartRoom");
                        }
                        else
                            SceneManager.LoadScene(PlayerPrefs.GetString("CorrLoadingLevel"));

                    }

                    if (!AU.isPlaying)
                    {
                        AU.clip = EnterClip;
                        AU.Play();
                    }

                }
                if (ChoisePositionY == 2 )
                {

                    if (SceneManager.GetActiveScene().name == "StartMenu")
                        Application.Quit();
                    else SceneManager.LoadScene("StartMenu");

                    if (!AU.isPlaying)
                    {
                        AU.clip = EnterClip;
                        AU.Play();
                    }

                }
                if (ChoisePositionY == 3 )
                {
                    Forget();
                    EnterDeley = Time.fixedTime + 0.05f;

                    if (!AU.isPlaying)
                    {
                        AU.clip = EnterClip;
                        AU.Play();
                    }

                }
            }
                if (SettingsBox && EnterDeley < Time.fixedTime&& !Visuals && !Sound && !Languages && !JoystickBool)
                {
                    if (ChoisePositionY == InnerOptions.Length - 1)
                    {
                        if (!Sound&&!Languages&&!Visuals&&!JoystickBool)
                        {
                            SettingsBox = false;
                            EnterDeley = Time.fixedTime + 0.1f;
                            AU.clip = EnterClip;
                            AU.Play();
                        }
                        
                    }

                    if (ChoisePositionY == 0 && !Visuals)
                    {
                        Visuals = true;
                       
                        EnterDeley = Time.fixedTime + 0.1f;
                        AU.clip = EnterClip;
                        AU.Play();
                    }
                    if (ChoisePositionY == 1 && !Sound)
                    {
                        Sound = true;
                        EnterDeley = Time.fixedTime + 0.1f;
                        AU.clip = EnterClip;
                        AU.Play();
                    }
                    if (ChoisePositionY == 2 && !Languages)
                    {
                        Languages = true;
                        EnterDeley = Time.fixedTime + 0.1f;
                        AU.clip = EnterClip;
                        AU.Play();
                    }
                    if (ChoisePositionY == 3 && !JoystickBool)
                    {
                        JoystickBool = true;
                        EnterDeley = Time.fixedTime + 0.1f;
                        AU.clip = EnterClip;
                        AU.Play();
                    }
                }
                else
                     if (ChoisePositionY == 1 && !SettingsBox)
                {
                    SettingsBox = true;
                    EnterDeley = Time.fixedTime + 0.1f;
                    AU.clip = EnterClip;
                    AU.Play();
                }

                }
            if (Languages) SetLanguages();
            if (Visuals) SetVisuals();
            if (Sound) SetSounds();
            if (JoystickBool) SetJoystick();

        }
    }





    void DrawOP()
    {


        if (SceneManager.GetActiveScene().name == "StartMenu") {

            if (PlayerPrefs.GetInt("Language") == 1)
                InnerOptions = new string[4]
            {"Back","Options","Exit","Forget everything"};
            else
                InnerOptions = new string[4]
            {"Назад","Опции","Выход","Забыть все"};


            if (PlayerPrefs.GetInt("Language") == -1) {
                if (PlayerPrefs.GetInt("FirstRun") == 1)
                    InnerOptions[0] = "Продолжить";
                else
                    InnerOptions[0] = "Новая игра";

                InnerOptions[InnerOptions.Length - 1] = "Забыть все";

            } else {
                if (PlayerPrefs.GetInt("FirstRun") == 1)
                    InnerOptions[0] = "Continue";
                else
                    InnerOptions[0] = "Start";

                InnerOptions[InnerOptions.Length - 1] = "Forget all this";
            }
        } else {
            if (PlayerPrefs.GetInt("Language") == 1)
                InnerOptions = new string[3]
            {"Back","Options","To main menu"};
            else
                InnerOptions = new string[3]
            {"Назад","Опции","В главное меню"};

        }






        DrawBoxInnerOptions(InnerOptions.Length - 1, false);
    }


    void OnGUI()
    {



        if (Options)
        {
            skin.customStyles[2].fontSize = Screen.width / 67;
            skin.customStyles[6].fontSize = Screen.width / 67;

            GUI.Box(new Rect(Screen.width - Screen.width / 6, Screen.height - Screen.width / 11, Screen.width / 7, Screen.width / 12), "Made by: Marginal act", skin.customStyles[2]);

            
            //if(new Rect(Screen.width - 200,Screen.height - 90,200,80).Contains(Input.mousePosition)&&Input.GetMouseButtonDown(2))

            if (Sound) DrawSound();
            else if (Languages) DrawLanguage();
            else if (Visuals) DrawVisuals();
            else if (JoystickBool) DrawJoystick();
            else {
                
                if (SettingsBox) DrawSettings();
                else DrawOP();
            }
            
        }

    }
    void DrawJoystick()
    {
        if (PlayerPrefs.GetInt("Language") == 1 && JoystickONOFF[1] != "Gamepad PS")
            JoystickONOFF = new string[2] { "Gamepad XBox", "Gamepad PS" };
        if (PlayerPrefs.GetInt("Language") != 1 && JoystickONOFF[1] != "Геймпад PS")
            JoystickONOFF = new string[2] { "Геймпад XBox", "Геймпад PS" };

        if (PlayerPrefs.GetInt("Language") == 1 )
            InnerOptions = new string[2] { JoystickONOFF[JoystickHorNum], "Back" };
        if (PlayerPrefs.GetInt("Language") != 1)
            InnerOptions = new string[2] { JoystickONOFF[JoystickHorNum], "Назад" };
        

        DrawBoxInnerOptions(InnerOptions.Length - 1, true);

    }
    void SetJoystick()
    {
        if (ChoisePositionY == 0)
        {

            ChoiseXMax = 1;
            JoystickHorNum = SetInHorPlusMinus(JoystickHorNum);
        }

    

        if (ChoisePositionY == InnerOptions.Length - 1 && enter_b&&EnterDeley<Time.fixedTime)
        {
            if (!AU.isPlaying)
            {
                AU.clip = EnterClip;
                AU.Play();
            }

            if (JoystickHorNum == 0)
            {
                XBoxGamepad = true;
                PSGamepad = false;
                PlayerPrefs.SetInt("JoystickINT", 0);
            }
            if (JoystickHorNum == 1)
            {
                XBoxGamepad = false;
                PSGamepad = true;
                PlayerPrefs.SetInt("JoystickINT", 1);
            }

            

            EnterDeley = Time.fixedTime + 0.1f;
            JoystickBool = false;
        }
    }
    void DrawSettings()
    {

        if (PlayerPrefs.GetInt("Language") == 1 && InnerOptions[0] != "Visuals")
            InnerOptions = new string[5] { "Visuals", "Sound","Language", "Gamepad", "Back" };
        if (PlayerPrefs.GetInt("Language") != 1 && InnerOptions[0] != "Экран")
            InnerOptions = new string[5] { "Экран", "Звук","Язык", "Геймпад","Назад" };

  

        DrawBoxInnerOptions(InnerOptions.Length - 1, false);
    }

    //VISUALS
    void SetVisuals()
	{
		if (ChoisePositionY == 0) {

			ChoiseXMax = 3;
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

        if (ChoisePositionY == 3&&enter_b)
        {
            Sound = false;
            EnterDeley = Time.fixedTime + 0.1f;
            AU.clip = EnterClip;
            AU.Play();
        }
    }

	void DrawSound()
	{
		if(PlayerPrefs.GetInt("Language")==1)InnerOptions = new string[4]{"Master","BG","Objects","Accept"};
		else InnerOptions = new string[4]{"Master","Фон","Объекты","Подтвердить"};

        float[] FS = new float[3] { SoundVolume[0]* MenuRects[0].width/10, SoundVolume[1] * MenuRects[0].width / 10, SoundVolume[2] * MenuRects[0].width / 10 };

        DrawSliders(InnerOptions.Length - 1, true, FS);

        //DrawBoxInnerOptions (InnerOptions.Length-1,true);
    }

    void DrawSliders(int MaxArrows, bool DrawArrows,float[] SliderPosition)
    {
        float SH = Screen.height / 4;
        float YPos = 30 + MenuRects[ChoisePositionY].y + MenuRects[ChoisePositionY].height + MenuRects[ChoisePositionY].height * ChoisePositionY;
        if (ChoisePositionY < InnerOptions.Length - 1)
         GUI.DrawTexture(new Rect(MenuRects[0].x - 10, YPos - 30, MenuRects[0].width + 20, MenuRects[0].height + 10), ChoiseTexture);
        else GUI.DrawTexture(new Rect(MenuRects[0].x - 10, MenuRects[ChoisePositionY].y + MenuRects[ChoisePositionY].height * ChoisePositionY-5f, MenuRects[0].width + 20, MenuRects[0].height + 10), ChoiseTexture);
        
       
        for (int i = 0; i < InnerOptions.Length; i++)
        {
                GUI.Box(new Rect(MenuRects[i].x, MenuRects[i].y + MenuRects[i].height * i, MenuRects[i].width, MenuRects[i].height), InnerOptions[i], skin.customStyles[6]);
            if (i < InnerOptions.Length - 1)
            {
                float h = MenuRects[i].width / 10;
                GUI.DrawTexture(new Rect(MenuRects[i].x, MenuRects[i].height/2-h/4+ MenuRects[i].y + MenuRects[i].height + MenuRects[i].height * i, MenuRects[i].width, h/2), SliderBG);
                GUI.DrawTexture(new Rect(MenuRects[i].x + SliderPosition[i], MenuRects[i].height / 2 - h/2 + MenuRects[i].y + MenuRects[i].height + MenuRects[i].height * i, h, h), SliderFG);

            }
        }


        if (DrawArrows)
        {
            if (ChoisePositionY < MaxArrows)
            {
                
                GUI.DrawTexture(new Rect(MenuRects[0].x - 70, YPos, 70, 50), ArrowLeft);
                GUI.DrawTexture(new Rect(MenuRects[0].x + MenuRects[0].width, YPos, 70, 50), ArrowRight);
            }


        }
       

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
        /*int j = 0;
		for (int i = 0; i<Input.GetJoystickNames ().Length; i++) {
			
			if (Input.GetJoystickNames () [i] == "") {
				j++;
			}
		}
		if (j == Input.GetJoystickNames ().Length) 
		{
			PlayerPrefs.SetFloat ("JoyStickOn", 0);
		}*/

        if (PlayerPrefs.GetFloat("JoystickINT") == 1)

        {
            XBoxGamepad = true;
            PSGamepad = false;
        }
        else
        {
            XBoxGamepad = false;
            PSGamepad = true;
        }

        if (PlayerPrefs.GetFloat("FullScreen")==0)
		FullScreen = true;
		else 
			FullScreen = false;

		Screen.SetResolution(Sc_width[(int)PlayerPrefs.GetFloat("ScreenSize")], Sc_height[(int)PlayerPrefs.GetFloat("ScreenSize")], FullScreen, 1);

        if (PlayerPrefs.GetInt("Language") == 1 )
            JoystickONOFF = new string[2] { "Gamepad OFF", "Gamepad ON" };
        if (PlayerPrefs.GetInt("Language") != 1)
            JoystickONOFF = new string[2] { "Геймпад Выкл", "Геймпад Вкл" };


        SoundVolume[0] = PlayerPrefs.GetInt("SoundVolume[0]");
        SoundVolume[1] = PlayerPrefs.GetInt("SoundVolume[1]");
        SoundVolume[2] = PlayerPrefs.GetInt("SoundVolume[2]");

    
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
        if (SoundVolume[0] == 0)
            PlayerPrefs.SetFloat("Master_V", -80);
        else
            PlayerPrefs.SetFloat("Master_V", -15 + SoundVolume[0] * 2);

        if (SoundVolume[1] == 0)
            PlayerPrefs.SetFloat("BG_V", -80);
        else
            PlayerPrefs.SetFloat("BG_V", -15 + SoundVolume[1] * 2);

        if (SoundVolume[2] == 0)
            PlayerPrefs.SetFloat("Objects_V", -80);
        else
            PlayerPrefs.SetFloat("Objects_V", -15 + SoundVolume[2] * 2);


        PlayerPrefs.SetInt("SoundVolume[0]", SoundVolume[0]);
        PlayerPrefs.SetInt("SoundVolume[1]", SoundVolume[1]);
        PlayerPrefs.SetInt("SoundVolume[2]", SoundVolume[2]);

        mg.SetFloat("Master", PlayerPrefs.GetFloat("Master_V"));
        
        mg.SetFloat ("BG", PlayerPrefs.GetFloat("BG_V"));
        
        mg.SetFloat ("Objects", PlayerPrefs.GetFloat("Objects_V"));
		
	}


	int SetInHorPlusMinus(int t)
	{
		if (t > ChoiseXMax)
			t = ChoiseXMax;
        if (t < 0)
            t = 0;

        if (EnterDeley < Time.fixedTime)
        {
            if (t < ChoiseXMax && _horizontalScroll_axis > 0)
                t++;
            else if (t > 0 && _horizontalScroll_axis < 0)
                t--;
            EnterDeley = Time.fixedTime + 0.1f;
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
        if (!joystick)
        {

            _horizontalScroll_axis = Input.GetAxis("Horizontal");
            _verticalScroll_axis = Input.GetAxis("Vertical");
            
            enter_b = Input.GetButtonDown("Enter");

            exit_b = Input.GetButtonDown("Exit");

        }
       
        else
        {
            _horizontalScroll_axis = Input.GetAxis("Horizontal_J");
           
            _verticalScroll_axis = Input.GetAxis("Vertical_J");
            
            enter_b = Input.GetKeyDown(KeyCode.JoystickButton0);
            
            exit_b = Input.GetKeyDown(KeyCode.JoystickButton1);


        }

    }

   
}


