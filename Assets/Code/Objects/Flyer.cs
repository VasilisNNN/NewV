using UnityEngine;
using System.Collections;

public class Flyer : MonoBehaviour {

	private Movement vas;
	private bool Show;
	public Texture T;
	// Use this for initialization
	void Start () {


		vas = GameObject.Find ("Vasilis").GetComponent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {


	
		if (vas.Getcollob().Contains(gameObject)&& vas.enter_b) {
				Show = !Show;
			}
		if(!vas.Getcollob().Contains(gameObject))Show = false;

	}
	private void OnGUI()
	{

		if(Show)GUI.DrawTexture (new Rect (Screen.width/2f-(T.width*Screen.height/T.height)/2f, 0, T.width*Screen.height/T.height, Screen.height), T);
	}
}
