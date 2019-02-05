using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class AddingItems: MonoBehaviour {
	
	private Inventory inv;
	public bool ItemAdded{ get; set;}

    public int NeededItem = -1;
    public int ItemNeededCount = 1;

    public int[] ItemAdding;
	public List<int> ItemAddingCount;
    private Movement pl;

    public bool DontDestroy;
    public string Quest_NameLocationQuest = "";
    private AudioSource AU;
    public AudioClip Clip;
    void Start () {
        if (ItemAdding != null)
        {

            if (ItemAddingCount.Count < ItemAdding.Length)
            {
                for (int i = 0; i < ItemAdding.Length - ItemAddingCount.Count; i++)
                    ItemAddingCount.Add(1);
            }

        }
        if (NeededItem > -1&& ItemNeededCount==0) ItemNeededCount = 1;

         inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
        pl = GameObject.Find("Vasilis").GetComponent<Movement>();
        AU = GameObject.Find("Vasilis").GetComponent<AudioSource>();
        if (!DontDestroy&&PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name + "DestroyAdd") == 1) Destroy(gameObject);

        if(Clip == null)
        Clip = Resources.Load<AudioClip>("Sound/PickItems/PickPaperPlastic");
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (pl.enter_b && pl.Getcollob().Contains(gameObject))
        {

           
            


            if (NeededItem == -1) ContainersF();
            else if (inv.CheckCorrentItem() == NeededItem && inv.showinvent && inv.CheckCorrentItemNum() >= ItemNeededCount)
            {
                ContainersF();
               if(ItemNeededCount > 0) inv.RemoveSlot(inv.correntSlot);
               
            }
        }
    }

	void ContainersF()
	{
        
        if (Quest_NameLocationQuest.Length > 0) PlayerPrefs.SetInt(Quest_NameLocationQuest, 1);

        for (int i = 0; i < ItemAdding.Length; i++) {

				inv.AddItem(ItemAdding[i], ItemAddingCount[i]);
            if (!AU.isPlaying && Clip != null)
            {
                AU.clip = Clip;
                AU.Play();

            }

            if (i == ItemAdding.Length - 1)
            {
                if (!DontDestroy)
                {
                    PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name + "DestroyAdd", 1);
                    Destroy(gameObject);
                    
                }
               

            }
			}
        inv.SaveInv();
    }

}