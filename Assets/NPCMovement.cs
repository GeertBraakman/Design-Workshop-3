using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float speedIncrease = 1;
    public float walkRadius = 5;
    public bool DoWaypoints = true;
    public bool startChase = false;
    public GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (DoWaypoints == true)
        {
            float dist = GetComponent<NavMeshAgent>().remainingDistance;
            if (startChase)
            {
                Chase();
            }
            else if (dist != Mathf.Infinity && GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && GetComponent<NavMeshAgent>().remainingDistance < 5)//Arrived.
            {
                Wonder();
            }
        }
    }
    void Wonder()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        Vector3 finalPosition = hit.position;
        GetComponent<NavMeshAgent>().destination = finalPosition;
    }
    void Chase()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter collision with player");
            startChase = true;
            //other.gameObject.transform.Translate(Vector3.up * Time.deltaTime * 1000);
            //other.gameObject.GetComponent<FPSWalkerEnhanced>().Jump();
        }
    }
}
