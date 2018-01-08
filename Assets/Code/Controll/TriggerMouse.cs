using UnityEngine;
using System.Collections;

public class TriggerMouse : MonoBehaviour {

	private bool Clicked = false;

	
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
