using UnityEngine;
using System.Collections;

public class DayTimerSprite : MonoBehaviour {
	
	public float Timer{ get; set;}
	private float T;
	public float x { get; set;}
	// Use this for initialization
	void Start () {
		//gameObject.transform.localScale = new Vector3 (PlayerPrefs.GetFloat("TimerLong"),gameObject.transform.localScale.y, 10f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		/*if (PlayerPrefs.GetInt ("PlayDay") == 1) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true;			
			SetTimer ();
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - 6.5f, Camera.main.transform.position.y + 3f, 10f);
			if (T + 1 < Time.fixedTime) {
				gameObject.transform.localScale = new Vector3 (gameObject.transform.localScale.x - Timer, gameObject.transform.localScale.y, 10f);
				T = Time.fixedTime;
				
				//print ("TimerLong" + PlayerPrefs.GetFloat ("TimerLong"));
			}
			x = gameObject.transform.localScale.x;
		} else if(PlayerPrefs.GetInt ("PlayDay") == 0){
			gameObject.GetComponent<SpriteRenderer>().enabled = false;		
		}*/
		
	}
	
	private void SetTimer()
	{
		
		/*PlayerPrefs.SetFloat("TimerLong", gameObject.transform.localScale.x);
		if (PlayerPrefs.GetFloat ("TimerLong") < -0.5) {
			PlayerPrefs.SetFloat ("TimerLong", 1.5f);
		}*/
		
	}
	public void SetX(Vector3 r)
	{
		//transform.localScale = r;
		
	}
	
}
