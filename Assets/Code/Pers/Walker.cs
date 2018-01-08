using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour {
	public bool isFacingRight = true;
	public float Speed = 0.05f;
	private Vector3 MoveWalker;
	public Transform BG;

	// Use this for initialization
	void Start () {

		MoveWalker.z = transform.position.z;
		MoveWalker.y = transform.position.y;
		MoveWalker.x = Random.Range(BG.position.x + (BG.localScale.x / 2),BG.position.x - (BG.localScale.x / 2));

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//	print (PlayerPrefs.GetInt ("PlayDay"));
	
							
		

						if (isFacingRight) {
								MoveWalker.x += Speed;
								transform.position = MoveWalker;
						} else {
								MoveWalker.x -= Speed;
								transform.position = MoveWalker;
						}


						if (transform.position.x > BG.position.x + (BG.localScale.x / 2))
								Flip ();
						if (transform.position.x < BG.position.x - (BG.localScale.x / 2))
								Flip ();

			

	}

	private void Flip()
	{
				//меняем направление движения персонажа
				isFacingRight = !isFacingRight;
				//получаем размеры персонажа
				Vector3 theScale = transform.localScale;
				//зеркально отражаем персонажа по оси Х
				theScale.x *= -1;
				//новый размер персонажа, равный старому, но зеркально отраженный
				transform.localScale = theScale;
		}
}
