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
    void SimpleParalaxing()
    {
        if (pl.Getcollob().Contains(gameObject))
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].position = new Vector3(backgrounds[i].position.x+(pl._normalHSpeed * backgrounds[i].position.z)/10, backgrounds[i].position.y, backgrounds[i].position.z);
            
        }
        }

    }

    void ComplexParalaxing()
    {
        if (pl.Getcollob().Contains(gameObject))
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                if (backgrounds[i] != null)
                {
                    // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
                    float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
                    float parallaxY = (previousCamPos.y - cam.position.y) * parallaxScales[i];
                    // set a target x position which is the current position plus the parallax
                    float backgroundTargetPosX = backgrounds[i].position.x + parallax;
                    float backgroundTargetPosY = backgrounds[i].position.y;
                    // create a target position which is the background's current position with it's target x position
                    Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundTargetPosY, backgrounds[i].position.z);

                    // fade between current position and the target position using lerp
                    backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
                }
            }

            // set the previousCamPos to the camera's position at the end of the frame

        }
        previousCamPos = cam.position;

    }
    // Update is called once per frame
    void FixedUpdate () {
        ComplexParalaxing();

      

    }
}
