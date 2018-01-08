using UnityEngine;
using System.Collections;

public class Change_Sceen_Item : MonoBehaviour {

	private Mix_ChangeItems MCI;
	public string LevelName;

	private void Start()
	{		 		
		MCI = GetComponent<Mix_ChangeItems>();
	}



	void Update()
	{
		if(MCI.GetCollisinWithItem())
		{
			Application.LoadLevel(LevelName);
		}
	}

}
