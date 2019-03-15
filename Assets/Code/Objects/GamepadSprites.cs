using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadSprites : MonoBehaviour {
    public Sprite XBoxSPSRT;
    public Sprite PSSPSRT;

    private Menu menu;
    private void Start()
    {
        menu = GameObject.Find("Vasilis").GetComponent<Menu>();
    }
    void Update ()
    {
        if (menu.XBoxGamepad)
        GetComponent<SpriteRenderer>().sprite = XBoxSPSRT;
        
        if (menu.PSGamepad)
        GetComponent<SpriteRenderer>().sprite = PSSPSRT;
        
    }
}
