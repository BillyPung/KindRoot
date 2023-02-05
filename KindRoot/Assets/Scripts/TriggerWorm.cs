using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWorm : MonoBehaviour
{
    public bool triggered = false;
    public bool canMove = false;
    public bool initialMove;
    public float beforeFlyTime;
    public Vector2 startPos;
    public Rigidbody2D rig;
    public Animator anim;
    
    public float speed = 100f;
    public float moveTime;
    private float _moveTimer;
    public float acceleration;
    public float initialMoveTime;
    private float _initialMoveTimer;
    
    private AudioSource audioSource;
    public AudioClip biteSound;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = (Vector2)transform.position;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _moveTimer = moveTime;
        _initialMoveTimer = initialMoveTime;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            StartCoroutine(Fly());
        }

        if (initialMove)
        {
            if (_initialMoveTimer >= 0)
            {
                _initialMoveTimer -= Time.deltaTime;
                rig.velocity = Vector2.right * Time.deltaTime * 20f;
            }
            else
            {
                _initialMoveTimer = initialMoveTime;
                rig.velocity = Vector2.zero;
                initialMove = false;
            }
        }
        
        if (canMove)
        {
            if (_moveTimer >= 0)
            {
                _moveTimer -= Time.deltaTime;
                rig.velocity = Vector2.right * Time.deltaTime * speed;
                speed += acceleration * Time.deltaTime;
            }
            else if(_moveTimer < 0)
            {
                anim.SetBool("TriggeredMove", false);
                _moveTimer = moveTime;
                canMove = false;
                rig.velocity = Vector2.zero;
                transform.position = startPos;
                speed = 300f;
                initialMove = true;
            }
        }
    }

    IEnumerator Fly()
    {
        StartCoroutine(TriggerAnimation());
        yield return new WaitForSeconds(beforeFlyTime);
        canMove = true;
        triggered = false;
        // anim.SetBool("TriggeredMove", true);
    }
    
    IEnumerator TriggerAnimation()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("TriggeredMove", true);
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Rope_1" || col.gameObject.name == "Rope_2")
        {
            audioSource.clip = biteSound;
            audioSource.Play();
            col.gameObject.GetComponent<NewRopeScript>().maxDist -= 1f;
        }
    }
}
