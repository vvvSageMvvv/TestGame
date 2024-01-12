using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bubble : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D r2d;
    public Vector3 bubbleOrigin;
    public Quaternion rotation;
    private Animator animator;
    private Transform currentPoint;
    public float speed;
    Movement m;
    public GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }


    void SpawnBubble()
    {
        Instantiate(this, bubbleOrigin, rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }


    void Update()
    {
        if (currentPoint == pointB.transform)
        {
            r2d.velocity = new Vector2(0, speed);
        }
        else
        {
            r2d.velocity = new Vector2(0, -speed);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.9f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.9f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
        animator.SetFloat("height", r2d.position.y);
        if (player != null)
        {
            m = player.GetComponent<Movement>();
            if (m.collisions.inBubble)
            {
                player.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            }
        }
        if (r2d.position.y >= 9)
        {
            if (player != null)
            {
                m = player.GetComponent<Movement>();
                m.inBubble = false;
                m.collisions.inBubble = false;
            }
            r2d.position = bubbleOrigin;
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.9f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.9f);
    }
}
