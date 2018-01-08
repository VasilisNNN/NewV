using UnityEngine;
using System.Collections;

public class Draw_if_CheckItem : MonoBehaviour {

	private Inventory inv;
	public int NeedItem;
	//public int[] multsprt;
	public bool IfItem_Get;
	// Use this for initialization
	void Start () {
		inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (IfItem_Get) {
			if (inv.CheckItem (NeedItem)) 
				Draw (true);
			else
				Draw (false);
		} else {
			if (inv.CheckItem (NeedItem)) {
				Draw (false);
			} else
				Draw (true);
		}
	}
	private void Draw(bool draw)
	{
		if(GetComponent<BoxCollider2D> ()!=null)GetComponent<BoxCollider2D> ().enabled = draw;
		if(GetComponent<SpriteRenderer> ()!=null)GetComponent<SpriteRenderer> ().enabled = draw;
	}
}
