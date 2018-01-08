using UnityEngine;
using System.Collections;

public class AddingItems: MonoBehaviour {
	
	private Inventory Inv;
	private TriggerMouse MouseTrig;
	public bool ItemAdded{ get; set;}	

	public int[] ItemCondition;
	public int[] ItemAdding;
	
	void Start () {
	
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
	MouseTrig = GetComponent<TriggerMouse>();
	}
	
	// Update is called once per frame
	void Update () {
				
for(int i =0; i<ItemCondition.Length;i++)
{
			//if(Inv.CheckItem(ItemAdding[i]))ItemAdded = false;

			/*if(Inv.GetCorrentItem()==ItemCondition[i]&&Input.GetKeyDown(KeyCode.Mouse0)&&MouseTrig.GetClicked())
			{   
				/*if(!Inv.CheckItem(ItemAdding[i]))
				{
				ItemAdded = true;
				if(ItemAdding[i]>-1)
				{Inv.AddItem(ItemAdding[i]);}
                 Inv.RemoveSlot();
				}*/
	
	}
}
}