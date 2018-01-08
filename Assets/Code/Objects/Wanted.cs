using UnityEngine;
using System.Collections;

public class Wanted : MonoBehaviour {

	public TriggerMouse[] mouseT;
	private SpriteControll[] objectsSP = new SpriteControll[3];



	void Start () {
		objectsSP[0]= GameObject.Find("0_SP").GetComponent<SpriteControll>();
		objectsSP[1]= GameObject.Find("1_SP").GetComponent<SpriteControll>();
		objectsSP[2]= GameObject.Find("2_SP").GetComponent<SpriteControll>();
	}
	

	void Update () {

		print (PlayerPrefs.GetInt("PoweWay"));


		for (int i = 0; i<mouseT.Length; i++) {
			if (mouseT [i].GetClicked ()&&Input.GetKeyDown(KeyCode.Mouse0)) {

				if (objectsSP[i].GetCorrSprite () == 0)
					PlayerPrefs.SetInt ("PoweWay", PlayerPrefs.GetInt ("PoweWay") +1);
				else if (objectsSP[i].GetCorrSprite () == 1)
					PlayerPrefs.SetInt ("PoweWay", PlayerPrefs.GetInt ("PoweWay") + 1);
				else if (objectsSP[i].GetCorrSprite () == 2)
					PlayerPrefs.SetInt ("PoweWay", PlayerPrefs.GetInt ("PoweWay") - 2);
			}
		}


	}
}
