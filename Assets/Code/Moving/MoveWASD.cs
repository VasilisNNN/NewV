using UnityEngine;
using System.Collections;

public class MoveWASD : MonoBehaviour {
	public float speed = 0.1f;
	public bool invers =true;

	public BoxCollider2D Bounds;
	private Vector3
		_min,
		_max;

	public bool MoveVert = true;
	void Start()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
	}
	// Update is called once per frame
	void Update () {

		if (invers) {
			if (Input.GetAxis("Horizontal")<0 && transform.position.x > _min.x + Camera.main.orthographicSize * 2f) 
				transform.Translate (Vector2.right * (speed / (100f * -1)));
			
			if (Input.GetAxis("Horizontal")>0 && transform.position.x < _max.x - Camera.main.orthographicSize * 2f) 
				transform.Translate (Vector2.right * (speed / (100f)));
			
			if(MoveVert){	
				if (Input.GetAxis("Vertical")>0 && transform.position.y < _max.y - Camera.main.orthographicSize) 
				transform.Translate (Vector2.up * (speed / (100f)));
			
				if (Input.GetAxis("Vertical")<0 && transform.position.y > _min.y + Camera.main.orthographicSize) 
					transform.Translate (Vector2.up * (speed / (100f * -1)));}
		} else {
			if (Input.GetAxis("Horizontal")<0 && transform.position.x > _min.x + Camera.main.orthographicSize * 2f) 
				transform.Translate (Vector2.right * (speed / (100f * -1)));
			
			if (Input.GetAxis("Horizontal")>0 && transform.position.x < _max.x - Camera.main.orthographicSize * 2f) 
				transform.Translate (Vector2.right * (speed / (100f)));

	if(MoveVert){
				if (Input.GetAxis("Vertical")>0 && transform.position.y < _max.y - Camera.main.orthographicSize) 
				transform.Translate (Vector2.up * (speed / (100f)));

				if (Input.GetAxis("Vertical")<0 && transform.position.y > _min.y + Camera.main.orthographicSize) 
				transform.Translate (Vector2.up * (speed / (100f * -1)));
			}
		}
	}
	}

