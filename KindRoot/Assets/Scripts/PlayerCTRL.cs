using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int knifeNum;
    
    public float velocityX;

    // public float axisVal;
    public bool isJumping;
    public bool isOnGround;
    
    private AudioSource audioSource;
    
    [Header("跳一跳版本")]
    
    public bool inAir = false;
    public bool inMoving = false;

    public bool facingRight = true;
    public float strengthMulti = 1.7f;

    
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;

    public float jumpStrength = 0f;
    public float jumpDirection = 0f;

    public float maxJumpStren;
    public float jumpStrengthAddSpd;

    public GameObject[] dirArrows;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        // groundLayerMask = LayerMask.GetMask("Ground");
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        col2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = OnGround();
        if (isOnGround)
        {
            anim.SetBool("Player-Jump", false);
        }
        // LeftRightMove();
        // Jump();
        // GravityAdjustment();
        Jumpjump();
    }

    void Jumpjump()
    {
        if (Input.GetKey(jumpKey))
        {
            // Increase jump strength linearly within 5 seconds
            // jumpStrength = Mathf.Clamp(jumpStrength + 3f * Time.deltaTime, 0f, 3.5f);
            print("Jump Strength: " + jumpStrength);

            jumpStrength += jumpStrengthAddSpd * Time.deltaTime;
            if (jumpStrength > maxJumpStren || jumpStrength < 0f)
            {
                jumpStrengthAddSpd *= -1;
            }
            
        }
        // Determine jump direction based on key input
        if (Input.GetKey(leftKey))
        {
            sr.flipX = true;
            if (Input.GetKey(upKey))
            {
                print("A + W");
                for (int i = 0; i < dirArrows.Length; i++)
                {
                    dirArrows[i].GetComponent<Image>().enabled = false;
                }
                dirArrows[1].GetComponent<Image>().enabled = true;
                jumpDirection = 15f;
            }
            else
            {
                print("A");
                for (int i = 0; i < dirArrows.Length; i++)
                {
                    dirArrows[i].GetComponent<Image>().enabled = false;
                }
                dirArrows[0].GetComponent<Image>().enabled = true;
                jumpDirection = 45f;
            }
        }
        else if (Input.GetKey(rightKey))
        {
            sr.flipX = false;
            if (Input.GetKey(upKey))
            {
                for (int i = 0; i < dirArrows.Length; i++)
                {
                    dirArrows[i].GetComponent<Image>().enabled = false;
                }
                dirArrows[3].GetComponent<Image>().enabled = true;
                print("D + W");
                jumpDirection = -15f;
            }
            else
            {
                for (int i = 0; i < dirArrows.Length; i++)
                {
                    dirArrows[i].GetComponent<Image>().enabled = false;
                }
                dirArrows[4].GetComponent<Image>().enabled = true;
                print("D");
                jumpDirection = -45f;
            }
        }
        else if(Input.GetKey(upKey) && !Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            for (int i = 0; i < dirArrows.Length; i++)
            {
                dirArrows[i].GetComponent<Image>().enabled = false;
            }
            dirArrows[2].GetComponent<Image>().enabled = true;
            print("W");
            jumpDirection = 0f;
        }
        else
        {
            for (int i = 0; i < dirArrows.Length; i++)
            {
                dirArrows[i].GetComponent<Image>().enabled = false;
            }
        }
        
        if (Input.GetKeyUp(jumpKey))
        {
            // Get the jump vector based on direction and strength
            Vector3 jumpVector = Quaternion.Euler(0, 0, jumpDirection) * Vector3.up * (strengthMulti * jumpStrength);

            audioSource.Play();
            anim.SetBool("Player-Jump", true);
            
            // Apply the jump force to the character's rigidbody
            rig.AddForce(jumpVector, ForceMode2D.Impulse);
            //rb2d.MovePosition();
            // Reset jump strength and direction
            jumpStrength = 0f;
            jumpDirection = 0f;

            // anim.SetBool("Player-Jump", false);
            for (int i = 0; i < dirArrows.Length; i++)
            {
                dirArrows[i].GetComponent<Image>().enabled = false;
            }
        }
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


    #region 用不到的了

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
                    anim.SetBool("Player-Jump", true);
                }

                if (Input.GetAxis("Jump") == 1 && isJumping == false)
                {
                    rig.velocity = new Vector2(rig.velocity.x, jumpingSpeed);
                    isJumping = true;
                    audioSource.Play();
                    anim.SetBool("Player-Jump", true);
                }

                else if (isOnGround && Input.GetAxis("Jump") == 1)
                {
                    // isJumping = false;
                    anim.SetBool("Player-Jump", false);
                }

                else if (isOnGround && Input.GetAxis("Jump") == 0)
                {
                    isJumping = false;
                    anim.SetBool("Player-Jump", false);
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

    #endregion


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (knifeNum > 0)
        {
            if (col.gameObject.name == "Rope_2")
            {
                col.gameObject.GetComponent<NewRopeScript>().maxDist -= 0.5f;
                knifeNum -= 1;
            }
        }
    }
}