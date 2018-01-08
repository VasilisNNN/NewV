using UnityEngine;
using System.Collections;

public class ChoiseInterface : MonoBehaviour {
	private bool mv;

	public float StartPosx = 100;
	public float StartPosy = 0;
	public float ItemW =0;
	public float ItemH = 50;


	public int Row;
	public int Line;
	//private int itemnum = 0;


	private float posplx;
	private float posply;

	public int CorrentItem;

	public Texture tBox;
	public Texture[] texture;

	private bool OnChoise = true;
	private bool DrawChoise = true;
	private Movement move;
	//private Dialog dialog;
	// Update is called once per frame
	void Start()
	{
		

	
		if(GameObject.Find ("Vasilis")!=null)
		move = GameObject.Find ("Vasilis").GetComponent<Movement> ();

	}

	void OnGUI () {

//		itemnum = Row*Line;
		if (DrawChoise) {
			mv = true;
			/*if (move != null)
				move.SetMove (false);*/
			if (tBox != null)
				GUI.DrawTexture (new Rect (StartPosx + posplx * ItemW * 2 - 10f, StartPosy + posply * ItemH * 2 - 10f, ItemW + 20f, ItemH + 20f), tBox);

			for (int i = 0; i < Row; i++) {
				for (int j = 0; j < Line; j++) {
					//int f = i*j;
					if (texture [i + (j * Row)] != null)
						GUI.DrawTexture (new Rect (StartPosx + i * ItemW * 2, StartPosy + j * ItemH * 2, ItemW, ItemH), texture [i + (j * Row)]);
				

				}
			}

		} else if (move != null && mv) {
			//move.SetMove(true);
			mv = false;
		}


	}


	void Update()
	{
		if (StartPosx < 0)
			StartPosx = Screen.width/2  - ItemW*Row;
		if (OnChoise) {

			if (Input.GetAxis("Horizontal") <0&&Input.GetButtonDown("Horizontal")) {
	
				if(CorrentItem>0)CorrentItem--;

								if (posplx > 0 && posplx <= Row) {
										posplx--;
										
								} else if (posplx == 0 && posply <= Line && posply > 0) {
										posply--;
										posplx = Row - 1;
								} 
						}

			if (Input.GetAxis("Horizontal") >0&&Input.GetButtonDown("Horizontal"))  {
				if(CorrentItem<Row*Line-1)CorrentItem++;
								if (posplx >= 0 && posplx < Row - 1) {
										posplx++;
								
								} else if (posplx == Row - 1 && posply < Line - 1) {
										posply++;
										posplx = 0;
								} 
						}

		}
	}

	public int ReturnCorrentItem()
	{
		return CorrentItem;
	}
	public void SetOnChoise(bool On)
	{
		OnChoise = On;
	}
	public bool GetOnChoise()
	{
		return OnChoise;
	}
	public void SetDrawChoise(bool On)
	{
		DrawChoise = On;
	}
	public bool GetDrawChoise()
	{
		return DrawChoise;
	}
	public void SetAll(bool b)
	{
		DrawChoise = b;
		OnChoise = b;
	}
}
