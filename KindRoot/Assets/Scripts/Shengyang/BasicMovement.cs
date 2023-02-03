using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public bool inAir = false;
    public bool inMoving = false;

    public bool facingRight = true;
    public float strengthMulti = 1.7f;
    
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;
    
    //public 

    private float jumpStrength = 0f;
    private float jumpDirection = 0f;
    
    private Rigidbody2D rb2d;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(jumpKey))
        {
            // Increase jump strength linearly within 5 seconds
            jumpStrength = Mathf.Clamp(jumpStrength + 2 * Time.deltaTime, 0f, 5f);
            print("Jump Strength: " + jumpStrength);
        }
        // Determine jump direction based on key input
        if (Input.GetKey(leftKey))
        {
            
            if (Input.GetKey(upKey))
            {
                print("A + W");
                jumpDirection = 15f;
            }
            else
            {
                print("A");
                jumpDirection = 45f;
            }
        }
        else if (Input.GetKey(rightKey))
        {
            if (Input.GetKey(upKey))
            {
                print("D + W");
                jumpDirection = -15f;
            }
            else
            {
                print("D");
                jumpDirection = -45f;
            }
        }
        if (Input.GetKeyUp(jumpKey))
        {
            
            ;
            
            // Get the jump vector based on direction and strength
            Vector3 jumpVector = Quaternion.Euler(0, 0, jumpDirection) * Vector3.up * (strengthMulti * jumpStrength);

            // Apply the jump force to the character's rigidbody
            rb2d.AddForce(jumpVector, ForceMode2D.Impulse);
            //rb2d.MovePosition();
            // Reset jump strength and direction
            jumpStrength = 0f;
            jumpDirection = 0f;
        }
    }
}