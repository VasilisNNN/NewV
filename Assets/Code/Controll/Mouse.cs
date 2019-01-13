using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
	private List<GameObject> coll_obj = new List<GameObject>();
	private Texture2D EnterDoor,ExitDoor,MouseDialog,Hand;
	public Texture CursorT;
	private Movement pl;
    public bool pointnclick { get; set; }


    void Start()
	{
        pointnclick = false;
        CursorT = Resources.Load<Texture2D> ("Interface/Cursor");
		EnterDoor = Resources.Load<Texture2D> ("Interface/CursorFoot");
		EnterDoor = Resources.Load<Texture2D> ("Interface/CursorFoot");
		ExitDoor = Resources.Load<Texture2D> ("Interface/Cursor");
		MouseDialog = Resources.Load<Texture2D> ("Interface/CursorMouth");
		Hand = Resources.Load<Texture2D> ("Interface/CursorHand");
		pl = GameObject.Find ("Vasilis").GetComponent<Movement> ();
       
        Cursor.visible = false;
    }
	void LateUpdate () 
	{
        if (Input.GetKeyDown(KeyCode.F12)) PlayerPrefs.DeleteAll();

		if (CheckItem ("Door"))
			CursorT = EnterDoor;
		else if (CheckItem ("Item"))
			CursorT = Hand;
		else if (CheckItem ("Pers"))
			CursorT = MouseDialog;
		else
			CursorT = ExitDoor;
		
		transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 1f);
	}


	public bool CheckItem (string tagg)
	{
		bool result = true;
		for(int i = 0; i<GameObject.FindGameObjectsWithTag(tagg).Length;i++)
		{
			if(coll_obj.Contains(GameObject.FindGameObjectsWithTag(tagg)[i])&&
				pl.Getcollob().Contains(GameObject.FindGameObjectsWithTag(tagg)[i]))
			{
				result = true;
				break;}
			else result = false;

		}

		if (GameObject.FindGameObjectsWithTag (tagg).Length == 0)
			result = false;
		
		return result;
	}
	public Texture GetTexture()
	{
		return CursorT;
	}

	public List<GameObject> GetCollObj()
	{
		return coll_obj;
	}
	private void OnTriggerStay2D(Collider2D c)
	{

		if(!coll_obj.Contains(c.gameObject))
		{
			coll_obj.Add(c.gameObject);
		}

	}

	private void OnTriggerExit2D(Collider2D c)
	{

		if(coll_obj.Contains(c.gameObject))
		{
			coll_obj.Remove(c.gameObject);
		}

	}
}
