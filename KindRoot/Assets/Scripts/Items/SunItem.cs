using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunItem : GameItems
{
    // Start is called before the first frame update
    [Header("阳光单独有的")] 
    public float addRopeVal;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1")
        {
            player1.GetComponent<PlayerCTRL>().rootScript.maxDist += addRopeVal;
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Player_2")
        {
            player2.GetComponent<PlayerTwoCTRL>().rootScript.maxDist += addRopeVal;
            Destroy(gameObject);
        }
    }
}
