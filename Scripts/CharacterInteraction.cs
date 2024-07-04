using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public GameObject closedObject;  
    public GameObject openObject;     

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))  
        {
            if (closedObject != null)
                closedObject.SetActive(false);  

            if (openObject != null)
                openObject.SetActive(true);  
        }
    }
}
