using System.Collections;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public Transform door; 
    public float moveDownDistance = 0.2f; 
    public float moveDownSpeed = 2.0f; 

    private Vector3 initialPosition;
    private bool isPressed = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            StartCoroutine(MoveDownAndDestroyDoor());
        }
    }

    private IEnumerator MoveDownAndDestroyDoor()
    {
        Vector3 targetPosition = initialPosition - new Vector3(0, moveDownDistance, 0);
        while (transform.position.y > targetPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDownSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(door.gameObject); 
    }
}
