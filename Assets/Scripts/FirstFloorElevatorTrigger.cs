using UnityEngine;

public class FirstFloorElevatorTrigger : MonoBehaviour
{
    public GameObject ElevatorTriggerWall;
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ElevatorTriggerWall.gameObject.SetActive(true);
            leftDoorAnimator.SetBool("isOpened", false);
            rightDoorAnimator.SetBool("isOpened", false);
        }
    }
}
