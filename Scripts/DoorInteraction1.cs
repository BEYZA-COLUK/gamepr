using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class DoorInteraction : MonoBehaviour
{
    public GameObject doorObject;       
    public GameObject doorSmokeEffect;  
    public string nextSceneName;       
    public float effectDuration = 2f;  
    void Start()
    {
        
        if (doorSmokeEffect != null)
            doorSmokeEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doorObject != null)
        {
            
            if (doorSmokeEffect != null)
            {
                doorSmokeEffect.SetActive(true);
                StartCoroutine(TransitionToNextScene());
            }
        }
    }

    private IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(effectDuration); 
        SceneManager.LoadScene(nextSceneName);         
    }
}
