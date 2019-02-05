using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrigger : MonoBehaviour {
    private Mouse _mouse;
    private Movement pl;
    public Transform[] tr;
    public float[] r;
    public bool rotate;
    // Use this for initialization
    void Start () {
        _mouse = GameObject.Find("Mouse(Clone)").GetComponent<Mouse>();
        pl = GameObject.Find("Vasilis").GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rotate)
        {
            for (int i = 0; i < tr.Length; i++)
            {
                tr[i].Rotate(new Vector3(0, 0, r[i]));
                if (tr[i].GetComponent<AudioSource>() != null && !tr[i].GetComponent<AudioSource>().isPlaying)
                    tr[i].GetComponent<AudioSource>().Play();
            }
        }
        else
        {

            for (int i = 0; i < tr.Length; i++)
            {
                if (tr[i].GetComponent<AudioSource>() != null && tr[i].GetComponent<AudioSource>().isPlaying)
                    tr[i].GetComponent<AudioSource>().Stop();
            }
        }

        if (pl.Getcollob().Contains(gameObject) && pl.enter_b)
        {
            rotate = !rotate;

            if (GetComponent<AudioSource>() != null&& !GetComponent<AudioSource>().isPlaying)
             GetComponent<AudioSource>().Play();
            
            
        }
	}
}
