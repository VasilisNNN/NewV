using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DoorCol : MonoBehaviour {
	//public bool EnterToTheDoor{ get; set; }
	public string LevelName;
	private bool DoorColl;
	public bool LoadLocation = true;
	private Inventory Inv;
    

	private bool SW;

	private Movement pl;
    private List<GameObject> coll_obj = new List<GameObject>();
    private bool enter;
    private Mouse _mouse;
    public int NeededItemm = -1;
    public bool NoEnter;
    public bool MinusNeededItem;
    private AudioSource AU;
    private void Start()
	{
		if (GameObject.Find ("Vasilis") != null) {
			Inv = GameObject.Find ("Vasilis").GetComponent<Inventory> ();
			pl = GameObject.Find("Vasilis").GetComponent<Movement> ();
		}

        AU = GetComponent<AudioSource>();
         _mouse = GameObject.Find("Mouse(Clone)").GetComponent<Mouse>();
        
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "SPRT") == 1) NeededItemm = -1;

        //	print ("s "  + PlayerPrefs.GetString ("CorrLevel"));
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

        if (LevelName != null)
        {
            if (!NoEnter)
            {
                if (enter && coll_obj.Contains(gameObject))
                {
                    if (NeededItemm > -1)
                    {
                        if (Inv.CheckCorrentItem() == NeededItemm && Inv.showinvent)
                        {
                            Location();
                            
                        }
                    }
                    else if (LoadLocation) Location();

                }
            }
            else
            {
                if (coll_obj.Contains(gameObject))
                {
                    if (NeededItemm > -1)
                    {
                        if (Inv.CheckCorrentItem() == NeededItemm && Inv.showinvent)
                        {
                            Location();

                           
                        }
                    }
                    else if (LoadLocation) Location();

                }

            }
        }


    }
    void Location()
    {

        if (AU != null)
        {
            if (!AU.isPlaying) AU.Play();

        }
        if (NeededItemm > -1)
        {
            PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "SPRT",1);
            Inv.RemoveMultiSlot(Inv.correntSlot, 1);
        }
        if (pl.DayFinish >1)
        {
            pl.DayFinish = 0;
            pl.EndDayLocation = LevelName;
            pl.PlusDay = false;
            pl.Save();
            SavePrev();
            if(SceneManager.GetActiveScene().name!="6Day")
            PlayerPrefs.SetString("CorrLoadingLevel", LevelName);
            else PlayerPrefs.SetString("CorrLoadingLevel", "SecretLocation");
        }
        //SceneManager.LoadScene(LevelName);
        //Cursor.SetCursor (ExitDoor, Vector2.zero, CursorMode.Auto);
        

    }

    void SavePrev()
    {
        PlayerPrefs.SetString("PrevLoadingLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("XPos", pl.transform.position.x);
        PlayerPrefs.SetFloat("YPos", pl.transform.position.y);
    }



}
