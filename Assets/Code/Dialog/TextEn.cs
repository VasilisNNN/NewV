using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TextEn : MonoBehaviour {
	
	public  List<TextA> Lines;
	private  List<TextA> Lll = new List<TextA>();

	private string[] l = new string[]{"Go now!"};

	private string[] random0 = new string[]{"I don't care about you."};
	private string[] random1 = new string[]{"I don't talk."};
	private string[] random2 = new string[]{"Go away."};


	public Texture[] Face;
	//private int cc;
	void Start()
	{

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


	public Texture GetFace(int i)
	{
		return Face[i];
	}



}
