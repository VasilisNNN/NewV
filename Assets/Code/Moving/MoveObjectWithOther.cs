using UnityEngine;
using System.Collections;

public class MoveObjectWithOther : MonoBehaviour {

	public Transform Set;

	public float 
	X_Plus,
	Y_Plus;


	void Update () {

		transform.position = new Vector3 (Set.position.x+X_Plus,Set.position.y+Y_Plus,transform.position.z);
	}
}
