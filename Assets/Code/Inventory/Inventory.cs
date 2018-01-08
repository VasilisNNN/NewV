using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
		 

	
	private int slotX,slotY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	
	public bool showinvent{get;set;}
	public bool showI{get;set;}
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;
	
	private bool draggingItem;
	private Item draggedItem;

	
	private PickObject PickOb;
	private int previIndex;
	private Event e;
	private int correntItem = 0;
	private int correntItemNum = 0;
	private bool isMultipleT = false;
	private Item item;
	private float mousedeley;
	// Use this for initialization
void Start () {
	
		showI= true;
		slotX = 15;
		slotY = 1;
		for(int i = 0; i<(slotX*slotY);i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		
	    database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
	    
	
	LoadInv();
	}
	

void OnGUI()
	{
		
		tooltip = "";
		GUI.skin = skin;
		
		if(showinvent&&showI)
		{
			DrawInventory();
			
			if(showTooltip){
				float W = 200;
				if(Event.current.mousePosition.x<Screen.width-W)
					GUI.Box(new Rect(Event.current.mousePosition.x +15f,Event.current.mousePosition.y-W,W,W),tooltip);
				else 	
					GUI.Box(new Rect(Event.current.mousePosition.x +15f-W,Event.current.mousePosition.y-W,W,W),tooltip);

			
			}
			}
		if(draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,50,50),draggedItem.itemIcon);
		}
		
	}




void DrawInventory()
	{
		int i  =0 ;
		e = Event.current;
	
			for(int x= 0; x<slotX;x++)
			{
				Rect slotRect = new Rect(x*70,Screen.height - 60,60,60);
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
			    slots[i] = inventory[i];
				item = slots[i];
				
				if(slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
					if(slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;
				
			
					if (Input.GetMouseButtonDown (0) &&mousedeley<Time.fixedTime&& !draggingItem&&slotRect.Contains(new Vector2(Input.mousePosition.x,Screen.height - Input.mousePosition.y))) 
						{

							draggingItem = true;
							previIndex = i;
							draggedItem = item;
							correntItem = item.itemID;
							correntItemNum = item.itemNum;	

							inventory [i] = new Item ();
						mousedeley = Time.fixedTime + 0.1f;						
					}

					if(draggingItem&&Input.GetMouseButtonDown (1))
					{
						inventory[previIndex] = inventory[i];
						inventory[i] = draggedItem;
						draggingItem = false;
						draggedItem = null;						
					}


						
						
						
					}
					
				}else{
				if(slotRect.Contains(new Vector2(Input.mousePosition.x,Screen.height - Input.mousePosition.y)))
					{
					if(Input.GetMouseButtonDown(0)&& draggingItem&&mousedeley<Time.fixedTime)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						mousedeley = Time.fixedTime + 0.1f;	
						}
					}
					
				}
				if(tooltip == "")
				{
					showTooltip = false;
					
				}
				i++;
				
				
			}
			

		
	}
	
	string CreateTooltip(Item item)
	{
		tooltip =  item.itemName + "\n\n" + item.itemDesc + "\n";
		//tooltip = item.itemName;
		return tooltip;
		
	}
	
	private void UseCons(Item item,int slot,bool deleteItem)
	{
		switch(item.itemID)
		{
		case 0:
			//Последствия от использования предмета
			print("UseCons" + item.itemName);
			break;
		case 1:
			//Последствия от использования предмета
			print("UseCons" + item.itemName);
			break;
		default:break;
		}
		
		if(deleteItem)
		{
			draggedItem = null;
			draggingItem = false;
			inventory[slot] = new Item();
			
		}
	}
	
public bool CheckItem (int id)
	{
		bool result = true;
		 for(int i = 0; i<inventory.Count;i++)
		{
		if(inventory[i].itemID == id)
			{
		     result = true;
			 break;}
		else result = false;
			
	    }
	return result;
	}

public bool CheckSlot()
	{
		bool result = true;
		for(int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemID == -1)
			{
				result = true;
				break;}
			else result = false;
			
		}
		return result;
	}
	
	
	
	public void AddItem(int id)
	{
	   for(int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemName == null)
			{
				for(int j = 0;j<database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
						
					}
					
				}
				break;
			}
			
			
		}
	}
	
	
// Этот фрагмент возвращает поднят ли предмет или нет.
// Использовать в квестах.
	
	public bool InventoryCont(int id)
	{
		bool result = false;
	    for(int i = 0; i<inventory.Count;i++)
		{
			result =  inventory[i].itemID == id;
			if(result)
			{
				break;
			}
			
		}
		return result;
	}

//Удалять предмет из Инвентаря

	public void RemoveItem(int i)
	{
			inventory[i] = new Item();
		    draggingItem = false;
			draggedItem = null;	
		    
	}
	public void RemoveSlot(int i)
	{
			slots[i] = new Item();
		    draggingItem = false;
			draggedItem = null;	
		    
	}	
	 public void SaveInv()
	{
		for (int i = 0; i<inventory.Count; i++) {
			
						if (draggingItem && inventory [i].itemName == null) {
								inventory [i] = draggedItem;
								PlayerPrefs.SetInt ("Inv " + i, inventory [i].itemID);	
								break;
						}
				}


		for(int i = 0; i<inventory.Count;i++)
		{
			PlayerPrefs.SetInt("Inv " + i,inventory[i].itemID);	
		}


		//print("Saved Inv");
	}
	 public void SaveInvNULL()
	{

		for(int i = 0; i<inventory.Count;i++)
		{
		 PlayerPrefs.SetInt("Inv " + i,-1);	
		}
		//print("Saved Inv");
	}
	 public void LoadInv()
	{
		for(int i = 0; i<inventory.Count;i++)
		{
		inventory[i] = PlayerPrefs.GetInt("Inv " + i,-1)>= 0 ? database.items[PlayerPrefs.GetInt("Inv " + i)] : new Item();
		}
		//print("Load Inv");
	}
	
	
     public void UsingItems(int i)
	{
	
		  if(e.type == EventType.MouseDown&&e.button == 0)
			RemoveItem(i);
		
	}

public int GetCorrentItemMouse()
	{
	return correntItem;
	}
	
	
public bool isMultiple()
	{	
		return isMultipleT;
	}

	
	
public int GetItemNum()
	{
	 return correntItemNum;
	}


public int GetItemDataNum(int id)
	{
	 return database.items[id].itemNum;
	}


public int GetInvCount()
	{
		return inventory.Count;
	}


public void SetItemNum(int id,int num)
	{
	 database.items[id].itemNum = num;
	print ("itemNum " + database.items[id].itemNum);
	}
	
public bool GetDraggingItem()
	{
		return draggingItem;
	}

}
