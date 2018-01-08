using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialog : MonoBehaviour {
	public  List<TextA> LinesRu;
	public  List<TextA> LinesEn;
	public Texture[] Face;

	public bool CollisionCase  =true;


	private Rect rectlable = new Rect(0,0,Screen.width-100,100);
	private GUISkin skin;


	private string[] texB;
	private int finalLine = 1;
	private int finalLinePl = 1;
	private int CorrentLine = 0;

	public bool PlayIn = false;

	public string DialogPartName{ get; set;}
	private Movement pl;
	private Texture2D EnterDoor,ExitDoor;
	public bool Picked{ get; set;}
	private float MinDialogTime;
	private void Start () {
		skin = Resources.Load<GUISkin> ("Invent/Slot");
	
		if(GameObject.Find("Vasilis")!=null)
			pl = GameObject.Find("Vasilis").GetComponent<Movement> ();

		EnterDoor = Resources.Load<Texture2D> ("Interface/CursorMouth");
		ExitDoor = Resources.Load<Texture2D> ("Interface/Cursor");
		//dialogText = texB.GetLines ();
		PlayerPrefs.SetInt ("Day", 0);
	}

	private void Update()
	{
		if(PlayerPrefs.GetInt("Day")<LinesRu.Count){
		if (PlayerPrefs.GetInt ("Language") == -1)
			texB = LinesRu[PlayerPrefs.GetInt("Day")].line;
		else texB = LinesEn[PlayerPrefs.GetInt("Day")].line;
		}
		if (CollisionCase) {

			if (pl.Getcollob ().Contains (gameObject)) {
				if (Input.GetMouseButtonDown (0) && MinDialogTime < Time.fixedTime&&Picked) {
					if (PlayIn && CorrentLine < texB.Length)
					{CorrentLine++;
						MinDialogTime = Time.fixedTime + 0.2f;
					}

					if (!PlayIn) {
						pl.MovePers = false;
						PlayIn = true;
						MinDialogTime = Time.fixedTime + 0.2f;
					}

						if (PlayIn&&CorrentLine == texB.Length)
						{
							PlayIn = false;
							pl.MovePers = true;
							CorrentLine = 0;
							MinDialogTime = Time.fixedTime + 0.2f;
						}
					
				}


			}else 
				if(PlayIn)
				{
					PlayIn = false;
					pl.MovePers = true;

				}
			


		
		}
	}
	

	// Update is called once per frame
	private void OnGUI () {



			if (PlayIn == true&&CorrentLine<texB.Length) {
				GUI.Box (rectlable, texB[CorrentLine], skin.customStyles[2]);

				if(Face.Length>1)
				{
					if (CorrentLine%2==0) 
				{
						GUI.DrawTexture(new Rect(rectlable.x+rectlable.width,0f,rectlable.height,rectlable.height),Face[0]);		
					}else GUI.DrawTexture(new Rect(rectlable.x+rectlable.width,0f,rectlable.height,rectlable.height),Face[1]);
				}
				else GUI.DrawTexture(new Rect(rectlable.x+rectlable.width,0f,rectlable.height,rectlable.height),Face[0]);

			    }
				




			



	}

	private void OnMouseOver()
	{
		if (pl.Getcollob().Contains(gameObject)) {
			//Cursor.SetCursor (EnterDoor, Vector2.zero, CursorMode.Auto);
			pl.CursorT = EnterDoor;
			Picked = true;
		}
		
	}
	
	private void OnMouseExit()
	{
		if (Picked||!pl.Getcollob().Contains(gameObject)) {
			pl.CursorT = ExitDoor;
			Picked = false;
		}
		
	}
	public Texture[] GetFace()
	{return Face;}

	public Texture GetFace(int i)
	{return Face[i];}

public void SetFinalLine(int FL)
	{
		finalLine = FL;
	}
	
public void SetFinalLinePl(int FL)
	{
		finalLinePl = FL;
	}

public void SetDialogPartName(string PL)
	{
		DialogPartName = PL;
	}



public int GetFinalLine()
	{
		return finalLine;
	}


public void SetTextField(Rect Field)
	{
		rectlable = Field;
	}

		
}
