using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeItem : MonoBehaviour
{
    
    // Start is called before the first frame update
    private AudioSource audioSource;
    public bool canUse;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player_1")
        {
            if (canUse)
            {
                audioSource.Play();
                col.GetComponent<PlayerCTRL>().knifeNum += 1;
                GetComponent<SpriteRenderer>().enabled = false;
                canUse = false;
            }

            StartCoroutine(DestroySelf());
        }
        else if(col.name == "Player_2")
        {
            if (canUse)
            {
                audioSource.Play();
                col.GetComponent<PlayerTwoCTRL>().knifeNum += 1;
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
