using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {
	public int Contains{ get; set;}
	private GUISkin skin;
	public int NeedItem;
	private GameObject LArrow,RArrow,Close,Confirm;
	private Mouse _Mouse;
	private bool ChoiseNumInterfaceONOFF;
	// Use this for initialization
	private Inventory inv;
	private int CorrentPlus;
	void Start () {
		inv = GameObject.Find ("Vasilis").GetComponent<Inventory> ();
		if (GameObject.Find ("LArrow") == null) {
					LArrow  = new GameObject();
			        LArrow  = (GameObject)Instantiate(Resources.Load("PrefabObjects/LArrow"));
			LArrow.transform.position = new Vector3 (transform.position.x-1, transform.position.y, transform.position.z);
				}
		if (GameObject.Find ("RArrow") == null) {
			RArrow  = new GameObject();
			RArrow  = (GameObject)Instantiate(Resources.Load("PrefabObjects/RArrow"));
			RArrow.transform.position = new Vector3 (transform.position.x+1, transform.position.y, transform.position.z);
		}
		if (GameObject.Find ("Close") == null) {
			Close  = new GameObject();
			Close  = (GameObject)Instantiate(Resources.Load("PrefabObjects/Close"));
			Close.transform.position = new Vector3 (transform.position.x, transform.position.y+1, transform.position.z);
		}
		if (GameObject.Find ("Confirm") == null) {
			Confirm  = new GameObject();
			Confirm  = (GameObject)Instantiate(Resources.Load("PrefabObjects/Confirm"));
			Confirm.transform.position = new Vector3 (transform.position.x, transform.position.y-1, transform.position.z);
		}

		skin = Resources.Load<GUISkin> ("Invent/Slot");
		_Mouse = GameObject.Find ("Mouse").GetComponent<Mouse> ();

		Load ();
	}

	void Update()
	{
		Close.SetActive (ChoiseNumInterfaceONOFF);
		LArrow.SetActive (ChoiseNumInterfaceONOFF);
		RArrow.SetActive (ChoiseNumInterfaceONOFF);
		Confirm.SetActive (ChoiseNumInterfaceONOFF);

		if (inv.GetDraggedItem () != null) {
			if (_Mouse.GetCollObj ().Contains (gameObject) && Input.GetMouseButtonDown (0) && inv.GetDraggedItem ().itemID == NeedItem)
				ChoiseNumInterfaceONOFF = true;
		}
		
		if (ChoiseNumInterfaceONOFF)
			ChoiseNumInterface ();
		
	}

	void OnGUI()
	{
		Vector3 tr = Camera.main.WorldToScreenPoint (transform.position);
		GUI.Box (new Rect (tr.x-30, Screen.height - tr.y-30, 60f, 60f), Contains.ToString(), skin.customStyles [3]);
	}

	void ChoiseNumInterface()
	{
		if (_Mouse.GetCollObj ().Contains (LArrow) && Input.GetMouseButtonDown (0) && CorrentPlus > 0) {
			Contains--;
			CorrentPlus --;
			//inv.SetInvNum(1);
		}
		if (_Mouse.GetCollObj ().Contains (RArrow) && Input.GetMouseButtonDown (0) && CorrentPlus < inv.GetDraggedItem().itemNum) {
			Contains++;
			CorrentPlus ++;
			//CorrentPlus;
			//inv.SetInvNum(-1);
		}
		if (_Mouse.GetCollObj ().Contains (Close) && Input.GetMouseButtonDown (0)) {
			ChoiseNumInterfaceONOFF = false;
			CorrentPlus = 0;
			Save ();
		}
		if (_Mouse.GetCollObj ().Contains (Confirm) && Input.GetMouseButtonDown (0)) {
			{
				inv.ItemToContainer (Contains);
				CorrentPlus = 0;
				Save ();
			}
			//print (name);
		}
	}

	void Save()
	{
		PlayerPrefs.SetInt (name + "Contains", Contains);
	}

	void Load()
	{
		Contains = PlayerPrefs.GetInt (name + "Contains");
	}
}
