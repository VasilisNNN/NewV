using UnityEngine;
using System.Collections;

public class NumberCount : MonoBehaviour {
	private Rect rect;
	public int Number = 0;
	public int MaxNumber = 100;
	public int MinNumber = 0;
	public GUIStyle skin;
	public GUIStyle skin_1;
	private TriggerMouse MPL;
	private TriggerMouse MPR;
	public bool On{ get; set;}
	private Camera cam;
	public bool Onoff =false;
	public int NumberPlus = 1;

	public float dileytimer;
	private float timer;
	public bool DRAW_START = false;
	// Use this for initialization
	void Awake()
	{
		On = Onoff;
	}
	void Start () {
		cam = Camera.main;

		//cam.WorldToScreenPoint;

		MPL = GameObject.Find("LeftTrigger").GetComponent<TriggerMouse>();
		MPR = GameObject.Find("RightTrigger").GetComponent<TriggerMouse>();
		timer = Time.fixedTime;
	}

	void Update()
	{

		rect = new Rect (cam.WorldToScreenPoint(transform.position).x,
		                 cam.WorldToScreenPoint(transform.position).y*-1f+Screen.height,
		                 10f,
		                 10f); 

		if(On&&timer<Time.fixedTime)
		{


			if (MPL.GetClicked()&&Input.GetKeyDown(KeyCode.Mouse0))
				if(Number<MaxNumber)
			{Number += NumberPlus;
				timer = Time.fixedTime + dileytimer;
			}

			if (MPR.GetClicked()&&Input.GetKeyDown(KeyCode.Mouse0))
				if(Number>MinNumber)
			{Number -= NumberPlus;      
				timer = Time.fixedTime + dileytimer;
			}
			
			}
	}
	// Update is called once per frame
	void OnGUI () {
		if (On&&!DRAW_START)
			GUI.TextField (rect, "" + Number, skin);
		if (DRAW_START) {
			if(On)GUI.Box(new Rect(cam.WorldToScreenPoint(transform.position).x,
			                 cam.WorldToScreenPoint(transform.position).y*-1f+Screen.height,
			                 50f,
			                 50f),"",skin_1);
			GUI.TextField (rect, "" + Number, skin);
		}
	}

	public int GetNumber()
	{
		return Number;
	}


}
