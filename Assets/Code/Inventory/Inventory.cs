using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {
		 

	
	private int slotX,slotY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	
	public bool showinvent{get;set;}
    public bool JournalDraw { get; set; }
    //public bool showI{get;set;}
    private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;
	
	private bool draggingItem;
	private Item draggedItem;

	
	private PickObject PickOb;
	private int previIndex;
	private Event e;
    public int correntSlot { get; set; }

	private bool isMultipleT = false;
	private Item item;
	private float mousedeley;
    private Movement pl;
    private Mouse _mouse;
    private Texture Choise;
    private Texture2D JournalBG,CrossFace;
    
    void Awake()
	{
        pl = GameObject.Find("Vasilis").GetComponent<Movement>();
        
        if (GameObject.Find ("Mouse") == null) {
			GameObject Stepss  = new GameObject();
			Stepss = (GameObject)Instantiate(Resources.Load("PrefabObjects/Mouse"));
		}
        _mouse = GameObject.Find("Mouse(Clone)").GetComponent<Mouse>();
        Choise = Resources.Load<Texture>("Invent/Seed");
        JournalBG = Resources.Load<Texture2D>("Invent/Journal");
        CrossFace = Resources.Load<Texture2D>("Invent/CrossFace");
    }
    // Use this for initialization
    void Start () {
	
		//showI= true;
		slotX = 15;
		slotY = 1;
		for(int i = 0; i<(slotX*slotY);i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		
	    database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
	    


	LoadInv();

		if (SceneManager.GetActiveScene ().name == "BombCraft")
			showinvent = true;
        /*AddItem (0, 2);
        AddItem(1, 2);*/
        /*AddItem (8, 4);
		AddItem (9, 5);*/

        //AddPeterParts
       /* AddItem (26, 1);
       AddItem (27, 1);
       AddItem (28, 1);
       AddItem (29, 1);*/
        //AddItem(18, 300);
    }
    private void Update()
    {
        if (!_mouse.pointnclick&&showinvent)
        {
            if (pl._horizontal < 0 && mousedeley < Time.fixedTime&& correntSlot > 0)
            {
                correntSlot--;
                mousedeley = Time.fixedTime + 0.2f;
            }
            if (pl._horizontal > 0 && mousedeley < Time.fixedTime&& correntSlot < slotX-1)
            {
                correntSlot++;
                mousedeley = Time.fixedTime + 0.2f;
            }
        }
    }

    void OnGUI()
	{

        if (JournalDraw)
            Journal();

            tooltip = "";
		GUI.skin = skin;
		
		if(showinvent)
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

        if(GameObject.Find("Mouse(Clone)").GetComponent<Mouse>().pointnclick)
		GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), 
			GameObject.Find("Mouse(Clone)").GetComponent<Mouse>().GetTexture());

		if(draggingItem&&draggedItem!=null)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,50,50),draggedItem.itemIcon);
			GUI.Box(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,50,50),draggedItem.itemNum.ToString(),skin.customStyles[3]);
		}
		
	}



    void Journal()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), JournalBG);

        int CorrentPage = PlayerPrefs.GetInt("CorrentPage");
        
        float XPos = 0;
        Texture2D facet;
        for (int i = 0; i < 6; i++)
        {
           
           
                if (i < 3) XPos = 0;
                else if(i >= 3) XPos = 1;

            float Y = 20 + 150 * i - XPos * 150*3;

            if (PlayerPrefs.GetString((CorrentPage * 6 + i) + "Face").Length > 1)
            {
                facet = Resources.Load<Texture2D>("Pers/Portrey/" + PlayerPrefs.GetString((CorrentPage * 6 + i) + "Face"));

                GUI.DrawTexture(new Rect(20 + (Screen.width / 2) * XPos, Y, 150, 150), facet);

                if (PlayerPrefs.GetInt(PlayerPrefs.GetString((CorrentPage * 6 + i) + "Name") + "Quest") == 1)
                {
                    GUI.DrawTexture(new Rect(20 + (Screen.width / 2) * XPos, Y, 150, 150), CrossFace);
                    // print(PlayerPrefs.GetString((CorrentPage * 6 + i) + "Name") + "Quest");
                }

                if (PlayerPrefs.GetString((CorrentPage * 6 + i).ToString()).Length > 1)
                    GUI.Box(new Rect(170 + (Screen.width / 2) * XPos, Y, Screen.width / 2 - 200, 150),
                             PlayerPrefs.GetString((CorrentPage * 6 + i).ToString()), skin.customStyles[2]);

            }
            else
            {
                if (PlayerPrefs.GetString((CorrentPage * 6 + i).ToString()).Length > 1)
                    GUI.Box(new Rect(20 + (Screen.width / 2) * XPos, Y, Screen.width / 2 - 50, 150),
                             PlayerPrefs.GetString((CorrentPage * 6 + i).ToString()), skin.customStyles[2]);
            }

            if (i < 3) XPos = 0;
            else XPos = 1;

          

           




        }



    }
