using UnityEngine;
using System.Collections;

public class Move_Right_Left : MonoBehaviour {
	public float speed_x = 0.1f;
	public float speed_y = 0f;
	public BoxCollider2D Bounds;
	
	private Vector3
		_min,
		_max;

	void Start()
	{
		
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;

	}
	// Update is called once per frame
	void Update () {

		if(transform.position.x >_min.x&&transform.position.x <_max.x
		   &&transform.position.y >_min.y&&transform.position.y <_max.y)
		transform.position = new Vector3 (transform.position.x + speed_x, transform.position.y+speed_y, transform.position.z);
	}
}
