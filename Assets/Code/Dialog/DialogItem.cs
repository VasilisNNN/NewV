using UnityEngine;
using System.Collections;

public class DialogItem : MonoBehaviour {


	private Mix_ChangeItems Mix;
	//private BoxCollider2D move;
	public BoxCollider2D offColl;
	public bool PlayIn{ get; set; }

	private Rect rectlable = new Rect(0,0,Screen.width-100,100);
	public GUIStyle skin;
	public TextB texB;
	public TextEn texEn;
	private string[] dialogText; 
	private int i = 0;
//	private ChoiseInterface CI;
	private Inventory inv;
	private DoorCol door1;
	// Use this for initialization
	void Start () {
		if(GameObject.Find("Door1")!=null)door1 = GameObject.Find("Door1").GetComponent<DoorCol> ();
		inv = GameObject.Find("Vasilis").GetComponent<Inventory>();

		if(PlayerPrefs.GetInt ("Language") == 0)dialogText = texB.GetLines ();
		if(PlayerPrefs.GetInt ("Language") == 1)dialogText = texEn.GetLines ();
		Mix = gameObject.GetComponent<Mix_ChangeItems> ();

		if (offColl != null) {
						offColl.enabled = true;
						//GameObject.Find (name).GetComponent<BoxCollider2D> ().enabled = false;
				}
		skin.wordWrap = true;
		skin.font = Resources.Load<Font> ("Fonts/Merriweather Light_ForDialogs");
		
		skin.contentOffset = new Vector2 (4f, 4f);
	}

	
	// Update is called once per frame
	void Update () {


	/*if (Mix.GetCollisinWithItem ()) {
			if(door1!=null)door1.enabled = false;
			inv.showinvent = false;
			PlayIn = true;
			if(offColl!=null)offColl.enabled = false;
				}*/

		if(Input.GetButtonDown("Enter")&&PlayIn){i++;}

	
	}


	private void OnGUI () {
		

			if (i < texB.GetLines ().Length && PlayIn == true) {
			//print ("dddd");
			GUI.TextField (rectlable, dialogText [i], skin);
				/*if(Face.Length>1)
				{
					if (i%2==0) 
					{
						GUI.DrawTexture(new Rect(rectlable.x+rectlable.width,0f,rectlable.height,rectlable.height),texB.GetFace(0));		
					}else GUI.DrawTexture(new Rect(rectlable.x+rectlable.width,0f,rectlable.height,rectlable.height),texB.GetFace(1));
				}else if(Face.Length == 1)
					GUI.DrawTexture(new Rect(rectlable.x+rectlable.width,0f,rectlable.height,rectlable.height),texB.GetFace(0));
				*/
			}

		
			if (i==dialogText.Length)
			{
				i = 0;
				PlayIn = false;
			if(door1!=null)door1.enabled = true;
			}
			
			
		}
		
		
		
	}
