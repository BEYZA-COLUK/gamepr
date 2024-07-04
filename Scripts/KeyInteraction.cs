using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject keyObject;    
    public GameObject key2Object; 
    public GameObject keyDoorObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (keyObject != null)
            {
               
                Destroy(keyObject);

                
                if (key2Object != null)
                    key2Object.SetActive(true);
            }
        }

        
        if (other.gameObject == keyDoorObject && key2Object != null && key2Object.activeSelf)
        {
            
            if (keyDoorObject != null)
            {
                Destroy(keyDoorObject);
                key2Object.SetActive(false);
            }
        }
    }
}
