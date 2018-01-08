using UnityEngine;
using System.Collections;

public class DayStart: MonoBehaviour {

	public float timer {get;set;}
	private float timer2;


	private bool Coll;
	private Texture textureDay;
	private ChoiseInterface CI;
	private ClosedDoor CD;
	private Movement Move;
	private bool DrawNewDay;

	private Animator anim;
	private SpriteRenderer StendUpSpr;
	private SpriteRenderer StendUpSprBG;

	private bool dpl;

	private bool start_anim; 
	void Start()
	{
		timer = Time.fixedTime+6;
		StendUpSpr = GameObject.Find ("Vasilis_StandUp").GetComponent<SpriteRenderer> ();
		StendUpSprBG = GameObject.Find ("Vasilis_StandUp_Bg").GetComponent<SpriteRenderer> ();


		anim = GameObject.Find ("Vasilis_StandUp").GetComponent<Animator>();


		CI = GetComponent<ChoiseInterface>();
		CD = GetComponent<ClosedDoor>();
		Move = GameObject.Find ("Vasilis").GetComponent<Movement>();

		if(CI!=null)CI.SetAll (false);
		//PlayerPrefs.SetInt("DayPlus",1);

		if(StendUpSpr!=null)StendUpSpr.enabled = false;
		if(StendUpSprBG!=null)StendUpSprBG.enabled = false;
		anim.SetInteger ("AnimSw", 0);
	}



	void Update()
	{
	
		if (timer + 4 < Time.fixedTime&&PlayerPrefs.GetInt ("DayPlus")== 0
		    &&timer + 6.5 > Time.fixedTime&&start_anim == true) 
		{

			anim.SetInteger ("AnimSw", 1);
			StendUpSpr.enabled = true;
			StendUpSprBG.enabled = true;
		}
		else {
			anim.SetInteger ("AnimSw", 0);
				 StendUpSpr.enabled = false;
				 StendUpSprBG.enabled = false;
			     start_anim = false;

		}

		
		if(PlayerPrefs.GetInt ("Day")>=11||PlayerPrefs.GetInt ("Language")==0)
		textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt ("Day"));
		else if(PlayerPrefs.GetInt ("Day")<11&&PlayerPrefs.GetInt ("Language")==1)
		textureDay = Resources.Load<Texture2D> ("Days/Day" + PlayerPrefs.GetInt ("Day")+"En");
	

		if (CI != null) {


			if (Input.GetButtonDown ("Enter")&&Coll)
			{
				if (PlayerPrefs.GetInt ("DayPlus") == 1&&!CI.GetOnChoise()) {
					CD.enabled  = false;				
					CI.SetAll (true);
					Move.MovePers  = false;
					
					timer2 = Time.fixedTime+0.5f;
				}






			    if(timer2<Time.fixedTime&& PlayerPrefs.GetInt ("DayPlus") == 1) {
					if(CI.ReturnCorrentItem () == 0)
					{
						CI.SetAll(!CI.GetOnChoise());
						Move.MovePers =  true;
					}


				if( CI.ReturnCorrentItem () == 1){
					

				if (PlayerPrefs.GetInt ("Day") < 14)
				{
							start_anim = true;

					timer = Time.fixedTime;


				if(timer + 4 >= Time.fixedTime)
				PlayerPrefs.SetInt ("Day", PlayerPrefs.GetInt ("Day") + 1);
					DrawNewDay = true;
					PlayerPrefs.SetInt ("DayPlus", 0);
					CI.SetAll (false);
				}

			} 


			}
			}
	} 


}


	
	void OnGUI () {

		
		if (DrawNewDay) {
			if (CD != null)
				CD.enabled = false;
			if (timer + 0.3f < Time.fixedTime && timer + 4 >= Time.fixedTime) {
				Move.MovePers = false;
				GUI.DrawTexture (new Rect (Screen.width/2  - 1366f/2f, 0, 1366f, 768f), textureDay);
			} else if (timer + 4 < Time.fixedTime)
	
				DrawNewDay = false;
		

		} else if (CD != null && PlayerPrefs.GetInt ("DayPlus") != 1) 
		{
			Move.MovePers = true;
			CD.enabled = true;
		}

	}
	void OnTriggerStay2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			Coll = true;
		} 
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			Coll = false;
		} 
	}
	public void StartDayDay()
	{
		PlayerPrefs.SetInt ("DayPlus", 1);
	}


}
