using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mix_ChangeItems : MonoBehaviour {
	
	

	public bool ItemOperator{get;set;}
	private Inventory Inv;
	private bool CollisinWithItem = false;
	private int CorrentNumItemList = 0;
	private int CorrentNumItemNum = 0;
	
	public int[] ItemList;
	

	public bool AddPreviousItem = true;
	public bool AddCorrentItem = false;

	private int prevI;
	private Trigger MouseTrig;
	private bool DraggI = false;

	public AudioSource AudioSS;
	public AudioClip[] AudioClipp;
	private bool NotRemove = false;
	
private void Start()
	{


		ItemOperator = true;

		//ItemList = new int[ItemNumber];
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
		MouseTrig = gameObject.GetComponent<Trigger>();
		//prevI  = Inv.GetCorrentItemMouse();

	}



private void Update()
	{

		/*if(!MouseTrig.GetClicked()&&CollisinWithItem )
		{
			CollisinWithItem = false;
			//if(AudioSS.isPlaying) AudioSS.Stop();
			  }	*/

			

for(int i =0; i<ItemList.Length;i++)
{


/*if(Inv.GetCorrentItem()==ItemList[i]&&MouseTrig.GetClicked())
{	
				if(AudioSS!=null)
					AudioSS.PlayOneShot( AudioClipp[i]);



				//print (i);

CorrentNumItemList = ItemList[i];	
CorrentNumItemNum = i;

if(!NotRemove)Inv.RemoveSlot();

if(AddCorrentItem&&Input.GetKeyDown(KeyCode.Mouse0))Inv.AddItem(ItemList[i]);

CollisinWithItem = true;
					
}*/

}
		

}

	
public bool GetCollisinWithItem()
{
return CollisinWithItem;
}

public int GetCorrentNumItemList()
{
return CorrentNumItemList;
}
	
	public int GetCorrentNumItemNum()
	{
		return CorrentNumItemNum;
	}
public int GetCorrentItemRange()
	{
    return  ItemList.Length;
	}


public void SetPrevI(int pri)
	{
		prevI = pri;
	}
public int GetPrevI()
	{
		return prevI;
	}
public int GetItemNum()
	{
		return ItemList.Length;
	}

public void SetNotRemove(bool nr)
	{
		NotRemove = nr;
	}

}
