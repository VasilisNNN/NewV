using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySPRT : MonoBehaviour
{
    public Sprite[] ENSPRT;
    public Sprite[] RUSPRT;
    
    void Update()
    {
        int L = PlayerPrefs.GetInt("Language");
        SpriteRenderer SPRT = GetComponent<SpriteRenderer>();

        if (RUSPRT.Length > 0)
        {
            if(L == 1)
                SPRT.sprite = ENSPRT[PlayerPrefs.GetInt("Day")];
            else
                SPRT.sprite = RUSPRT[PlayerPrefs.GetInt("Day")];
        }else SPRT.sprite = ENSPRT[PlayerPrefs.GetInt("Day")];


    }
}
