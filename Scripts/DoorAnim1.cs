using UnityEngine;

public class SaloonDoorInteraction : MonoBehaviour
{
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;
    public string openTrigger = "Open";
    public string closeTrigger = "Close";
    public float closeDelay = 2.0f;

    private bool isPlayerNearby = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            OpenDoors();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Invoke("CloseDoors", closeDelay);
        }
    }

    void OpenDoors()
    {
        if (leftDoorAnimator != null && rightDoorAnimator != null)
        {
            leftDoorAnimator.SetTrigger(openTrigger);
            rightDoorAnimator.SetTrigger(openTrigger);
        }
    }

    void CloseDoors()
    {
        if (!isPlayerNearby)
        {
            if (leftDoorAnimator != null && rightDoorAnimator != null)
            {
                leftDoorAnimator.SetTrigger(closeTrigger);
                rightDoorAnimator.SetTrigger(closeTrigger);
            }
        }
    }
}
