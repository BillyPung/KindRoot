using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    [Header("移动")] public float walkSpeed;
    public float accelerationTime;
    public float decelerationTime;

    [Header("跳跃")] public bool canJump = true;
    public float jumpingSpeed;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    [Header("判定是否在地上")] public Vector2 pointOffset;
    public Vector2 size;
    public LayerMask groundLayerMask;
    public bool gravityModifier = true;

    [Header("自身")] public NewRopeScript rootScript;
    public Rigidbody2D rig;
    public Animator anim;
    public SpriteRenderer sr;
    public BoxCollider2D col2D;

    public float velocityX;

    // public float axisVal;
    public bool isJumping;
    public bool isOnGround;
    
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        // groundLayerMask = LayerMask.GetMask("Ground");
        rig = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        col2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isOnGround = OnGround();
        LeftRightMove();
        Jump();
        GravityAdjustment();
    }

    private bool OnGround()
    {
        Collider2D Coll = Physics2D.OverlapBox((Vector2) transform.position + pointOffset, size, 0, groundLayerMask);
        if (Coll != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube((Vector2) transform.position + pointOffset, size);
    }

    private void LeftRightMove()
    {
        MoveLogic(walkSpeed);
    }

    private void MoveLogic(float inputSpeed)
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rig.velocity =
                new Vector2(
                    Mathf.SmoothDamp(rig.velocity.x, inputSpeed * Time.fixedDeltaTime * 60, ref velocityX,
                        accelerationTime), rig.velocity.y);
            sr.flipX = false;
            // anim.SetBool("Player-CanWalk", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rig.velocity =
                new Vector2(
                    Mathf.SmoothDamp(rig.velocity.x, inputSpeed * Time.fixedDeltaTime * 60 * -1, ref velocityX,
                        accelerationTime), rig.velocity.y);
            sr.flipX = true;
            // anim.SetBool("Player-CanWalk", true);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            rig.velocity = new Vector2(Mathf.SmoothDamp(rig.velocity.x, 0, ref velocityX, decelerationTime),
                rig.velocity.y);
            // anim.SetBool("Player-CanWalk", false);
        }
    }


    private void Jump()
    {
        if (canJump)
        {
            {
                if (!isOnGround)
                {
                    isJumping = true;
                    // anim.SetBool("Player-CanWalk", false);
                    // anim.SetBool("Player-Jump", true);
                }

                if (Input.GetAxis("Jump") == 1 && isJumping == false)
                {
                    rig.velocity = new Vector2(rig.velocity.x, jumpingSpeed);
                    isJumping = true;
                    audioSource.Play();
                    // anim.SetBool("Player-Jump", true);
                }

                else if (isOnGround && Input.GetAxis("Jump") == 1)
                {
                    // isJumping = false;
                    // anim.SetBool("Player-Jump", false);
                }

                else if (isOnGround && Input.GetAxis("Jump") == 0)
                {
                    isJumping = false;
                    // anim.SetBool("Player-Jump", false);
                }
            }
        }
    }

    private void GravityAdjustment()
    {
        if (gravityModifier)
        {
            if (rig.velocity.y < 0) // 当玩家下坠时候
            {
                rig.velocity +=
                    Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) *
                    Time.fixedDeltaTime; // (加速下坠)
                //Rig.velocity = new Vector2(Rig.velocity.x, -JumpingSpeed);
            }
            else if (rig.velocity.y > 0
                     // else if (rig.velocity.y > 0 && Input.GetAxis("Jump") != 1
                    ) //当玩家上升且没有按下跳跃键时
            {
                rig.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) *
                                Time.fixedDeltaTime; // (减速上升)
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Rope_2")
        {
            col.gameObject.GetComponent<NewRopeScript>().maxDist -= 0.5f;
        }
    }*/
}