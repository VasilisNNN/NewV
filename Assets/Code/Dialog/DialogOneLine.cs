using UnityEngine;
using System.Collections;

public class DialogOneLine : MonoBehaviour {
	private Rect rectlable;
	public GUIStyle skin;
	private string[] dialogText; 
	public string namee;

	private TextB texB;
	private TextEn texEn;

	public bool startDialog;
	private int i = 0;
	
	// Use this for initialization
	void Start () {

		texB =  GameObject.Find(namee).GetComponent<TextB>();
		texEn = GameObject.Find(namee).GetComponent<TextEn>();


		if(PlayerPrefs.GetInt("Language")==0)dialogText = texB.GetLines ();
		else if(PlayerPrefs.GetInt("Language")==1)dialogText = texEn.GetLines ();

		skin.wordWrap = true;
		skin.font = Resources.Load<Font> ("Fonts/Merriweather Light_ForDialogs");
		skin.padding.right = 6;
		skin.contentOffset = new Vector2 (4f, 4f);
		skin.fontSize = 20;
		skin.padding.left = 6;
	}
	
	// Update is called once per frame
	void Update () {
		rectlable = new Rect(0,0,Screen.width,100);
		if(Input.GetButtonDown("Enter"))i++;
	}
	void OnGUI()
	{
		if (i < dialogText.Length && startDialog == true) 
				GUI.Box(rectlable, dialogText [i], skin);
				
		
		if (startDialog) {
			
			if (i==dialogText.Length)
			{
				i = 0;
				startDialog = false;
			}
			
			
		}

	}
}
