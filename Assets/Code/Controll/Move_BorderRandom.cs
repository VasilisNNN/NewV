using UnityEngine;
using System.Collections;

public class Move_BorderRandom : MonoBehaviour {
	public float speedx = 0.3989f,speedy = 0.189f;
	
	public BoxCollider2D Bounds;
	private Vector3
		_min,
		_max;

	// Use this for initialization
	void Start () {
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > _min.x + Camera.main.orthographicSize * 2f
		    && transform.position.x < _max.x - Camera.main.orthographicSize * 2f) 
			transform.Translate (Vector2.right * (speedx / 100f));
		
		if(transform.position.y < _max.y - Camera.main.orthographicSize &&
		   transform.position.y > _min.y + Camera.main.orthographicSize)
			transform.Translate (Vector2.up * (speedy / 100f));
		
		
		if(transform.position.x < _min.x + Camera.main.orthographicSize * 2f+1f)
			speedx *= -1;
		
		if(transform.position.x > _max.x - Camera.main.orthographicSize * 2f-1f)
			speedx *= -1;
		
		if(transform.position.y < _min.y + Camera.main.orthographicSize+1f)
			speedy *= -1;
		if(transform.position.y > _max.y - Camera.main.orthographicSize-1f)
			speedy *= -1;
	}
}