void DrawInventory()
	{
		int i  =0 ;
		e = Event.current;
        float w = Screen.width / slotX - 10;
        if (!_mouse.pointnclick)
        {
            GUI.DrawTexture(new Rect((w + 10) * correntSlot - 5f, Screen.height - 110, 80, 80), Choise);
        }
        
        for (int x= 0; x<slotX;x++)
			{
				Rect slotRect = new Rect(x* (w + 10), Screen.height - w, w, w);
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
			    slots[i] = inventory[i];
				item = slots[i];
				
				if(slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
                float numw = slotRect.width / 2.1f;
                GUI.Box(new Rect(slotRect.x+ slotRect.width -numw, slotRect.y+ slotRect.width-numw, numw, numw),slots[i].itemNum.ToString(),skin.customStyles[3]);

                if (slots[correntSlot].itemDescEN != null)
                GUI.Box(new Rect((w + 10) * correntSlot - 5f, Screen.height - slotRect.width-150, 150, 150), CreateTooltip(slots[correntSlot]), skin.customStyles[2]);
                
               /* if (slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;
				
			
					if (Input.GetMouseButtonDown (0) &&mousedeley<Time.fixedTime&& !draggingItem&&slotRect.Contains(new Vector2(Input.mousePosition.x,Screen.height - Input.mousePosition.y))) 
						{

							draggingItem = true;
							previIndex = i;
							draggedItem = item;
						    slots[i] = new Item ();
							//correntItem = item.itemID;

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
                    
					}*/
					
				}/*else{
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
					
				}*/
				if(tooltip == "")
				{
					showTooltip = false;
					
				}
				i++;
				
				
			}


		
	}
	
	string CreateTooltip(Item item)
	{
        
            if (PlayerPrefs.GetInt("Language") == 1)
                tooltip = item.itemDescEN;
            else
                tooltip = item.itemDescRU;

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

    public int CheckCorrentItem()
    {
        
        return inventory[correntSlot].itemID;
    }
    public int CheckCorrentItemNum()
    {

        return inventory[correntSlot].itemNum;
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

	public void AddItem(int id,int numplus)
	{
		if (CheckItem(database.items[id].itemID))
		{
			for (int i = 0; i < inventory.Count; i++)
			{

				if (inventory[i].itemID == id)
				{
					inventory[i].itemNum+=numplus;
					break;
				}
			}
		}
		else
		{
			for (int i = 0; i < inventory.Count; i++)
			{
				if (inventory[i].itemName == null)
				{
					for (int j = 0; j < database.items.Count; j++)
					{
						if (database.items[j].itemID == id)
						{
							inventory[i] = database.items[j];
							inventory[i].itemNum+=numplus;

						}

					}
					break;
				}


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


        if (slots[i].itemNum <= 1)
        {
            slots[i] = new Item();
            inventory[i] = new Item();
            draggingItem = false;
            draggedItem = null;
        }
        else
        {
            slots[i].itemNum--;
         
        }

		    
	}

    public void RemoveMultiSlot(int i,int numrem)
    {


        if (slots[i].itemNum <= numrem)
        {
            slots[i] = new Item();
            inventory[i] = new Item();
            draggingItem = false;
            draggedItem = null;
        }
        else
        {
            slots[i].itemNum-= numrem;

        }


    }
    public void SaveInv()
	{
		for (int i = 0; i< inventory.Count; i++) {

            if (_mouse.pointnclick)
            {
                if (draggingItem && inventory[i].itemName == null)
                {
                    slots[i] = draggedItem;
                    PlayerPrefs.SetInt("Inv " + i, inventory[i].itemID);
                    PlayerPrefs.SetInt("Invnum" + i, inventory[i].itemNum);
                    break;
                }
                else {

                    PlayerPrefs.SetInt("Inv " + i, inventory[i].itemID);
                    PlayerPrefs.SetInt("Invnum" + i, inventory[i].itemNum);

                }

            }
            else
            {
                
                PlayerPrefs.SetInt("Inv " + i, inventory[i].itemID);
                PlayerPrefs.SetInt("Invnum" + i, inventory[i].itemNum);
                
            }
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
	 private void LoadInv()
	{
		for(int i = 0; i<inventory.Count;i++)
		{
            
            inventory[i] = PlayerPrefs.GetInt("Inv " + i,-1)>= 0 ? database.items[PlayerPrefs.GetInt("Inv " + i)] : new Item();

            if(PlayerPrefs.GetInt("Invnum" + i)>0)inventory[i].itemNum = PlayerPrefs.GetInt("Invnum" + i);

        }
		//print("Load Inv");
	}
	
	
     public void UsingItems(int i)
	{
	
		  if(e.type == EventType.MouseDown&&e.button == 0)
			RemoveItem(i);
		
	}



	
public bool isMultiple()
	{	
		return isMultipleT;
	}




public int GetItemDataNum(int id)
	{
	 return database.items[id].itemNum;
	}


public int GetInvNum()
	{
		return draggedItem.itemNum;
	}

	public void SetInvNum(int n)
	{
		draggedItem.itemNum += n;
	}

public void SetItemNum(int id,int num)
	{
	 database.items[id].itemNum = num;
	
	}

	public void ItemToContainer(int plus_minus)
	{
		if (draggedItem != null) {

			int n = draggedItem.itemNum - plus_minus;
			//print (n);
				if (draggedItem.itemNum <= plus_minus) {
					draggedItem = null;
					draggingItem = false;
				} 
				else{
				   // draggedItem.itemNum =  draggedItem.itemNum- plus_minus;

				for (int i = 0; i < inventory.Count; i++)
				{
					if (inventory[i].itemName == null)
					{
						for (int j = 0; j < database.items.Count; j++)
						{
							if (database.items[j].itemID == draggedItem.itemID)
							{
								inventory[i] = draggedItem;
								inventory[i].itemNum=n;

							}

						}
						break;
					}


				}

					draggedItem = null;
					draggingItem = false;
				} 
			}
			
		

	}

public bool GetDraggingItem()
	{
		return draggingItem;
	}

	public Item GetDraggedItem()
	{
		return draggedItem;
	}
}
