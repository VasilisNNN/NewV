using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemNum;

	public List<string> itemCraft = new List<string>();

	public Item(string name,int ID,string desc)
	{
		itemName = name;
		itemID = ID;
		itemDesc = desc;
		
		itemIcon = Resources.Load<Texture2D>("ItemIcons/"+ name);
	}

	public Item()
	{
		itemID = -1;
	}
}
