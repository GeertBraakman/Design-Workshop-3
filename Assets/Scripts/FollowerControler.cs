using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerControler : MonoBehaviour
{
    public float speed = 2f;
    public GameObject destination;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPoint = transform.position;
        endPoint = destination.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != endPoint){
            transform.position = Vector3.MoveTowards(transform.position, endPoint, speed);
        }
    }
}
