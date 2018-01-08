using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeDialog : MonoBehaviour {

	public  List<TextA> Lines;
	public  List<TextA> LinesEn;

	public bool buttom;

	private Rect rectlable;
	public GUIStyle skin;

	private int i = 0;
	
	public float timer = 4f;

	public int FS = 20;
	/*public int[] IntV;
	public string[] IntName;
*/
	private void Start () {

		skin.wordWrap = true;
		skin.font = Resources.Load<Font> ("Fonts/Merriweather Light_ForDialogs");
		skin.padding.right = 10;
		skin.contentOffset = new Vector2 (4f, 4f);
		skin.fontSize = FS;
		timer = Time.fixedTime + timer;




	}


	void Update () {
		if(!buttom)
		rectlable = new Rect (0f, 0f, Screen.width, 100f);
		else 
			rectlable = new Rect (0f, Screen.height-100f, Screen.width, 100f);
if (timer < Time.fixedTime) {
			if(i < Lines[0].line.Length-1f)i++;
			timer = Time.fixedTime + 4f;

		}
	}
	
	
	// Update is called once per frame
	private void OnGUI () {

		//for (int i = 0; i<IntName.Length; i++) {
			//if (PlayerPrefs.GetInt (IntName[i]) >= IntV[i])

		
		if (PlayerPrefs.GetInt ("Language") == 0)
		GUI.TextField (rectlable,Lines[0].line[i], skin);
		else 	
		if (PlayerPrefs.GetInt ("Language") == 1) 
				GUI.TextField (rectlable,LinesEn[0].line[i], skin);

		//}	
			}
			
			

}
