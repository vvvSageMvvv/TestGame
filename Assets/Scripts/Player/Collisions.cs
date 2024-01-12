using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    public bool isGrounded = false;

    public bool inWater = false;
    public bool inBubble = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Bubble"))
        {
            inBubble = true;
            print("IN BUBBLE");
        }
            if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("test");
            print("GROUNDED");
        }
        if (collision.collider.CompareTag("Water"))
        {
            inWater = true;
            Debug.Log("test");
            print("IN WATER");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bubble"))
        {
            inBubble = false;
        }
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.collider.CompareTag("Water"))
        {
            inWater = false;
        }
    }

}
