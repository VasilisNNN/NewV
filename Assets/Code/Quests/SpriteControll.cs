using UnityEngine;
using System.Collections;

public class SpriteControll : MonoBehaviour {
	private TriggerMouse MPup;
	public Mix_ChangeItems MCI;
	private SpriteRenderer spr;

	public Sprite[] sprites;
	private int CorrSprite;
	public GameObject TriggerName;
	public int AlwaysDraw = 0;
	public int NeededItem;
	private Inventory Inv;
	private AudioSource AU;

	// Use this for initialization
	void Start () {
		if(GetComponent<AudioSource>()!=null)AU = GetComponent<AudioSource>();
		spr = GetComponent<SpriteRenderer>();

		if (AlwaysDraw == 2&&PlayerPrefs.GetInt(gameObject.name)>-1)
	    spr.sprite = sprites[PlayerPrefs.GetInt(gameObject.name)];

		if (AlwaysDraw == 0 && PlayerPrefs.GetInt(gameObject.name)==1)
		spr.enabled = true;

		if (AlwaysDraw == 1 && PlayerPrefs.GetInt (gameObject.name) > -1) {
			CorrSprite = PlayerPrefs.GetInt (gameObject.name);
			spr.sprite = sprites [PlayerPrefs.GetInt (gameObject.name)];
		}


		MPup = TriggerName.GetComponent<TriggerMouse>();

	}

	
	// Update is called once per frame
	void Update () {
		switch(AlwaysDraw) 
		{
		case 0:

			if(PlayerPrefs.GetInt (gameObject.name)==1)
			{	spr.enabled = true;
				if(AU!=null&&!AU.isPlaying)AU.Play();
			}
			else {
				if(AU!=null&&AU.isPlaying)AU.Stop();
				spr.enabled = false;
			}


			if (MCI.GetCollisinWithItem() && MCI.GetCorrentNumItemList() == NeededItem) {

				PlayerPrefs.SetInt (gameObject.name, 1);
				spr.enabled = true;
			}

			break;
		case 1:
			MixItems_Sprite ();
			break;
		case 2:
			ChangeItems_Sprite ();
			break;
		default:break;
		} 
		   
	}

	private void MixItems_Sprite()
	{
		spr.sprite = sprites[PlayerPrefs.GetInt(gameObject.name)];

		if (MPup.GetClicked ()&&Input.GetKeyDown(KeyCode.Mouse0)) {
			CorrSprite+=1;
			if(CorrSprite==sprites.Length)CorrSprite = 0;
			PlayerPrefs.SetInt(gameObject.name,CorrSprite);

		}


	}

	private void ChangeItems_Sprite()
	{
		MCI = TriggerName.GetComponent<Mix_ChangeItems>();
		if (MCI.GetCollisinWithItem () && MCI.GetCorrentNumItemList () == NeededItem) {
			PlayerPrefs.SetInt (gameObject.name, 1);
			spr.enabled = true;
			spr.sprite = sprites[1];
		}
	}


	public int GetCorrSprite()
	{
		return CorrSprite;
	}

}
