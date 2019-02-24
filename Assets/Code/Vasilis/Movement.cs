using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public static Movement Instance { get; private set; }

    private List<GameObject> coll_obj = new List<GameObject>();
    private Inventory Inv;
    public float speed = 0.1f;
    public float _normalHSpeed { get; set; }
    public float _normalVSpeed { get; set; }
    public float DayFinish { get; set; }
    public string EndDayLocation{get;set;}

    private float speednormal; 
    private bool isFacingRight = true;
    private Animator anim;

	public bool Col{get;set;}
	public bool VerMove;

	public bool MovePers{ get; set;}
    public bool PlusDay { get; set; }
    public bool flip = true;
	private AudioSource Au;
	public float NextFoot;
	private float soundtimer,SpeedCountTimer;
	public bool draw = true;


	public bool DrawDialog{ get; set; }
    
	private bool menu_b;
	public bool inventory_b{ get; set;}
	
	public bool enter_b{ get; set;}
	public bool exit_b{ get; set;}
    public bool journal { get; set; }
    public float _horizontal { get; set; }
	public float _vertical { get; set; }

    private bool joystick;
	private float InvTimer, ChoiseDeley, LocationStart;
	private CharacterController2D _controller;
	private Vector3 CorrentPos, ExPos,camx;

	private Rect CursorRect;
	public bool steps = true;
    private Mouse _mouse;
    private BoxCollider2D _boxcollider, PlayerBox;
    private Transform _transform;
    private string StartLayerName, ForG;
    private Menu menu;
    public float menubackdeley { get; set; }
    public float StepsVolume = 0;
    public UnityEngine.Audio.AudioMixer mg;

    private AudioSource AU,AUJournal;


    private AudioClip OpenBook, CloseBook;
    private List<AudioClip> Pages = new List<AudioClip>();

    void Awake()
	{
        joystick = false;
        mg = Resources.Load<UnityEngine.Audio.AudioMixer>("PrefabObjects/NewAudioMixer");

        LocationStart = 1;
        EndDayLocation = null;
        StartLayerName = "Default";

        if (GetComponent<Menu>() == null) gameObject.AddComponent<Menu>();
        ForG = "FG";
        _transform = transform;

        GameObject VA = GameObject.Find("VasilisA");

        if (VA.GetComponent<CollList>() == null)
            VA.AddComponent<CollList>();

        if (VA.GetComponent<Rigidbody2D>() == null) VA.AddComponent<Rigidbody2D>();
        if (VA.GetComponent<BoxCollider2D>() == null) VA.AddComponent<BoxCollider2D>();

        VA.GetComponent<BoxCollider2D>().size = new Vector2(0.7f,1.8f);
        VA.GetComponent<BoxCollider2D>().isTrigger = true;
        VA.GetComponent<Rigidbody2D>().gravityScale = 0;

        if (GameObject.Find ("Steps") == null&&steps) {
			GameObject Stepss  = new GameObject();
			Stepss = (GameObject)Instantiate(Resources.Load("PrefabObjects/Steps"));
			Stepss.transform.parent = GameObject.Find("VasilisA").transform;
            Stepss.transform.position = new Vector3(transform.position.x+0.3f,transform.position.y,0);

            Stepss.name = "Steps";
        }

       

        Inv = GetComponent<Inventory> ();
        
		_controller = GetComponent<CharacterController2D>();
        
        speednormal = speed;
       if(SceneManager.GetActiveScene().name!="CarRide") DayFinish = 1.2f;
        else DayFinish = 3.2f;

        if (SceneManager.GetActiveScene().name == "CarRide") draw = false;

        OpenBook = Resources.Load<AudioClip>("Sound/UI/Journal/OpenBook");
        CloseBook = Resources.Load<AudioClip>("Sound/UI/Journal/CloseBook");

        for (int i = 0; i < 6; i++)
            Pages.Add(Resources.Load<AudioClip>("Sound/UI/Journal/Page_" + i) );

        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
            GetComponent<AudioSource>().outputAudioMixerGroup = Resources.Load<UnityEngine.Audio.AudioMixer>("PrefabObjects/NewAudioMixer").FindMatchingGroups("Object")[0];
        }
         
                AU = GetComponent<AudioSource>();
    }

    void Start()
    {

        if (GetComponent<Menu>() != null) menu = GetComponent<Menu>();

        if (GameObject.Find("VasilisA").GetComponent<SpriteRenderer>()!=null)GameObject.Find("VasilisA").GetComponent<SpriteRenderer>().enabled = draw;
		GetComponent<BoxCollider2D>().enabled = draw;

       


		MovePers = true;
        anim = GameObject.Find("VasilisA").GetComponent<Animator>();

		if (PlayerPrefs.GetInt ("FaceVector") == 1)
			isFacingRight = true;
		else if(PlayerPrefs.GetInt ("FaceVector") == -1)
			isFacingRight = false;

        if (PlayerPrefs.GetInt("FaceVector") == 0) PlayerPrefs.SetInt("FaceVector", 1);

        if (flip)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= PlayerPrefs.GetInt("FaceVector");
            transform.localScale = theScale;
        }

        if (SceneManager.GetActiveScene().name == "Police" && PlayerPrefs.GetInt("Day") == 2&&
            transform.localScale.x>0) Flip();


        _mouse = GameObject.Find("Mouse(Clone)").GetComponent<Mouse>();

        PlayerPrefs.SetString ("CorrLevel", Application.loadedLevelName);

        if (SceneManager.GetActiveScene().name == PlayerPrefs.GetString("CorrLoadingLevel") &&
            GameObject.Find(PlayerPrefs.GetString("PrevLoadingLevel") + "Exit") != null)
        {
            transform.position = GameObject.Find(PlayerPrefs.GetString("PrevLoadingLevel") + "Exit").transform.position;
        }



       
    }

	void FixedUpdate()
    {
        // if (PlayerPrefs.GetString("CorrLoadingLevel") != SceneManager.GetActiveScene().name) PlayerPrefs.SetString("CorrLoadingLevel", SceneManager.GetActiveScene().name);
       if(StepsVolume>-80&& StepsVolume<20) mg.SetFloat("Steps", StepsVolume);


        if (GameObject.Find("5DayWave")==null&&PlayerPrefs.GetInt("Day") == 5&& PlayerPrefs.GetInt("KladbCrossEMPTYProspektPowerSPRT") == 1
            && PlayerPrefs.GetInt("KladbCrossEMPTYProspektWildSPRT") == 1 && PlayerPrefs.GetInt("KladbCrossEMPTYMorgStreetSPRT") == 1)
        {
            GameObject Wave = new GameObject();
            Wave = (GameObject)Instantiate(Resources.Load("PrefabObjects/5DayWave"));
            Wave.name = "5DayWave";
            Wave.transform.parent = transform;
            Wave.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }


        if (PlayerPrefs.GetInt("FirstRun") == 0)
            PlayerPrefs.SetInt("FirstRun", 1);

                if (Cursor.visible)
        Cursor.visible = false;
     


        if (PlayerPrefs.GetInt("Day")>0) PlayerPrefs.SetInt("PickJournal", 1);

         if(SceneManager.GetActiveScene().name!="6Day") coll_obj = GameObject.Find("VasilisA").GetComponent<CollList>().Getcollob();
         else coll_obj = GameObject.Find("6DayColl").GetComponent<CollList>().Getcollob();

        LayerMove();

       /* for (int i = 0; i<Input.GetJoystickNames ().Length; i++) {
			if (Input.GetJoystickNames () [i] != "")
				joystick = true;
			else
				joystick = false;
		}*/
       
		if(isFacingRight)PlayerPrefs.SetInt ("FaceVector",1);
		else PlayerPrefs.SetInt ("FaceVector",-1);

	float move  = Input.GetAxis("Horizontal");
        if (!menu.Options && menubackdeley <= Time.fixedTime)
            Controls();


    }
    private void Update()
    {
        if (!menu.Options && menubackdeley <= Time.fixedTime)
        {
            InputSets();
            ControlsButton();
        }
    }
    private void LayerMove()
    {
        PlayerBox = GetComponent<BoxCollider2D>();

        for (int ob = 0; ob < GameObject.FindGameObjectsWithTag("LayerFlip").Length; ob++)
        {
            _boxcollider = GameObject.FindGameObjectsWithTag("LayerFlip")[ob].GetComponent<BoxCollider2D>();

            _transform = GameObject.FindGameObjectsWithTag("LayerFlip")[ob].transform;


           
                if (_boxcollider.bounds.min.y > PlayerBox.bounds.min.y)
                    _transform.GetComponent<SpriteRenderer>().sortingLayerName = StartLayerName;
                else _transform.GetComponent<SpriteRenderer>().sortingLayerName = ForG;

            
            for (int i = 0; i < _transform.childCount; i++)
            {
                if (_transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
                {
                    if (_boxcollider.bounds.min.y > PlayerBox.bounds.min.y)
                        _transform.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = StartLayerName;
                    else _transform.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = ForG;

                }

                
            }
        }
    }

    void ControlsButton()
    {
        if (GameObject.Find("Journal") != null)
        {
            if (coll_obj.Contains(GameObject.Find("Journal")) && enter_b)
            {

                PlayerPrefs.SetInt("PickJournal", 1);
                Inv.JournalDraw = true;
                AUPLAY(OpenBook);
            }
            if (PlayerPrefs.GetInt("PickJournal") == 1) Destroy(GameObject.Find("Journal"));
        }

        if (journal && PlayerPrefs.GetInt("PickJournal") == 1 && ChoiseDeley < Time.fixedTime)
        {
            Inv.JournalDraw = !Inv.JournalDraw;
            if (Inv.showinvent) Inv.showinvent = false;

            if (Inv.JournalDraw)
            {
                AUPLAY(OpenBook);
                MovePers = false;
            }
            else
            {
                AUPLAY(CloseBook);
                MovePers = true;
            }
            ChoiseDeley = Time.fixedTime + 0.007f;
        }
        if (Inv.JournalDraw)
        {
            
                if (_horizontal > 0 && PlayerPrefs.GetInt("CorrentPage") < (int)(PlayerPrefs.GetInt("LastSlot") / 6)&& ChoiseDeley < Time.fixedTime)
                {
                    PlayerPrefs.SetInt("CorrentPage", PlayerPrefs.GetInt("CorrentPage") + 1);
                    AUPLAY(Pages[Random.Range(0, 6)]);
                    ChoiseDeley = Time.fixedTime + 0.01f;
                }
                if (_horizontal < 0 && PlayerPrefs.GetInt("CorrentPage") > 0&& ChoiseDeley < Time.fixedTime)
                {
                    PlayerPrefs.SetInt("CorrentPage", PlayerPrefs.GetInt("CorrentPage") - 1);
                    AUPLAY(Pages[Random.Range(0, 6)]);
                    ChoiseDeley = Time.fixedTime + 0.01f;
                }
             
        }
        if (inventory_b && Inv != null && ChoiseDeley < Time.fixedTime)
        {
            Inv.showinvent = !Inv.showinvent;

            if (Inv.showinvent) MovePers = false;
            else MovePers = true;
            ChoiseDeley = Time.fixedTime + 0.007f;
        }

        /* if (Input.GetKeyDown("l"))
         {
             PlayerPrefs.SetString("CorrLevel", Application.loadedLevelName);

             if (Input.GetKeyDown("n"))
                 Application.LoadLevel(PlayerPrefs.GetString("CorrLevel"));

         }*/
        if (Input.GetKey(KeyCode.F12)) PlayerPrefs.DeleteAll();
        

    }
    public void Controls()
    {
        //PersDialog ();
        
		

		if (MovePers) {
			CountSpeed ();



            /*if (_mouse.pointnclick)
            {
                if (Input.GetMouseButton(0))
                {
                    camx = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
                    if (camx.x > transform.position.x)
                        _normalHSpeed = 1;
                    if (camx.x < transform.position.x)
                        _normalHSpeed = -1;
                    if (camx.y > transform.position.y)
                        _normalVSpeed = 1;
                    if (camx.y < transform.position.y)
                        _normalVSpeed = -1;
                }

                if (transform.position.x < camx.x + 0.2f && transform.position.x > camx.x - 0.2f)
                    _normalHSpeed = 0;
                if (transform.position.y < camx.y + 0.2f && transform.position.y > camx.y - 0.2f)
                    _normalVSpeed = 0;
            }
            else
            {*/
                _normalHSpeed = _horizontal;
                _normalVSpeed = _vertical;
            //}


            if (speed > 0) {
				if (_normalVSpeed != 0 || _normalHSpeed != 0)
					anim.SetBool ("Move", true);
				else
					anim.SetBool ("Move", false);
				
				

				if (_normalHSpeed > 0 && !isFacingRight)

					Flip ();
				else if (_normalHSpeed < 0 && isFacingRight)
					Flip ();
				
			}



			if (_horizontal != 0 && _vertical != 0)
				speed = speednormal / 1.28f;
			else
				speed = speednormal;

		
		
	
	     
			/*if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();*/
		} else {
			_normalHSpeed = _normalVSpeed = 0;
			anim.SetBool ("Move", false);
		}
		_controller.SetHorizontalForce (
			Mathf.Lerp (_controller.Velocity.x,
		            _normalHSpeed * speed, 10));
		
		if (VerMove)
			_controller.SetVerticalForce (Mathf.Lerp (_controller.Velocity.y, _normalVSpeed * speed, 10));

	}
    
    private void Flip()
    {
		if (flip) {

						//меняем направление движения персонажа
						isFacingRight = !isFacingRight;
						//получаем размеры персонажа
						Vector3 theScale = transform.localScale;
						//зеркально отражаем персонажа по оси Х
						theScale.x *= -1;
						//задаем новый размер персонажа, равный старому, но зеркально отраженный
						transform.localScale = theScale;
						//transform.localPosition(Vector3());
				}
    }

    private void OnGUI()
    {
       

        if (LocationStart > 0)
        {
            Texture BlackFG = Resources.Load<Texture>("ItemIcons/GunPower");
            Color guiColor = GUI.color; // Save the current GUI color
            GUI.color = new Color(1, 1, 1, LocationStart);
            LocationStart -= 0.015f;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackFG);
            GUI.color = guiColor; // Get back to previous GUI color
        }

        if (DayFinish < 1.2)
        {
            MovePers = false;
            Texture BlackFG = Resources.Load<Texture>("ItemIcons/GunPower");
            Color guiColor = GUI.color; // Save the current GUI color
            GUI.color = new Color(1, 1, 1, DayFinish);
            DayFinish += 0.01f;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackFG);
            GUI.color = guiColor; // Get back to previous GUI color


            if (DayFinish >=1f)
            {
                if (PlusDay)
                {
                    PlayerPrefs.SetInt("Day", PlayerPrefs.GetInt("Day") + 1);
                    PlayerPrefs.SetFloat("DayStart", 1);
                    PlusDay = false;
                }
                if(EndDayLocation!=null&& EndDayLocation.Length>2)
                SceneManager.LoadScene(EndDayLocation);
               // DayFinish = 1.3f;
            }


        }

     
        if (PlayerPrefs.GetFloat("DayStart")> 0)
        {
            
            Texture BlackFG = Resources.Load<Texture>("ItemIcons/GunPower");
            Color guiColor = GUI.color; // Save the current GUI color
            GUI.color = new Color(1, 1, 1, PlayerPrefs.GetFloat("DayStart"));
            PlayerPrefs.SetFloat("DayStart", PlayerPrefs.GetFloat("DayStart") - 0.0025f);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackFG);
            GUI.color = guiColor; // Get back to previous GUI color


           

        }

      
    }
    public void SetVasInLevel()
	{	
		if (GameObject.Find (PlayerPrefs.GetString ("PrevName") + "Exit") != null) {
			Vector3 t = GameObject.Find (PlayerPrefs.GetString ("PrevName") + "Exit").transform.position;
			transform.position = new Vector3 (t.x, t.y, 0f);
		}

	}
	                    




	void InputSets()
	{
		
		if (!joystick) {
			_horizontal = Input.GetAxis ("Horizontal");
			_vertical = Input.GetAxis ("Vertical");
            //atack_b = Input.GetButtonDown ("Atack");
            journal = Input.GetButtonDown("Journal");
            enter_b = Input.GetButtonDown ("Enter");
		
			exit_b = Input.GetButtonDown ("Exit");
			menu_b = Input.GetButton ("Exit");
			inventory_b = Input.GetButtonDown ("Inventory");

			
		} else {
			_horizontal = Input.GetAxis ("Horizontal_J");
			_vertical = Input.GetAxis ("Vertical_J");
			//atack_b = Input.GetKeyDown(KeyCode.JoystickButton2);
			enter_b = Input.GetKeyDown (KeyCode.JoystickButton0);

            journal = Input.GetKeyDown(KeyCode.JoystickButton2);

            exit_b = Input.GetKeyDown(KeyCode.JoystickButton1);
			menu_b = Input.GetKey (KeyCode.JoystickButton9);
			inventory_b = Input.GetKeyDown(KeyCode.JoystickButton3);
		
			
		}
	}
		

	void CountSpeed()
	{
		if (SpeedCountTimer < Time.fixedTime) 
		{
			CorrentPos = ExPos;
			ExPos = transform.position;

			if (CorrentPos.x < ExPos.x + 0.3f && CorrentPos.x > ExPos.x - 0.3f )
				_normalHSpeed = 0;
				if(CorrentPos.y > ExPos.y - 0.3f && CorrentPos.y < ExPos.y + 0.3f)
				_normalVSpeed = 0;
			SpeedCountTimer = Time.fixedTime + 0.4f;
		}


		

	}

	public void SetDraw(bool dr)
	{
		draw = dr;
	}
    public void Save()
    {
        Inv.SaveInv();
    }

    private void AUPLAY(AudioClip clip)
    {
        AU.clip = clip;
        AU.Play();
    }
    public List<GameObject> Getcollob()
	{
		return coll_obj;
	}


}

