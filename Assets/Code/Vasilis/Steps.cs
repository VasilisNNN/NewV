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
    public AudioClip[] WoodClips;
    public AudioClip[] AsphaltClips;
    public AudioClip[] CarpetClips;


    private AudioClip[] MainClipArray;

    private int[] meatsteps,concretesteps,metalsteps, woodsteps, asphaltsteps, carpetsteps;
    private GameObject[] MeatFloor, ConcreteFloor,MetalFloor, WoodFloor, AsphaltFloor, CarpetFloor;
    

    private int s;
    private List<GameObject> coll_obj = new List<GameObject>();
    public bool RND;
    void Start () {
        MeatFloor = GameObject.FindGameObjectsWithTag("Mud");
        ConcreteFloor = GameObject.FindGameObjectsWithTag("Concrete");
        MetalFloor = GameObject.FindGameObjectsWithTag("Metal");
        WoodFloor = GameObject.FindGameObjectsWithTag("Wood");
        AsphaltFloor = GameObject.FindGameObjectsWithTag("Asphalt");
        CarpetFloor = GameObject.FindGameObjectsWithTag("Carpet");

        meatsteps = new int[MeatFloor.Length];
        concretesteps = new int[ConcreteFloor.Length];
        metalsteps = new int[MetalFloor.Length];
        woodsteps = new int[WoodFloor.Length];
        asphaltsteps = new int[AsphaltFloor.Length];
        carpetsteps = new int[CarpetFloor.Length];

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
        if (WoodClips.Length > 0)
        {

            for (int i = 0; i < WoodFloor.Length; i++)
            {
                if (coll_obj.Contains(WoodFloor[i])) woodsteps[i] = 1;
                else woodsteps[i] = 0;
            }
            if (MainClipArray != WoodClips && woodsteps.Sum() > 0)
                ChangeToCorrentClipArray(WoodClips);




        }
        if (AsphaltClips.Length > 0)
        {

            for (int i = 0; i < AsphaltFloor.Length; i++)
            {
                if (coll_obj.Contains(AsphaltFloor[i])) asphaltsteps[i] = 1;
                else asphaltsteps[i] = 0;
            }
            if (MainClipArray != AsphaltClips && asphaltsteps.Sum() > 0)
                ChangeToCorrentClipArray(AsphaltClips);




        }
        if (CarpetClips.Length > 0)
        {

            for (int i = 0; i < CarpetFloor.Length; i++)
            {
                if (coll_obj.Contains(CarpetFloor[i])) carpetsteps[i] = 1;
                else carpetsteps[i] = 0;
            }
            if (MainClipArray != CarpetClips && carpetsteps.Sum() > 0)
                ChangeToCorrentClipArray(CarpetClips);
        }


        if (meatsteps.Sum() <= 0&& concretesteps.Sum() <= 0 && metalsteps.Sum() <= 0&& woodsteps.Sum() <= 0 && asphaltsteps.Sum() <= 0 && carpetsteps.Sum() <= 0)
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
