using UnityEngine;
using System.Collections;

public class ChangeObjSprite : MonoBehaviour {
	
	private Mix_ChangeItems MCI;
    public Sprite[] SpritesArray ;
	public int StartSprite = 0;
	private bool mix;
	private SpriteRenderer Sprt;
private void Start()
	{		 		
		MCI = GetComponent<Mix_ChangeItems>();
        // add a "SpriteRenderer" component to the newly created object
       // gameObject.GetComponent<SpriteRenderer>().sprite = SpritesArray[StartSprite];
		Sprt = GetComponent<SpriteRenderer>();
	}

void Update()
{

Sprt.sprite = SpritesArray[PlayerPrefs.GetInt(gameObject.name+"SpriteNum")];
//		print (PlayerPrefs.GetInt(gameObject.name+"SpriteNum"));

if(MCI.GetCollisinWithItem()&&Input.GetKeyDown(KeyCode.Mouse0))
{
			/*if(Sprt.enabled)
			{
				Inv.AddItem(MCI.GetCorrentNumItemList());
			}*/
			if(!Sprt.enabled)Sprt.enabled = true;
				PlayerPrefs.SetInt(gameObject.name+"SpriteNum",MCI.GetCorrentNumItemNum());
}


}


public void SetSprite(int i)
	{
		Sprt.sprite = SpritesArray[i];
	}
public string GetSprite()
	{
		return Sprt.name;
	}	
}