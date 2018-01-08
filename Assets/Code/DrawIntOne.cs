using UnityEngine;
using System.Collections;

public class DrawIntOne : MonoBehaviour {

	public string namee;
	private SpriteRenderer SP;
	private BoxCollider2D BC;
	private PolygonCollider2D PC;
	public int yy;

	void Start()
	{
		SP = gameObject.GetComponent<SpriteRenderer> ();
		BC = gameObject.GetComponent<BoxCollider2D> ();
		PC = gameObject.GetComponent<PolygonCollider2D> ();

	}
	

	void Update()
	{
	
			if (PlayerPrefs.GetInt (namee) == yy)
			Draw (true);
		else {
			Draw (false);
			Destroy(gameObject);
		}
	}




	void Draw(bool draw)
	{
		if(SP!=null)SP.enabled = draw;
		if(BC!=null)BC.enabled = draw;
		if(PC!=null)PC.enabled = draw;
	}
}
