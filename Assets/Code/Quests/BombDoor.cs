using UnityEngine;
using System.Collections;

public class BombDoor : MonoBehaviour {
private Mix_ChangeItems MCI;
	// Use this for initialization
    public Sprite[] SpritesArray ;
	public int StartSprite = 0;
	
void Start () {
	
		
	MCI = gameObject.GetComponent<Mix_ChangeItems>();
    
	if(gameObject.GetComponent<SpriteRenderer>().name == "BombDoor_0")
	{

	PlayerPrefs.SetInt("BombDoorOpen",0);}
		
	GetComponent<SpriteRenderer>().sprite = SpritesArray[PlayerPrefs.GetInt("BombDoorOpen")];
		
		
	if(PlayerPrefs.GetInt("BombDoorOpen")>0)
		{
	GetComponent<BoxCollider2D>().isTrigger = true;
	MCI.ItemOperator = false;
	
		}
	}

	// Update is called once per frame
	void Update () {
	if(MCI.GetCollisinWithItem()){

	if(MCI.GetCorrentNumItemNum() == 2)PlayerPrefs.SetInt("NeighbourDoor",1);

	GetComponent<SpriteRenderer>().enabled = true;
    GetComponent<SpriteRenderer>().sprite = SpritesArray[MCI.GetCorrentNumItemNum()+1];
	PlayerPrefs.SetInt("BombDoorOpen",MCI.GetCorrentNumItemNum()+1);
		
		}
	}


	
	
}
