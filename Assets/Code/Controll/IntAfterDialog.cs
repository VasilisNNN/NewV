using UnityEngine;
using System.Collections;

public class IntAfterDialog : MonoBehaviour {


	private Movement pl;
	public string Iname;
	public int Ivalue;
	private bool p = false;
	public bool Plus = false;
	void Start () 
	{
		pl = GameObject.Find("Vasilis").GetComponent<Movement>();
	}
	

	void Update () 
	{


		if(GetComponent<SpriteRenderer>()!=null&&GetComponent<SpriteRenderer>().enabled&&pl.DrawDialog)
		{
			p = true;
		}


		if(p && !pl.DrawDialog) {
		if(!Plus)PlayerPrefs.SetInt(Iname,Ivalue);
			else PlayerPrefs.SetInt(Iname, PlayerPrefs.GetInt(Iname)+Ivalue);
			pl.DrawDialog = false;

		}

	}


}
