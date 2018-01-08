using UnityEngine;
using System.Collections;

public class Move_if_give_Item : MonoBehaviour {
	public float speed_y,speed_x = 0.1f;

	
	public BoxCollider2D Bounds;
	private Vector3
		_min,
		_max;
	public Mix_ChangeItems MCI;
	private bool move = false;
	void Start()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
	}
	// Update is called once per frame
	void Update () {

		if (MCI.GetCollisinWithItem ()) {
			move = true;
		}
			
		if (move && transform.position.x >= _min.x && transform.position.x <= _max.x
				&& transform.position.y >= _min.y && transform.position.y <= _max.y) 
			transform.position = new Vector3 (transform.position.x + speed_x, transform.position.y + speed_y, -1f);

		if (transform.position.x <= _min.x+0.1f || transform.position.x >= _max.x-0.1f
		    || transform.position.y <= _min.y+0.1f || transform.position.y >= _max.y-0.1f) 
			PlayerPrefs.SetInt(gameObject.name,-1);
	}
}
