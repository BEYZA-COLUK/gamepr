using UnityEngine;

public class Book : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        ObjectLevel objectLevel = other.GetComponent<ObjectLevel>();
        if (objectLevel != null)
        {
            objectLevel.IncreaseLevel();
            Destroy(gameObject); 
        }
    }
}
