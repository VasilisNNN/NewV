using UnityEngine;
using System.Collections;

public class OffCollision : MonoBehaviour {
   
	private Mix_ChangeItems MCI;
	
	
private void Start()
	{
		MCI = gameObject.GetComponent<Mix_ChangeItems>();
	}
	
	
	// Update is called once per frame
	void Update () {
	
	if(MCI.GetCollisinWithItem())GetComponent<BoxCollider2D>().isTrigger = true;
	}
}
