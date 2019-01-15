using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour {
	public  List<TextA> LinesRu;
	public  List<TextA> LinesEn;
	public Texture2D Face;

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
	//public bool Picked{ get; set;}
	private float MinDialogTime;
    private Mouse _mouse;
    private List<GameObject> coll_obj = new List<GameObject>();
    private bool enter;

    public bool NoEnter = false;
    public bool VasilisMind = false;
    public bool PlayOnes = false;
    private int SkinNum = 0;
    private float fheight, fwidth, ymove;
    private Rect pos;
    private Rect dialogpos;
    private float move_dialog = Screen.width;
    public bool WrightInJournal;
    public string FaceString = "";
    private void Start () {
       // MinDialogTime = -1;
        skin = Resources.Load<GUISkin> ("Invent/Slot");
	   
		if(GameObject.Find("Vasilis")!=null)
			pl = GameObject.Find("Vasilis").GetComponent<Movement> ();

        _mouse = GameObject.Find("Mouse(Clone)").GetComponent<Mouse>();
        if(FaceString.Length>1)
        Face = Resources.Load<Texture2D>("Pers/Portrey" + FaceString);
    }
    

	private void Update()
	{

        if (_mouse.pointnclick)
        {
            enter = Input.GetMouseButtonDown(0);
            coll_obj = _mouse.GetCollObj();
        }
        else
        {
            enter = pl.enter_b;
            coll_obj = pl.Getcollob();
        }


       /*print(name + "__" + LinesRu[LinesRu.Count - 1].line);
        print(name + "__" + LinesEn[LinesEn.Count - 1].line);*/
       if(LinesRu.Count> LinesEn.Count) print(name + "__" + "LessRUCount");
        if (LinesRu.Count < LinesEn.Count) print(name + "__" + "LessENCount");
       // print(name);

        if (LinesRu!=null&& PlayerPrefs.GetInt("Language") == -1&& LinesRu.Count>0) {

            if (PlayerPrefs.GetInt("Day") < LinesRu.Count) texB = LinesRu[PlayerPrefs.GetInt("Day")].line;
            else texB = LinesRu[LinesRu.Count - 1].line;
        }
        if (LinesEn !=null&& PlayerPrefs.GetInt("Language") >=0 && LinesEn.Count > 0)
        {
            
            if (PlayerPrefs.GetInt("Day")< LinesEn.Count) texB = LinesEn[PlayerPrefs.GetInt("Day")].line;
            else texB = LinesEn[LinesEn.Count-1].line;
            
        }
		
		if (CollisionCase) {

            if (coll_obj.Contains(gameObject))
            {

                if (enter && MinDialogTime < Time.fixedTime&& pl.DayFinish>=1&&texB!=null)
                {

                    if (PlayIn && CorrentLine < texB.Length)
                    {
                        CorrentLine++;
                        MinDialogTime = Time.fixedTime + 0.2f;
                    }

                    if (!PlayIn)
                    {
                        PlayIn = true;
                        MinDialogTime = Time.fixedTime + 0.2f;
                    }

                    if (PlayIn && CorrentLine == texB.Length)
                    {
                        PlayIn = false;

                        CorrentLine = 0;
                        MinDialogTime = Time.fixedTime + 0.2f;
                    }

                }

                if (NoEnter)
                {
                    if (PlayOnes)
                    {
                        if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name) != 1)
                        {
                            PlayIn = true;

                        }
                    }
                    else
                        PlayIn = true;


                    Save();
                }
            
            
            

                // if((pl._horizontal!=0|| pl._vertical != 0)&& PlayIn&& MinDialogTime < Time.fixedTime) PlayIn = false;


            }
            else 
				if(PlayIn)
				PlayIn = false;
				

				
			


		
		}
	}


    // Update is called once per frame
    private void OnGUI()
    {
        if (pl.DayFinish>1.1f&& texB!=null) { 
        /*if (LinesRu != null && PlayerPrefs.GetInt("Language") == -1)
        {

            if (PlayerPrefs.GetInt("Day") < LinesRu.Count) texB = LinesRu[PlayerPrefs.GetInt("Day")].line;
            else texB = LinesRu[LinesRu.Count - 1].line;
        }
        if (LinesEn != null && PlayerPrefs.GetInt("Language") == 1)
        {

            if (PlayerPrefs.GetInt("Day") < LinesEn.Count) texB = LinesEn[PlayerPrefs.GetInt("Day")].line;
            else texB = LinesEn[LinesEn.Count - 1].line;

        }*/

        if (PlayIn == true && CorrentLine < texB.Length)
        {

            float XPosD = Camera.main.WorldToScreenPoint(transform.position).x - 100;
            float YPosD = Screen.height - Camera.main.WorldToScreenPoint(transform.position).y - 200;
            if (YPosD < 0) YPosD = 0;


            if (Face == null)
            {
                if (XPosD < 0)
                    XPosD = 0;
            }
            else
            {
                if (XPosD - 130 < 0)
                    XPosD = 130;
            }

            SkinNum = 2;
            if (VasilisMind)
            {
                SkinNum = 4;

                XPosD = Camera.main.WorldToScreenPoint(pl.transform.position).x - 150;
                    Vector3 np = new Vector3(pl.transform.position.x, pl.transform.position.y+4.5f,1);

                if (Screen.height - Camera.main.WorldToScreenPoint(np).y > 0)
                    YPosD = Screen.height - Camera.main.WorldToScreenPoint(np).y;
                else YPosD = 0;
                pos = new Rect(fheight + move_dialog, 0, fwidth, fheight);
                rectlable = new Rect(XPosD, YPosD, 300, 150);
            }

            rectlable = new Rect(XPosD, YPosD, fwidth, fheight);
            DrawLines();


        }

    }
	}
    void PosM(float stringslength)
    {
        if ((19 * (stringslength / 16)) >= 75)
            fheight = 35 + 19 * stringslength / 16;
        else
            fheight = 110;
        fwidth = 30 * 10;
        

    }
   
    void DrawLines()
    {


        if (texB.Length > 0)
        {
            if (GetComponent<AudioSource>() != null && GetComponent<Trigger>() == null)
            {
                if(!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            }

            PosM(texB[PlayerPrefs.GetInt(name + "Dialog")].Length);

            if (CorrentLine <= texB.Length - 1)
            {
                GUI.Box(rectlable, texB[CorrentLine], skin.customStyles[SkinNum]);

                if (WrightInJournal && PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "InJournal") == 0)
                {
                    PlayerPrefs.SetString(PlayerPrefs.GetInt("LastSlot") + "Name", name + SceneManager.GetActiveScene().name);

                    for (int i = 0; i < texB.Length; i++)
                    {
                        PlayerPrefs.SetString(PlayerPrefs.GetInt("LastSlot").ToString(), texB[i]);

                        if (i == 0) PlayerPrefs.SetString(PlayerPrefs.GetInt("LastSlot").ToString() + "Face", FaceString);
                        else PlayerPrefs.SetString(PlayerPrefs.GetInt("LastSlot").ToString() + "Face", null);
                        PlayerPrefs.SetInt("LastSlot", PlayerPrefs.GetInt("LastSlot") + 1);
                    }


                    PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "InJournal", 1);
                    PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "Quest", 0);

                }
            }
            if (CorrentLine < texB.Length - 1)
            {
                string nextt = "next";
                if (PlayerPrefs.GetInt("Language") == 1) nextt = "(next - e)";
                else nextt = "(далее - e)";

                GUI.Box(new Rect(rectlable.x + rectlable.width - 120, rectlable.y + rectlable.height - 30, 140, 30), nextt, skin.customStyles[5]);
            }
        }

        if (Face!=null)
        {
             GUI.DrawTexture(new Rect(rectlable.x - 110, rectlable.y, 110, 110), Face);
           
        }


    }


    void Save()
    {
        PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name, 1);
    }
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
