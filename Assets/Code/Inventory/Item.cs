using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class Item {
	public string itemName;
	public int itemID;

	public Texture2D itemIcon;
	public int itemNum;
    public string itemDescEN;
    public string itemDescRU;
    public List<string> itemCraft = new List<string>();

	public Item(string name,int ID,string descEN, string descRU)
	{
		itemName = name;
		itemID = ID;
		itemDescEN = descEN;
        itemDescRU = descRU;


        itemIcon = Resources.Load<Texture2D>("ItemIcons/"+ name);
	}

	public Item()
	{
		itemID = -1;
	}
}
