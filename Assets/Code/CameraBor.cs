using UnityEngine;
using System.Collections;

public class CameraBor : MonoBehaviour {

	private float timer = 0;

	private Transform PlayerV;
	public static CameraBor Instance{get;private set;}
	
	public Vector2 Smoothin = new Vector2(2, 2);
    public BoxCollider2D _bounds{ get; set;}
	private GameObject[] CamBounds;
	private Vector3
		_min,
		_max;
	public Vector2 Margin = new Vector2 (3, 3);
	private bool isFollowing;
	public bool StartPos{ get; set;}

	private float x;
	private float y;
    public float YPlus = 0;
    public float Zoom = 0;
    public bool Move = true;
    public Vector2 MoveBorders = new Vector2(1,10);
    private void Start()
	{
        CamBounds = GameObject.FindGameObjectsWithTag("CameraBound");
        foreach (GameObject c in CamBounds)
        {
            if (c.GetComponent<BoxCollider2D>().enabled)
                _bounds = c.GetComponent<BoxCollider2D>();
        }

       // print(CamBounds.Length);
        if (Margin.x == 0)
        {
            Margin.x = 0.2f;
            Margin.y = 0.2f;
        }

        PlayerV = GameObject.Find("Vasilis").GetComponent<Transform>();
        x = PlayerV.position.x;
        y = PlayerV.position.y + YPlus;

        isFollowing = true;
        Application.targetFrameRate = 60;
        //transform.position = new Vector3(x, y, -21);

        Moving();

    }
   
        void Moving()
    {
        if (Zoom != 0 && Camera.main.orthographicSize > MoveBorders.x && Camera.main.orthographicSize < MoveBorders.y)
            Camera.main.orthographicSize += Zoom;

       
        if (Move)
        {
            _min = _bounds.bounds.min;
            _max = _bounds.bounds.max;


            if (isFollowing)
            {
                if (Mathf.Abs(x - PlayerV.position.x) > Margin.x)
                    x = Mathf.Lerp(x, PlayerV.position.x, Smoothin.x * Time.deltaTime);

                if (Mathf.Abs(y - PlayerV.position.y) > Margin.y)
                    y = Mathf.Lerp(y, PlayerV.position.y + YPlus, Smoothin.y * Time.deltaTime);

            }

            var cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
            //  var cameraHalfHeight = Camera.main.orthographicSize * ((float)Screen.height / Screen.height);

            x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);

            transform.position = new Vector3(x, y, -21);
        }
    }
	public void LateUpdate()
	{
       
        Moving();
        
	}


	public void Set_UpdateBounds()
	{
		timer = Time.fixedTime+0.08f;

	}

	public void SetVasPos()
	{


		if (timer > Time.fixedTime) 
		{
			x = PlayerV.position.x;
			y = PlayerV.position.y;
		}

	}
    public void SetZoom(float z)
    {
        Zoom = z;

    }

}
