using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectLevel : MonoBehaviour
{
    public int level;
    public TextMeshPro levelText;
    public Animator animator;
    public string attackTrigger = "Attack";
    public string dieTrigger = "Die";
    private bool isDead = false;

    void Start()
    {
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Lv. " + level;
        }
    }

    void LateUpdate()
    {
        if (levelText != null && Camera.main != null)
        {
            levelText.transform.LookAt(Camera.main.transform);
            levelText.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ObjectLevel otherLevel = other.GetComponent<ObjectLevel>();
        if (otherLevel != null && other.CompareTag("Player"))
        {
            if (level > otherLevel.level)
            {
                TriggerAttackAnimation();
                StartCoroutine(TriggerDieAfterDelay(otherLevel));
            }
            else if (level < otherLevel.level)
            {
                otherLevel.TriggerAttackAnimation();
                StartCoroutine(TriggerDieAfterDelay(this));
            }
        }
    }

    public void TriggerAttackAnimation()
    {
        if (!isDead)
        {
            animator.SetTrigger(attackTrigger);
        }
    }

    public void TriggerDieAnimation()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetTrigger(dieTrigger);
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private IEnumerator TriggerDieAfterDelay(ObjectLevel otherLevel)
    {
        yield return new WaitForSeconds(1.0f); 
        otherLevel.TriggerDieAnimation();
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

        
        if (gameObject.CompareTag("Player")) // Player ölünce yeniden 
        {
            ReloadScene();
        }
    }

    public void IncreaseLevel()
    {
        level++;
        UpdateLevelText();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
