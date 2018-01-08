using UnityEngine;
using System.Collections;

public class Scales : MonoBehaviour {
	private int num = 0;

	private bool[] picked = new bool[3];
	private bool[] puting = new bool[3];

	private Inventory Inv;
	private Mix_ChangeItems MCI;
	private BoxCollider2D Box;

	private bool drawscales = false;
	private NumberCount NC;
	//private bool draggItem = false;
	
	private int[] GunPowerNum = new int[3];
	public GUIStyle skin;

//	private int[] ReturnItems = new int[10];
	
	private int UsedIng = 0;
	private SpriteRenderer Scales_Sprite;
	//private Camera maincam;

	private AddingItems AI;
	private SpriteRenderer SP_AI;
	private TriggerMouse triggerEnter;

	public Texture box;


	private bool UseRes;




	private void Start()
	{

		for (int i = 0; i<puting.Length; i++) {
			puting[i] = false;
		}

		NC = GameObject.Find ("Num").GetComponent<NumberCount> ();
		AI = GameObject.Find ("Capsule").GetComponent<AddingItems> ();
		SP_AI = GameObject.Find ("Capsule").GetComponent<SpriteRenderer> ();

		if (PlayerPrefs.GetInt ("Capsule_sp") == 0)
			SP_AI.enabled = false;
		else SP_AI.enabled = true;

		//maincam = Camera.main;
	

		Scales_Sprite = GameObject.Find ("Scales_Sprite").GetComponent<SpriteRenderer>();

		triggerEnter = GameObject.Find ("EnterTrigger").GetComponent<TriggerMouse> ();


		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
		Inv.showinvent = true;
		//Inv.AddItem (44);
		MCI = GetComponent<Mix_ChangeItems>();
		//gameObject.GetComponent<GUIText>().text = str+num;
		Box = GetComponent<BoxCollider2D>();


		GameObject.Find("GunPowerSelf").GetComponent<SpriteRenderer>().enabled = false;

		for (int j = 0; j<GunPowerNum.Length; j++) {
			GunPowerNum[j] = 0;
		}

		for (int i= 0; i< picked.Length; i++) {
		
			for(int y = 7; y<9;y++)
			{
				if (Inv.CheckItem (y))
					picked [i] = true;
				else picked [i] = false;
			}
		}
/*
		if (Inv.CheckItem (7))
			picked[0] = true;
		else picked [0] = false;

		if (Inv.CheckItem (8))
			picked [1] = true;
		else picked [1] = false;

		if (Inv.CheckItem (9))
			picked [2] = true;
		else picked [2] = false;
		*/
	}


	





	void Update()
	    {


		NC.On = drawscales;
		Scales_Sprite.enabled = drawscales;

		if (drawscales) {
			Triggers ();
			Box.enabled = false;
		}else Box.enabled = true;

		if(SP_AI.enabled)PlayerPrefs.SetInt("Capsule_sp",1);
		if (AI.ItemAdded) {
			PlayerPrefs.SetInt("Capsule_sp",0);
			SP_AI.enabled = false;
		}


		if (Input.GetKeyDown (KeyCode.Escape))
		{ReturnNotUsedItems();
			Inv.SaveInv();
			PlayerPrefs.SetString("CorrLevel","Kitchen");
			Application.LoadLevel ("TableRoom");
		}

		if (MCI.GetCollisinWithItem ()&&!drawscales) {
				for (int i = 0; i<puting.Length; i++) {
					if (MCI.GetCorrentNumItemNum () == i)
						puting [i] = true;
				}


				num = MCI.GetCorrentNumItemNum ();
				drawscales = true;
			}



	

		if(drawscales||UsedIng==3)
		{MCI.ItemOperator = false;}
		else{MCI.ItemOperator = true;}
		
	


//////StartMixing/////	


	
		
	}
	
	private void Restart()
	{
		for(int i = 0; i<Inv.GetInvCount();i++)
		{
			if(i == 7||i == 8|| i ==9)
			{
				if(!Inv.CheckItem(i))
				{
					Inv.AddItem(i);

				}
			}
		}
	}
	
	
	public int GetNum()
	{
		return num;
	}
	
	
	private void ReturnNotUsedItems()
	{
		
		if((!Inv.CheckItem(10)&&!Inv.CheckItem(11)&&!Inv.CheckItem(12))&&
		   (!Inv.CheckItem(14)&&!Inv.CheckItem(15)&&!Inv.CheckItem(16))&&
		   (!Inv.CheckItem(7)&&!Inv.CheckItem(8)&&!Inv.CheckItem(9))
		   )
		   
		{
			
			if(picked [0])Inv.AddItem(7);
			if(picked [1])Inv.AddItem(8);
			if(picked [2])Inv.AddItem(9);
			UsedIng = 0;
		}

		if(!Inv.CheckItem (10) && !Inv.CheckItem (11) && !Inv.CheckItem (12)) 
		{

			if (puting [0] && !puting [1] && !puting [2])
				Inv.AddItem (7);
			if (!puting [0] && puting [1] && !puting [2])
				Inv.AddItem (8);
			if (!puting [0] && !puting [1] && puting [2])
				Inv.AddItem (9);
		}


	}

	private void Triggers()
	{


		//TRIGGERS	/// ////////////////////////
		for (int r = 0; r<3; r++) {
			if (MCI.GetCorrentNumItemNum () == r)
				GunPowerNum [r] = NC.GetNumber ();
		}


		if(drawscales && triggerEnter.GetClicked()&&Input.GetKeyDown(KeyCode.Mouse0))
		{

			/*if(Inv.GetCorrentItem()){
				drawscales = false;
			UsedIng++;
			GameObject.Find("GunPowerSelf").GetComponent<SpriteRenderer>().enabled = true;
			
			}*/


			//Inv.SetItemNum(Inv.GetCorrentItemMouse(),num);
			
			if(UsedIng == 3)
			{
				GameObject.Find("GunPowerSelf").GetComponent<SpriteRenderer>().enabled = false;
				if(GunPowerNum[0] ==10&&GunPowerNum[1] >=90&&GunPowerNum[2] >=90)	
				{
					Inv.AddItem(10);
					UseRes = true;
					UsedIng = 0;
				}
				if(GunPowerNum[0] ==50&&GunPowerNum[1] ==50&&GunPowerNum[2] ==40)	
				{
					Inv.AddItem(11);
					UseRes = true;
					UsedIng = 0;
				}
				if(GunPowerNum[0] ==80&&GunPowerNum[1] ==60&&GunPowerNum[2] ==30)	
				{
					Inv.AddItem(12);
					UseRes = true;
					UsedIng = 0;
				}
				
				if(!UseRes&&UsedIng == 3)
				{

					Inv.AddItem(7);
					Inv.AddItem(8);
					Inv.AddItem(9);
					UsedIng = 0;

				}

			}

		}
	}



}

