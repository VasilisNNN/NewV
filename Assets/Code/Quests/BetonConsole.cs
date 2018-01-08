using UnityEngine;
using System.Collections;

public class BetonConsole : MonoBehaviour {


	private TriggerMouse Cement;
	private TriggerMouse Sheben;
	private TriggerMouse Finish;


	private NumberCount CemC;
	private NumberCount ShebC;
	// Use this for initialization

	void Start () {

		Cement = GameObject.Find("Cement").GetComponent<TriggerMouse>();
		Sheben = GameObject.Find("Sheben").GetComponent<TriggerMouse>();
		Finish = GameObject.Find("Finish").GetComponent<TriggerMouse>();


		CemC = GameObject.Find("CemC").GetComponent<NumberCount>();
		ShebC = GameObject.Find("ShebC").GetComponent<NumberCount>();
	}
	
	// Update is called once per frame
	void Update () {

	if (Cement.GetClicked()){
						CemC.On = true;
				
						
						ShebC.On = false;
				}
	if (Sheben.GetClicked()){
						ShebC.On = true;
			            
			            CemC.On  = false;
				}
	
	if (Finish.GetClicked())
		{

			PlayerPrefs.SetInt("ShebC",ShebC.GetNumber());
			PlayerPrefs.SetInt("CemC",CemC.GetNumber());

			if(ShebC.GetNumber()>40)
			PlayerPrefs.SetInt("PowerWay",PlayerPrefs.GetInt("PowerWay")+5);
			if(CemC.GetNumber()>50)
				PlayerPrefs.SetInt("DeathWay",PlayerPrefs.GetInt("DeathWay")+4);

			if(ShebC.GetNumber()<=40&&ShebC.GetNumber()>10)
				PlayerPrefs.SetInt("LiveWay",PlayerPrefs.GetInt("LiveWay")+5);
			if(CemC.GetNumber()<=50&&CemC.GetNumber()>10)
				PlayerPrefs.SetInt("FireWay",PlayerPrefs.GetInt("FireWay")+4);

			if(ShebC.GetNumber()==10||CemC.GetNumber()==10)
				PlayerPrefs.SetInt("EmptyWay",PlayerPrefs.GetInt("EmptyWay")+10);


			PlayerPrefs.SetInt("BetonCar",1);

			PlayerPrefs.SetString("CorrLavel","Fabric0");
			Application.LoadLevel("Fabric0");
		}

}
}