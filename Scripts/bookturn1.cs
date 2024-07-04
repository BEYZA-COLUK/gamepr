using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookturn : MonoBehaviour
{
    public float rotationSpeed = 50f; 

    void Update()
    {
       
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
