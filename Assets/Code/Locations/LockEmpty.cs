using UnityEngine;
using System.Collections;

public class LockEmpty : MonoBehaviour {

	private SpriteControll One;
	private SpriteControll Two;
	private SpriteControll Three;
	private SpriteControll Four;
	private SpriteControll Five;

	
	// Update is called once per frame
	void Update () {
		One = GameObject.Find ("1").GetComponent<SpriteControll> ();
		Two = GameObject.Find ("2").GetComponent<SpriteControll> ();
		Three = GameObject.Find ("3").GetComponent<SpriteControll> ();
		Four = GameObject.Find ("4").GetComponent<SpriteControll> ();
		Five = GameObject.Find ("5").GetComponent<SpriteControll> ();

		if (One.GetCorrSprite () == 2 && Two.GetCorrSprite () == 3 && Three.GetCorrSprite () == 0
			&& Four.GetCorrSprite () == 3 && Five.GetCorrSprite () == 0) {
			{
				PlayerPrefs.SetInt("ChernIn",1);
				Application.LoadLevel("Empty2");
			}
		}
	}
}
