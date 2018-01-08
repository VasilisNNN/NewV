using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TextB : MonoBehaviour {
	
	public  List<TextA> Lines;
	private  List<TextA> Lll = new List<TextA>();

	private string[] l = new string[]{"Я с вами не буду говорить"};

	private string[] random0 = new string[]{"Я с вами не буду говорить"};
	private string[] random1 = new string[]{"Я с вами не говорю"};
	private string[] random2 = new string[]{"Сегодня я с вами не говорю"};



	//private int cc;
	private Texture2D EnterDoor,ExitDoor;
	private Movement pl;
	void Start()
	{
		if(GameObject.Find("Vasilis")!=null)
		pl = GameObject.Find("Vasilis").GetComponent<Movement> ();
	
		Lll.Insert(0,new TextA(random0));
		Lll.Insert(1,new TextA(random1));
		Lll.Insert(2,new TextA(random2));

		for(int i = 0; i<16;i++)
		{
		//cc = Lines.Count+i;
			l = Lll[Random.Range(0,2)].line;

		if(i>=Lines.Count)
				Lines.Insert(i,new TextA(l));

		}
	}

	//{get;set;}
	public string[]  GetLines()
	{ 
			return Lines[PlayerPrefs.GetInt("Day")].line;

	}





}
