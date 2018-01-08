using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();
	
	void Awake()
	{
		items.Add(new Item("Cure",0,"CanCure"));
		items.Add(new Item("HandSin",1,"CanKill"));
		
		items.Add(new Item("Tube",2,"CanKill"));
		items.Add(new Item("TubeWide",3,"CanKill"));
		items.Add(new Item("MetalBox",4,"CanKill"));
		items.Add(new Item("PaperBox",5,"CanKill"));
		items.Add(new Item("Tape",6,"CanKill"));
		
		items.Add(new Item("FireUp",7,"Part of gun power"));
		items.Add(new Item("Fuel",8,"Part of gun power"));
		items.Add(new Item("Oxidant",9,"Part of gun power"));
		
		items.Add(new Item("GunPower",10,"Weak"));
		items.Add(new Item("GunPower",11,"Normal"));
		items.Add(new Item("GunPower",12,"Strond"));
		items.Add(new Item("GunPower",13,"Danger"));
		
		items.Add(new Item("Bomb0",14,"Weak Bomb"));
		items.Add(new Item("Bomb1",15,"Midle Bomb"));
		items.Add(new Item("Bomb2",16,"Strong Bomb"));
		items.Add(new Item("Bomb3",17,"WallBuster Bomb"));
		
		items.Add(new Item("TubeWide",18,"WallBuster Bomb"));
		items.Add(new Item("TubeWide",19,"Ключ из мертвого тела"));
		items.Add(new Item("TubeWide",20,"WallBuster Bomb"));
		
		items.Add(new Item("TubeWide",21,"KeyFromMorg"));
		items.Add(new Item("TubeWide",22,""));
		items.Add(new Item("TubeWide",23,""));
		
		items.Add(new Item("Ax",24,"WallBuster Bomb"));
		items.Add(new Item("Ax",25,"WallBuster Bomb"));

		
		items.Add (new Item ("Peter's Right Eye", 26, "Peter's Right Eye"));
		items.Add (new Item ("Peter's Left Eye", 27, "Peter's Left Eye"));
		items.Add (new Item ("Peter's Right Hand", 28, "Peter's Right Hand"));
		items.Add (new Item ("Peter's Left Hand", 29, "Peter's Left Hand"));

	
		items.Add (new Item ("Plant", 30, "Plant"));
		items.Add (new Item ("TubeWide", 31, "ForBombs"));


	}


}
