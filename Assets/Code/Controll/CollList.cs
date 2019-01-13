using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CollList : MonoBehaviour {
	private List<GameObject> coll_obj = new List<GameObject>();
    void LateUpdate()
    {
        for (int i = 0; i < coll_obj.Count; i++)
        {
            if (coll_obj[i] != null)
            {
                if (coll_obj[i].GetComponent<BoxCollider2D>() != null)
                {
                    if (!coll_obj[i].GetComponent<BoxCollider2D>().enabled)
                    {
                        //print(coll_obj[i].name);
                        coll_obj.RemoveAt(i);
                    }
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D c)
	{
        if (!coll_obj.Contains(c.gameObject))
        {
            coll_obj.Add(c.gameObject);
            
        }
     
    }
	
	private void OnTriggerExit2D(Collider2D c)
	{
		
		if(coll_obj.Contains(c.gameObject))
			coll_obj.Remove(c.gameObject);
		
	}
	public List<GameObject> Getcollob()
	{
		return coll_obj;
	}



    


	}