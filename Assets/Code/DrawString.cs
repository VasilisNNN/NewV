using UnityEngine;
using System.Collections;

public class DrawString : MonoBehaviour {
	public string namee_Key = "CorrLevel";
	public string namee_Value;
	private SpriteRenderer[] SP;
	private BoxCollider2D[] BC;
	private PolygonCollider2D[] PC;
	private AudioSource[] AU;
	private Movement[] Move;

	void Awake()
	{
		SP = GetComponentsInChildren<SpriteRenderer> ();
		BC = GetComponentsInChildren<BoxCollider2D> ();
		PC = GetComponentsInChildren<PolygonCollider2D> ();
		AU = GetComponentsInChildren<AudioSource> ();
		Move = GetComponentsInChildren<Movement> ();


		if (PlayerPrefs.GetString (namee_Key) != namee_Value)
		Draw (false);
		else 
		Draw (true);

	}
	
	void Update()
	{
		SP = GetComponentsInChildren<SpriteRenderer> ();
		BC = GetComponentsInChildren<BoxCollider2D> ();
		PC = GetComponentsInChildren<PolygonCollider2D> ();
		AU = GetComponentsInChildren<AudioSource> ();
		Move = GetComponentsInChildren<Movement> ();
		if (PlayerPrefs.GetString (namee_Key) == namee_Value)
			Draw (true);
		else {
		
			Draw (false);
		}
	}
	
	
	
	
	void Draw(bool draw)
	{
		for(int i= 0; i<SP.Length;i++)
		{
		if(SP!=null)SP[i].enabled = draw;
		}
		for(int i= 0; i<BC.Length;i++)
		{
			if(BC!=null)BC[i].enabled = draw;
		}
		for(int i= 0; i<AU.Length;i++)
		{
			if(AU!=null)
			{  //AU[i].enabled = draw;
				if(!AU[i].isPlaying && draw)AU[i].Play();
				else if(AU[i].isPlaying && !draw)AU[i].Stop();
			}

		}
		for(int i= 0; i<PC.Length;i++)
		{
			if(PC!=null)PC[i].enabled = draw;
		}
		for(int i= 0; i<Move.Length;i++)
		{
			if(Move!=null)Move[i].enabled = draw;
		}
	


	}
}
