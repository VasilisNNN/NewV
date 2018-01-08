using UnityEngine;
using System.Collections;

public class Days_INT_Draw : MonoBehaviour {

	public bool equel = true;
	public bool less = false;
	public bool grater = false;
	public bool graterIntEquelDay = false;
	public bool NonEquelInt_GreaterDay = false;
	public bool EquelInt_GreaterDay = false;
	public string namee;
	private SpriteRenderer SP;
	private BoxCollider2D BC;
	private PolygonCollider2D PC;
	private AudioSource AU;
	public int yy;
	public int days;
	public int end_days = 15;

	public bool Box = true;
	public bool Sprite = true;
	public bool Delete = false;
	void Awake()
	{
		AU = GetComponent<AudioSource>();

	}
	void Start()
	{
		SP = gameObject.GetComponent<SpriteRenderer> ();
		BC = gameObject.GetComponent<BoxCollider2D> ();
		PC = gameObject.GetComponent<PolygonCollider2D> ();

	}
	
	
	void Update()
	{

		if (less) {
			if (PlayerPrefs.GetInt (namee) < yy && PlayerPrefs.GetInt ("Day") >= days&&PlayerPrefs.GetInt ("Day") < end_days)
				Draw (true);
			else{
				Draw (false);
				if(Delete)Destroy(gameObject);
			}
		} else if (equel) {
			if (PlayerPrefs.GetInt (namee) == yy && PlayerPrefs.GetInt ("Day") == days&&PlayerPrefs.GetInt ("Day") < end_days)
				Draw (true);
			else
			{Draw (false);
				if(Delete)Destroy(gameObject);
			}

		} else if (grater) {
			if (PlayerPrefs.GetInt (namee) >= yy && PlayerPrefs.GetInt ("Day") >= days&&PlayerPrefs.GetInt ("Day") < end_days)
				Draw (true);
			else{
				Draw (false);
				if(Delete)Destroy(gameObject);
			}
		} else if (graterIntEquelDay) {
			if (PlayerPrefs.GetInt (namee) >= yy && PlayerPrefs.GetInt ("Day") >= days&&PlayerPrefs.GetInt ("Day") < end_days)
				Draw (true);
			else{
				Draw (false);
				if(Delete)Destroy(gameObject);
			}
		}
		if(NonEquelInt_GreaterDay)
		{
			if (PlayerPrefs.GetInt (namee) != yy&&PlayerPrefs.GetInt ("Day") >= days&&PlayerPrefs.GetInt ("Day") < end_days)
				Draw (true);
			else{
				Draw (false);
				if(Delete)Destroy(gameObject);
			}
		}
		if(EquelInt_GreaterDay)
		{
			if (PlayerPrefs.GetInt (namee) == yy&&PlayerPrefs.GetInt ("Day") >= days)
				Draw (true);
			else{
				Draw (false);
				if(Delete)Destroy(gameObject);
			}
		}
	}
	
	
	
	
	void Draw(bool draw)
	{
		if (AU != null) {
			
			if(!AU.isPlaying&&draw)AU.Play ();
			else if(AU.isPlaying&&!draw||!draw)AU.Stop ();
		}
		if(SP!=null&&Sprite)SP.enabled = draw;
		if(BC!=null&&Box)BC.enabled = draw;
		if(PC!=null)PC.enabled = draw;
	}
}
