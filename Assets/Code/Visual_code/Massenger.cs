using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Massenger : MonoBehaviour {

	private string[] line_boy_0 = new string[100];

	private string[] line_boy_1 = new string[100];


	private  int[] line_count = new int[2];



	private Rect r;
	private Rect r2;
	private Camera cam ;
	public GUIStyle skin;
	private float[] y = new float[2];

	private float HightBor = 100f;
	private float BottBor;
	void Start () 
	{

		cam = Camera.main;
		BottBor = HightBor + 120f;
		y [0] = BottBor -5f;
		y [1] = BottBor - 65f;

		skin.wordWrap = true;
		skin.font = Resources.Load<Font> ("Fonts/Merriweather Light_ForDialogs");
		skin.padding.right = 7;
		skin.padding.left = 10;
		skin.padding.top = 4;
		skin.padding.bottom = 4;
		skin.fontSize = 17;
	
		r = new Rect(cam.WorldToScreenPoint(transform.position).x,cam.WorldToScreenPoint(transform.position).y,50f,40f);
	
		line_count [0] = 0;
		line_count [1] = 0;
	
	}




	void Update () 
	{

		int Day = PlayerPrefs.GetInt ("Day");


//Russian
		if (PlayerPrefs.GetInt ("Language") == 0) {
			if (Day == 5) {
			
				line_boy_1.SetValue ("Да, сижу сейчас в парке.", 0);
				line_boy_0.SetValue ("Привет. У тебя все в порядке?", 0);
			
				line_boy_1.SetValue ("Нет, меня не отпустят.", 1);
				line_boy_0.SetValue (" Не пойдешь сегодня?", 1);
			
				line_boy_1.SetValue ("До связи.", 2);
				line_boy_0.SetValue ("Ладно, я завтра напишу как прошло.", 2);
			
			}


			if (PlayerPrefs.GetInt ("Burning5D") == 3 && Day == 6) {
				line_boy_0.SetValue ("Не знаю, это точно не наши.", 0);
				line_boy_1.SetValue ("Слышал, что ,больницу подожгли. Кто мог не знаешь?", 0);
			}
			if (PlayerPrefs.GetInt ("Burning5D") == 2 && Day == 6) {
				line_boy_0.SetValue ("Не знаю, это точно не наши.", 0);
				line_boy_1.SetValue ("Слышал, что Морг подожгли. Кто мог не знаешь?", 0);
			}


			if (Day == 7) {

				line_boy_1.SetValue ("Да у нас тут перекрыли все.", 0);
				line_boy_0.SetValue ("Кажется в город теперь не пробраться.", 0);

				line_boy_1.SetValue ("Хорошо, я тоже поищу лазейки.", 1);
				line_boy_0.SetValue ("Я еще опробую старые тропы, но ничего не обещаю.", 1);

				line_boy_1.SetValue ("Да. Я буду днем в сети.", 2);
				line_boy_0.SetValue ("Надеюсь связь не упадет, буду писать завтра.", 2);

			}

			if (Day == 8) {

				line_boy_1.SetValue ("Да у нас тут перекрыли все.", 0);
				line_boy_0.SetValue ("Кажется в город теперь не пробраться.", 0);
			
				line_boy_1.SetValue ("Хорошо, я тоже поищу лазейки.", 1);
				line_boy_0.SetValue ("Я еще опробую старые тропы, но ничего не обещаю.", 1);
			
				line_boy_1.SetValue ("Да. Я буду днем в сети.", 2);
				line_boy_0.SetValue ("Надеюсь связь не упадет, буду писать завтра.", 2);
			}
			if (Day == 12) {
			
				line_boy_1.SetValue ("Тут очень плохо ловит.", 0);
				line_boy_0.SetValue ("Ничего. Напиши что еще добыть нужно.", 0);
			
				line_boy_1.SetValue ("Сейчас вода нужна очень. Хорошо что ты пробрался в город.", 1);
				line_boy_0.SetValue ("Да постараюсь добыть.", 1);
			
				line_boy_1.SetValue ("Да. Я буду днем в сети.", 2);
				line_boy_0.SetValue ("Надеюсь связь не упадет, буду писать завтра.", 2);
			}
		} 



//English

		else if (PlayerPrefs.GetInt ("Language") == 1) {
			if (Day == 5) {
				
				line_boy_1.SetValue ("I'm in the park now.", 0);
				line_boy_0.SetValue ("Hi. Are you ok?", 0);
				
				line_boy_1.SetValue ("No, they will not let me go.", 1);
				line_boy_0.SetValue ("Whould you come today?", 1);
				
				line_boy_1.SetValue ("Bye.", 2);
				line_boy_0.SetValue ("Ok, I will tell you how does it goes.", 2);
				
			}
			
			
			if (PlayerPrefs.GetInt ("Burning5D") == 3 && Day == 6) {
				line_boy_0.SetValue ("I do not know, it's not one of us.", 0);
				line_boy_1.SetValue ("I've heard that the hospital was set on fire. Who could do this?", 0);
			}
			if (PlayerPrefs.GetInt ("Burning5D") == 2 && Day == 6) {
				line_boy_0.SetValue ("I do not know, it's not one of us.", 0);
				line_boy_1.SetValue ("I've heard that the mortuary was set on fire. Who could do this??", 0);
			}

			
			if (Day == 7) {
				
				line_boy_1.SetValue ("Yes, they blocked all roads.", 0);
				line_boy_0.SetValue ("It seems the city is no longer open.", 0);
				
				line_boy_1.SetValue ("ok,I will look for loopholes too.", 1);
				line_boy_0.SetValue ("I still tring the old trails, but no promising anything.", 1);
				
				line_boy_1.SetValue ("Yep, I will be here.", 2);
				line_boy_0.SetValue ("I hopes the network will not fall, I will write tomorrow.", 2);
				
			}
			
			if (Day == 8) {
				
				line_boy_1.SetValue ("Ye, everything is blocked.", 0);
				line_boy_0.SetValue ("Is that true, about city siege?", 0);
				
				line_boy_1.SetValue ("Good, I will search for path too.", 1);
				line_boy_0.SetValue ("I'll try the old ways, but not promess save pathing.", 1);
				
				line_boy_1.SetValue ("Ok, I'll be waiting.", 2);
				line_boy_0.SetValue ("I assume tomorrow network will be stable. I'll write.", 2);
			}
			if (Day == 12) {
				
				line_boy_1.SetValue ("Connection is so bad.", 0);
				line_boy_0.SetValue ("Do you need any stuff?", 0);
				
				line_boy_1.SetValue ("We got no water left.", 1);
				line_boy_0.SetValue ("Ok, I'll try to get some.", 1);
				
				line_boy_1.SetValue ("Will wait", 2);
				line_boy_0.SetValue ("Will write", 2);
			}
		
		}
		for (int j = 0; j<2; j++) {
			if (y [j] > HightBor)
				y [j] -= 0.2f;
			else
			{
				if(y [0] <= HightBor)line_count[1]++;
				else if(y [1] <= HightBor)line_count[0]++;
				y [j] = BottBor;
			}
		}
		r = new Rect(cam.WorldToScreenPoint(transform.position).x-100f,y[0],200f,50f);
		r2 = new Rect(cam.WorldToScreenPoint(transform.position).x-130f,y[1],200f,50f);

	}


	void OnGUI()
	{
		if(line_boy_1[line_count[1]] != null)GUI.Box(r,line_boy_1[line_count[1]],skin);
		if(line_boy_1[line_count[0]] != null)GUI.Box(r2,line_boy_0[line_count[0]],skin);
	}



}
