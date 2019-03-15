using UnityEngine;
using System.Collections;

public class MoveWASD : MonoBehaviour {
	public float speed = 0.1f;
	public bool invers =true;

	public BoxCollider2D Bounds;
	private Vector3
		_min,
		_max, _min_0, _max_0;

	public bool MoveVert = true;

	// Update is called once per frame
	void FixedUpdate () {

        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        _min_0 = gameObject.GetComponent<BoxCollider2D>().bounds.min;
        _max_0 = gameObject.GetComponent<BoxCollider2D>().bounds.max;


        if (Input.GetAxis("Horizontal")<0 && _min_0.x > _min.x ) 
				transform.Translate (Vector2.right * (speed / (100f * -1)));


       if (Input.GetAxis("Horizontal")>0 && _max_0.x < _max.x ) 
				transform.Translate (Vector2.right * (speed / (100f)));
			
			if(MoveVert){	
				if (Input.GetAxis("Vertical")>0 && _max_0.y < _max.y) 
				transform.Translate (Vector2.up * (speed / (100f)));
			
				if (Input.GetAxis("Vertical")<0 && _min_0.y > _min.y ) 
					transform.Translate (Vector2.up * (speed / (100f * -1)));}
		
            
		
	}


	}

