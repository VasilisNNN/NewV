using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	private ChoiseInterface CI;
	private Inventory Inv;
	public int AddedItem;
	public bool ReturnItem = true;
	// Use this for initialization
	void Start () {
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory> ();
		CI = GetComponent<ChoiseInterface> ();
		Inv.showinvent = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (CI.ReturnCorrentItem () == 2 && Input.GetKeyDown (KeyCode.E)&&ReturnItem) 
		{
			if(!Inv.CheckItem(AddedItem))Inv.AddItem(AddedItem);
		}



	}
}
