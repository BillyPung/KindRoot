using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MovingWorm : MonoBehaviour
{
    public GameObject leftBound;
    public GameObject rightBound;
    public Rigidbody2D rig;
    public float speed;
    private AudioSource audioSource;
    public AudioClip biteSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > rightBound.transform.position.x || transform.position.x < leftBound.transform.position.x)
        {
            speed *= -1;
        }
        
        rig.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Player_1")
        {
            audioSource.clip = biteSound;
            audioSource.Play();
            col.gameObject.GetComponent<PlayerCTRL>().rootScript.maxDist -= 0.5f;
        }
        else if(col.gameObject.name == "Player_2")
        {
            audioSource.Play();
            col.gameObject.GetComponent<PlayerTwoCTRL>().rootScript.maxDist -= 0.5f;
        }

    }
}
