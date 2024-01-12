using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D r2d;
    private Transform currentPoint;
    public float speed;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }
    void Update()
    {
        if (currentPoint == pointB.transform)
        {
            r2d.velocity = new Vector2(speed, 0);
        }
        else
        {
            r2d.velocity = new Vector2(-speed, 0);
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
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(pointA.transform.position,0.9f);
        Gizmos.DrawWireSphere(pointB.transform.position,0.9f);
    }

}
