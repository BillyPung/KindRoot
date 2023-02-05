using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunItem : GameItems
{
    // Start is called before the first frame update
    [Header("阳光单独有的")] 
    public float addRopeVal;

    public bool canUse;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1")
        {
            if (canUse)
            {
                audioSource.Play();
                player1.GetComponent<PlayerCTRL>().rootScript.maxDist += addRopeVal;
                GetComponent<SpriteRenderer>().enabled = false;
                canUse = false;
            }

            StartCoroutine(DestroySelf());
        }
        else if (col.gameObject.name == "Player_2")
        {
            if (canUse)
            {
                audioSource.Play();
                player2.GetComponent<PlayerTwoCTRL>().rootScript.maxDist += addRopeVal;
                GetComponent<SpriteRenderer>().enabled = false;
                canUse = false;
            }

            StartCoroutine(DestroySelf());
        }
    }

    private  IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
