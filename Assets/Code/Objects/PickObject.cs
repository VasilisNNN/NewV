using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PickObject : MonoBehaviour {
	
    

    public int AddedItem = -1;
	public int ItemNum = 0;
	private Inventory Inv;

	private Movement pl;
	private Mouse _mouse;
    public bool DestroyAfterGetItem = false;
    private bool enter;
    private List<GameObject> coll_obj = new List<GameObject>();

    void Start()
	{ 
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();


		if (PlayerPrefs.GetInt ("Death" + name) == 1)
			Destroy (gameObject);
		if(GameObject.Find("Vasilis")!=null)
			pl = GameObject.Find("Vasilis").GetComponent<Movement> ();

        _mouse = GameObject.Find("Mouse(Clone)").GetComponent<Mouse>();
    }
	
private	void Update()
	{
    
    if (_mouse.pointnclick)
    {
        enter = Input.GetMouseButtonDown(0);
        coll_obj = _mouse.GetCollObj();
    }
    else
    {
        enter = pl.enter_b;
        coll_obj = pl.Getcollob();
    }

    if (enter&& coll_obj.Contains(gameObject))
			{
            if (AddedItem > -1)
            {
                Inv.AddItem(AddedItem, ItemNum);

                if (DestroyAfterGetItem)
                {

                    Destroy(gameObject);
                    PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "Destroy", 1);
                    pl.Save();
                }
            }
        }

	
	}


	private void Load()
	{
		if (PlayerPrefs.GetInt (name) == -1)
			Destroy (gameObject);
	}
	public string GetObName()
	{
		return gameObject.name;
	}

}
