using UnityEngine;
using System.Collections;

public class TriggerMouse : MonoBehaviour {

	private bool Clicked = false;
	public AudioClip[] clips;
	private AudioSource AS;
	public bool RNDClip = false;
	void Start()
	{
		AS = GetComponent<AudioSource> ();
	}
	void Update()
	{
		if (clips.Length > 0&&Clicked) 
		{
			if(!RNDClip)AS.clip = clips[0];
			else AS.clip = clips[Random.Range(0,clips.Length)];
			if(!AS.isPlaying)AS.Play ();
		}


	}
void OnMouseDown()
{

		if(Input.GetKeyDown(KeyCode.Mouse0))Clicked = true;
}
	
	
void OnMouseUp()
{	
		if(Input.GetKeyUp(KeyCode.Mouse0))Clicked = false;
}
	
public bool GetClicked()
{
return Clicked;
}
public string GetName()
{
return gameObject.name;
}	
	
public string GetTag()
{
return gameObject.tag;
}	
	
}
