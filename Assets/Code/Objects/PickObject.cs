using UnityEngine;
using System.Collections;

public class PickObject : MonoBehaviour {
	
    
	public bool Picked {get;set;}	
    public int IconNum;
	private Inventory Inv;
	private Texture2D Enter,Exit;
	private Movement pl;
void Start()
	{ 
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
		Picked = false;	
		Enter = Resources.Load<Texture2D> ("Interface/CursorHand");
		Exit = Resources.Load<Texture2D> ("Interface/Cursor");
		if (PlayerPrefs.GetInt ("Death" + name) == 1)
			Destroy (gameObject);
		if(GameObject.Find("Vasilis")!=null)
			pl = GameObject.Find("Vasilis").GetComponent<Movement> ();


	}
	
private	void Update()
	{

	 
      if(Picked)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(Inv.CheckSlot()){
			    PlayerPrefs.SetInt (name, -1);
		        Inv.AddItem(IconNum);
				//Inv.SaveInvDestroy(IconNum);
				Inv.SaveInv();
				Destroy(gameObject);
				//Cursor.SetCursor (Exit, Vector2.zero, CursorMode.Auto);
					pl.CursorT = Exit;
					PlayerPrefs.SetInt("Death"+name,1);
			}

			}
		}
		
	}
	private void OnMouseOver()
	{
		//Cursor.SetCursor (Enter, Vector2.zero, CursorMode.Auto);
		//if (pl.Getcollob ().Contains (gameObject)) {
			pl.CursorT = Enter;
			Picked = true;
		//}
		
	}
	
	private void OnMouseExit()
	{
		if (Picked) {
			//Cursor.SetCursor (Exit, Vector2.zero, CursorMode.Auto);
			pl.CursorT = Exit;
			Picked = false;
		}

	}

	private void Load()
	{
		if (PlayerPrefs.GetInt (name) == -1)
			Destroy (gameObject);
	}
	public string GetObName()
	{
		return gameObject.name;
	}

}
