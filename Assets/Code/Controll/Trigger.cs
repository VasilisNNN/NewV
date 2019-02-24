using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class Trigger : MonoBehaviour {

    private bool Clicked = false;
    public AudioClip[] clips;
    private AudioSource AS;
    public bool RNDClip = false;
    private Mouse _mouse;
    public string[] PrefsName;
    public int[] PrefsINT;
    private List<GameObject> coll_obj = new List<GameObject>();
    private Movement pl;
    private bool enter;
    private bool[] AUPLAY;

    public SpriteRenderer[] SPRT;
    public bool[] SPRTBools;
    public bool SelfTransperent = false;
    private bool SelfTransperentStart = false;
    private float SelfTransperentFloat = 1;

    public bool ConnectBoxToSPRT = false;
    public bool OnOffBools = false;

    public Animator[] Anims;
    public string[] AnimsNames;
    public bool[] AnimsBools;

  

    public int NeededItem = -1;
    public int NeededItemNum = 1;

    public int AddedItem = -1;
    public int AddedItemNum = 1;

    public bool MinusNeededItem = false;
    public bool MinusNeededItemONES = false;

    private Inventory inv;

    public bool OffIfNotColl;

    public SpriteRenderer[] MultiCases;
    private int[] MultiCasesNumbs;

    public bool DayPlus;
    public bool NoEnter;
    public bool StopPlayer;
    public bool MovePlayer = false;


    public string LoadLocationDayEnd = "-1";
    public float SetZoom = -1000;
    public string Quest_NameLocationQuest = "";

    public bool DontLoad = false;

    void Start()
	{
		_mouse = GameObject.Find ("Mouse(Clone)").GetComponent<Mouse> ();
        pl = GameObject.Find("Vasilis").GetComponent<Movement>();
        AS = GetComponent<AudioSource> ();
        inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
        if(MultiCases!=null)
        MultiCasesNumbs = new int[MultiCases.Length];

        if(SPRT!=null)
        AUPLAY = new bool[SPRT.Length];
        if (!DontLoad)
        {
            if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "Anim") == 1) AnimONOFF();
            if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "DestroyTrigger") == 1) Destroy(gameObject);

            if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "SPRT") == 1)
            {
                if (SelfTransperent) SelfTransperentStart = true;

                for (int i = 0; i < SPRT.Length; i++)
                {
                    if (MultiCases.Length == 0)
                    {
                        
                        SpritesBools(i);
                    }

                }
            }
        }

        
    }
    void Update()
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

        if (SelfTransperentStart) {
            SelfTransperentFloat -= 0.01f;
            GetComponent<SpriteRenderer>().color =
new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, SelfTransperentFloat);
            if (SelfTransperentFloat <= 0)
            {
                PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "DestroyTrigger", 1);
                Destroy(gameObject);
            }
        }
        if (MultiCasesNumbs!=null)
        {
            for (int i = 0; i < MultiCases.Length; i++)
            {
                if (MultiCases[i] != null) {
                        if (MultiCases[i].enabled) MultiCasesNumbs[i] = 1;
                        else MultiCasesNumbs[i] = 0;
                    }
                else MultiCasesNumbs[i] = 0;
            }
            if (SPRT.Length > 0)
            {
                for (int i = 0; i < SPRT.Length; i++)
                {
                    if (MultiCases.Length > 0 && MultiCasesNumbs.Sum() == MultiCasesNumbs.Length)
                    {
                        AUDIOSPRT(i);
                        SpritesBools(i);
                    }
                }
            }

        }

        if (OffIfNotColl && !coll_obj.Contains(gameObject))
            {
                for (int i = 0; i < SPRT.Length; i++)
                {
                if (SPRT[i] != null)
                {
                    SPRT[i].enabled = false;
                    if (ConnectBoxToSPRT && SPRT[i].GetComponent<BoxCollider2D>() != null)
                        SPRT[i].GetComponent<BoxCollider2D>().enabled = false;
                }
                }

            }

            if (coll_obj.Contains(gameObject) )
            {
            if (!NoEnter)
            {
                if (enter)
                {
                    AllActions();
                    if (StopPlayer) pl.MovePers = false;
                    if (AS != null)
                    {
                        if (!AS.isPlaying) AS.Play();
                    }
                }
            }
            else
            {
                AllActions();
                if (StopPlayer) pl.MovePers = false;
                if (MovePlayer) pl.MovePers = true;
            }


        }
        
	}
    void AllActions()
    {
        if (SetZoom != -1000) Camera.main.GetComponent<CameraBor>().SetZoom(SetZoom);

        if (NeededItem < 0)
        {
            if (AddedItem > -1 && PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "AddedItem")!=1)
            {
                inv.AddItem(AddedItem, AddedItemNum);
                PlayerPrefs.SetInt(name+SceneManager.GetActiveScene().name+"AddedItem", 1);
                inv.SaveInv();
            }
            

            if (Quest_NameLocationQuest.Length > 0) PlayerPrefs.SetInt(Quest_NameLocationQuest, 1);
        }
        else if (inv.CheckCorrentItem() == NeededItem && inv.showinvent && inv.CheckCorrentItemNum() >= NeededItemNum)
        {
            if (AddedItem > -1)
            {
                inv.AddItem(AddedItem, AddedItemNum);
                inv.SaveInv();
            }

            if (Quest_NameLocationQuest.Length > 0) PlayerPrefs.SetInt(Quest_NameLocationQuest, 1);
        }


        if (SelfTransperent)
        {
            if (NeededItem == -1) SelfTransperentStart = true;
            else if (inv.CheckCorrentItem() == NeededItem && inv.showinvent)
                SelfTransperentStart = true;
        }
        
            
        if (DayPlus)
        {
            if (NeededItem < 0)
            {
                pl.DayFinish = 0;
                if (LoadLocationDayEnd != "-1")
                {
                    inv.SaveInv();
                    pl.EndDayLocation = LoadLocationDayEnd;
                    pl.PlusDay = true;
                }

                //Destroy(gameObject);
                DayPlus = false;
            }

            else
            {
                if (inv.CheckCorrentItem() == NeededItem && inv.showinvent)
                {
                    pl.DayFinish = 0;
                    if (LoadLocationDayEnd != "-1")
                    {
                        inv.SaveInv();
                     
                        pl.EndDayLocation = LoadLocationDayEnd;
                        pl.PlusDay = true;
                    }
                    DayPlus = false;
                }

            }
        }


       

        if (SPRT.Length > 0)
        {
            if (NeededItem < 0)
            {
                for (int i = 0; i < SPRT.Length; i++)
                {
                    if (MultiCases.Length == 0)
                    {
                        AUDIOSPRT(i);
                        SpritesBools(i);

                    }
                }
                if (MultiCases.Length == 0)
                    PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "SPRT", 1);
                else if(MultiCasesNumbs.Sum()>= MultiCases.Length)
                    PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "SPRT", 1);

            }
            else if (inv.CheckCorrentItem() == NeededItem && inv.showinvent&&inv.CheckCorrentItemNum()>=NeededItemNum)
            {

                for (int i = 0; i < SPRT.Length; i++)
                {
                    if (MultiCases.Length == 0)
                    {
                        AUDIOSPRT(i);
                        SpritesBools(i);
                       
                    }
                }
                if (MinusNeededItem)
                {
                    inv.RemoveMultiSlot(inv.correntSlot, NeededItemNum);
                   // inv.RemoveSlot(inv.correntSlot);
                }
                if (MinusNeededItemONES&& PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "SPRT")!=1)
                {
                    inv.RemoveMultiSlot(inv.correntSlot, NeededItemNum);
                    MinusNeededItemONES = false;
                }
                PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "SPRT", 1);
            }
            

        }

        if (Anims.Length > 0)
        {
            if (NeededItem < 0)
                AnimONOFF();
            else if (inv.CheckCorrentItem() == NeededItem && enter && inv.showinvent)
            {
                AnimONOFF();

                if (MinusNeededItem) inv.RemoveSlot(inv.correntSlot);
            }

            
        }

        if (PrefsName.Length > 0)
        {
            for (int i = 0; i < PrefsName.Length; i++)
                PlayerPrefs.SetInt(PrefsName[i], PrefsINT[i]);
        }
        if (clips.Length > 0)
        {
            if (clips.Length > 0 && Clicked)
            {
                if (!RNDClip)
                    AS.clip = clips[0];
                else
                    AS.clip = clips[Random.Range(0, clips.Length)];
                if (!AS.isPlaying)
                {
                    AS.Play();
                    
                }
            }

        }
    }
    void AUDIOSPRT(int i)
    {
        if (SPRT.Length > 0)
        {
            if (SPRT[i].GetComponent<AudioSource>() != null && !SPRT[i].GetComponent<AudioSource>().isPlaying && !AUPLAY[i])
            {
                SPRT[i].GetComponent<AudioSource>().Play();
                AUPLAY[i] = true;
            }
        }

    }
    void SpritesBools(int i)
    {
      
        if (pl.DayFinish >= 1)
        {
           

            if (!OnOffBools)
            {
                if (SPRT[i] != null)
                {
                    SPRT[i].enabled = SPRTBools[i];
                    if (ConnectBoxToSPRT && SPRT[i].GetComponent<BoxCollider2D>() != null)
                        SPRT[i].GetComponent<BoxCollider2D>().enabled = SPRTBools[i];

                    

                    if (SPRT[i].GetComponent<Move_Right_Left>() != null)
                        SPRT[i].GetComponent<Move_Right_Left>().enabled = SPRTBools[i];

                    if (SPRT[i].GetComponent<RotationTrigger>() != null)
                        SPRT[i].GetComponent<RotationTrigger>().enabled = SPRTBools[i];
                }
                
            }
            else
            {

                if (SPRT[i] != null)
                {
                    if (ConnectBoxToSPRT)
                        SPRT[i].enabled = SPRT[i].GetComponent<BoxCollider2D>().enabled = !SPRT[i].enabled;
                    else SPRT[i].enabled = !SPRT[i].enabled;
                }
            }

        }
    }

    void AnimONOFF()
    {
       for (int i = 0; i < Anims.Length; i++) Anims[i].SetBool(AnimsNames[i], AnimsBools[i]);

       PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "Anim", 1);

    }
public bool GetClicked()
{
return Clicked;
}
public string GetName()
{
return gameObject.name;
}	
	
public string GetTag()
{
return gameObject.tag;
}	
	
}
