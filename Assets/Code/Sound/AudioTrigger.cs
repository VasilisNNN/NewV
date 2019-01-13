using UnityEngine;
using System.Collections;

public class AudioTrigger: MonoBehaviour {
	private AudioSource Au;
    private Movement pl;
    public bool NoEnter;
    public bool PlayOnes;
    private bool Play = true;
    void Start () {
        pl = GameObject.Find("Vasilis").GetComponent<Movement>();
        Au = GetComponent<AudioSource>();
    }



	void Update () {
        if (Play)
        {
            if (!NoEnter)
            {
                if (pl.Getcollob().Contains(gameObject) && pl.enter_b)
                {
                    if (!Au.isPlaying)
                    {
                        Au.Play();
                        if (PlayOnes) Play = false;
                    }
                }

            }
            else
            {
                if (pl.Getcollob().Contains(gameObject))
                {
                    if (!Au.isPlaying)
                    {
                        if (PlayOnes) Play = false;
                        Au.Play();
                    }

                }


            }
        }
    }

}
