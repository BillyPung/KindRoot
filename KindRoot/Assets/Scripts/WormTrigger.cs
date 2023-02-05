using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormTrigger : MonoBehaviour
{
    public bool startCountDown = false;
    public bool canTrigger;

    public float noTriggerTime;
    private float _noTriggerTimer;

    public TriggerWorm tgw;
    public Sprite normalSprite;
    public Sprite triggeredSprite;
        
        // Start is called before the first frame update
    void Start()
    {
        _noTriggerTimer = noTriggerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDown)
        {
            if (_noTriggerTimer < 0)
            {
                _noTriggerTimer = noTriggerTime;
                canTrigger = true;
                startCountDown = false;
            }
            else
            {
                _noTriggerTimer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1" || col.gameObject.name == "Player_2")
        {
            if (canTrigger)
            {
                startCountDown = true;
                tgw.triggered = true;
                GetComponent<SpriteRenderer>().sprite = triggeredSprite;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player_1" || other.gameObject.name == "Player_2")
        {
            GetComponent<SpriteRenderer>().sprite = normalSprite;
            
        }
    }
}
