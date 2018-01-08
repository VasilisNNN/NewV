using UnityEngine;
using System.Collections;

public class Mix_Sev_Items_ToOne : MonoBehaviour {
	

	private Inventory Inv;
	private Mix_ChangeItems MCI;


	public int finaleItem;
	public Sprite[] sprites;

	private void Awake()
	{
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
	}
	private void Start()
	{

		MCI = gameObject.GetComponent<Mix_ChangeItems>();
		GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("Mix_Seed")];
		MCI.SetNotRemove (true);
	
	}

	
	
	
	void Update()
	{


		if(MCI.GetCollisinWithItem()){

		if(MCI.GetCorrentNumItemNum() == 0)
			{
			
			if(PlayerPrefs.GetInt("Mix_Seed")==0)
			{
			GetComponent<SpriteRenderer>().sprite = sprites[1];
			PlayerPrefs.SetInt("Mix_Seed",1);
			//Inv.RemoveSlot(i);

			}

			}
		if(MCI.GetCorrentNumItemNum() == 1)
		{
			if(PlayerPrefs.GetInt("Mix_Seed")==1)
			{
			GetComponent<SpriteRenderer>().sprite = sprites[2];
			PlayerPrefs.SetInt("Mix_Seed",2);
//			Inv.RemoveSlot();
			}

		}
		if(MCI.GetCorrentNumItemNum() == 2)
			{
				if(PlayerPrefs.GetInt("Mix_Seed")==2)
				{
					PlayerPrefs.SetInt("Mix_Seed",3);
					//Inv.RemoveSlot();
				}
				
			}
		}
		if (PlayerPrefs.GetInt("Mix_Seed")==3) 
		{
			Inv.AddItem(finaleItem);
			PlayerPrefs.SetInt("Mix_Seed",0);
			GetComponent<SpriteRenderer>().sprite = sprites[0];
		}

	}

	private void AddI()
	{
		if(!Inv.CheckItem(MCI.GetCorrentNumItemList()))Inv.AddItem(MCI.GetCorrentNumItemList());
	}


}
