using UnityEngine;
using System.Collections;

public class Move_Right_Left : MonoBehaviour {
	public float speed_x = 0.1f;
	public float speed_y = 0f;
	public BoxCollider2D Bounds;
    private int flipX = 1;
    private int flipY = 1;
    private bool Flipped;
    private bool flip,isFacingRight;
    public bool flipping;
    public bool OneWay = false;
    public bool OneWayStop = false;
    private bool Stop = false;
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
        if (!OneWay)
        {
            if ((transform.position.x > _max.x || transform.position.x < _min.x) && !Flipped)
            {
                flipX *= -1;

                Flip();
                Flipped = true;
            }
            if (transform.position.x > _min.x + 0.2f && transform.position.x < _max.x - 0.2f) Flipped = false;
        }
        else
        {
            if (transform.position.x > _max.x && speed_x > 0)
            {
                if(!OneWayStop)
                transform.position = new Vector3(_min.x, transform.position.y, transform.position.z);
                else Stop = true;
            }
            if (transform.position.x < _min.x && speed_x < 0)
            {
                if (!OneWayStop)
                    transform.position = new Vector3(_max.x, transform.position.y, transform.position.z);
                else Stop = true;
            }
        }

        if(!Stop)
		transform.position = new Vector3 (transform.position.x + speed_x*flipX, transform.position.y+speed_y*flipY, transform.position.z);
	}
    
    private void Flip()
    {

        if (flipping)
        {
            //меняем направление движения персонажа
            isFacingRight = !isFacingRight;
            //получаем размеры персонажа
            Vector3 theScale = transform.localScale;
            //зеркально отражаем персонажа по оси Х
            theScale.x *= -1;
            //задаем новый размер персонажа, равный старому, но зеркально отраженный
            transform.localScale = theScale;
            //transform.localPosition(Vector3());
        }
    }
}
