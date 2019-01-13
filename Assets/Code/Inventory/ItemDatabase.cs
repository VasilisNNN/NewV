using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();
	
	void Awake()
	{
		items.Add(new Item("SleepingPills",0, "Sleeping Pills","Снотворное"));
		items.Add(new Item("Cure",1, "Cure","Лекарство"));
		
		items.Add(new Item("Ax",2, "Ax","Топор"));
		items.Add(new Item("Seeds",3, "Seeds","Семена"));
		items.Add(new Item("KidsKey",4, "KidsKey","Детский ключ"));
		items.Add(new Item("TurboKey",5, "TurboKey","Ключ от Турбин"));
		items.Add(new Item("Car key", 6, "Car key", "Ключ от машины"));
		
		items.Add(new Item("Heart",7, "Heart","Сердце"));
		items.Add(new Item("Fuel",8,"Part of gun power","Порох"));
		items.Add(new Item("Oxidant",9,"Part of gun power","Порох"));
		
		items.Add(new Item("Beer",10,"Beer","Пиво"));
		items.Add(new Item("Water",11, "Water","Вода"));
		items.Add(new Item("Key",12,"Key","Ключ"));
		items.Add(new Item("CasualLeg", 13, "CasualLeg","Нога"));
		
		items.Add(new Item("Bomb0",14,"Weak Bomb","Бомба"));
		items.Add(new Item("Bomb1",15,"Midle Bomb", "Бомба"));
		items.Add(new Item("Bomb2",16,"Strong Bomb", "Бомба"));
		items.Add(new Item("Bomb3",17,"WallBuster Bomb", "Бомба"));
		
		items.Add(new Item("1 $",18, "1 $", "Деньги"));
		items.Add(new Item("Rare book",19, "Rare book", "Редкая книга"));
		items.Add(new Item("Old cup",20,"Old cup", "Сатаря чашка"));
		
		items.Add(new Item("HeartLocked", 21, "HeartLocked", "Запертое сердце"));
		items.Add(new Item("Old crosses", 22, "Old crosses", "Кресты"));
		items.Add(new Item("TubeWide",23,"", "широкая труба"));
		
		items.Add(new Item("Meat",24, "Meat", "Мясо"));
		items.Add(new Item("Milk",25, "Milk", "Молоко"));

		
		items.Add (new Item ("Peter's Right Eye", 26, "Peter's Right Eye", "Правый глаз Петра"));
		items.Add (new Item ("Peter's Left Eye", 27, "Peter's Left Eye", "Левый глаз Петра"));
		items.Add (new Item ("Peter's Right Hand", 28, "Peter's Right Hand", "Правая рука Петра"));
		items.Add (new Item ("Peter's Left Hand", 29, "Peter's Left Hand", "Левая рука Петра"));

	
		items.Add (new Item ("Plant", 30, "Plant", "Растение"));
		items.Add (new Item ("Card", 31, "Card", "Карточка"));
        items.Add(new Item("Coat", 32, "Coat", "Пальто"));
        items.Add(new Item("Loto", 33, "Loto", "Лото"));
        items.Add(new Item("SkeletKey", 34, "SkeletKey", "Скелетный ключ"));
        items.Add(new Item("Uniform", 35, "Uniform", "Униформа"));


    }


}
