using UnityEngine;
using System.Collections;

public class Police_Gerb : MonoBehaviour {
	
	public Transform[] backgrounds;	
	public BoxCollider2D Bounds;
	
	private Vector3
		_min,
		_max;
	
	
	private Vector3[] backgrounds_Start;
	private Vector3[] pos;
	private float[] speed;
	void Awake()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		
		pos = new Vector3[backgrounds.Length];
		backgrounds_Start = new Vector3[backgrounds.Length];
		speed = new float[backgrounds.Length];
	}
	void Start () {
		for (int i = 0; i<(backgrounds.Length); i++)
		{
			backgrounds_Start[i] =  new Vector3(backgrounds[i].position.x,backgrounds[i].position.y,backgrounds[i].position.z);
			pos[i] = new Vector3(backgrounds[i].position.x,backgrounds[i].position.y,backgrounds[i].position.z);
			speed[i] = 0.1f/(backgrounds[i].position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i<(backgrounds.Length); i++)
		{
			
			backgrounds[i].position = new Vector3(pos[i].x,backgrounds[i].position.y,transform.position.z);
			
			if (Input.GetAxis ("Horizontal") > 0&&pos[i].x>_min.x+backgrounds[i].localScale.x)
			{	
				
				if(pos[i].x<backgrounds_Start[i].x)
					speed[i] -=0.001f;
				else
					speed[i]+=0.001f;
				
				
				pos[i].x-=speed[i];
			}
			else if(Input.GetAxis ("Horizontal") < 0&&pos[i].x<_max.x-backgrounds[i].localScale.x)
			{
				if(pos[i].x>=backgrounds_Start[i].x)
					speed[i]-=0.001f;
				else
					speed[i]+=0.001f;
				
				
				pos[i].x+=speed[i];
			}
		}
		
	}
}
