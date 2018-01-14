using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	
public static Movement Instance{get;private set;}

	private List<GameObject> coll_obj = new List<GameObject>();
	private Inventory Inv;
	private GameObject[] Pers;
	public float speed = 0.1f; 
	public float _normalHSpeed{ get; set;}
	public float _normalVSpeed{ get; set;}
	private float speednormal; 
    private bool isFacingRight = true;
    private Animator anim;

	public bool Col{get;set;}
	public bool VerMove;

	public bool MovePers{ get; set;}

	public bool flip = true;
	private AudioSource Au;
	public float NextFoot;
	private float soundtimer,SpeedCountTimer;
	public bool draw = true;


	public bool DrawDialog{ get; set; }


	private bool mv ;

	private Rect rectlable;
	public GUISkin skin;
	private string[] dialogText; 
	
	private TextB texB;
	private TextEn texEn;
	private int finalLine = 1;
	private int finalLinePl = 1;

	public bool PlayIn = false;
	
	private bool menu_b;
	public bool inventory_b{ get; set;}
	
	public bool enter_b{ get; set;}
	public bool exit_b{ get; set;}
	public float _horizontal { get; set; }
	public float _vertical { get; set; }
	private bool joystick;
	private int nextline;
	private Texture face;
	private float MinimalDialogTimer,InvTimer;
	private CharacterController2D _controller;
	public bool DontLoadPosStart;
	private Vector3 CorrentPos, ExPos,camx;
	public Texture CursorT;
	private Rect CursorRect;
	public bool steps = true;
	void Awake()
	{
		if (GameObject.Find ("Steps(Clone)") == null&&steps) {
			GameObject Stepss  = new GameObject();
			Stepss = (GameObject)Instantiate(Resources.Load("PrefabObjects/Steps"));
			Stepss.transform.parent = GameObject.Find("VasilisA").transform;
			GameObject.Find ("Steps(Clone)").transform.position = new Vector3(transform.position.x+0.3f,transform.position.y,0);
		}
		
		Inv = GetComponent<Inventory> ();
		Pers = GameObject.FindGameObjectsWithTag("Pers");

		rectlable = new Rect (0, 0, Screen.width, 100f);
		
		
		_controller = GetComponent<CharacterController2D>();
		speednormal = speed; 
	}

    private void Start()
    {
		CursorT = Resources.Load<Texture2D> ("Interface/Cursor");
		Cursor.visible = false;
		if(GameObject.Find("VasilisA").GetComponent<SpriteRenderer>()!=null)GameObject.Find("VasilisA").GetComponent<SpriteRenderer>().enabled = draw;
		GetComponent<BoxCollider2D>().enabled = draw;

		
		Au = gameObject.GetComponent<AudioSource>(); 
		if (Au != null)
						Au.playOnAwake  =true;


		MovePers = true;
        anim = GameObject.Find("VasilisA").GetComponent<Animator>();

		if (PlayerPrefs.GetInt ("FaceVector") == 1)
			isFacingRight = true;
		else if(PlayerPrefs.GetInt ("FaceVector") == -1)
			isFacingRight = false;

		Vector3 theScale = transform.localScale;
		theScale.x *= PlayerPrefs.GetInt ("FaceVector");
		transform.localScale = theScale;
        if(!DontLoadPosStart)
		SetVasInLevel ();

		PlayerPrefs.SetString ("CorrLevel", Application.loadedLevelName);


    }

	void Update()
    {

		for (int i = 0; i<Input.GetJoystickNames ().Length; i++) {
			if (Input.GetJoystickNames () [i] != "")
				joystick = true;
			else
				joystick = false;
		}
		InputSets();


		if(isFacingRight)PlayerPrefs.SetInt ("FaceVector",1);
		else PlayerPrefs.SetInt ("FaceVector",-1);

	float move  = Input.GetAxis("Horizontal");

		Controls();
		Cursor.visible = false;
    
    }
/*	void LateUpdate()
	{
		PlayerPrefs.DeleteAll ();
	}*/
	public void Controls()
	{
		//PersDialog ();
	
		if (inventory_b && Inv!=null)
		Inv.showinvent = !Inv.showinvent;
	
		if (Input.GetKeyDown ("l")) {
			PlayerPrefs.SetString ("CorrLevel", Application.loadedLevelName);

			if (Input.GetKeyDown ("n"))
			Application.LoadLevel(PlayerPrefs.GetString ("CorrLevel"));

		}
		if(Input.GetKeyDown("=")&&PlayerPrefs.GetInt("Day")<14)
			PlayerPrefs.SetInt("Day",PlayerPrefs.GetInt("Day")+1);
		if(Input.GetKeyDown("-")&&PlayerPrefs.GetInt("Day")>0)
			PlayerPrefs.SetInt("Day",PlayerPrefs.GetInt("Day")-1);

		if (MovePers) {
			CountSpeed ();




			if (Input.GetMouseButton (0)) {
				camx = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1f));
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
	
	
	public void SetVasInLevel()
	{	
		if (GameObject.Find (PlayerPrefs.GetString ("PrevName") + "Exit") != null) {
			Vector3 t = GameObject.Find (PlayerPrefs.GetString ("PrevName") + "Exit").transform.position;
			transform.position = new Vector3 (t.x, t.y, 0f);
		}

	}
	                    




		private void OnGUI () {
		
		
	

		GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), CursorT);
		
		/*if (DrawDialog) {
			
			if (i == dialogText.Length) {
				i = 0;
				startDialog = false;
				PlayIn = false;
				finalLine = finalLinePl; 
			}
			
			
		}*/
	}
	void InputSets()
	{
		
		if (!joystick) {
			_horizontal = Input.GetAxis ("Horizontal");
			_vertical = Input.GetAxis ("Vertical");
			//atack_b = Input.GetButtonDown ("Atack");
			enter_b = Input.GetButtonDown ("Enter");
		
			exit_b = Input.GetButtonDown ("Exit");
			menu_b = Input.GetButton ("Exit");
			inventory_b = Input.GetButtonDown ("Inventory");

			
		} else {
			_horizontal = Input.GetAxis ("Horizontal_J");
			_vertical = Input.GetAxis ("Vertical_J");
			//atack_b = Input.GetKeyDown(KeyCode.JoystickButton2);
			enter_b = Input.GetKeyDown (KeyCode.JoystickButton2);

			exit_b = Input.GetKey (KeyCode.JoystickButton1);
			menu_b = Input.GetKey (KeyCode.JoystickButton9);
			inventory_b = Input.GetButtonDown ("Inventory_J");
		
			
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


	private void OnTriggerStay2D(Collider2D c)
	{
		
		if(!coll_obj.Contains(c.gameObject))
		{
			coll_obj.Add(c.gameObject);
		}
		
	}
	
	private void OnTriggerExit2D(Collider2D c)
	{
		
		if(coll_obj.Contains(c.gameObject))
		{
			coll_obj.Remove(c.gameObject);
		}
		
	}
	public List<GameObject> Getcollob()
	{
		return coll_obj;
	}


}

