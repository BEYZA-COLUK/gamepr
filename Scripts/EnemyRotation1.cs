using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public float rotationSpeed = 2.0f; 
    public float rotationTime = 2.0f;  
    private bool isRotatingForward = true;
    private float timer;

    void Start()
    {
        timer = rotationTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isRotatingForward = !isRotatingForward;
            timer = rotationTime;
        }

        if (isRotatingForward)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotationSpeed);
        }
    }
}
