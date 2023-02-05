using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeItem : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player_1")
        {
            col.GetComponent<PlayerCTRL>().knifeNum += 1;
            Destroy(gameObject);
        }
        else if(col.name == "Player_2")
        {
            col.GetComponent<PlayerTwoCTRL>().knifeNum += 1;
            Destroy(gameObject);
        }
    }
}
