using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 500f;
    public float waterJumpSpeed = 250f;
    Rigidbody2D r2d;
    public GameObject wallCheck;
    bool isGrounded = false;
    bool inWater = false;
   public bool inBubble = false;
    

    public int boundsBottom = -76;
    public Collisions collisions;
    PlayerHealth hp;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        collisions = wallCheck.GetComponent<Collisions>();
        hp = GetComponent<PlayerHealth>();
        isGrounded = collisions.isGrounded;
        inWater = collisions.inWater;
        inBubble = collisions.inBubble;
    }
    void Update()
    {
        if (hp.health > 0)
        {
            if (!inBubble)
            {
                float newSpeed = 0f;
                bool isSprinting = Input.GetButtonDown("Sprint");
                if (isSprinting)
                {
                    newSpeed = speed * 2;
                }
                else
                {
                    newSpeed = speed;
                }
                float move = Input.GetAxis("Horizontal");
                r2d.velocity = new Vector2(newSpeed * move, r2d.velocity.y);
                Jump();
                if (r2d.transform.position.y <= -76)
                {
                    hp.DamagePlayer(10);
                }
            }
            else
            {
                r2d.velocity = new Vector2(0, 0);
            }
        }
    }


    void Jump()
    {
        inWater = collisions.inWater;
        isGrounded = collisions.isGrounded;
        inBubble = collisions.inBubble;
        if (!inBubble)
        {
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                r2d.AddForce(new Vector2(transform.position.x, jumpSpeed));
            }
            else
            if (inWater && Input.GetButtonDown("Jump"))
            {
                r2d.AddForce(new Vector2(transform.position.x, waterJumpSpeed));
            }
        }
    }
}
