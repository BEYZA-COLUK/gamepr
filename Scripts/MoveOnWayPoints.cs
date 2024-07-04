using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWayPoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    public bool isLoop = true;
    public bool isDead = false; 
    public Animator animator;

    void Start()
    {
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].transform.position; // Obje ilk waypointten
        }
    }

    private void Update()
    {
        if (isDead) return; 

        if (waypoints.Count == 0) return; 

        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05f) 
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                if (isLoop)
                {
                    index = 0;
                }
            }

            
            transform.Rotate(0, -90, 0);
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("Die"); 
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
