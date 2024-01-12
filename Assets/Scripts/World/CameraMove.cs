using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public Transform target;
    public Transform target2;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3(target.position.x,target.position.y,-10f);
        Vector3 vector = new Vector3(target2.position.x,target2.position.y,-10f);
        transform.position= Vector3.Slerp(transform.position,vector3,speed*Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, vector3, speed * Time.deltaTime);

    }
}
