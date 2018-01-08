using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	
	public Transform[] backgrounds;			
	private float[] parallaxScales;			
	public float smoothing = 1f;			

	private Transform cam;					// reference to the main cameras transform
	private Vector3 previousCamPos;			// the position of the camera in the previous frame
	private Movement pl;

	void Awake () {
		pl = GameObject.Find("Vasilis").GetComponent<Movement>() ;
		cam = Camera.main.transform;
	}

	void Start () {
		previousCamPos = cam.position;
		
		// asigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// for each background
		if(pl.Getcollob().Contains(gameObject)){
		for (int i = 0; i < backgrounds.Length; i++) {
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
			
			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			
			// create a target position which is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			
			// fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		
		// set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;
		}
	}
}
