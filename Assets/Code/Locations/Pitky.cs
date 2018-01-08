using UnityEngine;
using System.Collections;

public class Pitky : MonoBehaviour {
	public int Palash{ get; set;}
	public int Health{ get; set;}
	public int Freedom{ get; set;}

	private ChoiseInterface CI;

	private Animator animVasilis;

//	private Animator animPeter;

	private int Sw = 0;
	private int prevDPart;
//Dialog
	private TextB textB;
	public GUIStyle skin;
	private int q = 0;
	private int r = -1;
	private int[] i = new int[9];
	public string[] dialogT;
	public string[] PushFrases;
	/*public string[] dialogT_En;
	public string[] PushFrases_En;*/
	//private string Dname ;
	private string[] Dtext; 
//Answer
	private int Repeat = 0;
	private bool PushFrase;
	private int Answer;
	private bool VasilisTalk;
//Color BG
	private float col = 1;

//Dead Bodies
	public GameObject[] bodies;
	private int Bodies = -1;

	void Start () {
		i[0] = 0;
		i[1] = 0;
		i[2] = 0;
		i[3] = 0;

		animVasilis =  GameObject.Find("Vasilis").GetComponent<Animator>();
//		animPeter = GameObject.Find("Palach").GetComponent<Animator>();
		Palash = 0;
		Health = 20;
		Freedom = 0;
		CI = GameObject.Find("ChInt").GetComponent<ChoiseInterface>();


		CI.SetAll (true);

	}
	

	void Update () 
	{
		for (int i = 0; i<bodies.Length; i++) 
		{
			if(i<=Bodies)
			bodies[i].GetComponent<SpriteRenderer>().enabled = true;
			else 
			bodies[i].GetComponent<SpriteRenderer>().enabled = false;
		}

		/*if (Answer == 2) {
						 Answer = 0;
			if(q<dialogT.Length-1){q++;}	
		                 }*/
		
		animVasilis.SetInteger("Sw", Sw);	


		if (Palash > 20) {

			Application.LoadLevel ("HospitalHall2");
			PlayerPrefs.SetInt("DayPlus",1);
		}
		if (Health <= 0) {
			Application.LoadLevel ("DvorSon");
			PlayerPrefs.SetInt("DayPlus",1);
		}
		if (Freedom > 20) {
			Application.LoadLevel ("ProspektWild");
			PlayerPrefs.SetInt("DayPlus",1);
		}




		if (Input.GetButtonDown ("Horizontal")&&VasilisTalk) 
		{
			if(i[prevDPart]<10)
			i[prevDPart]+=1;
			

			Push ();
			VasilisTalk = false;
			if(q<dialogT.Length-1)q++;
		}

	


		Camera.main.backgroundColor =  new Vector4(col, col, col, 0.8f);



/////////Switching_Answers/////

		if (Input.GetButtonDown ("Enter")&&!VasilisTalk) {


			Sw = CI.ReturnCorrentItem ();

				
						if (CI.ReturnCorrentItem () == 0) {

				ChoisePlus();
		
				Bodies++;
				                Health -= 1;
								Freedom -= 1;
				//Dname = "ShutUp";
						}
						if (CI.ReturnCorrentItem () == 1) {
				ChoisePlus();
				col -=0.07f;
								Palash += 1;
			//	Dname = "Free";
	
						}
						
						if (CI.ReturnCorrentItem () == 2) {
				ChoisePlus();
								Health -= 1;
				//Dname = "Struggle";
				col -=0.07f;
						}
						if (CI.ReturnCorrentItem () == 3) {
				ChoisePlus();
								Palash -= 1;
								Health -= 1;
				                Bodies++;
			//	Dname = "FuckOff";

						}
				} 
	}




void OnGUI()
	{


		if (!PushFrase) {
			GUI.TextField (new Rect(Screen.width/2,0f,Screen.width/2,130), dialogT [q], skin);	
		
				} 


		else if (PushFrase) {
			GUI.TextField (new Rect(Screen.width/2,0f,Screen.width/2,130), PushFrases[r],skin);	
		}

	}






private void ChoisePlus()
	{
		prevDPart = CI.ReturnCorrentItem ();
		VasilisTalk = !VasilisTalk;
		Answer ++;
	}


	private void Push()
	{
		if(Repeat<2)
		{
			Repeat ++;
			PushFrase = false;
		}
		
		
		else if(Repeat >=2)
		{
			PushFrase = true;
			if(r<PushFrases.Length-1)r++;
			Repeat = 0;
		}

	}

}
