using UnityEngine;
using System.Collections;

public class Endings : MonoBehaviour {
	private bool DoorColl;

	//private Movement move;

	private int[] more = new int[6];
	private int[] item_count = new int[6];
	private int largest_name = -1;

	private int largest = int.MinValue;
	private int n = 0;
	private int im = 0;
	private SpriteRenderer SP;
	private Color c;

	void Start () {
	//	move = GameObject.Find("Vasilis").GetComponent<Movement>();
		SP = GetComponent<SpriteRenderer>();
		c = SP.color;
	
				more[0] = PlayerPrefs.GetInt ("PowerWay");
				more[1] = PlayerPrefs.GetInt ("LiveWay");
				more[2] = PlayerPrefs.GetInt ("HaosWay");
				more[3] = PlayerPrefs.GetInt ("DeathWay");
				more[4] = PlayerPrefs.GetInt ("EmptyWay");
				more[5] = PlayerPrefs.GetInt ("FireWay");


	}


	
	private void Update()
	{	
		if (c.r < 1f) {
			c.r+= 0.2f;
			c.b += 0.2f;
			c.g += 0.2f;
		} else {
			c.r = 0f;
			c.b = 0f;
			c.g = 0f;
		}

		SP.color = c;
	

		foreach (int i in more)
		{
			if (i > largest)
			{
				largest = i;
			}
		}


		if(n<5) 
		{
			if(largest == more[n])
			{

			item_count[im]  = n;
			im ++;

				}
			n++;

		}

	
		if (n >= 5) {
			if (im == 1) {
				for (int i = 0; i<more.Length; i++) {
					if (more [i] == largest)
					if (largest_name == -1)
						largest_name = i;
				}
			} else if (im > 1&&largest_name == -1) 
				if (largest_name == -1)largest_name = item_count[Random.Range (0, im)];


		}

		//print ("Largest  "+largest);
		
		//print ("Largest Name  "+largest_name);


if (DoorColl && Input.GetButtonDown ("Enter")) {
			if (largest_name == 0)
				Application.LoadLevel ("PowerEnding");
			else if (largest_name == 1)
				Application.LoadLevel ("WhiteEnding");
			else if (largest_name == 2)
				Application.LoadLevel ("BlackEnding");
			else if (largest_name == 3)
				Application.LoadLevel ("BlackEnding");
			else if (largest_name == 4)
				Application.LoadLevel ("EmptyEnding");
			else if (largest_name == 5)
				Application.LoadLevel ("FireEnding");
		} 

	}
		

	void OnTriggerStay2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			DoorColl = true;
		} 
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			
			DoorColl = false;
		} 
	}

	
	

}
