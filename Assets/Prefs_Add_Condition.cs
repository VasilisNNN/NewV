using UnityEngine;
using System.Collections;

public class Prefs_Add_Condition : MonoBehaviour {

	public string Condition,ItemName;
	public int ConditionValue,ItemValue;


	void Start () {
	if (PlayerPrefs.GetInt (Condition) == ConditionValue)
			PlayerPrefs.SetInt (ItemName, ItemValue);
	}
}
