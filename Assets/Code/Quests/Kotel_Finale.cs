using UnityEngine;
using System.Collections;

public class Kotel_Finale : MonoBehaviour {

	public Tube_Move_Boiler[] TMB;
	private Mix_ChangeItems left_mix,right_mix;
	private bool[] check;
	void Awake()
	{
		check = new bool[5]; 
		left_mix = GameObject.Find ("FireLeft").GetComponent<Mix_ChangeItems> ();
		right_mix = GameObject.Find ("FireRight").GetComponent<Mix_ChangeItems> ();
		/*for (int i = 0; i<check.Length; i++) {
			check[i] = false;
		}*/
	}



	// Update is called once per frame
	void Update () {
	
		if (TMB [0].GetA () == -1 )
		check [0] = true;
		else
		check[0] = false;

		if ((TMB [1].GetA () == -1||TMB [2].GetA () == 1)&&check [0])
			check [1] = true;
		else
			check[1] = false;

		if ((TMB [2].GetA () == -1||TMB [3].GetA () == 1||TMB [4].GetA () == 1)&&check [1])
			check [2] = true;
		else
			check[2] = false;

		if ((TMB [3].GetA () == -1||TMB [4].GetA () == -1||TMB [5].GetA () == 1||TMB [6].GetA () == 1)&&check [2])
			check [3] = true;
		else
			check[3] = false;

		if ((TMB [5].GetA () == -1||TMB [6].GetA () == -1)&&check [3])
			check [4] = true;
		else
			check[4] = false;

		if (left_mix.GetCollisinWithItem ())
			PlayerPrefs.SetInt ("FireLeft",1);
		if (right_mix.GetCollisinWithItem ())
			PlayerPrefs.SetInt ("FireRight",1);

		print ("0_"+TMB [0].GetA ());
		print ("1_"+TMB [1].GetA ());
		print ("2_"+check [2]);
		print ("3_"+check [3]);
		print ("4_"+check [4]);

		if(check[0]&&check[1]&&check[2]&&check[3]&&check[4])
			{
				if(PlayerPrefs.GetInt ("FireLeft")==1&&PlayerPrefs.GetInt ("FireRight") == 1)
				PlayerPrefs.SetInt("FireWay",PlayerPrefs.GetInt("FireWay")+10);
			PlayerPrefs.SetInt("WaterFallKotel",1);
		}else PlayerPrefs.SetInt("WaterFallKotel",0);

	}
}
