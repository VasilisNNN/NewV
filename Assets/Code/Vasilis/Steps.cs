using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Steps : MonoBehaviour {
	private Movement pl;
    public float delay = 0.35f;
    private float timer;
    public float stepLength = 0.2f;
    private AudioSource AS;
    public AudioClip[] AC;
	public AudioClip[] MudClips;
    public AudioClip[] MetalClips;

    public AudioClip[] ConcreteClips;
    private AudioClip[] MainClipArray;

    private int[] meatsteps,concretesteps,metalsteps;
    private GameObject[] MeatFloor, ConcreteFloor,MetalFloor;
    

    private int s;
    private List<GameObject> coll_obj = new List<GameObject>();
    public bool RND;
    void Start () {
        MeatFloor = GameObject.FindGameObjectsWithTag("Mud");
        ConcreteFloor = GameObject.FindGameObjectsWithTag("Concrete");
        MetalFloor = GameObject.FindGameObjectsWithTag("Metal");

        meatsteps = new int[MeatFloor.Length];
        concretesteps = new int[ConcreteFloor.Length];
        metalsteps = new int[MetalFloor.Length];

		pl = GameObject.Find("Vasilis").GetComponent<Movement>();
        AS = GetComponent<AudioSource>();


        MainClipArray = AC;
        AS.clip = MainClipArray[s];

    }
	
	
	void Update () {

       
        if (MeatFloor.Length > 0)
        {
            for (int i = 0; i < MeatFloor.Length; i++)
            {
                if (coll_obj.Contains(MeatFloor[i])) meatsteps[i] = 1;
                else meatsteps[i] = 0;
            }

			if (MainClipArray != MudClips && meatsteps.Sum() > 0)
				ChangeToCorrentClipArray(MudClips);
            

        }

        if (ConcreteFloor.Length > 0)
        {
            for (int i = 0; i < ConcreteFloor.Length; i++)
            {
                if (coll_obj.Contains(ConcreteFloor[i])) concretesteps[i] = 1;
                else concretesteps[i] = 0;
            }

            if (concretesteps.Sum() > 0 && MainClipArray != ConcreteClips)
            ChangeToCorrentClipArray(ConcreteClips);
                
            
        }


       if (MetalFloor.Length > 0)
        {

            for (int i = 0; i < MetalFloor.Length; i++)
            {
                if (coll_obj.Contains(MetalFloor[i])) metalsteps[i] = 1;
                else metalsteps[i] = 0;
            }
                if (MainClipArray != MetalClips && metalsteps.Sum() > 0)
                ChangeToCorrentClipArray(MetalClips);
               

            
           
        }

        if (meatsteps.Sum() <= 0&& concretesteps.Sum() <= 0 && metalsteps.Sum() <= 0)
        {
            if (MainClipArray != AC)
            ChangeToCorrentClipArray(AC);
                
            

        }

       
        
        
        if (pl._normalHSpeed!= 0 || pl._normalVSpeed != 0)
        {
            if (timer + delay + stepLength < Time.fixedTime && !AS.isPlaying) PlaySteps();
            if (timer + stepLength < Time.fixedTime && AS.isPlaying) AS.Stop();
        }
    }
    void ChangeToCorrentClipArray(AudioClip[] ac)
    {
        MainClipArray = ac;

        AS.Stop();
        timer  = Time.fixedTime  - delay - stepLength - 1;
        if (s >= MainClipArray.Length) s = 0;
        AS.clip = MainClipArray[s];
    }
    void PlaySteps()
    {
        
      if (!RND) s++;
      else s = Random.Range(0, MainClipArray.Length);


      if(s > AC.Length - 1) s = 0;

      AS.clip =  MainClipArray[s];
      AS.Play();
        
      timer = Time.fixedTime;

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

        if (coll_obj.Contains(c.gameObject))
            coll_obj.Remove(c.gameObject);

    }

}
