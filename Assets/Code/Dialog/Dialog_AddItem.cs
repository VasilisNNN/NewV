using UnityEngine;
using System.Collections;

public class Dialog_AddItem : MonoBehaviour {
	private Movement move;
	private Inventory Inv;
	public int needitem;

	void Start () {
		move = GameObject.Find("Vasilis").GetComponent<Movement>();
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
	}

	void Update () {
		if (move.Getcollob().Contains(gameObject)&&Input.GetButtonDown("Enter")&&!Inv.CheckItem(needitem)) 
		Inv.AddItem(needitem);
	}


}
