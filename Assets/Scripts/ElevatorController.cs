using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private Animator leftDoorAnimator;
    [SerializeField] private Animator rightDoorAnimator;

    
    private static Animator _leftDoorAnimator;
    private static Animator _rightDoorAnimator;

    private static ElevatorController elevatorController;
    
    void Start()
    {
        elevatorController = this;
        _leftDoorAnimator = leftDoorAnimator;
        _rightDoorAnimator = rightDoorAnimator;
    }

    public static void ManageDoors()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_leftDoorAnimator.GetBool("isOpened") && !_rightDoorAnimator.GetBool("isOpened"))
                Open();
            else Close();
        }
    }

    private static void Open()
    {
        elevatorController.StartCoroutine(Coroutine());
        _leftDoorAnimator.SetBool("isOpened", true);
        _rightDoorAnimator.SetBool("isOpened", true);
    }

    private static void Close()
    {
        _leftDoorAnimator.SetBool("isOpened", false);
        _rightDoorAnimator.SetBool("isOpened", false);
    }

    private static IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(10.0f);
        if (_rightDoorAnimator.GetBool("isOpened"))
        {
            Close();
        }
    }
}
